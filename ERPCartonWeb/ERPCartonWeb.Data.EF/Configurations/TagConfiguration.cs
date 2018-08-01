using ERPCartonWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static ERPCartonWeb.Data.EF.Extensions.ModelBuilderExtensions;

namespace ERPCartonWeb.Data.EF.Configurations
{
    public class TagConfiguration : DbEntityCOnfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50)
                .IsRequired().HasColumnType("varchar(50)");
        }
    }
}
