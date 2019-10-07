using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Application.AutoMapper
{
   public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterAllMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainCommandMappingProfile());
            });
        }

        public static MapperConfiguration RegisterDtoDomainMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
            });
        }
    }
}
