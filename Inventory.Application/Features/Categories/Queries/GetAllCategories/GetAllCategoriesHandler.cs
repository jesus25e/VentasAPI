using AutoMapper;
using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Category;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, Result<PagedResult<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var filter = new CategoryFilter
            {
                Search = request.Search,
                Name = request.Name,
                Description = request.Description
            };

            var result = await _categoryRepository.GetPagedAsync(filter, cancellationToken);

            return Result<PagedResult<CategoryDto>>.Success(result);
        }
    }
}
