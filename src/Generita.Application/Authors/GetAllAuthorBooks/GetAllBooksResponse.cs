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
        public string bookTitle {  get; set; }
        public Guid? JobId {  get; set; }
        public string status {  get; set; }
        public String createdAt { get; set; }
        public string ErrorMessage {  get; set; }
    }
}
