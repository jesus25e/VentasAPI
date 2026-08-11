using AutoMapper;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return Result<ProductDto>.Failure("El producto solicitado no existe.");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Success(productDto);
        }
    }
}
