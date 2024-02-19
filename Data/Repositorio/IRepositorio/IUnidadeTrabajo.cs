using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio.IRepositorio
{
    // Interfaz que representa una unidad de trabajo
    public interface IUnidadeTrabajo
    {
        // Propiedad que representa un repositorio para la entidad 'Estudiante'
        IEstudiante estudiante { get; }
        IAsignaturas asignatura { get; }
        IAsignaciones asignaciones { get; }
        // Método asincrónico para guardar los cambios en la base de datos
        Task Save();
    }
}
