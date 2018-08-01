using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static ERPCartonWeb.Data.EF.Extensions.ModelBuilderExtensions;

namespace ERPCartonWeb.Data.EF.Extensions
{
   public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
            this ModelBuilder modelBuilder,DbEntityCOnfiguration<TEntity>entityConfiguration) where TEntity:class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
        public abstract class DbEntityCOnfiguration<TEntity> where TEntity:class
        {
            public abstract void Configure(EntityTypeBuilder<TEntity> entity);
        }
    }
}
