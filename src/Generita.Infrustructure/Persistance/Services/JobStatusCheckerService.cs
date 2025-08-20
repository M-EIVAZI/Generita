using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Enums;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Generita.Infrustructure.Persistance.Services
{
    public class JobStatusCheckerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public JobStatusCheckerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<GeneritaDbContext>();
                    var _bookService = scope.ServiceProvider.GetRequiredService<IBookService>();
                    var _songRepository = scope.ServiceProvider.GetRequiredService<ISongRepository>();
                    var _jobRepository = scope.ServiceProvider.GetRequiredService<IJobRepository>();
                    var _paragraphRepository = scope.ServiceProvider.GetRequiredService<IParagraphRepository>();
                    var _entityRepository = scope.ServiceProvider.GetRequiredService<IEntityRepository>();
                    var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    // کل پردازش داخل scope انجام می‌شه


                    var jobs = await _context.Jobs
                        .Where(j => j.JobStatus == JobStatus.Processing)
                        .ToListAsync(stoppingToken);

                    foreach (var job in jobs)
                    {
                        var status = await _bookService.GetJobStatus(job.Id);
                        var book = await _jobRepository.GetById(job.Id);
                        if (status.Value.Status == JobStatus.Completed)
                        {
                            var json = await _bookService.DownloadResult(job.Id);

                            var res = json.Value;
                            //var entities = res.Paragraphs.Select(e => new Paragraph(Guid.NewGuid(){ AgeClass=Enum.Parse<AgeClasses>(e.AudioTags.Age),});
                            var paragraphTasks = res.Paragraphs.Select(async e =>
                            {
                                var age = Enum.Parse<AgeClasses>(e.AudioTags.Age);
                                var sense = Enum.Parse<MusicSense>(e.AudioTags.Sense);
                                var song = await _songRepository.GetBySenseAndAge(sense, age);
                                var paragraphId = Guid.NewGuid();

                                var entityTasks = e.Entities.Select(async x =>
                                {
                                    var entitySong = await _songRepository.GetByEntityType(x.Type);
                                    return new Entity(Guid.NewGuid())
                                    {
                                        MusicId = entitySong.Id,
                                        ParagraphId = paragraphId,
                                        Position = x.StartPos,
                                        sample = x.Sample,
                                        type = x.Type,
                                    };
                                });

                                var entities = await Task.WhenAll(entityTasks);

                                return new Paragraph(paragraphId)
                                {
                                    BookId = book.BookId,
                                    AgeClass = age,
                                    MusicSense = sense,
                                    SongId = song.Id,
                                    Text = e.Text,
                                    Entities = entities.ToList()
                                };
                            });
                            //var paragraphs = res.Paragraphs.Select(p => new Paragraph { ... });
                            var paragraphs = await Task.WhenAll(paragraphTasks);
                            await _paragraphRepository.AddList(paragraphs);
                            await _unitOfWork.CommitAsync(stoppingToken);
                            var canonicalEntities = res.CanonicalEntityBank.Select(c =>
                            {
                                var canonicalEntityId = Guid.NewGuid();

                                var variants = c.Value.Select(v => new CanonicalEntityVariant(Guid.NewGuid())
                                {
                                    Value = v,
                                    CanonicalEntityId = canonicalEntityId
                                }).ToList();

                                return new CanonicalEntity(canonicalEntityId)
                                {
                                    Type = c.Key,
                                    Variants = variants
                                };
                            }).ToList();

                            await _entityRepository.AddCanonicalEntityRange(canonicalEntities);
                            await _unitOfWork.CommitAsync(stoppingToken);

                            job.JobStatus = JobStatus.Completed;
                            await _unitOfWork.CommitAsync(stoppingToken);
                        }
                        else if (status.Value.Status == JobStatus.Failed)
                        {
                            job.JobStatus = JobStatus.Failed;
                            await _unitOfWork.CommitAsync(stoppingToken);
                        }

                    }
                }
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
