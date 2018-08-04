using AutoMapper;
using ERPCartonWeb.Application.ViewModels.Product;
using ERPCartonWeb.Data.Entities;
using System;

namespace ERPCartonWeb.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<ProductCategory, ProductCategoryViewModel>();


        }
    }
}
