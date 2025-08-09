using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    public class GetEntityAudioHandler : IQueryHandler<GetEntityAudioQuery, AudioTagsResponse>
    {
        private IEntityRepository _entityRepository;

        public GetEntityAudioHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<ErrorOr<AudioTagsResponse>> Handle(GetEntityAudioQuery request, CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetByType(request.type);
            if (entity is null)
                return Error.NotFound(description: "Entity Type Doesn't Found");
            var res = new AudioTagsResponse()
            { Url=entity.Songs.FilePath};
            return res;
        }
    }
}
