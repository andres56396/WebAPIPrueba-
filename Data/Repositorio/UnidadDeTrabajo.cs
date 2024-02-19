using Data.Datos;
using Data.Repositorio.IRepositorio;
using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    // Clase que implementa la interfaz de unidad de trabajo
    public class UnidadDeTrabajo : IUnidadeTrabajo
    {

        private AplicacionDBContext _db;

        // Constructor que recibe un contexto de base de datos
        public UnidadDeTrabajo(AplicacionDBContext db)
        {
            _db = db;
            // Inicialización de los repositorios específicos para cada entidad
            estudiante = new RepositorioEstudiante(_db);
            asignatura = new RepositorioAsignatura(_db);
            asignaciones = new RepositorioAsignaciones(_db);

        }

        // Propiedad que proporciona acceso al repositorio de la entidad 'Estudiante'
        public IEstudiante estudiante { get; private set; }
        public IAsignaturas asignatura { get; private set; }
        public IAsignaciones asignaciones { get; private set; }


        // Método asincrónico para guardar los cambios en la base de datos
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }


    }
}
