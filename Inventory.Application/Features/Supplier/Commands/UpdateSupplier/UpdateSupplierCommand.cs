using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand
    (
        int Id,
        string Name,
        string CompanyName,
        string Phone,
        string Address
    ) : IRequest<Result<int>>;
    
}
