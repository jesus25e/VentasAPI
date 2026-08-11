using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByNameAsync(string Name);

        Task<PagedResult<ProductDto>> GetPagedAsync(ProductFilter filter, CancellationToken cancellationToken);

        //Task<Product?> GetBySkuAsync(string sku);

        //Task<bool> ExistsSkuAsync(string sku);

        //Task<IEnumerable<Product>> GetLowStockAsync();

        //Task<IEnumerable<Product>> GetExpiredProductsAsync();
    }
}
