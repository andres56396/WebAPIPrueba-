using Data.Datos;
using Data.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Modelos.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {

        private readonly IUnidadeTrabajo _db;

        public AsignacionesController(IUnidadeTrabajo db, AplicacionDBContext dbContext)
        {
            _db = db;

        }

        [HttpGet]
        [Route("ListarCompleta")]
        public async Task<IActionResult>listarAsignaciones(int id)
        {
            var asignaciones = _db.asignaciones.listaProcedimiento(id);
            
            return new JsonResult(asignaciones.Result);
        }

        [HttpPost]
        [Route("RegitrarAsignacion")]
        public async Task<IActionResult> EjecutarProcedimientoRegistrarAsignacion(string? detalle, int IDEstudiante, int idAsignatura)
        {
            
                await _db.asignaciones.ProcemientoRegistrarAsignacion(detalle, IDEstudiante, idAsignatura);
                return Ok();
            
        }

        [HttpDelete]
        [Route("EliminarAsignacion")]
        public async Task<IActionResult> EjecutarProcedimientoEliminarAsignacion(int idAsignacion)
        {
            try
            {
                var resultado = await _db.asignaciones.ProcemientoEliminarAsignacion(idAsignacion);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción aquí
                return BadRequest($"Error al ejecutar el procedimiento: {ex.Message}");
            }
        }




    }
}