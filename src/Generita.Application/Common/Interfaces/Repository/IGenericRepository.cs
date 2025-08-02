using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IGenericRepository<T>
     where T : class
    {
        Task Add(T value);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T value);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(Guid id);

    }
}
