using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaBotMicroService.DiagnosticoService.Application.AppModel;
using FarmaBotMicroService.DiagnosticoService.Service.Api.Contexts;
using System.Linq;
using FarmaBotMicroService.DiagnosticoService.Application;
using FarmaBotMicroService.DiagnosticoService.Infra.DataAccess.Repositories;
using FarmaBotMicroService.DiagnosticoService.Application.AutoMapper;

namespace FarmaBotMicroService.DiagnosticoService.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly DiagnosticoDbContext _context;

        public DiagnosticoController(DiagnosticoDbContext context)
        {
            _context = context;
        }

        // GET: api/Diagnostico
        [HttpGet]
        public IActionResult GetDiagnostico(string sintomas)
        {
            var dtoConfig = AutoMapperConfig.RegisterAllMappings();
            var mapper = dtoConfig.CreateMapper();

            var apiAppService = new ApiAppService(
                new Domain.Services.DiagnosticoQueryService(
                    new DiagnosticoQueryEFRepository(
                        new DiagnosticoDbContext()
                    )
                ), mapper
            );

            var result = apiAppService.Diagnosticar(sintomas);

            return new JsonResult(result.Select(m => new { m.Nome, m.Preco }));
        }
    }
}
