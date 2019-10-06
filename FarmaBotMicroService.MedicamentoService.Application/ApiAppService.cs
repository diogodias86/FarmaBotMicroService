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
        private readonly Domain.Services.MedicamentoService _medicamentoQueryService;

        public ApiAppService(IQueue queue, Domain.Services.MedicamentoService service)
        {
            _queue = queue;
            _medicamentoQueryService = service;
        }
        
        //====== COMMANDS ======
        public void AddMedicamento(MedicamentoDTO medicamentoDTO)
        {
            _queue.EnqueueAsync(new AddMedicamentoCommand(new Medicamento
            {
                Nome = medicamentoDTO.Nome,
                Preco = medicamentoDTO.Preco
            }));
        }

        public void UpdateMedicamento(MedicamentoDTO medicamentoDTO)
        {
            _queue.EnqueueAsync(new UpdateMedicamentoCommand(new Medicamento
            {
                Id = medicamentoDTO.Id,
                Nome = medicamentoDTO.Nome,
                Preco = medicamentoDTO.Preco
            }));
        }

        public void DeleteMedicamento(Guid id)
        {
            _queue.EnqueueAsync(new DeleteMedicamentoCommand(new Medicamento
            {
                Id = id
            }));
        }

        //====== QUERIES ======
        public MedicamentoDTO GetMedicamento(Guid id)
        {
            var medicamento = _medicamentoQueryService.GetMedicamento(id);
            return new MedicamentoDTO
            {
                Id = medicamento.Id,
                Nome = medicamento.Nome,
                Preco = medicamento.Preco
            };
        }

        public IEnumerable<MedicamentoDTO> GetAllMedicamentos()
        {
            var medicamentos = _medicamentoQueryService.GetAllMedicamentos();

            return medicamentos.Select((m) =>
                new MedicamentoDTO
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    Preco = m.Preco
                });
        }
    }
}
