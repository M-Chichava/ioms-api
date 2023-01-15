using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations.PostGreSSQLMigrations
{
    public partial class StarterEntitiesMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeCostAccounts_Accounts_AccountId",
                table: "AdministrativeCostAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositAccounts_Accounts_AccountId",
                table: "DepositAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisbursementAccounts_Accounts_AccountId",
                table: "DisbursementAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureAccounts_Accounts_AccountId",
                table: "ExpenditureAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_LateInterestAccounts_Accounts_AccountId",
                table: "LateInterestAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_Accounts_AccountId",
                table: "PaymentAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReinforcementAccounts_Accounts_AccountId",
                table: "ReinforcementAccounts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ReinforcementAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ReinforcementAccounts_AccountId",
                table: "ReinforcementAccounts",
                newName: "IX_ReinforcementAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "PaymentAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAccounts_AccountId",
                table: "PaymentAccounts",
                newName: "IX_PaymentAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "LateInterestAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_LateInterestAccounts_AccountId",
                table: "LateInterestAccounts",
                newName: "IX_LateInterestAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ExpenditureAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenditureAccounts_AccountId",
                table: "ExpenditureAccounts",
                newName: "IX_ExpenditureAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "DisbursementAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DisbursementAccounts_AccountId",
                table: "DisbursementAccounts",
                newName: "IX_DisbursementAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "DepositAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DepositAccounts_AccountId",
                table: "DepositAccounts",
                newName: "IX_DepositAccounts_BankAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AdministrativeCostAccounts",
                newName: "BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AdministrativeCostAccounts_AccountId",
                table: "AdministrativeCostAccounts",
                newName: "IX_AdministrativeCostAccounts_BankAccountId");

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeCostAccounts_BankAccount_BankAccountId",
                table: "AdministrativeCostAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositAccounts_BankAccount_BankAccountId",
                table: "DepositAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisbursementAccounts_BankAccount_BankAccountId",
                table: "DisbursementAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureAccounts_BankAccount_BankAccountId",
                table: "ExpenditureAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LateInterestAccounts_BankAccount_BankAccountId",
                table: "LateInterestAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccounts_BankAccount_BankAccountId",
                table: "PaymentAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReinforcementAccounts_BankAccount_BankAccountId",
                table: "ReinforcementAccounts",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministrativeCostAccounts_BankAccount_BankAccountId",
                table: "AdministrativeCostAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositAccounts_BankAccount_BankAccountId",
                table: "DepositAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_DisbursementAccounts_BankAccount_BankAccountId",
                table: "DisbursementAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureAccounts_BankAccount_BankAccountId",
                table: "ExpenditureAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_LateInterestAccounts_BankAccount_BankAccountId",
                table: "LateInterestAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAccounts_BankAccount_BankAccountId",
                table: "PaymentAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReinforcementAccounts_BankAccount_BankAccountId",
                table: "ReinforcementAccounts");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "ReinforcementAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ReinforcementAccounts_BankAccountId",
                table: "ReinforcementAccounts",
                newName: "IX_ReinforcementAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "PaymentAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentAccounts_BankAccountId",
                table: "PaymentAccounts",
                newName: "IX_PaymentAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "LateInterestAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_LateInterestAccounts_BankAccountId",
                table: "LateInterestAccounts",
                newName: "IX_LateInterestAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "ExpenditureAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenditureAccounts_BankAccountId",
                table: "ExpenditureAccounts",
                newName: "IX_ExpenditureAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "DisbursementAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DisbursementAccounts_BankAccountId",
                table: "DisbursementAccounts",
                newName: "IX_DisbursementAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "DepositAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_DepositAccounts_BankAccountId",
                table: "DepositAccounts",
                newName: "IX_DepositAccounts_AccountId");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "AdministrativeCostAccounts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AdministrativeCostAccounts_BankAccountId",
                table: "AdministrativeCostAccounts",
                newName: "IX_AdministrativeCostAccounts_AccountId");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdministrativeCostAccounts_Accounts_AccountId",
                table: "AdministrativeCostAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositAccounts_Accounts_AccountId",
                table: "DepositAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DisbursementAccounts_Accounts_AccountId",
                table: "DisbursementAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureAccounts_Accounts_AccountId",
                table: "ExpenditureAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LateInterestAccounts_Accounts_AccountId",
                table: "LateInterestAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAccounts_Accounts_AccountId",
                table: "PaymentAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReinforcementAccounts_Accounts_AccountId",
                table: "ReinforcementAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
