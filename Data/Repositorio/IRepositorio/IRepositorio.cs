using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repositorio.IRepositorio
{
    // Interfaz genérica para un repositorio
    public interface IRepositorio<T> where T : class 
    {
        // Método para obtener todos los elementos de tipo T
        public Task<IEnumerable<T>> GetAll();

        // Método para agregar un elemento de tipo T al repositorio
        public Task Add([FromForm] T entity);

        // Método para eliminar un elemento de tipo T del repositorio
        void Remove(T entity);

        // Método para eliminar una colección de elementos de tipo T del repositorio
        void RemoveRange(IEnumerable<T> entity);
            


    }
    
}
