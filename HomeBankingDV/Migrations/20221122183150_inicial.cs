﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeBankingDV.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CajaAhorro",
                columns: table => new
                {
                    idCajaDeAhorro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cbu = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaAhorro", x => x.idCajaDeAhorro);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    mail = table.Column<string>(type: "varchar(512)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    idMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monto = table.Column<double>(type: "float", nullable: false),
                    idCaja = table.Column<int>(type: "int", nullable: false),
                    detalle = table.Column<string>(type: "varchar(50)", nullable: false),
                    fecha = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.idMovimiento);
                    table.ForeignKey(
                        name: "FK_movimiento_CajaAhorro_idCaja",
                        column: x => x.idCaja,
                        principalTable: "CajaAhorro",
                        principalColumn: "idCajaDeAhorro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlazoFijo",
                columns: table => new
                {
                    idPlazoFijo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fechaIni = table.Column<DateTime>(type: "Date", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    tasa = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlazoFijo", x => x.idPlazoFijo);
                    table.ForeignKey(
                        name: "FK_PlazoFijo_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titulares",
                columns: table => new
                {
                    idTi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCa = table.Column<int>(type: "int", nullable: false),
                    idUs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titulares", x => x.idTi);
                    table.ForeignKey(
                        name: "FK_titulares_CajaAhorro_idCa",
                        column: x => x.idCa,
                        principalTable: "CajaAhorro",
                        principalColumn: "idCajaDeAhorro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_titulares_Usuarios_idUs",
                        column: x => x.idUs,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CajaAhorro",
                columns: new[] { "idCajaDeAhorro", "cbu", "saldo" },
                values: new object[,]
                {
                    { 1, 935147312, 0.0 },
                    { 2, 935147311, 0.0 },
                    { 3, 935147310, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "apellido", "bloqueado", "dni", "isAdmin", "mail", "nombre", "password" },
                values: new object[,]
                {
                    { 1, "perez", false, 31859480, true, "jose@jose.com.ar", "Jose", "1234" },
                    { 2, "Upalala", false, 31859481, false, "Carlos@Upalala.com.ar", "Carlos", "1234" },
                    { 3, "Lagonegro", false, 35147312, true, "111@111", "adriancin", "123" },
                    { 4, "Lagonegro", true, 35147313, true, "222@222", "adrianzon", "123" }
                });

            migrationBuilder.InsertData(
                table: "PlazoFijo",
                columns: new[] { "idPlazoFijo", "fechaFin", "fechaIni", "idUsuario", "monto", "pagado", "tasa" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, false, 7.0 },
                    { 2, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 310.0, false, 7.0 },
                    { 3, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 420.0, false, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "titulares",
                columns: new[] { "idTi", "idCa", "idUs" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_idCaja",
                table: "movimiento",
                column: "idCaja");

            migrationBuilder.CreateIndex(
                name: "IX_PlazoFijo_idUsuario",
                table: "PlazoFijo",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_titulares_idCa",
                table: "titulares",
                column: "idCa");

            migrationBuilder.CreateIndex(
                name: "IX_titulares_idUs",
                table: "titulares",
                column: "idUs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimiento");

            migrationBuilder.DropTable(
                name: "PlazoFijo");

            migrationBuilder.DropTable(
                name: "titulares");

            migrationBuilder.DropTable(
                name: "CajaAhorro");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
