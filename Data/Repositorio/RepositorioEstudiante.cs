using Data.Datos;
using Data.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    // Clase que implementa el repositorio para la entidad 'Estudiantes'
    public class RepositorioEstudiante : Repositorio<Estudiantes>, IEstudiante
    {
        private readonly AplicacionDBContext _db;

        // Constructor que recibe un contexto de base de datos
        public RepositorioEstudiante(AplicacionDBContext db) : base(db)
        {
            _db = db;
        }

        // Implementación del método para obtener una lista paginada de estudiantes
        public async Task<dynamic> listaEstudiante(int? NumeroPagina, int? TamañoPagina)
        {
            int NumeroPaginaD = NumeroPagina ?? 1;
            int TamañoPaginaD = TamañoPagina ?? 5;
            var estudiantes = await (from estudiante in _db.Estudiantes
                                  select new
                                  {
                                      Nombre = estudiante.EstuNombre,
                                      Email = estudiante.Estuemail
                                  }).ToListAsync();

            return estudiantes.Skip((NumeroPaginaD - 1) * TamañoPaginaD).Take(TamañoPaginaD);
        }

        // Implementación del método para obtener información sobre un estudiante específico
        public async Task<dynamic> listaIdEstudiante(int id)
        {
            var estudianteId = await _db.Estudiantes.Where(a => a.IDEstudiante == id).ToListAsync();//Incluye la informacion de las canciones del artista
            return (estudianteId);
        }
    }
}
