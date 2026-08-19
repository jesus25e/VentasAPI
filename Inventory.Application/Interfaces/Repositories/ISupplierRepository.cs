using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Supplier;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<PagedResult<SupplierDto>> GetPagedAsync(SupplierFilter supplierFilter, CancellationToken cancellationToken);
    }
}
