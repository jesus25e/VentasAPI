using AutoMapper;
using Inventory.Application.DTOs.Category;
using Inventory.Application.DTOs.Supplier;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Supplier,SupplierDto>();
        }
    }
}
