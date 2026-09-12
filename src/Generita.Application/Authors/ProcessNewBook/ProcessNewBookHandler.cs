using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Options;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Enums;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Events;
using Generita.Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Http; 
using Microsoft.Extensions.Options;
namespace Generita.Application.Authors.ProcessNewBook
{
    public class ProcessNewBookHandler : ICommandHandler<ProcessNewBookCommand, ProcessNewBookResponse>
    {
        private IBookRepository _bookRepository;
        private IBookService _bookService;
        private IUnitOfWork _unitOfWork;
        private IJobRepository _jobRepository;
        private ISongRepository _songRepository;
        private IPublisher _publisher;
        private readonly ApplicationUrlOptions _urlOptions;

        public ProcessNewBookHandler(IBookRepository bookRepository, IBookService bookService, IUnitOfWork unitOfWork, IJobRepository jobRepository, ISongRepository songRepository, IPublisher publisher, IOptions<ApplicationUrlOptions> urlOptions)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _unitOfWork = unitOfWork;
            _jobRepository = jobRepository;
            _songRepository = songRepository;
            _publisher = publisher;
            _urlOptions = urlOptions.Value;
        }

        public async Task<ErrorOr<ProcessNewBookResponse>> Handle(ProcessNewBookCommand request, CancellationToken cancellationToken)
        {
            #region processingfile
            var file = request.processNewBookDto.file;
            var image = request.processNewBookDto.Image;
            if (request.processNewBookDto.file == null || request.processNewBookDto.file.Length == 0)
                return Error.Failure();
            if (request.processNewBookDto.Image == null || request.processNewBookDto.Image.Length == 0)
                return Error.Failure();
            var projectRoot = Directory.GetCurrentDirectory();
            var wwwrootPath = Path.Combine(projectRoot, "wwwroot");
            var filesFolder = Path.Combine(wwwrootPath, "files");
            var imagesFolder = Path.Combine(wwwrootPath, "images");
            if (!Directory.Exists(filesFolder))
            {
                Directory.CreateDirectory(filesFolder);
            }
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            Guid guid = Guid.NewGuid();
            var fileName = $"{guid}_{Path.GetFileName(file.FileName)}";
            var imageName = $"{guid}_{Path.GetFileName(image.FileName)}";
            var filePath = Path.Combine(filesFolder, fileName);
            var imagePath = Path.Combine(imagesFolder, imageName);
            // مسیرهای کامل برای ذخیره در سرور
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream, cancellationToken);
            }
            #endregion
            #region processing song

            var dic = request.processNewBookDto.situational_audio;
            var situationalRegex = new Regex(@"^situational_audio_(\d+)_(\d+)$");
            foreach (var kvp in dic)
            {
                var key = kvp.Key;
                var songfile = kvp.Value;

                var match = situationalRegex.Match(key);
                if (match.Success)
                {
                    int senseId = int.Parse(match.Groups[1].Value);
                    int ageId = int.Parse(match.Groups[2].Value);
                    var songId = Guid.NewGuid();
                    var songName = $"{songId}_{Path.GetFileName(songfile.FileName)}";

                    Songs song = new(songId)
                    {

                        AgeClasses = (AgeClasses)ageId,
                        MusicSense = (MusicSense)senseId,
                        CreateAt = DateTime.UtcNow,
                        Name = key,
                        Owner = Domain.Enums.OwnerShip.Author,
                        FilePath = BuildPublicUrl($"Musics/{Uri.EscapeDataString(songName)}"),
                        AuthorId = request.processNewBookDto.AuthorId
                    };
                    var songFolder = Path.Combine(wwwrootPath, "Musics");
                    if (!Directory.Exists(songFolder))
                    {
                        Directory.CreateDirectory(songFolder);
                    }
                    var songPath = Path.Combine(songFolder, songName);
                    using (var stream = new FileStream(songPath, FileMode.Create))
                    {
                        await songfile.CopyToAsync(stream, cancellationToken);
                    }
                    await _songRepository.Add(song);
                    await _unitOfWork.CommitAsync();

                }
                else
                {
                    return Error.Conflict("The age or sense id is incorrect");
                }
            }

            #endregion
            var book = new Book(guid)
            {
                AuthorId = request.processNewBookDto.AuthorId,
                Access = request.processNewBookDto.Access,
                CategoryId = request.processNewBookDto.CategoryId,
                FilePath = BuildPublicUrl($"files/{Uri.EscapeDataString(fileName)}"),
                Synopsis = request.processNewBookDto.Synopsis,
                PublishedDate = request.processNewBookDto.PublishedDate,
                Cover = BuildPublicUrl($"images/{Uri.EscapeDataString(imageName)}"),
                Title = request.processNewBookDto.Title,

            };
            await _bookRepository.Add(book);
            await _unitOfWork.CommitAsync(cancellationToken);
            var req = new PostJobRequest()
            {
                file = file,
                config_json = request.processNewBookDto.config_json,
                abstract_audio = request.processNewBookDto.abstract_audio,
                AuthorId = request.processNewBookDto.AuthorId,

            };

            var response = await _bookService.PostBook(req);
            var res = new ProcessNewBookResponse()
            {
                JobId = response.Value.job_id,
                Message = response.Value.message,
            };
            Jobs job = new(res.JobId)
            {
                JobStatus = JobStatus.Processing,
                AuthorId = book.AuthorId,
                BookId = book.Id,
                CreateAt = DateTime.UtcNow,
            };
            await _jobRepository.Add(job);
            await _unitOfWork.CommitAsync(cancellationToken);
            BookAddedEvent event1 = new()
            {
                BookId = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
            };
            await _publisher.Publish(event1, cancellationToken);
            //return new ProcessNewBookResponse(file.FileName, file.Length);
            return res;

        }

        private string BuildPublicUrl(string relativePath)
        {
            return $"{_urlOptions.PublicBaseUrl.TrimEnd('/')}/{relativePath.TrimStart('/')}";
        }
    }
}
