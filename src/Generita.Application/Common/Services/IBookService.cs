using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Dtos.ApiDtos;
using Generita.Domain.Common.Enums;

namespace Generita.Application.Common.Services
{
    public interface IBookService
    {
        Task<ErrorOr<GetJobStatusResponse>> GetJobStatus(Guid jobId);
        Task<ErrorOr<Root>> DownloadResult(Guid jobId);
        Task<ErrorOr<PostJobResponse>> PostBook(PostJobRequest request);
    }
}
