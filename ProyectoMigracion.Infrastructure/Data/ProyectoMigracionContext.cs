using Microsoft.EntityFrameworkCore;
using ProyectoMigracion.Core.Entities;

namespace ProyectoMigracion.Infrastructure.Data
{
    public partial class ProyectoMigracionContext : DbContext
    {
        public ProyectoMigracionContext(DbContextOptions<ProyectoMigracionContext> options) : base(options){}

        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipo");

                entity.Property(e => e.EstadoId).HasMaxLength(25);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_Equipo_Estado");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Equipo_Persona");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.HasKey(e => e.NombreEstado);

                entity.Property(e => e.NombreEstado).HasMaxLength(25);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Pasaporte).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.Sexo).HasMaxLength(1);

                entity.Property(e => e.Foto).HasMaxLength(500);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("Solicitud");

                entity.Property(e => e.NombreEstado).HasMaxLength(25);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Solicitud_Persona");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.NombreEstado)
                    .HasConstraintName("FK_Solicitud_Estado");

            });
        }
    }
}
