using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler:IRequestHandler<CreateCategoryCommand, Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetByNameAsync(request.Name);

            if (existingCategory is not null) return Result<int>.Failure($"La categoría '{request.Name}' ya existe.");

            var category = new Category( request.Name, request.Description);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(category.Id);
        }
    }
}
