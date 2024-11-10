using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectCafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Orden",
                table: "Ordenes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Ordenes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Fecha_Orden",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Ordenes");
        }
    }
}
