using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PC12420021524100635.CORE.Core;

namespace PC12420021524100635.CORE.Infrastructure.Data;

public partial class TallerMecanicoDbContext : DbContext
{
    public TallerMecanicoDbContext()
    {
    }

    public TallerMecanicoDbContext(DbContextOptions<TallerMecanicoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<OrdenServicio> OrdenServicios { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC0773D0BA2D");

            entity.ToTable("Cliente");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Materno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Paterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrdenServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenSer__3214EC0784192E93");

            entity.ToTable("OrdenServicio");

            entity.Property(e => e.CostoEstimado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DescripcionProblema).IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenServ__TipoS__2E1BDC42");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenServ__Vehic__2D27B809");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoServ__3214EC0791F1F6D1");

            entity.ToTable("TipoServicio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioBase).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC0787E53A18");

            entity.ToTable("Vehiculo");

            entity.HasIndex(e => e.Placa, "UQ__Vehiculo__8310F99D55067544").IsUnique();

            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehiculo__Client__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
