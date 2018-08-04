using ERPCartonWeb.Data.Enums;
using ERPCartonWeb.Data.Interfaces;
using ERPCartonWeb.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPCartonWeb.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>,
        IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name, string description, int? parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
        }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public string Description { get; set; }

        public bool? HomeFlag { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Product> Products { set; get; }
        public string SeoAlias { set; get; }

        public string SeoDescription { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoPageTitle { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}