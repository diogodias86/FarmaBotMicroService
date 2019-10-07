using FarmaBotMicroService.PedidoService.Application;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Application.AutoMapper;
using FarmaBotMicroService.PedidoService.Domain.CQRS.Commands;
using FarmaBotMicroService.PedidoService.Infra.CQRS;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Contexts;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Repositories.EFCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace FarmaBotMicroService.PedidoService.Tests
{
    [TestClass]
    public class PedidosUnitTest
    {
        [TestMethod]
        public void Adicionar_Pedido()
        {
            var medicamentos = new List<MedicamentoDTO>();
            medicamentos.Add(new MedicamentoDTO { Nome = "Dorflex", Preco = 5.00M });
            medicamentos.Add(new MedicamentoDTO { Nome = "Ibuprofeno", Preco = 10.00M });
            medicamentos.Add(new MedicamentoDTO { Nome = "Novalgina", Preco = 15.00M });

            var data = JsonConvert.SerializeObject(
                    new PedidoDTO
                    {
                        Data = DateTime.Now,
                        ClienteId = Guid.NewGuid(),
                        Endereco = "Rua São Jose, 90, Centro, Rio de Janeiro",
                        Medicamentos = medicamentos
                    });

            var _httpClient = new HttpClient();
            var response = _httpClient.PostAsync("https://localhost:44350/api/pedido",
                new StringContent(data, Encoding.UTF8, "application/json")).Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void Recuperar_Todos_Pedidos()
        {
            var _httpClient = new HttpClient();
            var response = _httpClient.GetAsync("https://localhost:44350/api/pedido").Result;

            Debug.WriteLine(response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void Add_Pedido_Queue()
        {

            var dtoConfig = AutoMapperConfig.RegisterAllMappings();
            var mapper = dtoConfig.CreateMapper();

            var apiAppService = new ApiAppService(new AzureStorageQueue(), mapper, 
                new Domain.Services.PedidoService(
                    new PedidoRepository(
                        new PedidoContext()
                    )
                )
            );

            var medicamentos = new List<MedicamentoDTO>();
            medicamentos.Add(new MedicamentoDTO { Nome = "Dipirona", Preco = 5.00M });
            medicamentos.Add(new MedicamentoDTO { Nome = "Doril", Preco = 10.00M });
            medicamentos.Add(new MedicamentoDTO { Nome = "Paracetamol", Preco = 15.00M });

            apiAppService.AddPedido(new PedidoDTO
            {
                Data = DateTime.Now,
                ClienteId = Guid.NewGuid(),
                Endereco = "Rua São Jose, 120, Centro, Rio de Janeiro",
                Medicamentos = medicamentos
            });
        }

        [TestMethod]
        public void Add_Pedido_Dequeue()
        {
            var _commandHandler = new CommandHandler(
                new Domain.Services.PedidoService(
                    new PedidoRepository(
                        new PedidoContext()
                    )
                )
            );

            var queue = new AzureStorageQueue();
            var message = queue.DequeueAsync(AddPedidoCommand.ConstQueueName).Result;

            var command = JsonConvert.DeserializeObject<AddPedidoCommand>(message);
            _commandHandler.Handle(command);
        }
    }

}

