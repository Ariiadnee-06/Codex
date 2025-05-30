using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codex.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstructuraInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDispositivo = table.Column<int>(type: "int", nullable: false),
                    Procesador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneracionCPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoriaRam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaGrafica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneGPUIntegrada = table.Column<bool>(type: "bit", nullable: false),
                    PantallaPulgadas = table.Column<double>(type: "float", nullable: false),
                    ResolucionVertical = table.Column<int>(type: "int", nullable: false),
                    ResolucionHorizontal = table.Column<int>(type: "int", nullable: false),
                    Puertos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conectividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRecomendado = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoUsoAsociado = table.Column<int>(type: "int", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computadoras");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Preguntas");
        }
    }
}
