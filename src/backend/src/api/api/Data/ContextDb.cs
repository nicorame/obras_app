using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data;

public partial class ContextDb : DbContext
{
    public ContextDb()
    {
    }

    public ContextDb(DbContextOptions<ContextDb> options)
        : base(options)
    {
    }

    public virtual DbSet<albanile> albaniles { get; set; }

    public virtual DbSet<albaniles_x_obra> albaniles_x_obras { get; set; }

    public virtual DbSet<deporte> deportes { get; set; }

    public virtual DbSet<obra> obras { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<socio> socios { get; set; }

    public virtual DbSet<tipos_obra> tipos_obras { get; set; }

    public virtual DbSet<usuario> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=DESKTOP-DH9BN0G\\SQLEXPRESS;Initial catalog=parcial_prog2_db;User id=sa;Password=nico1234;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<albanile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__albanile__3214EC071FD17409");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CodPost)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<albaniles_x_obra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__albanile__3214EC0773F2D886");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TareaARealizar)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlbanilNavigation).WithMany(p => p.albaniles_x_obras)
                .HasForeignKey(d => d.IdAlbanil)
                .HasConstraintName("fk_albaniles");

            entity.HasOne(d => d.IdObraNavigation).WithMany(p => p.albaniles_x_obras)
                .HasForeignKey(d => d.IdObra)
                .HasConstraintName("fk_obras");
        });

        modelBuilder.Entity<deporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__deportes__3214EC0738694B65");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<obra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__obras__3214EC0798A00639");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DatosVarios)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoObraNavigation).WithMany(p => p.obras)
                .HasForeignKey(d => d.IdTipoObra)
                .HasConstraintName("fk_obras_tp");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3214EC07EDC8C1DB");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<socio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__socios__3214EC077C1894BD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CodPost)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDeporteNavigation).WithMany(p => p.socios)
                .HasForeignKey(d => d.IdDeporte)
                .HasConstraintName("fk_socios_dep");
        });

        modelBuilder.Entity<tipos_obra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipos_ob__3214EC07E3C4735B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3214EC0763ED0760");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CodPost)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_usuario_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
