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

        public ApiAppService(DiagnosticoQueryService diagnosticoQueryService)
        {
            _diagnosticoQueryService = diagnosticoQueryService;
        }

        public IEnumerable<MedicamentoDTO> Diagnosticar(string sintomas)
        {
            var result = _diagnosticoQueryService.Diagnosticar(sintomas);
            return result.Select(m => new MedicamentoDTO
            {
                Id = m.Id,
                Nome = m.Nome
            });
        }
    }
}
