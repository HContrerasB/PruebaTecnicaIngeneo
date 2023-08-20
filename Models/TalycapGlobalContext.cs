using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IngeneoPT.Models
{
    public partial class TalycapGlobalContext : DbContext
    {
        public TalycapGlobalContext()
        {
        }

        public TalycapGlobalContext(DbContextOptions<TalycapGlobalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Envio> Envios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<TipoTransporte> TipoTransportes { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KEITOR\\MSSQLSERVER01;Database=TalycapGlobal;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cedula).HasMaxLength(15);

                entity.Property(e => e.Direccion).HasMaxLength(200);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(15);
            });

            modelBuilder.Entity<Envio>(entity =>
            {
                entity.ToTable("Envio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(25)
                    .HasColumnName("MATRICULA");

                entity.Property(e => e.NumeroGuia).HasMaxLength(8);

                entity.Property(e => e.PrecioEnvio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.TipoTransporteId).HasColumnName("TipoTransporteID");

                entity.Property(e => e.UbicacionId).HasColumnName("UbicacionID");

                entity.Property(e => e.ValorDescuento).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Envio__ClienteID__4AB81AF0");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Envio__ProductoI__4BAC3F29");

                entity.HasOne(d => d.TipoTransporte)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.TipoTransporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Envio__TipoTrans__4CA06362");

                entity.HasOne(d => d.Ubicacion)
                    .WithMany(p => p.Envios)
                    .HasForeignKey(d => d.UbicacionId)
                    .HasConstraintName("FK__Envio__Ubicacion__4D94879B");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.ToTable("TipoProducto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<TipoTransporte>(entity =>
            {
                entity.ToTable("TipoTransporte");

                entity.Property(e => e.Tipo).HasMaxLength(20);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("Ubicacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.TipoTransporteId).HasColumnName("TipoTransporteID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
