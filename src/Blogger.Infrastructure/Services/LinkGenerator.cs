﻿using Blogger.Application.Services;

namespace Blogger.Infrastructure.Services;
public class LinkGenerator : ILinkGenerator
{
    public string Generate()
    {
        // TODO: implement a generator algorithm
        return Guid.NewGuid().ToString();
    }
}
