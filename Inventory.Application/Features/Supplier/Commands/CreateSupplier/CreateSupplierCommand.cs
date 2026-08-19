using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.CreateSupplier
{
    public record CreateSupplierCommand
        (
            string Name,
            string CompanyName,
            string Phone,
            string Address
        ): IRequest<Result<int>>;

}
