using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Supplier;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SupplierRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper= mapper;
        }

        public async Task<PagedResult<SupplierDto>> GetPagedAsync(SupplierFilter filter, CancellationToken cancellationToken)
        {
            var query = _context.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                query = query.Where(c =>
                    c.Name.Contains(filter.Search) ||
                    c.CompanyName.Contains(filter.Search));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(c => c.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.CompanyName))
            {
                query = query.Where(c => c.CompanyName.Contains(filter.CompanyName));
            }

            if (!string.IsNullOrEmpty(filter.Address))
            {
                query = query.Where(c => c.Address.Contains(filter.Address));
            }

            query = filter.SortBy.ToLower() switch
            {
                "name" => filter.Descending
                    ? query.OrderByDescending(c => c.Name)
                    : query.OrderBy(c => c.Name),

                "companyname" => filter.Descending
                    ? query.OrderByDescending(c => c.CompanyName)
                    : query.OrderBy(c => c.CompanyName),


                _ => filter.Descending
                    ? query.OrderByDescending(c => c.Name)
                    : query.OrderBy(c => c.Name)
            };

            var supplier = query.ProjectTo<SupplierDto>(_mapper.ConfigurationProvider);

            return await supplier.ToPageResultAsync(filter, cancellationToken);
        }
    }
}
