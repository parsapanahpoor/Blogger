﻿using Blogger.Application.Common;
using Blogger.Domain.CommentAggregate;

namespace Blogger.Application.Usecases.MakeComment;

public class MakeCommentCommandHandler(
    ICommentRepository commentRepository,
    IArticleService articleService,
    IEmailService emailService,
    ILinkGenerator linkGenerator) : IRequestHandler<MakeCommentCommand, MakeCommentCommandResponse>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IArticleService _articleService = articleService;
    private readonly ILinkGenerator _linkGenerator = linkGenerator;
 
    public async Task<MakeCommentCommandResponse> Handle(MakeCommentCommand request, CancellationToken cancellationToken)
    {
 
        if (await _articleService.IsArticleIdValidAsync(request.ArticleId, cancellationToken))
        {
            throw new NotFoundArticleException();
        }

        var link = _linkGenerator.Generate();
        var approveLink = ApproveLink.Create(link, DateTime.UtcNow.AddHours(ApplicationSettings.ApproveLink.ExpairationOnHours));

        var comment = Comment.Create(request.ArticleId, request.Client, request.Content, approveLink);
        await _commentRepository.CreateAsync(comment, cancellationToken);
        await _commentRepository.SaveChangesAsync(cancellationToken);

        var content = EmailTemplates.ConfirmEngagementEmail;
        await emailService.SendAsync(request.Client.Email,
            ApplicationSettings.ApproveLink.ConfirmEmailSubject, 
            content, 
            cancellationToken);

        return new MakeCommentCommandResponse(comment.Id);
    }
}
