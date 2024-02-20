using Data.Datos;
using Data.Repositorio.IRepositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositorioAsignaciones : Repositorio<Asignaciones>, IAsignaciones
    {
        private readonly AplicacionDBContext _db;
        public RepositorioAsignaciones(AplicacionDBContext db) : base(db)
        {
            _db = db;
        }

        // Método para obtener una lista de asignaturas mediante un procedimiento almacenado,
        // filtradas por el ID de un estudiante específico
        public async Task<dynamic> listaProcedimiento(int idEstudiante)
        {
            // Ejecutar el procedimiento almacenado con el ID de estudiante como parámetro
            var resultado = _db.Asignaciones.FromSqlRaw("exec ObtenerAsignaturasXEstudiante @IdEstudiante", new SqlParameter("@IdEstudiante", idEstudiante)).ToList();
            // Devolver el resultado, que es una lista de asignaturas relacionadas con el estudiante
            return (resultado);
        }

        // Método para ejecutar el procedimiento almacenado para eliminar una asignación basada en su ID
        public async Task<dynamic> ProcemientoEliminarAsignacion(int idAsignacion)
        {
            // Ejecutar el procedimiento almacenado con el ID de la asignación como parámetro
              await _db.Database.ExecuteSqlRawAsync("exec EliminarRegistroAsignacion @IDAsignacion", new SqlParameter("@IDAsignacion", idAsignacion));
              return "OK";
        }

        // Método para ejecutar el procedimiento almacenado para registrar una nueva asignación
        public async Task<dynamic> ProcemientoRegistrarAsignacion(string? detalle, int IDEstudiante, int idAsignatura)
        {
            // Crear un array de parámetros para el procedimiento almacenado
            var parametros = new[]
            {
              new SqlParameter("@Detalle", detalle),
                 new SqlParameter("@IDEstudiante", IDEstudiante),
               new SqlParameter("@IDAsignatura", idAsignatura)
            };

            // Ejecutar el procedimiento almacenado con los parámetros especificados
            
            await _db.Database.ExecuteSqlRawAsync("exec RegistrarAsignacion @Detalle, @IDEstudiante, @IDAsignatura", parametros);
            return "OK";
        }
    }
}
