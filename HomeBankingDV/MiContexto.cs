using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HomeBankingDV.Logica;
using Microsoft.EntityFrameworkCore;

namespace HomeBankingDV
{
    class MiContexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<CajaDeAhorro> cajaDeAhorros { get; set; }

        public DbSet<PlazoFijo> plazoFijos { get; set; }

        public DbSet<TarjetaDeCredito> tarjetaDeCredito { get; set; }

        public DbSet<Pago> pago { get; set; }

        public DbSet<Movimiento> movimientos { get; set; }

        public DbSet<TitularesRel> titulares { get; set; }

       
        public MiContexto() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // creacion de las tablas :
            modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(u => u.idUsuario);
            modelBuilder.Entity<Usuario>(
            user =>
            {
                user.Property(u => u.dni).HasColumnType("int");
                user.Property(u => u.dni).IsRequired(true);
                user.Property(u => u.nombre).HasColumnType("varchar(50)");
                user.Property(u => u.apellido).HasColumnType("varchar(50)");
                user.Property(u => u.mail).HasColumnType("varchar(512)");
                user.Property(u => u.password).HasColumnType("varchar(50)");
                user.Property(u => u.isAdmin).HasColumnType("bit");
                user.Property(u => u.bloqueado).HasColumnType("bit");



            });
            modelBuilder.Entity<CajaDeAhorro>().ToTable("CajaAhorro").HasKey(c => c.idCajaDeAhorro);
            modelBuilder.Entity<CajaDeAhorro>(
                cajaAhorro =>
                {
                    cajaAhorro.Property(c => c.cbu).HasColumnType("int");
                    cajaAhorro.Property(c => c.saldo).HasColumnType("float");
           
                });
            modelBuilder.Entity<PlazoFijo>().ToTable("PlazoFijo").HasKey(p => p.idPlazoFijo);
            modelBuilder.Entity<PlazoFijo>(
                plazoFijo =>
                {
                    plazoFijo.Property(p => p.NumUsuario).HasColumnType("int");
                    plazoFijo.Property(p => p.monto).HasColumnType("float");
                    plazoFijo.Property(p => p.fechaIni).HasColumnType("Date");
                    plazoFijo.Property(p => p.fechaFin).HasColumnType("Date");
                    plazoFijo.Property(p => p.tasa).HasColumnType("float");
                    plazoFijo.Property(p => p.pagado).HasColumnType("bit");
                });

            modelBuilder.Entity<TarjetaDeCredito>().ToTable("TarjetaDeCredito").HasKey(t => t.idTarjetaDeCredito);
            modelBuilder.Entity<TarjetaDeCredito>(
                tarjetaDeCredito =>
                {
                    tarjetaDeCredito.Property(t => t.NumUsuario).HasColumnType("int");
                    tarjetaDeCredito.Property(t => t.numero).HasColumnType("int");
                    tarjetaDeCredito.Property(t => t.codigoV).HasColumnType("int");
                    tarjetaDeCredito.Property(t => t.limite).HasColumnType("float");
                    tarjetaDeCredito.Property(t => t.consumos).HasColumnType("float");
                });

