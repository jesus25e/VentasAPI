using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand
    (
        int Id,
        string Name,
        string? Description,
        decimal Price,
        int Stock,
        int StockMin,
        int? CategoryId,
        int? SupplierId
    ) : IRequest<Result<int>>;

}
