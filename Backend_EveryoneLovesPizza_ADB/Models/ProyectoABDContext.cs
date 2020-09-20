using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class ProyectoABDContext : DbContext
    {
        public ProyectoABDContext()
        {
        }

        public ProyectoABDContext(DbContextOptions<ProyectoABDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompra { get; set; }
        public virtual DbSet<DetalleProducto> DetalleProducto { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Funciones> Funciones { get; set; }
        public virtual DbSet<Insumos> Insumos { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }
        public virtual DbSet<OrdenVenta> OrdenVenta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TransaccionesEntidad> TransaccionesEntidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ProyectoABD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AutorizadaPor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idinsumos).HasColumnName("IDInsumos");

                entity.Property(e => e.IdordenCompra).HasColumnName("IDOrdenCompra");

                entity.Property(e => e.PrecioUnitario).HasColumnType("money");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdinsumosNavigation)
                    .WithMany(p => p.DetalleCompra)
                    .HasForeignKey(d => d.Idinsumos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCompra_Insumos");

                entity.HasOne(d => d.IdordenCompraNavigation)
                    .WithMany(p => p.DetalleCompra)
                    .HasForeignKey(d => d.IdordenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCompra_OrdenCompra");
            });

            modelBuilder.Entity<DetalleProducto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idinsumo).HasColumnName("IDInsumo");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.UnidadMedidaInsumos)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdinsumoNavigation)
                    .WithMany(p => p.DetalleProducto)
                    .HasForeignKey(d => d.Idinsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProducto_Insumos");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.DetalleProducto)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleProducto_Producto");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("Detalle_Venta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idinsumos).HasColumnName("IDInsumos");

                entity.Property(e => e.Idorden).HasColumnName("IDOrden");

                entity.HasOne(d => d.IdinsumosNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idinsumos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Venta_Insumos");

                entity.HasOne(d => d.IdordenNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.Idorden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalle_V__IDOrd__32AB8735");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idfuncion).HasColumnName("IDFuncion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdfuncionNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.Idfuncion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Funciones");
            });

            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddepartamentoNavigation)
                    .WithMany(p => p.Funciones)
                    .HasForeignKey(d => d.Iddepartamento)
                    .HasConstraintName("FK_Funciones_Departamento1");
            });

            modelBuilder.Entity<Insumos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fechacaducidad).HasColumnType("date");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioVenta).HasColumnType("money");

                entity.Property(e => e.UnidadMedidaAlmacenamiento)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaVenta)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Insumos_Categoria");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idinsumos).HasColumnName("IDInsumos");

                entity.HasOne(d => d.IdinsumosNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.Idinsumos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Insumos");
            });

            modelBuilder.Entity<OrdenCompra>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Fechaingreso).HasColumnType("datetime");

                entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.OrdenCompra)
                    .HasForeignKey(d => d.Idproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenCompra_Proveedor");
            });

            modelBuilder.Entity<OrdenVenta>(entity =>
            {
                entity.ToTable("Orden_Venta");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EstadoOrden)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaOrden).HasColumnType("datetime");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Idencargado).HasColumnName("IDEncargado");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.OrdenVenta)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Venta_Cliente");

                entity.HasOne(d => d.IdencargadoNavigation)
                    .WithMany(p => p.OrdenVenta)
                    .HasForeignKey(d => d.Idencargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orden_Venta_Empleado");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransaccionesEntidad>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EntidadAfectada)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.Property(e => e.TipoTransaccion)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
