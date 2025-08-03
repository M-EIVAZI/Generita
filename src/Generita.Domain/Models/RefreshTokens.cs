using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class RefreshTokens : BaseEntity
    {
        public RefreshTokens(Guid id) : base(id)
        {
        }

        public string Token {  get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiresOnUtc {  get; set; }
        public virtual User User { get; set; }
    }
}
