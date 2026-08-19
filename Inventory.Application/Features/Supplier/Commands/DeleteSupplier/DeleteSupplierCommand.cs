using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.DeleteSupplier
{
    public record DeleteSupplierCommand
    (
        int Id,
        bool IsDeleted
        ) : IRequest<Result<bool>>;
}
