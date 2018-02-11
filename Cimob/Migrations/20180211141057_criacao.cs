using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cimob.Migrations
{
    public partial class criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraDia",
                table: "Entrevista",
                newName: "Hora");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Entrevista",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Entrevista");

            migrationBuilder.RenameColumn(
                name: "Hora",
                table: "Entrevista",
                newName: "HoraDia");
        }
    }
}
