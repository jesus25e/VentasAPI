using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand
    (
        int Id,
        bool IsDeleted
    ) : IRequest<Result<bool>>;
}
