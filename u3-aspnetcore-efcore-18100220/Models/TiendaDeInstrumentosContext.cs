using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace u3_aspnetcore_efcore_18100220.Models
{
    public partial class TiendaDeInstrumentosContext : DbContext
    {
        public TiendaDeInstrumentosContext()
        {
        }

        public TiendaDeInstrumentosContext(DbContextOptions<TiendaDeInstrumentosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InstrumentoMusical> InstrumentoMusicals { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= SANTANAPORTATIL\\SQLEXPRESS; Database=TiendaDeInstrumentos; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<InstrumentoMusical>(entity =>
            {
                entity.HasKey(e => e.IdInstrumento)
                    .HasName("PK__Instrume__1F937635E567D8C1");

                entity.ToTable("InstrumentoMusical");

                entity.Property(e => e.IdInstrumento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_instrumento");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.InstrumentoMusicals)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Instrumen__id_ti__267ABA7A");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo__CF9010894C8B89F8");

                entity.ToTable("Tipo");

                entity.Property(e => e.IdTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_tipo");

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
