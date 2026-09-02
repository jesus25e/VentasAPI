using AutoMapper;
using Inventory.Application.DTOs.Category;
using Inventory.Application.DTOs.Product;
using Inventory.Application.DTOs.Supplier;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, Result<SupplierDto>>
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public GetSupplierByIdHandler(ISupplierRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }
        public async Task<Result<SupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(request.Id);

            if (supplier == null)
            {
                return Result<SupplierDto>.Failure("El proveedor solicitado no existe.");
            }

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Result<SupplierDto>.Success(supplierDto);
        }
    }
}
