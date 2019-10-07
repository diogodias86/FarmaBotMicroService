using AutoMapper;
using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands;
using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Application.AutoMapper
{
    public class DtoToDomainCommandMappingProfile : Profile
    {
        public DtoToDomainCommandMappingProfile()
        {
            var dtoConfig = AutoMapperConfig.RegisterDtoDomainMappings();
            var mapper = dtoConfig.CreateMapper();

            CreateMap<MedicamentoDTO, AddMedicamentoCommand>()
                .ConstructUsing(a => new AddMedicamentoCommand(mapper.Map<MedicamentoDTO, Medicamento>(a)));

            CreateMap<MedicamentoDTO, UpdateMedicamentoCommand>()
                .ConstructUsing(a => new UpdateMedicamentoCommand(mapper.Map<MedicamentoDTO, Medicamento>(a)));

            CreateMap<MedicamentoDTO, DeleteMedicamentoCommand>()
                .ConstructUsing(a => new DeleteMedicamentoCommand(mapper.Map<MedicamentoDTO, Medicamento>(a)));
        }
    }
}
