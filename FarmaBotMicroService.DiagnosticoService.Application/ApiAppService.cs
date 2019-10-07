using AutoMapper;
using FarmaBotMicroService.DiagnosticoService.Application.AppModel;
using FarmaBotMicroService.DiagnosticoService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmaBotMicroService.DiagnosticoService.Application
{
    public class ApiAppService
    {
        private readonly DiagnosticoQueryService _diagnosticoQueryService;
        private readonly IMapper _mapper;

        public ApiAppService(DiagnosticoQueryService diagnosticoQueryService, IMapper mapper)
        {
            _diagnosticoQueryService = diagnosticoQueryService;
            _mapper = mapper;
        }

        public IEnumerable<MedicamentoDTO> Diagnosticar(string sintomas)
        {
            var medicamentos = _diagnosticoQueryService.Diagnosticar(sintomas);
            var medicamentosDTO = _mapper.Map<IEnumerable<MedicamentoDTO>>(medicamentos);
            return medicamentosDTO;
        }
    }
}
