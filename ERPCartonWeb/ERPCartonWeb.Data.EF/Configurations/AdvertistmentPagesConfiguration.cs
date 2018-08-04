using ERPCartonWeb.Data.EF.Extensions;
using ERPCartonWeb.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Data.EF.Configurations
{
    public class AdvertistmentPagesConfiguration : DbEntityConfiguration<AdvertistmentPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired();
        }
    }
}
