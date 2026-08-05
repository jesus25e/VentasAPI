using Inventory.Application.Common.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>>
            ToPageResultAsync<T>(
                this IQueryable<T> query,
                PaginationRequest request,
                CancellationToken cancellationToken = default)
        {
            var totalItems = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((request.Page-1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<T>
            {
                Items = items,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize)
            };
        }
    }
}
