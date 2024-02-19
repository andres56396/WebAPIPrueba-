using Data.Datos;
using Data.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
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
    public class RepositorioAsignatura : Repositorio<Asignaturas>, IAsignaturas
    {
        private readonly AplicacionDBContext _db;
        public RepositorioAsignatura(AplicacionDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<dynamic> listaAsignatura(int? NumeroPagina, int? TamañoPagina)
        {
            int NumeroPaginaD = NumeroPagina ?? 1;
            int TamañoPaginaD = TamañoPagina ?? 5;
            var asignatura = await(from asignaturas in _db.Asignaturas
                                    select new
                                    {
                                        Nombre = asignaturas.AsigNombre,
                                        Descripcion = asignaturas.AsigDescripcion
                                    }).ToListAsync();

            return asignatura.Skip((NumeroPaginaD - 1) * TamañoPaginaD).Take(TamañoPaginaD);
        }

        public async Task<dynamic> listaAsignaturaNORegistradas(int id)
        {
            var resultado = _db.Asignaturas.FromSqlRaw("exec ObtenerAsignaturasNoIncritaXEstudiante @IdEstudiante", new SqlParameter("@IdEstudiante", id)).ToList();
            return (resultado);
        }

        public async Task<dynamic> listaIdAsignatura(int id)
        {
            var asignaturaId = await _db.Asignaturas.Where(a => a.IDAsignatura == id).ToListAsync();//Incluye la informacion de las canciones del artista
            return (asignaturaId);
        }
    }
}
