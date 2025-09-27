using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;

using Microsoft.IdentityModel.Tokens;

namespace Generita.Application.Authors.GetStatusByJobId
{
    public class GetStatusByJobIdHandler : IQueryHandler<GetStatusByJobIdQuery, GetStatusByJobIdResponse>
    {
        private IBookService _bookService;
        private IBookRepository _bookRepository;

        public GetStatusByJobIdHandler(IBookService bookService, IBookRepository bookRepository)
        {
            _bookService = bookService;
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<GetStatusByJobIdResponse>> Handle(GetStatusByJobIdQuery request, CancellationToken cancellationToken)
        {
            var bookstatus = await _bookService.GetJobStatus(request.jobId);

            GetStatusByJobIdResponse res = new()
            {
                JobId=bookstatus.Value.Job_id,
                Status=bookstatus.Value.Status.ToString(),
                errorMessage= string.Join(" | ", bookstatus.Errors.Select(e => e.Description))
            };
            return res;
        }
    }
}
