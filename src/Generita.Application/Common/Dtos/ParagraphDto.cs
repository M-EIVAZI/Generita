using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class ParagraphDto
    {
        public string Text { get; set; }
        public AudioTagsDto AudioTags { get; set; }
        public ICollection<EntitiesDto> Entities { get; set; }
    }
}
