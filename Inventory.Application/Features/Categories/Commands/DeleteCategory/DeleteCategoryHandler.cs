using AutoMapper;
using Inventory.Application.Interfaces.Repositories;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
            {
                return Result<bool>.Failure($"La categoría {request.Id} no fue encontrada.");
            }

            category.SoftDelete();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Result<bool>.Success(true);
        }
    }
}
