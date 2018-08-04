using AutoMapper;
using ERPCartonWeb.Application.ViewModels.Product;
using ERPCartonWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<ProductCategory, ProductCategoryViewModel>();
           
            
        }
    }
}
