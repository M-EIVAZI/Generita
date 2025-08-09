using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Enums;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    public class GetAudioTagsHandler : IQueryHandler<GetAudioTagsQuery, AudioTagsResponse>
    {
        private IParagraphRepository _paragraphRepository;
        private ISongRepository _songRepository;

        public GetAudioTagsHandler(IParagraphRepository paragraphRepository, ISongRepository songRepository)
        {
            _paragraphRepository = paragraphRepository;
            _songRepository = songRepository;
        }

        public async Task<ErrorOr<AudioTagsResponse>> Handle(GetAudioTagsQuery request, CancellationToken cancellationToken)
        {
            AgeClasses age =(AgeClasses) Enum.Parse(typeof(AgeClasses), request.AudioTagsRequest.Age);
            MusicSense sense=(MusicSense) Enum.Parse(typeof(MusicSense), request.AudioTagsRequest.Sense);
            var res=await _paragraphRepository.GetBySenseAndAge(sense,age);
            if (res is null)
                return Error.NotFound(description: "Age Or Sense doesn't found");
            AudioTagsResponse response= new AudioTagsResponse() { Url=res.Songs.FilePath };
            return response;

        }
    }
}
