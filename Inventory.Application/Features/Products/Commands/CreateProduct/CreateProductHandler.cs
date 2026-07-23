using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand,int>
    {
        private readonly IProductRepository _reposiroty;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(
            IProductRepository repository,
            IUnitOfWork unitOfWork
            )
        {
            _reposiroty = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProductCommand request,CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.CategoryId,
                request.Stock
                );
            await _reposiroty.AddAsync( product );
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
