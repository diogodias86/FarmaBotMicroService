using AutoMapper;
using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands;
using FarmaBotMicroService.MedicamentoService.Domain.Interfaces.CQRS;
using FarmaBotMicroService.MedicamentoService.Domain.MedicamentoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmaBotMicroService.MedicamentoService.Application
{
    public class ApiAppService
    {
        private readonly IQueue _queue;
        private readonly IMapper _mapper;
        private readonly Domain.Services.MedicamentoService _medicamentoQueryService;

        public ApiAppService(IQueue queue, IMapper mapper, Domain.Services.MedicamentoService service)
        {
            _queue = queue;
            _mapper = mapper;
            _medicamentoQueryService = service;
        }
        
        //====== COMMANDS ======
        public void AddMedicamento(MedicamentoDTO medicamentoDTO)
        {
            var command = _mapper.Map<AddMedicamentoCommand>(medicamentoDTO);
            _queue.EnqueueAsync(command);
        }

        public void UpdateMedicamento(MedicamentoDTO medicamentoDTO)
        {
            var command = _mapper.Map<UpdateMedicamentoCommand>(medicamentoDTO);
            _queue.EnqueueAsync(command);

        }

        public void DeleteMedicamento(MedicamentoDTO medicamentoDTO)
        {
            var command = _mapper.Map<DeleteMedicamentoCommand>(medicamentoDTO);
            _queue.EnqueueAsync(command);

        }

        //====== QUERIES ======
        public MedicamentoDTO GetMedicamento(Guid id)
        {
            var medicamento = _medicamentoQueryService.GetMedicamento(id);
            var medicamentoDTO = _mapper.Map<MedicamentoDTO>(medicamento);
            return medicamentoDTO;
        }

        public IEnumerable<MedicamentoDTO> GetAllMedicamentos()
        {
            var medicamentos = _medicamentoQueryService.GetAllMedicamentos();
            return _mapper.Map<IEnumerable<MedicamentoDTO>>(medicamentos);

        }
    }
}
