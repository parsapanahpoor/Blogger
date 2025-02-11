﻿using Blogger.Application.Usecases.GetTaggedArticles;
using Blogger.Domain.ArticleAggregate;

namespace Blogger.APIs.Contracts.GetTaggedArticles;

public class GetTaggedArticlesMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GetTaggedArticlesRequest, GetTaggedArticlesQuery>()
                   .Map(x => x.Tag, src => Tag.Create(src.Tag));

        config.ForType<GetTaggedArticlesQueryResponse, GetTaggedArticlesResponse>()
                    .Map(x => x.ArticleId, src => src.ArticleId.Slug)
                    .Map(x => x.Tags, src => src.Tags.Select(x => x.Value)
                                                     .ToImmutableArray());
    }
}