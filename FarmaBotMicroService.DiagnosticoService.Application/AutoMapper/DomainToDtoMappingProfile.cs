using AutoMapper;
using FarmaBotMicroService.DiagnosticoService.Application.AppModel;
using FarmaBotMicroService.DiagnosticoService.Domain.DiagnosticoAggregate;

namespace FarmaBotMicroService.DiagnosticoService.Application.AutoMapper
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
