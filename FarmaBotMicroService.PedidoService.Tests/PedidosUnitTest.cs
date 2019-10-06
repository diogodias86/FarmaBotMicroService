using FarmaBotMicroService.PedidoService.Application;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Domain.CQRS.Commands;
using FarmaBotMicroService.PedidoService.Infra.CQRS;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Contexts;
using FarmaBotMicroService.PedidoService.Infra.DataAccess.Repositories.EFCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var response = _httpClient.PostAsync("http://localhost:50219/api/pedido",
                new StringContent(data, Encoding.UTF8, "application/json")).Result;

            Assert.IsTrue(response.IsSuccessStatusCode);

            for (var i = 0; i <= 10; i++)
            {
                var data2 = JsonConvert.SerializeObject(
                    new MedicamentoDTO
                    {
                        Nome = "Medicamento " + i,
                        Preco = i
                    });

                var _httpClient2 = new HttpClient();
                var response2 = _httpClient2.PostAsync("http://localhost:60737/api/pedido",
                    new StringContent(data2, Encoding.UTF8, "application/json")).Result;

                Assert.IsTrue(response2.IsSuccessStatusCode);
            }
        }

        [TestMethod]
        public void Recuperar_Todos_Pedidos()
        {
            var _httpClient = new HttpClient();
            var response = _httpClient.GetAsync("http://localhost:60737/api/pedido").Result;

            var data = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

    }
}
