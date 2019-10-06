using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace FarmaBotMicroService.DiagnosticoService.Tests
{
    [TestClass]
    public class DiagnosticoUnitTest
    {
        [TestMethod]
        public void Diagnosticar()
        {
            var _httpClient = new HttpClient();

            var sintomas = "dor de cabeça";
            var response = _httpClient.GetAsync($"http://localhost:58529/api/diagnostico?sintomas={sintomas}").Result;

            Debug.WriteLine(response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
