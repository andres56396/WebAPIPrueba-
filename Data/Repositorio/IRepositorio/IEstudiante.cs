using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio.IRepositorio
{
    // Interfaz que extiende la interfaz genérica de repositorio para la entidad 'Estudiantes'
    public interface IEstudiante: IRepositorio<Estudiantes>
    {
        // Método asincrónico que devuelve una lista paginada de estudiantes
        Task<dynamic> listaEstudiante(int? NumeroPagina, int? TamañoPagina);
        // Método asincrónico que devuelve información sobre un estudiante específico
        Task<dynamic> listaIdEstudiante(int id);
        
     } 
}
