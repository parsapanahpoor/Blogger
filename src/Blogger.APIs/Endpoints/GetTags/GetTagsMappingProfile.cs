﻿using Blogger.APIs.Endpoints.GetTags;
using Blogger.Application.Usecases.GetTags;

namespace Blogger.APIs.Contracts.GetTags;

public class GetTagsMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetTagsQueryResponse, GetTagsResponse>()
                  .Map(x => x.Count, src => src.Count)
                  .Map(x => x.Name, src => src.Tag.ToString());
    }
}
