using AutoMapper;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Application.Mappings;
using Inventory.Domain.Entities;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand,Result<int>>
    {
        private readonly IProductRepository _reposiroty;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(
            IProductRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _reposiroty = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request,CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.StockMin,
                request.CategoryId,
                request.SupplierId
                );

            //var product = _mapper.Map<Product>(request);

            var existingProdut = await _reposiroty.GetByNameAsync(request.Name);

            if (existingProdut is not null) return Result<int>.Failure("Ya existe un producto con ese nombre.");

            await _reposiroty.AddAsync( product );
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(product.Id);
        }
    }
}
