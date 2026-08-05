using System;
using System.Collections.Generic;
using System.Text;
using Inventory.Shared.Result;
using MediatR;

namespace Inventory.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand
    (
        string Name,
        string Description,
        decimal Price,
        int Stock,
        int CategoryId,
        int SupplierId
    ):IRequest<Result<int>>;
}
