using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand
    (
        int Id,
            bool IsDeleted
    ) : IRequest<Result<bool>>;
}
