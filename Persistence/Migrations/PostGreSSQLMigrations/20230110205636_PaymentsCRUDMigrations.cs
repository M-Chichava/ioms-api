using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations.PostGreSSQLMigrations
{
    public partial class PaymentsCRUDMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NReinforcement",
                table: "ReinforcementAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReinforcementDate",
                table: "ReinforcementAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPayment",
                table: "PaymentAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentDate",
                table: "PaymentAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LateInterestDate",
                table: "LateInterestAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NLateInterest",
                table: "LateInterestAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpenditureDate",
                table: "ExpenditureAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NExpenditure",
                table: "ExpenditureAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisbursementDate",
                table: "DisbursementAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NDisbursement",
                table: "DisbursementAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepositDate",
                table: "DepositAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NDeposit",
                table: "DepositAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdministrativeCostDate",
                table: "AdministrativeCostAccounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NAdministrativeCost",
                table: "AdministrativeCostAccounts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NReinforcement",
                table: "ReinforcementAccounts");

            migrationBuilder.DropColumn(
                name: "ReinforcementDate",
                table: "ReinforcementAccounts");

            migrationBuilder.DropColumn(
                name: "NPayment",
                table: "PaymentAccounts");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "PaymentAccounts");

            migrationBuilder.DropColumn(
                name: "LateInterestDate",
                table: "LateInterestAccounts");

            migrationBuilder.DropColumn(
                name: "NLateInterest",
                table: "LateInterestAccounts");

            migrationBuilder.DropColumn(
                name: "ExpenditureDate",
                table: "ExpenditureAccounts");

            migrationBuilder.DropColumn(
                name: "NExpenditure",
                table: "ExpenditureAccounts");

            migrationBuilder.DropColumn(
                name: "DisbursementDate",
                table: "DisbursementAccounts");

            migrationBuilder.DropColumn(
                name: "NDisbursement",
                table: "DisbursementAccounts");

            migrationBuilder.DropColumn(
                name: "DepositDate",
                table: "DepositAccounts");

            migrationBuilder.DropColumn(
                name: "NDeposit",
                table: "DepositAccounts");

            migrationBuilder.DropColumn(
                name: "AdministrativeCostDate",
                table: "AdministrativeCostAccounts");

            migrationBuilder.DropColumn(
                name: "NAdministrativeCost",
                table: "AdministrativeCostAccounts");
        }
    }
}
