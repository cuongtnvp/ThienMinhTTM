using ERPCartonWeb.Data.Entities;
using ERPCartonWeb.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Data.EF.Repositories
{
    public class FunctionRepository:EFRepository<Function,string>,IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {

        }
    }
}
