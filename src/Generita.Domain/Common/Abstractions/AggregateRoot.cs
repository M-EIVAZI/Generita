using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Interfaces;

namespace Generita.Domain.Common.Abstractions
{
    public  class AggregateRoot:BaseEntity
    {
        protected Guid _baseEntity;
        protected AggregateRoot(Guid Id)
        {
            _baseEntity = Id;   
        }
        protected readonly List<IDomainEvent> _domainEvents = new();

        public List<IDomainEvent> PopDomainEvents()
        {
            var copy = _domainEvents.ToList();
            _domainEvents.Clear();

            return copy;
        }
    }
}
