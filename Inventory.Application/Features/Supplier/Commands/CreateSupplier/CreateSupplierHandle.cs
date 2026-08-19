using AutoMapper;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;

namespace Inventory.Application.Features.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierHandle : IRequestHandler<CreateSupplierCommand,Result<int>>
    {
        public readonly ISupplierRepository _repository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public CreateSupplierHandle(ISupplierRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = new Domain.Entities.Supplier(
                request.Name,
                request.CompanyName,
                request.Phone,
                request.Address
                );

            await _repository.AddAsync(supplier);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<int>.Success(supplier.Id);
        }
    }
}
