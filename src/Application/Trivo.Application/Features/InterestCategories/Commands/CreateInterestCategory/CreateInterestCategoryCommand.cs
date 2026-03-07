using Trivo.Application.Abstractions.Messages;

namespace Trivo.Application.Features.InterestCategories.Commands.CreateInterestCategory;

public sealed record CreateInterestCategoryCommand(string Name) : ICommand<InterestCategoryDto>;