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
            var books = await _bookRepository.GetAll();
            var jobs = await Task.WhenAll(books.Select(x => _jobRepository.GetByBookId(x.Id)));
            var jobsstatus=await Task.WhenAll(jobs.Select(x=>_bookService.GetJobStatus(x.Id)));
 
            var res=books.Zip(jobs,(book,job)=>new {book,job})
                .Zip(jobsstatus,(bj,status)=>new GetAllBooksResponse()
            {
                bookId=bj.book.Id,
                booktitle=bj.book.Title,
                JobId=bj.job.Id,
                status=status.Value.Status.ToString()
            });
            return ErrorOrFactory.From(res);

        }
    }
}
