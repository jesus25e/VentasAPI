using AutoMapper;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Category;
using Inventory.Application.DTOs.Supplier;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Inventory.Application.Features.Supplier.Queries.GetAllSupplier
{
    public class GetAllSupplierHandler : IRequestHandler<GetAllSupplierQuery, Result<PagedResult<SupplierDto>>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<SupplierDto>>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = new SupplierFilter
            {
                Search = request.Search,
                Name = request.Name,
                CompanyName = request.CompanyName,
                Phone = request.Phone,
                Address = request.Address,
                SortBy = request.SortBy,
                Descending = request.Descending
            };

            var result = await _supplierRepository.GetPagedAsync(suppliers, cancellationToken);

            return Result<PagedResult<SupplierDto>>.Success(result);

        }
    }
}
