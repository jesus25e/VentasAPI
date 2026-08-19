using AutoMapper;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierHandle : IRequestHandler<UpdateSupplierCommand, Result<int>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierHandle(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (supplier is null) return Result<int>.Failure($"El provedor con ID {request.Id} no existe.");
            supplier.Update(
                request.Name,
                request.CompanyName,
                request.Phone,
                request.Address);
            _supplierRepository.Update(supplier);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(supplier.Id);
        }
    }
}
