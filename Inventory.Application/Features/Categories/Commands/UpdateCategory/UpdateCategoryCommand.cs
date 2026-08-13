using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand
    (
        int Id,
        string Name,
        string Description
    ): IRequest<Result<int>>;
}
