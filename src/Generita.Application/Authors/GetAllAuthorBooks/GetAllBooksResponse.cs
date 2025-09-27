using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authors.GetAllAuthorBooks
{
    public class GetAllBooksResponse
    {
        public Guid bookId { get; set; }
        public string booktitle {  get; set; }
        public Guid JobId {  get; set; }
        public string status {  get; set; }
        public DateTime CreateAt { get; set; }
        public string ErrorMessage {  get; set; }
    }
}
