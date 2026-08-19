using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Customer;
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
    internal class CustomerRespository : Repository<Customer>, ICustomerRepository
    {
        public readonly IMapper _mapper;
        public CustomerRespository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<Customer?> GetByDniAsync(int dni, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DNI == dni);
        }

        public async Task<PagedResult<CustomerDto>> GetPagedAsync(CustomerFilter filter, CancellationToken cancellationToken)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    x.FullName.Contains(search) ||
                    x.DNI.Equals(search));
            }

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(x => x.FullName.Contains(filter.FullName));
            }

            if (filter.Dni != null)
            {
                query = query.Where(x => x.DNI.Equals(filter.Dni));
            }

            if (!string.IsNullOrEmpty(filter.Phone))
            {
                query = query.Where(x => x.Phone.Contains(filter.Phone));
            }

            if (!string.IsNullOrEmpty(filter.Address))
            {
                query = query.Where(x => x.Address.Contains(filter.Address));
            }

            query = filter.SortBy.ToLower() switch
            {
                "fullName" => filter.Descending
                    ? query.OrderByDescending(x => x.FullName)
                    : query.OrderBy(x => x.FullName),

                "dni" => filter.Descending
                    ? query.OrderByDescending(x => x.DNI)
                    : query.OrderBy(x => x.DNI),

                "phone" => filter.Descending
                    ? query.OrderByDescending(x => x.Phone)
                    : query.OrderBy(x => x.Phone),

                "address" => filter.Descending
                    ? query.OrderByDescending(x => x.Address)
                    : query.OrderBy(x => x.Address),

                _ => filter.Descending
                    ? query.OrderByDescending(x => x.FullName)
                    : query.OrderBy(x => x.FullName)
            };

            var customer = query.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider);

            return await customer.ToPageResultAsync(filter, cancellationToken);
        }
    }
}