            modelBuilder.Entity<Pago>().ToTable("Pago").HasKey(p => p.idPago);
            modelBuilder.Entity<Pago>(
            pago =>
            {
            pago.Property(t => t.NumUsuario).HasColumnType("int");
            pago.Property(p => p.nombre).HasColumnType("varchar(50)");
            pago.Property(p => p.monto).HasColumnType("float");
            pago.Property(p => p.pagado).HasColumnType("bit");
            pago.Property(p => p.metodo).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Movimiento>().ToTable("movimiento").HasKey(m => m.idMovimiento);
            modelBuilder.Entity<Movimiento>(
                movimiento =>
                {
                    movimiento.Property(m => m.monto).HasColumnType("float");
                    movimiento.Property(m => m.idCaja).HasColumnType("int");
                    movimiento.Property(m => m.detalle).HasColumnType("varchar(50)");
                    movimiento.Property(m => m.fecha).HasColumnType("DateTime");

                });

            modelBuilder.Entity<TitularesRel>().ToTable("titulares").HasKey(t => t.idTi);
            modelBuilder.Entity<TitularesRel>(
                titulares =>
                {
                    titulares.Property(t => t.idCa).HasColumnType("int");
                    titulares.Property(t => t.idUs).HasColumnType("int");
                });

    


            // asignacion de las relaciones :
            // definicion de relacion muchos a muchos Usuario-titulares usando tabla intermedia TitularesRel

            modelBuilder.Entity<Usuario>().HasMany(u => u.cajas).WithMany(p => p.titulares).UsingEntity<TitularesRel>(
                eti => eti.HasOne(up => up.ca).WithMany(p => p.UserCajas).HasForeignKey(u => u.idCa),
                eti => eti.HasOne(up => up.us).WithMany(u => u.UserCajas).HasForeignKey(u => u.idUs),
                eti => eti.HasKey(k => k.idTi)
                );
            // definicion de relacion uno a muchos Usuario-plazoFijo :

            modelBuilder.Entity<PlazoFijo>().HasOne(d => d.titularP).WithMany(u => u.pfs).HasForeignKey(d => d.NumUsuario).OnDelete(DeleteBehavior.Cascade);

            // definicion de relacion uno a muchos cajaDeAhorro-movimientos :

            modelBuilder.Entity<Movimiento>().HasOne(m => m.caja).WithMany(u => u.movimientos).HasForeignKey(d => d.idCaja).OnDelete(DeleteBehavior.Cascade);

            // definicion de relacion uno a muchos tarjetaDeCredito-Usuario:

           
            modelBuilder.Entity<TarjetaDeCredito>().HasOne(m => m.titular).WithMany(t => t.tarjetas).HasForeignKey(d => d.NumUsuario);
           


            // definicion de relacion uno a uno pago-tarjeta

              //modelBuilder.Entity<TarjetaDeCredito>().HasOne(U => U.pago).WithOne(D => D.tarjeta).HasForeignKey<Pago>(D => D.idPago).OnDelete(DeleteBehavior.Cascade);
             
            //modelBuilder.Entity<Pago>().HasOne(D => D.user).WithOne(U => U.).HasForeignKey<Pago>(D => D.idPago).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pago>()     .HasOne(d => d.user)    .WithMany(u => u.pagos).HasForeignKey(d => d.NumUsuario).OnDelete(DeleteBehavior.Cascade);
           


            // definicion de relacion uno a muchos usuario-pago

            //modelBuilder.Entity<Pago>().HasOne(m => m.user).WithMany(t => t.pagos).HasForeignKey(d => d.idPago).OnDelete(DeleteBehavior.NoAction);

            // ingreso de datos :

            modelBuilder.Entity<Usuario>().HasData(
                new { idUsuario = 1, dni = 31859480, nombre = "Jose", apellido = "perez", mail = "jose@jose.com.ar", password = "1234", isAdmin = true, bloqueado = false },
                new { idUsuario = 2, dni = 31859481, nombre = "Carlos", apellido = "Upalala", mail = "Carlos@Upalala.com.ar", password = "1234", isAdmin = false, bloqueado = false },
                new { idUsuario = 3, dni = 35147312, nombre = "adrian", apellido = "Lagonegro", mail = "111@111", password = "123", isAdmin = true, bloqueado = false },
                new { idUsuario = 4, dni = 35147313, nombre = "Moro", apellido = "Eltoga", mail = "222@222", password = "123", isAdmin = true, bloqueado = true }
                );

            modelBuilder.Entity<CajaDeAhorro>().HasData(
                new { idCajaDeAhorro = 1, cbu = 935147312, saldo = 0F },
                new { idCajaDeAhorro = 2, cbu = 935147311, saldo = 0F },
                new { idCajaDeAhorro = 3, cbu = 935147310, saldo = 0F },
                new { idCajaDeAhorro = 4, cbu = 335189011, saldo = 0F });

            modelBuilder.Entity<TitularesRel>().HasData(
                new { idTi = 1, idCa = 1, idUs = 1 }, 
                new { idTi = 2, idCa = 2, idUs = 2 }, 
                new { idTi = 3, idCa = 2, idUs = 3 },
                new { idTi = 4, idCa = 4, idUs = 4 }
                );

            modelBuilder.Entity<PlazoFijo>().HasData(
                new { idPlazoFijo = 1, NumUsuario = 1, monto = 200F, fechaIni = new DateTime().Date, fechaFin = new DateTime().Date.AddMonths(8), tasa = 7F, pagado = false },
                new { idPlazoFijo = 2, NumUsuario = 2, monto = 310F, fechaIni = new DateTime().Date, fechaFin = new DateTime().Date.AddMonths(8), tasa = 7F, pagado = false },
                new { idPlazoFijo = 3, NumUsuario = 3, monto = 420F, fechaIni = new DateTime().Date, fechaFin = new DateTime().Date.AddMonths(8), tasa = 7F, pagado = false },
                new { idPlazoFijo = 4, NumUsuario = 4, monto = 530F, fechaIni = new DateTime().Date, fechaFin = new DateTime().Date.AddMonths(8), tasa = 7F, pagado = false });

            modelBuilder.Entity<TarjetaDeCredito>().HasData(
                new { idTarjetaDeCredito = 1, NumUsuario = 1, numero = 200, codigoV = 2, limite = 8F, consumos = 7F},
                new { idTarjetaDeCredito = 2, NumUsuario = 2, numero = 310, codigoV = 3, limite = 8F, consumos = 7F},
                new { idTarjetaDeCredito = 3, NumUsuario = 3, numero = 420, codigoV = 4, limite = 8F, consumos = 7F},
                new { idTarjetaDeCredito = 4, NumUsuario = 4, numero = 530, codigoV = 5, limite = 9F, consumos = 9F});




            // ignoramos la clase Banco para que no genere la tabla.
            modelBuilder.Ignore<Banco>();
          
        }



    }
}
