using Data.Datos;
using Data.Repositorio;
using Data.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IUnidadeTrabajo _db;

        public EstudianteController(IUnidadeTrabajo db, AplicacionDBContext dbContext)
        {
            _db = db;
            
        }

        [HttpGet]
        [Route("ListarCompleta")]
        public async Task<IActionResult> listarEstudiante()
        {
            var Estudiante = await _db.estudiante.GetAll();
            return new JsonResult(Estudiante);
        }

        [HttpGet]
        [Route("ListarEstudiante")]
        public async Task<IActionResult> listarEstudiante(int? NumeroPagina, int? TamañoPagina)
        {
            var Estudiante = await _db.estudiante.listaEstudiante(NumeroPagina, TamañoPagina);
            return new JsonResult(Estudiante);
        }


        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromForm] Estudiantes estudiante)
        {
            try
            {
                // Validar el modelo antes de intentar guardarlo
                if (ModelState.IsValid)
                {
                    // Agregar el nuevo Estudiante al contexto
                    await _db.estudiante.Add(estudiante);

                    // Guardar los cambios en la base de datos
                    await _db.Save();

                    return Ok(estudiante);
                }
                else
                {
                    // Devolver detalles de errores de validación si el modelo no es válido
                    return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                }
            }
            catch (Exception ex)
            {
                // Loguear la excepción o devolver un mensaje de error más específico
                return BadRequest($"Error al crear el usuario: {ex.Message}");
            }
        }   
        
        
        
        
        
        
        
        
        





    }
}
