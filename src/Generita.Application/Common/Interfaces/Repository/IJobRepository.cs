using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IJobRepository : IGenericRepository<Jobs>
    {
        Task<Jobs> GetByBookId(Guid bookId);
    }
}
