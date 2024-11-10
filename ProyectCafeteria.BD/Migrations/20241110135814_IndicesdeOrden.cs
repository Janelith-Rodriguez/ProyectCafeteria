using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectCafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class IndicesdeOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Ordenes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Orden_Total_Estado",
                table: "Ordenes",
                columns: new[] { "Total", "Estado" });

            migrationBuilder.CreateIndex(
                name: "Orden_UQ",
                table: "Ordenes",
                columns: new[] { "UsuarioId", "Fecha_Orden" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Orden_Total_Estado",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "Orden_UQ",
                table: "Ordenes");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId");
        }
    }
}
