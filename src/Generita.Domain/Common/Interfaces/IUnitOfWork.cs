using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public void SaveChangesAsync();
        public void Commit();
        public void Rollback();
    }
}
