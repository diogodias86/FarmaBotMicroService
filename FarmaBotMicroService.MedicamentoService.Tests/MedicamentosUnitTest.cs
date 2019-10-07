using FarmaBotMicroService.MedicamentoService.Application;
using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using FarmaBotMicroService.MedicamentoService.Application.AutoMapper;
using FarmaBotMicroService.MedicamentoService.Domain.CQRS.Commands;
using FarmaBotMicroService.MedicamentoService.Infra.CQRS;
using FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Contexts;
using FarmaBotMicroService.MedicamentoService.Infra.DataAccess.Repositories.EFCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace FarmaBotMicroService.MedicamentoService.Tests
{
    [TestClass]
    public class MedicamentosUnitTest
    {
        [TestMethod]
        public void Adicionar_Medicamento()
        {
            var sintomas = new List<SintomaDTO>();
            sintomas.Add(new SintomaDTO { Descricao = "dor de cabeça" });
            sintomas.Add(new SintomaDTO { Descricao = "dor no corpo" });
            sintomas.Add(new SintomaDTO { Descricao = "febre" });

            var data = JsonConvert.SerializeObject(
                    new MedicamentoDTO
                    {
                        Nome = "Dorflex",
                        Preco = 5.00m,
                        Sintomas = sintomas
                    });

            var _httpClient = new HttpClient();
            var response = _httpClient.PostAsync("http://localhost:60737/api/medicamento",
                new StringContent(data, Encoding.UTF8, "application/json")).Result;

            Assert.IsTrue(response.IsSuccessStatusCode);

        }

        [TestMethod]
        public void Recuperar_Todos_Medicamentos()
        {
            var _httpClient = new HttpClient();
            var response = _httpClient.GetAsync("http://localhost:60737/api/medicamento").Result;

            Debug.WriteLine(response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void Add_Medicamento_Queue()
        {
            var dtoConfig = AutoMapperConfig.RegisterAllMappings();
            var mapper = dtoConfig.CreateMapper();

            var apiAppService = new ApiAppService(new AzureStorageQueue(), mapper,
                new Domain.Services.MedicamentoService(
                    new MedicamentoRepository(
                        new MedicamentoContext()
                    )
                )
            );

            var sintomas = new List<SintomaDTO>();
            sintomas.Add(new SintomaDTO { Descricao = "dor de barriga" });
            sintomas.Add(new SintomaDTO { Descricao = "dor na nuca" });
            sintomas.Add(new SintomaDTO { Descricao = "ânsia" });

            apiAppService.AddMedicamento(new MedicamentoDTO
            {
                Nome = "Dorflex via Queue 3",
                Preco = 5.00m,
                Sintomas = sintomas
            });
        }

        [TestMethod]
        public void Add_Medicamento_Dequeue()
        {
            var _commandHandler = new CommandHandler(
                new Domain.Services.MedicamentoService(
                    new MedicamentoRepository(
                        new MedicamentoContext()
                    )
                )
            );

            var queue = new AzureStorageQueue();
            var message = queue.DequeueAsync(AddMedicamentoCommand.ConstQueueName).Result;

            var command = JsonConvert.DeserializeObject<AddMedicamentoCommand>(message);
            _commandHandler.Handle(command);
        }
    }
}
