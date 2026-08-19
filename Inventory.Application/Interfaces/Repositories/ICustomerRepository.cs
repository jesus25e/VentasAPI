using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Customer;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Customer?> GetByDniAsync(int dni, CancellationToken cancellationToken);

        Task<PagedResult<CustomerDto>> GetPagedAsync(CustomerFilter filter, CancellationToken cancellationToken);
    }
}
