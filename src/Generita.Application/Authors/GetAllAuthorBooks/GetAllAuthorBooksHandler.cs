using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Enums;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Authors.GetAllAuthorBooks
{
    internal class GetAllAuthorBooksHandler : IQueryHandler<GetAllAuthorBooksQuery, IEnumerable<GetAllBooksResponse>>
    {
        private IBookService _bookService;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private IJobRepository _jobRepository;

        public GetAllAuthorBooksHandler(IBookService bookService, IBookRepository bookRepository, IUnitOfWork unitOfWork, IJobRepository jobRepository)
        {
            _bookService = bookService;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _jobRepository = jobRepository;
        }

        public async Task<ErrorOr<IEnumerable<GetAllBooksResponse>>> Handle(GetAllAuthorBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAuthorBooks(request.id);
            var results = new List<GetAllBooksResponse>();

            foreach (var book in books)
            {
                var job = await _jobRepository.GetByBookId(book.Id); 
                string statusString = "NoJob";

                if (job != null)
                {
                    var statusResult = await _bookService.GetJobStatus(job.Id);
                    statusString = statusResult.IsError ? "Unknown" : statusResult.Value.Status.ToString();
                }

                results.Add(new GetAllBooksResponse
                {
                    bookId = book.Id,
                    bookTitle = book.Title,
                    JobId = job?.Id,
                    createdAt = job.CreateAt.ToString("yyyy-MM-dd"),
                    status = statusString
                });
            }

            return ErrorOrFactory.From(results.AsEnumerable());

        }
    }
}