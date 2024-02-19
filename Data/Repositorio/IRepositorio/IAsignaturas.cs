using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio.IRepositorio
{
    public interface IAsignaturas : IRepositorio<Asignaturas>
    {
        Task<dynamic> listaAsignatura(int? NumeroPagina, int? TamañoPagina);
        Task<dynamic> listaIdAsignatura(int id);
        Task<dynamic> listaAsignaturaNORegistradas(int id);
        //object Id(int?IDusuario);
    }
}
