using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Authors.ProcessNewBook
{
    public class ProcessNewBookHandler : IQueryHandler<ProcessNewBookQuery, ProcessNewBookResponse>
    {
        private IBookRepository _bookRepository;
        private IBookService _bookService;
        private IUnitOfWork _unitOfWork;

        public ProcessNewBookHandler(IBookRepository bookRepository, IBookService bookService, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ProcessNewBookResponse>> Handle(ProcessNewBookQuery request, CancellationToken cancellationToken)
        {
            var file = request.processNewBookDto.file;
            if (request.processNewBookDto.file == null || request.processNewBookDto.file.Length == 0)
                return Error.Failure();
            var projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
            var filesFolder = Path.Combine(projectRoot, "Files");
            if (!Directory.Exists(filesFolder))
            {
                Directory.CreateDirectory(filesFolder);
            }
            var filePath = Path.Combine(filesFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }
            var book = new Book(Guid.NewGuid())
            {
                AuthorId = request.processNewBookDto.AuthorId,
                Access = request.processNewBookDto.Access,
                CategoryId = request.processNewBookDto.CategoryId,
                FilePath = filePath,
                PublishedDate = request.processNewBookDto.PublishedDate,
                Cover= request.processNewBookDto.Cover,
                Title = request.processNewBookDto.Title,
                
            };
            await _bookRepository.Add(book);
            await _unitOfWork.CommitAsync(cancellationToken);
            var req = new PostJobRequest()
            {
                    file=file,
                    config_json=request.processNewBookDto.config_json,
            };

            var response = await _bookService.PostBook(req);
            var res = new ProcessNewBookResponse()
            { 
                JobId=response.Value.job_id,
                Message=response.Value.message,
            };

            //return new ProcessNewBookResponse(file.FileName, file.Length);
            return res;

        }
    }
}
