﻿using Blogger.APIs.Endpoints;
using Blogger.Application.Usecases.GetComments;

namespace Blogger.APIs.Contracts.GetComments;

public class GetCommentsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/comments/{article-id}", async (
                [AsParameters] GetCommentsRequest request,
                IMapper mapper,
                IMediator mediator,
                CancellationToken cancellationToken) =>
        {
            var command = mapper.Map<GetCommentsQuery>(request);
            var result = await mediator.Send(command, cancellationToken);

            return mapper.Map<IEnumerable<GetCommentsResponse>>(result);
        }).Validator<GetCommentsRequest>()
        .WithTags(EndpointSchema.CommentTag);
    }
}
