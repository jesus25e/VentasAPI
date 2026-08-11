using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        //public Task<IEnumerable<Product>> GetAllProductQuery()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<PagedResult<ProductDto>> GetPagedAsync(
            ProductFilter filter,
            CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.Name.Contains(search) || 
                    x.Description.Contains(search));
            }

            if (filter.SupplierId.HasValue)
            {
                query = query.Where(x =>
                    x.SupplierId == filter.SupplierId);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(x =>
                    x.Price >= filter.MinPrice);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(x =>
                    x.Price <= filter.MaxPrice);
            }

            if (filter.MinStock.HasValue)
            {
                query = query.Where(x =>
                    x.Stock >= filter.MinStock);
            }

            if (filter.MaxStock.HasValue)
            {
                query = query.Where(x =>
                    x.Stock <= filter.MaxStock);
            }

            query = filter.SortBy.ToLower() switch
            {
                "price" => filter.Descending
                    ? query.OrderByDescending(x => x.Price)
                    : query.OrderBy(x => x.Price),

                "stock" => filter.Descending
                    ? query.OrderByDescending(x => x.Stock)
                    : query.OrderBy(x => x.Stock),

                "createdat" => filter.Descending
                    ? query.OrderByDescending(x => x.CraetedAt)
                    : query.OrderBy(x => x.CraetedAt),

                _ => filter.Descending
                    ? query.OrderByDescending(x => x.Name)
                    : query.OrderBy(x => x.Name)
            };

            var products = query.ProjectTo<ProductDto>(
                _mapper.ConfigurationProvider);

            return await products.ToPageResultAsync(
                filter,
                cancellationToken);
        }

    }
}
