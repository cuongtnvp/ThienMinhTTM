using AutoMapper.QueryableExtensions;
using ERPCartonWeb.Application.Interfaces;
using ERPCartonWeb.Application.ViewModels.System;
using ERPCartonWeb.Data.IRepositories;
using ERPCartonWeb.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPCartonWeb.Application.Implementations
{
    public class FunctionService : IFunctionService
    {
        private IFunctionRepository _functionRepository;
        
        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            return _functionRepository.FindAll().ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}