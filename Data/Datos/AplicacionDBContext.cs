
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;

namespace Data.Datos
{
    // Clase que representa el contexto de la base de datos de la aplicación
    public class AplicacionDBContext : DbContext
    {
        // Constructor que toma opciones de contexto al configurar la base de datos
        public AplicacionDBContext(DbContextOptions<AplicacionDBContext> options)
           : base(options)
        {
        }

        // Propiedades DbSet que representan las entidades en la base de datos
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }

        // Método para configurar el modelo de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la clave primaria compuesta para la entidad 'Asignaciones'
            modelBuilder.Entity<Asignaciones>()
                .HasKey(a => new { a.IDEstudiante, a.IDAsignacion });

            // Configuración de la relación uno a muchos entre 'Estudiantes' y 'Asignaciones'
            modelBuilder.Entity<Asignaciones>()
                .HasOne(a => a.Estudiantes)
                .WithMany(e => e.Asignaciones)
                .HasForeignKey(a => a.IDEstudiante);

            // Configuración de la relación uno a muchos entre 'Asignaturas' y 'Asignaciones'
            modelBuilder.Entity<Asignaciones>()
                .HasOne(a => a.Asignaturas)
                .WithMany(a => a.Asignaciones)
                .HasForeignKey(a => a.IDAsignacion);
        }
       
    }
}
