using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface ITransactionsRepository : IGenericRepository<Domain.Models.Transactions>
    {
        Task<Domain.Models.Transactions> GetByAuthority(string authority);
        Task<Domain.Models.Transactions> GetByUserId(Guid userId);
    }
}
