﻿// <auto-generated />
using System;
using HomeBankingDV;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeBankingDV.Migrations
{
    [DbContext(typeof(MiContexto))]
    partial class MiContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeBankingDV.CajaDeAhorro", b =>
                {
                    b.Property<int>("idCajaDeAhorro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCajaDeAhorro"));

                    b.Property<int>("cbu")
                        .HasColumnType("int");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.HasKey("idCajaDeAhorro");

                    b.ToTable("CajaAhorro", (string)null);

                    b.HasData(
                        new
                        {
                            idCajaDeAhorro = 1,
                            cbu = 935147312,
                            saldo = 0.0
                        },
                        new
                        {
                            idCajaDeAhorro = 2,
                            cbu = 935147311,
                            saldo = 0.0
                        },
                        new
                        {
                            idCajaDeAhorro = 3,
                            cbu = 935147310,
                            saldo = 0.0
                        },
                        new
                        {
                            idCajaDeAhorro = 4,
                            cbu = 335189011,
                            saldo = 0.0
                        });
                });

            modelBuilder.Entity("HomeBankingDV.Logica.TitularesRel", b =>
                {
                    b.Property<int>("idTi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTi"));

                    b.Property<int>("idCa")
                        .HasColumnType("int");

                    b.Property<int>("idUs")
                        .HasColumnType("int");

                    b.HasKey("idTi");

                    b.HasIndex("idCa");

                    b.HasIndex("idUs");

                    b.ToTable("titulares", (string)null);

                    b.HasData(
                        new
                        {
                            idTi = 1,
                            idCa = 1,
                            idUs = 1
                        },
                        new
                        {
                            idTi = 2,
                            idCa = 2,
                            idUs = 2
                        },
                        new
                        {
                            idTi = 3,
                            idCa = 2,
                            idUs = 3
                        },
                        new
                        {
                            idTi = 4,
                            idCa = 4,
                            idUs = 4
                        });
                });

            modelBuilder.Entity("HomeBankingDV.Movimiento", b =>
                {
                    b.Property<int>("idMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMovimiento"));

                    b.Property<string>("detalle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("DateTime");

                    b.Property<int>("idCaja")
                        .HasColumnType("int");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.HasKey("idMovimiento");

                    b.HasIndex("idCaja");

                    b.ToTable("movimiento", (string)null);
                });

            modelBuilder.Entity("HomeBankingDV.Pago", b =>
                {
                    b.Property<int>("idPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPago"));

                    b.Property<int>("NumUsuario")
                        .HasColumnType("int");

                    b.Property<string>("metodo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.HasKey("idPago");

                    b.HasIndex("NumUsuario");

                    b.ToTable("Pago", (string)null);

                    b.HasData(
                        new
                        {
                            idPago = 1,
                            NumUsuario = 3,
                            metodo = "7F",
                            monto = 8.0,
                            nombre = "200",
                            pagado = false
                        },
                        new
                        {
                            idPago = 2,
                            NumUsuario = 2,
                            metodo = "7F",
                            monto = 8.0,
                            nombre = "310",
                            pagado = false
                        },
                        new
                        {
                            idPago = 3,
                            NumUsuario = 1,
                            metodo = "7F",
                            monto = 8.0,
                            nombre = "420",
                            pagado = true
                        },
                        new
                        {
                            idPago = 4,
                            NumUsuario = 3,
                            metodo = "9F",
                            monto = 9.0,
                            nombre = "530",
                            pagado = true
                        });
                });

            modelBuilder.Entity("HomeBankingDV.PlazoFijo", b =>
                {
                    b.Property<int>("idPlazoFijo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPlazoFijo"));

                    b.Property<int>("NumUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("Date");

                    b.Property<DateTime>("fechaIni")
                        .HasColumnType("Date");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.Property<double>("tasa")
                        .HasColumnType("float");

                    b.HasKey("idPlazoFijo");

                    b.HasIndex("NumUsuario");

                    b.ToTable("PlazoFijo", (string)null);

                    b.HasData(
                        new
                        {
                            idPlazoFijo = 1,
                            NumUsuario = 1,
                            fechaFin = new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fechaIni = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            monto = 200.0,
                            pagado = false,
                            tasa = 7.0
                        },
                        new
                        {
                            idPlazoFijo = 2,
                            NumUsuario = 2,
                            fechaFin = new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fechaIni = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            monto = 310.0,
                            pagado = false,
                            tasa = 7.0
                        },
                        new
                        {
                            idPlazoFijo = 3,
                            NumUsuario = 3,
                            fechaFin = new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fechaIni = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            monto = 420.0,
                            pagado = false,
                            tasa = 7.0
                        },
                        new
                        {
                            idPlazoFijo = 4,
                            NumUsuario = 4,
                            fechaFin = new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            fechaIni = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            monto = 530.0,
                            pagado = false,
                            tasa = 7.0
                        });
                });

            modelBuilder.Entity("HomeBankingDV.TarjetaDeCredito", b =>
                {
                    b.Property<int>("idTarjetaDeCredito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTarjetaDeCredito"));

                    b.Property<int>("NumUsuario")
                        .HasColumnType("int");

                    b.Property<int>("codigoV")
                        .HasColumnType("int");

                    b.Property<double>("consumos")
                        .HasColumnType("float");

                    b.Property<double>("limite")
                        .HasColumnType("float");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("idTarjetaDeCredito");

                    b.HasIndex("NumUsuario");

                    b.ToTable("TarjetaDeCredito", (string)null);

                    b.HasData(
                        new
                        {
                            idTarjetaDeCredito = 1,
                            NumUsuario = 1,
                            codigoV = 2,
                            consumos = 7.0,
                            limite = 8.0,
                            numero = 200
                        },
                        new
                        {
                            idTarjetaDeCredito = 2,
                            NumUsuario = 2,
                            codigoV = 3,
                            consumos = 7.0,
                            limite = 8.0,
                            numero = 310
                        },
                        new
                        {
                            idTarjetaDeCredito = 3,
                            NumUsuario = 3,
                            codigoV = 4,
                            consumos = 7.0,
                            limite = 8.0,
                            numero = 420
                        },
                        new
                        {
                            idTarjetaDeCredito = 4,
                            NumUsuario = 4,
                            codigoV = 5,
                            consumos = 9.0,
                            limite = 9.0,
                            numero = 530
                        });
                });

            modelBuilder.Entity("HomeBankingDV.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("varchar(512)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            idUsuario = 1,
                            apellido = "perez",
                            bloqueado = false,
                            dni = 31859480,
                            isAdmin = true,
                            mail = "jose@jose.com.ar",
                            nombre = "Jose",
                            password = "1234"
                        },
                        new
                        {
                            idUsuario = 2,
                            apellido = "Upalala",
                            bloqueado = false,
                            dni = 31859481,
                            isAdmin = false,
                            mail = "Carlos@Upalala.com.ar",
                            nombre = "Carlos",
                            password = "1234"
                        },
                        new
                        {
                            idUsuario = 3,
                            apellido = "Lagonegro",
                            bloqueado = false,
                            dni = 35147312,
                            isAdmin = true,
                            mail = "111@111",
                            nombre = "adrian",
                            password = "123"
                        },
                        new
                        {
                            idUsuario = 4,
                            apellido = "Eltoga",
                            bloqueado = true,
                            dni = 35147313,
                            isAdmin = true,
                            mail = "222@222",
                            nombre = "Moro",
                            password = "123"
                        });
                });

            modelBuilder.Entity("HomeBankingDV.Logica.TitularesRel", b =>
                {
                    b.HasOne("HomeBankingDV.CajaDeAhorro", "ca")
                        .WithMany("UserCajas")
                        .HasForeignKey("idCa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeBankingDV.Usuario", "us")
                        .WithMany("UserCajas")
                        .HasForeignKey("idUs")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ca");

                    b.Navigation("us");
                });

            modelBuilder.Entity("HomeBankingDV.Movimiento", b =>
                {
                    b.HasOne("HomeBankingDV.CajaDeAhorro", "caja")
                        .WithMany("movimientos")
                        .HasForeignKey("idCaja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("caja");
                });

            modelBuilder.Entity("HomeBankingDV.Pago", b =>
                {
                    b.HasOne("HomeBankingDV.Usuario", "user")
                        .WithMany("pagos")
                        .HasForeignKey("NumUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("HomeBankingDV.PlazoFijo", b =>
                {
                    b.HasOne("HomeBankingDV.Usuario", "titularP")
                        .WithMany("pfs")
                        .HasForeignKey("NumUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("titularP");
                });

            modelBuilder.Entity("HomeBankingDV.TarjetaDeCredito", b =>
                {
                    b.HasOne("HomeBankingDV.Usuario", "titular")
                        .WithMany("tarjetas")
                        .HasForeignKey("NumUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("titular");
                });

            modelBuilder.Entity("HomeBankingDV.CajaDeAhorro", b =>
                {
                    b.Navigation("UserCajas");

                    b.Navigation("movimientos");
                });

            modelBuilder.Entity("HomeBankingDV.Usuario", b =>
                {
                    b.Navigation("UserCajas");

                    b.Navigation("pagos");

                    b.Navigation("pfs");

                    b.Navigation("tarjetas");
                });
#pragma warning restore 612, 618
        }
    }
}
