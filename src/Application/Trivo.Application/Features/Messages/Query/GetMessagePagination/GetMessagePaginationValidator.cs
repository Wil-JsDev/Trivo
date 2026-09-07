using FluentValidation;
using Trivo.Application.Pagination;

namespace Trivo.Application.Features.Messages.Query.GetMessagePagination;

public sealed class GetMessagePaginationValidator : AbstractValidator<GetMessagePaginationQuery>
{
    public GetMessagePaginationValidator()
    {
        RuleFor(x => x.ChatId)
            .NotEmpty().WithMessage("Chat ID is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, PaginationValidator.MaxPageSize)
            .WithMessage($"Page size must be between 1 and {PaginationValidator.MaxPageSize}.");
    }
}
