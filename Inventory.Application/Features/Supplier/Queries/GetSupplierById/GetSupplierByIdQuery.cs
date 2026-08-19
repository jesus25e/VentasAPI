using Inventory.Application.DTOs.Supplier;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery
    (int Id) : IRequest<Result<SupplierDto>>
    { };
}
