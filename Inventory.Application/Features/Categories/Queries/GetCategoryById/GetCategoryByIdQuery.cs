using Inventory.Application.DTOs.Category;
using Inventory.Shared.Result;
using MediatR;
namespace Inventory.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(int Id): IRequest<Result<CategoryDto>>
    {

    }
}
