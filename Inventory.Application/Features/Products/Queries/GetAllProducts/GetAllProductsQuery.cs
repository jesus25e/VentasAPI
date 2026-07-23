using Inventory.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts;
    public record GetAllProductsQuery() : IRequest<List<ProductDto>>;

