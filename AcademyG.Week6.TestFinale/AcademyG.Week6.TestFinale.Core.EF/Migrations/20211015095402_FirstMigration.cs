using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyG.Week6.TestFinale.Core.EF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOrdine = table.Column<DateTime>(nullable: false),
                    CodiceOrdine = table.Column<string>(maxLength: 20, nullable: false),
                    CodiceProdotto = table.Column<string>(maxLength: 20, nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.CheckConstraint("CK_Ordine_Importo", "Importo >= 0");
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_CodiceCliente",
                table: "Clienti",
                column: "CodiceCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_ClienteId",
                table: "Ordini",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_CodiceOrdine",
                table: "Ordini",
                column: "CodiceOrdine",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_CodiceProdotto",
                table: "Ordini",
                column: "CodiceProdotto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
