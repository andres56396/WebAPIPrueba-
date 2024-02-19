using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio.IRepositorio
{
    // Interfaz que extiende la interfaz genérica de repositorio para la entidad 'Asignaciones'
    public interface IAsignaciones : IRepositorio<Asignaciones>
    {
        // Método asincrónico para obtener una lista de asignaciones mediante un procedimiento
        Task<dynamic> listaProcedimiento(int idEstudiante);
        // Método asincrónico para ejecutar el procedimiento de registrar una asignación
        Task<dynamic> ProcemientoRegistrarAsignacion(string? detalle,int IDEstudiante, int idAsignatura);
        // Método asincrónico para ejecutar el procedimiento de eliminar una asignación
        Task<dynamic> ProcemientoEliminarAsignacion(int idAsignacion);

    }
}
