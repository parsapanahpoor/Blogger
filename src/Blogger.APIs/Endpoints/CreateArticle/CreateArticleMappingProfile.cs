﻿using Blogger.Application.Usecases.CreateArticle;
using Blogger.Domain.ArticleAggregate;
using System.Collections.Immutable;

namespace Blogger.APIs.Contracts.CreateArticle;

public class CreateArticleMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateArticleRequest, CreateArticleCommand>()
                   .Map(x => x.Tags, src => src.Tags.Select(x => Tag.Create(x))
                                                    .ToImmutableList());

        config.ForType<CreateArticleCommandResponse, CreateArticleResponse>()
                  .Map(x => x.ArticleId, src => src.ArticleId.Slug);
    }
}
