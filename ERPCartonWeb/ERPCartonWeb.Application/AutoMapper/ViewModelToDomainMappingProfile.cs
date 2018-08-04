using AutoMapper;
using ERPCartonWeb.Application.ViewModels.Product;
using ERPCartonWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
                c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
        }


    }
}
