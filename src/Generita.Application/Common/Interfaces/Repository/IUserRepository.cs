using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        //Task<bool> IsExistsByEmail(string email);
    }
}
