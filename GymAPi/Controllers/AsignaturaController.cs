using Data.Datos;
using Data.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {

        private readonly IUnidadeTrabajo _db;

        public AsignaturaController(IUnidadeTrabajo db, AplicacionDBContext dbContext)
        {
            _db = db;

        }

        [HttpGet]
        [Route("ListarCompleta")]
        public async Task<IActionResult> listarAignatura()
        {
            var asigantura = await _db.asignatura.GetAll();
            return new JsonResult(asigantura);
        }
        [HttpGet]
        [Route("listarNoRegistradasAignatura")]
        public async Task<IActionResult> listarNoRegistradasAignatura(int id)
        {
            var asigantura = await _db.asignatura.listaAsignaturaNORegistradas(id);
            return new JsonResult(asigantura);
        }

    }
}
