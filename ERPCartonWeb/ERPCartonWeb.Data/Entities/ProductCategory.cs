using ERPCartonWeb.Data.Enums;
using ERPCartonWeb.Data.Interfaces;
using ERPCartonWeb.Infrastructure.SharedKernel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ERPCartonWeb.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
       public ProductCategory()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public int HomeFlag { get; set; }

        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeyWords { set; get; }
        public string SeoDescription { set; get; }
        public Status Status { set; get; }
        public int SorOrder { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public virtual ICollection<Product> Products { set; get; }
    }
}