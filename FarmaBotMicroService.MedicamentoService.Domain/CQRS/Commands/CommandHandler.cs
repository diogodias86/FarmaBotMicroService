namespace FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands
{
    public class CommandHandler
    {
        private readonly Services.MedicamentoService _service;

        public CommandHandler(Services.MedicamentoService service)
        {
            _service = service;
        }

        public void Handle(AddMedicamentoCommand command)
        {
            _service.AddMedicamento(command.Medicamento);
        }

        public void Handle(UpdateMedicamentoCommand command)
        {
            _service.UpdateMedicamento(command.Medicamento);
        }

        public void Handle(DeleteMedicamentoCommand command)
        {
            _service.DeleteMedicamento(command.Medicamento.Id);
        }
    }
}
