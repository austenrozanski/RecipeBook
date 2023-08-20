using Application.Business.Recipes.Models;
using MediatR;

namespace Application.Business.Recipes.Get;

public class GetRecipeSummariesQuery : IRequest<List<RecipeSummaryDto>>
{
}