﻿namespace Blogger.APIs.Contracts.MakeDraft;

public class MakeDraftRequestValidator : AbstractValidator<MakeDraftRequest>
{
    private const string TagMaximumLengthMessage = "The tags must contain at most 10 elements.";

    public MakeDraftRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(70)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Summary)
            .MaximumLength(300)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Body)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Tags)
             .Must(x => x is null || x.Length <= 10).WithMessage(TagMaximumLengthMessage);
    }
}