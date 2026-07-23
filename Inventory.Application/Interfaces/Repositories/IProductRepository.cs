using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<Product?> GetByNameAsync(string Name);
    }
}
