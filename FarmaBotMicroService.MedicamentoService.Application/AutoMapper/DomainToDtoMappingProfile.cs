using AutoMapper;
using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Medicamento, MedicamentoDTO>().ReverseMap();
            CreateMap<Sintoma, SintomaDTO>().ReverseMap();
        }
    }
}
