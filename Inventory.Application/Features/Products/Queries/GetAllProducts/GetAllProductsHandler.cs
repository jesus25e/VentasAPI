using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Shared.Result;
using MediatR;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<PagedResult<ProductDto>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<PagedResult<ProductDto>>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var filter = new ProductFilter{
                Search = request.Search,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                MinPrice = request.MinPrice,
                MaxPrice = request.MaxPrice,
                MinStock = request.MinStock,
                MaxStock = request.MaxStock,
                SortBy = request.SortBy,
                Descending = request.Descending,
                Page = request.Page,
                PageSize = request.PageSize
            };

            var result = await _repository.GetPagedAsync(
                filter,
                cancellationToken);

            return Result<PagedResult<ProductDto>>
                .Success(result);
        }
    }
}
