using Trivo.Application.Abstractions.Messages;
using Trivo.Application.Features.InterestCategories.Commands.CreateInterestCategory;
using Trivo.Application.Pagination;

namespace Trivo.Application.Features.InterestCategories.Query.GetPaginatedInterestCategories;

public sealed record GetPaginatedInterestCategoriesQuery(
    int PageNumber,
    int PageSize
) : IQuery<PagedResult<InterestCategoryDto>>;