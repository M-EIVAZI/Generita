using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class DownloadResultParagraph
    {
        public string Text { get; set; }
       public AudioTagsDto AudioTags { get; set; }
        public List<DownloadResultEntity> Entities { get; set; }
    }
}
