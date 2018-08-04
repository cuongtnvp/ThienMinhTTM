using ERPCartonWeb.Data.Entities;
using ERPCartonWeb.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Data.Repositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory,int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
