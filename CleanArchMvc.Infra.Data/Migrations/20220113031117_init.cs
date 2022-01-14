using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<long>(type: "bigint", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Idade", "Name" },
                values: new object[,]
                {
                    { new Guid("17e559a5-adf8-4daa-bb50-97b40bfaf4a2"), 25L, "Maria Ivotete Costa" },
                    { new Guid("268f5aae-0cc4-47fb-8793-ecaf658fffdf"), 39L, "Aderbaldo Oliveira Souza" },
                    { new Guid("46626c40-72ff-42f8-921e-7ffa0c2cea88"), 42L, "Romarildo de Alencar Silveira" },
                    { new Guid("7d56fe8c-5223-4a9a-a962-7ce162aa23b6"), 32L, "Joana da Silva Pereira" },
                    { new Guid("98a64dcb-d599-4201-8a80-82b8cd99e31d"), 15L, "Joao Luz da Silva" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
