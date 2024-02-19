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
    // Clase que implementa la interfaz genérica para un repositorio
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly AplicacionDBContext _db;
        internal DbSet<T> dbSet;

        // Constructor que recibe un contexto de base de datos
        public Repositorio(AplicacionDBContext db)
        {
            _db = db;            
            // Asigna el DbSet correspondiente al tipo T
            this.dbSet = _db.Set<T>();
        }


        // Método para eliminar un elemento de tipo T del repositorio
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
        // Método para eliminar una colección de elementos de tipo T del repositorio
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }


        // Implementación del método para agregar un elemento de tipo T al repositorio
        async Task IRepositorio<T>.Add([FromForm] T entity)
        {
            await dbSet.AddAsync(entity);
        }

        // Implementación del método para obtener todos los elementos de tipo T del repositorio
        async Task<IEnumerable<T>> IRepositorio<T>.GetAll()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }
    }
}
