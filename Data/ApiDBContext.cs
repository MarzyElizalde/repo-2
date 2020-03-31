using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        //Creación de tablas
        public DbSet<CtDivisa> CtDivisa { get; set; }
        public DbSet<CtDenominacion> CtDenominacion { get; set; }
        public DbSet<CtTipoMovimiento> CtTipoMovimiento { get; set; }
        public DbSet<TbFondo> TbFondo { get; set; }
        public DbSet<TbTurno> TbTurno { get; set; }
        public DbSet<CtUsuario> CtUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CtDivisa>(entity =>
            {
                entity.HasKey(e => e.PkIdDivisa);
                entity.ToTable("ctDivisa");
                entity.Property(e => e.PkIdDivisa).HasColumnName("llDivisa");
                entity.Property(e => e.Divisa).HasColumnName("dsDivisa");
                entity.HasData(new CtDivisa { PkIdDivisa = 1, Divisa = "MXN" });
                entity.HasData(new CtDivisa { PkIdDivisa = 2, Divisa = "USD" });
            });

            modelBuilder.Entity<CtDenominacion>(entity =>
            {
                entity.HasKey(e => e.PKIdDenominacion);
                entity.ToTable("ctDenominacion");
                entity.Property(e => e.PKIdDenominacion).HasColumnName("llDenominacion");
                entity.Property(e => e.FKIdDivisa).HasColumnName("llDivisa");
                entity.Property(e => e.Descripcion).HasColumnName("dsDenominacion");

                entity.HasOne(d => d.FkIdDivisaNavigation)
                    .WithMany(p => p.CtDenominacion)
                    .HasForeignKey(d => d.FKIdDivisa)
                    .HasConstraintName("FK_ct_divisa_llDivisa");

                entity.HasData(new CtDenominacion { PKIdDenominacion = 1, FKIdDivisa = 1, Descripcion = "Billete 50" });
                entity.HasData(new CtDenominacion { PKIdDenominacion = 2, FKIdDivisa = 2, Descripcion = "Dolar 100" });
            });

            modelBuilder.Entity<CtTipoMovimiento>(entity =>
            {
                entity.HasKey(e => e.PKIdTipoMovimiento);
                entity.ToTable("ctTipoMovimiento");
                entity.Property(e => e.PKIdTipoMovimiento).HasColumnName("llTipoMovimiento");
                entity.Property(e => e.TipoMovimiento).HasColumnName("dsTipoMovimiento");
                entity.HasData(new CtTipoMovimiento { PKIdTipoMovimiento = 1, TipoMovimiento = "Apertura" });
                entity.HasData(new CtTipoMovimiento { PKIdTipoMovimiento = 2, TipoMovimiento = "Cierre" });
            });

            modelBuilder.Entity<TbTurno>(entity =>
            {
                entity.HasKey(e => e.PKIdTurno);
                entity.ToTable("tbTurno");
                entity.Property(e => e.PKIdTurno).HasColumnName("llTurno");
                entity.Property(e => e.IdUsuario).HasColumnName("llUsuario");
                entity.Property(e => e.FechaHoraApertura)
                    .HasColumnName("fcFechaApertura")
                    .HasColumnType("date");
                entity.Property(e => e.FechaHoraCierre)
                    .HasColumnName("fcFechaHoraCierre")
                    .HasColumnType("date");
                entity.Property(e => e.FondoFijo).HasColumnName("dsFondoFijo");
                entity.Property(e => e.FondoVenta).HasColumnName("dsFondoVenta");
                entity.Property(e => e.TotalCierre).HasColumnName("dsTotalCierre");
                entity.Property(e => e.EntregaCompleta)
                   .HasDefaultValue(false);
            });

            modelBuilder.Entity<TbFondo>(entity =>
            {
                entity.HasKey(e => e.PKIdFondo);
                entity.ToTable("tbFondo");
                entity.Property(e => e.PKIdFondo).HasColumnName("llFondo");
                entity.Property(e => e.FKIdTurno).HasColumnName("llTurno");
                entity.Property(e => e.FKIdDenominacion).HasColumnName("llDenominacion");
                entity.Property(e => e.FKIdTipoMovimiento).HasColumnName("llTipoMovimiento");
                entity.Property(e => e.Cantidad).HasColumnName("dsCantidad");

                entity.HasOne(d => d.FKIdTurnoNavigation)
                    .WithMany(p => p.TbFondo)
                    .HasForeignKey(d => d.FKIdTurno)
                    .HasConstraintName("FK_tb_turno_llTurno");

                entity.HasOne(d => d.FKIdDenominacionNavigation)
                    .WithMany(p => p.TbFondo)
                    .HasForeignKey(d => d.FKIdDenominacion)
                    .HasConstraintName("FK_ct_denominacion_llDenominacion");

                entity.HasOne(d => d.FKIdTipoMovimientoNavigation)
                    .WithMany(p => p.TbFondo)
                    .HasForeignKey(d => d.FKIdTipoMovimiento)
                    .HasConstraintName("FK_ct_tipo_movimiento_llTipoMovimiento");
            });

            modelBuilder.Entity<CtUsuario>(entity =>
            {
                entity.HasKey(e => e.PKIdUsuario);
                entity.ToTable("ctUsuario");
                entity.Property(e => e.PKIdUsuario).HasColumnName("llUsuario");
                entity.Property(e => e.Nombre).HasColumnName("dsNombre");
                entity.Property(e => e.ApellidoPaterno).HasColumnName("dsApellidoPaterno");
                entity.Property(e => e.ApellidoMaterno).HasColumnName("dsApellidoMaterno");
                entity.Property(e => e.ClaveUsuario).HasColumnName("dsClaveUsuario");
            });
        }
    }
}
