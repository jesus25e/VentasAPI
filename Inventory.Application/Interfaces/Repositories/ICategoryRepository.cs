using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Category;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<PagedResult<CategoryDto>> GetPagedAsync(CategoryFilter filter, CancellationToken cancellationToken);
    }
}
