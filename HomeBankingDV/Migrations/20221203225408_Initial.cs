using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeBankingDV.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "Pago",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumUsuario = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    metodo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.idPago);
                    table.ForeignKey(
                        name: "FK_Pago_Usuarios_NumUsuario",
                        column: x => x.NumUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlazoFijo",
                columns: table => new
                {
                    idPlazoFijo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumUsuario = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_PlazoFijo_Usuarios_NumUsuario",
                        column: x => x.NumUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaDeCredito",
                columns: table => new
                {
                    idTarjetaDeCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumUsuario = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    codigoV = table.Column<int>(type: "int", nullable: false),
                    limite = table.Column<double>(type: "float", nullable: false),
                    consumos = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaDeCredito", x => x.idTarjetaDeCredito);
                    table.ForeignKey(
                        name: "FK_TarjetaDeCredito_Usuarios_NumUsuario",
                        column: x => x.NumUsuario,
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
                    { 3, 935147310, 0.0 },
                    { 4, 335189011, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "apellido", "bloqueado", "dni", "isAdmin", "mail", "nombre", "password" },
                values: new object[,]
                {
                    { 1, "perez", false, 31859480, true, "jose@jose.com.ar", "Jose", "1234" },
                    { 2, "Upalala", false, 31859481, false, "Carlos@Upalala.com.ar", "Carlos", "1234" },
                    { 3, "Lagonegro", false, 35147312, true, "111@111", "adrian", "123" },
                    { 4, "Eltoga", true, 35147313, true, "222@222", "Moro", "123" }
                });

            migrationBuilder.InsertData(
                table: "Pago",
                columns: new[] { "idPago", "NumUsuario", "metodo", "monto", "nombre", "pagado" },
                values: new object[,]
                {
                    { 1, 3, "7F", 8.0, "200", false },
                    { 2, 2, "7F", 8.0, "310", false },
                    { 3, 1, "7F", 8.0, "420", true },
                    { 4, 3, "9F", 9.0, "530", true }
                });

            migrationBuilder.InsertData(
                table: "PlazoFijo",
                columns: new[] { "idPlazoFijo", "NumUsuario", "fechaFin", "fechaIni", "monto", "pagado", "tasa" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, false, 7.0 },
                    { 2, 2, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 310.0, false, 7.0 },
                    { 3, 3, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 420.0, false, 7.0 },
                    { 4, 4, new DateTime(1, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 530.0, false, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "TarjetaDeCredito",
                columns: new[] { "idTarjetaDeCredito", "NumUsuario", "codigoV", "consumos", "limite", "numero" },
                values: new object[,]
                {
                    { 1, 1, 2, 7.0, 8.0, 200 },
                    { 2, 2, 3, 7.0, 8.0, 310 },
                    { 3, 3, 4, 7.0, 8.0, 420 },
                    { 4, 4, 5, 9.0, 9.0, 530 }
                });

            migrationBuilder.InsertData(
                table: "titulares",
                columns: new[] { "idTi", "idCa", "idUs" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_idCaja",
                table: "movimiento",
                column: "idCaja");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_NumUsuario",
                table: "Pago",
                column: "NumUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PlazoFijo_NumUsuario",
                table: "PlazoFijo",
                column: "NumUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaDeCredito_NumUsuario",
                table: "TarjetaDeCredito",
                column: "NumUsuario");

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
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PlazoFijo");

            migrationBuilder.DropTable(
                name: "TarjetaDeCredito");

            migrationBuilder.DropTable(
                name: "titulares");

            migrationBuilder.DropTable(
                name: "CajaAhorro");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
