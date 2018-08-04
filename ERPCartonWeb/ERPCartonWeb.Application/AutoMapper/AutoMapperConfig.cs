using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Application.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
