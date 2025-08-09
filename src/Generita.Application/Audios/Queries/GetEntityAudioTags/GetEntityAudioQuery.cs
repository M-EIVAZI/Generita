using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Audios.Queries.GetParagraphAudioTags;
using Generita.Application.Common.Dtos;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    public record GetEntityAudioQuery(string type):IQuery<AudioTagsResponse>
    {
    }
}
