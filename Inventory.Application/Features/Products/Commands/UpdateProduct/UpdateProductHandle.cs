using AutoMapper;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandle : IRequestHandler<UpdateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductHandle(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            //Console.WriteLine($"Producto {product.Result} - ID: {request.Id}");
            
            if (product == null)
            {
                return Result<int>.Failure($"El producto con ID {request.Id} no existe.");
            }

            product.Update(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.StockMin,
                request.CategoryId,
                request.SupplierId
                );

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(product.Id);
        }
    }
}
