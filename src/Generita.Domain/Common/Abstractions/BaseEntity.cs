using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Domain.Common.Abstractions
{
    public class BaseEntity
    {
        protected Guid _id;
        protected BaseEntity(Guid id)
        {
            this._id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            return ((Entity)obj).Id == _id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        protected BaseEntity() { }
    }
}
