﻿using Blogger.Application.Usecases.Subscribe;
using Blogger.Domain.SubscriberAggregate;

namespace Blogger.APIs.Contracts.Subscribe;

public class SubscribeMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<SubscribeRequest, SubscribeCommand>()
                   .Map(x => x.SubscriberId, src => SubscriberId.Create(src.Email));
    }
}
