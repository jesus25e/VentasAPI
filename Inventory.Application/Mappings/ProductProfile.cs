using AutoMapper;
using Inventory.Application.DTOs.Product;
using Inventory.Application.Features.Products.Commands.CreateProduct;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
