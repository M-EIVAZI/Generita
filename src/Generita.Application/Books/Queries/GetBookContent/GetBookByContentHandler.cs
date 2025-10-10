using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Books.Queries.GetBookContent
{
    internal class GetBookByContentHandler : IQueryHandler<GetBookByContentQuery, BookConentResponse>
    {
        private IBookRepository _bookRepository;
        private IParagraphRepository _paragraphRepository;
        private IEntityRepository _entityRepository;
        private IUnitOfWork _unitOfWork;

        public GetBookByContentHandler(IBookRepository bookRepository, IParagraphRepository paragraphRepository, IEntityRepository entityRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _paragraphRepository = paragraphRepository;
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<BookConentResponse>> Handle(GetBookByContentQuery request, CancellationToken cancellationToken)
        {
            var book =await _bookRepository.GetById(request.bookId);
            var paragraphs = await _paragraphRepository.GetByBookId(request.bookId);
            var result = new BookConentResponse
            {
                Paragraphs = await Task.WhenAll(
                    paragraphs.Select(async paragraph =>
                    {
                        var entities = await Task.WhenAll(
                            paragraph.EntityInstances.Select(async entity =>
                            {
                                var entityFromDb = await _entityRepository.GetById(entity.EntityId);

                                return new EntitiesDto
                                {
                                    Sample = entity.sample,
                                    Start_pos = entity.Position,
                                    Type = entityFromDb.type
                                };
                            })
                        );

                        return new ParagraphDto
                        {
                            AudioTags = new AudioTagsDto
                            {
                                Age = paragraph.AgeClass.ToString(),
                                Sense = paragraph.MusicSense.ToString()
                            },
                            Text = paragraph.Text,
                            Entities = entities.ToList()
                        };
                    })
                )
            };


            return result;



        }
    }
}
