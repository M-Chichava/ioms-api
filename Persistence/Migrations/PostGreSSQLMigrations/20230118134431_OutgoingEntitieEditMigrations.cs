using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations.PostGreSSQLMigrations
{
    public partial class OutgoingEntitieEditMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outgoings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outgoings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOutgoing = table.Column<string>(type: "text", nullable: true),
                    OutgoingDate = table.Column<string>(type: "text", nullable: true),
                    OutgoingId = table.Column<int>(type: "integer", nullable: true),
                    BankAccountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingAccounts_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutgoingAccounts_Outgoings_OutgoingId",
                        column: x => x.OutgoingId,
                        principalTable: "Outgoings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingAccounts_BankAccountId",
                table: "OutgoingAccounts",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingAccounts_OutgoingId",
                table: "OutgoingAccounts",
                column: "OutgoingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutgoingAccounts");

            migrationBuilder.DropTable(
                name: "Outgoings");
        }
    }
}
