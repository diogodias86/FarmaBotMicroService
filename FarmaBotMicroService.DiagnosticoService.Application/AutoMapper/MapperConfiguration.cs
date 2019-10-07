﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.DiagnosticoService.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterAllMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
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
