using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
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
            for (var i = 0; i <= 10; i++)
            {
                var data = JsonConvert.SerializeObject(
                    new MedicamentoDTO
                    {
                        Nome = "Medicamento " + i,
                        Preco = i
                    });

                var _httpClient = new HttpClient();
                var response = _httpClient.PostAsync("http://localhost:60737/api/medicamento",
                    new StringContent(data, Encoding.UTF8, "application/json")).Result;

                Assert.IsTrue(response.IsSuccessStatusCode);
            }
        }

        [TestMethod]
        public void Recuperar_Todos_Medicamentos()
        {
            var _httpClient = new HttpClient();
            var response = _httpClient.GetAsync("http://localhost:60737/api/medicamento").Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
