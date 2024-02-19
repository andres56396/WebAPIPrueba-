using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    public class Asignaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAsignacion { get; set; }

        [StringLength(80)]
        public string? Detalle { get; set; }

        [StringLength(100)]
        public string? Estudiante { get; set; }

        [StringLength(100)]
        public string? Asignatura { get; set; }

        public int IDEstudiante { get; set; }
       public Estudiantes Estudiantes { get; set; }

        public int IDAsignatura { get; set; }
        public Asignaturas Asignaturas { get; set; }


    }
}
