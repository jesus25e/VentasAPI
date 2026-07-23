using AutoMapper;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly Mapper _mapper;

        public GetAllProductsHandler(IProductRepository repository,Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            //return product.Select(x => new ProductDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Price = x.Price,
            //    Stock = x.Stock,
            //}).ToList();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
