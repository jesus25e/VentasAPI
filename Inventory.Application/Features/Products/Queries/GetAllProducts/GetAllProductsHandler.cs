using AutoMapper;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts
{
    //public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<PagedResult<ProductDto>>>
    //{
    //    private readonly IProductRepository _repository;
    //    private readonly IMapper _mapper;

    //    public GetAllProductsHandler(IProductRepository repository,IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }

    //    //public async Task<Result<PagedResult<ProductDto>>> Handle(
    //    //    GetAllProductsQuery request,
    //    //    CancellationToken cancellationToken)
    //    //{
    //    //    //var products = await _repository.AsQueryable();

    //    //    //return product.Select(x => new ProductDto
    //    //    //{
    //    //    //    Id = x.Id,
    //    //    //    Name = x.Name,
    //    //    //    Description = x.Description,
    //    //    //    Price = x.Price,
    //    //    //    Stock = x.Stock,
    //    //    //}).ToList();

    //    //    //return _mapper.Map<List<ProductDto>>(products);
    //    //}
    //}
}
