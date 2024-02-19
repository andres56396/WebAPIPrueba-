using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    // La clase representa la entidad 'Estudiantes' en la base de datos
    public class Estudiantes
    {
        // Clave primaria autoincremental generada por la base de datos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEstudiante { get; set; }

        // Nombre del estudiante con una longitud máxima de 100 caracteres
        [StringLength(100)]
        public string? EstuNombre { get; set; }

        [StringLength(100)]
        public string? Estuemail { get; set; }

        // Relación de uno a muchos con la entidad 'Asignaciones'
        public ICollection<Asignaciones>? Asignaciones { get; set; }
    }
}
