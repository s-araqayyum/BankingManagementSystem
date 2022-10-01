using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prime_Financial_Holdings.Migrations
{
    public partial class sozmozhoz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    registeredName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    contactNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.registeredName);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    accountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "12121, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    balance = table.Column<float>(type: "real", nullable: false),
                    requestedCheckbook = table.Column<bool>(type: "bit", nullable: false),
                    LoanID = table.Column<int>(type: "int", nullable: true),
                    loanAmount = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.accountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    billReferenceNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    billAmount = table.Column<float>(type: "real", nullable: false),
                    paidby = table.Column<int>(type: "int", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.billReferenceNumber);
                    table.ForeignKey(
                        name: "FK_Bills_Accounts_paidby",
                        column: x => x.paidby,
                        principalTable: "Accounts",
                        principalColumn: "accountNumber");
                    table.ForeignKey(
                        name: "FK_Bills_Companies_companyName",
                        column: x => x.companyName,
                        principalTable: "Companies",
                        principalColumn: "registeredName");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TRX_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountNumber = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<float>(type: "real", nullable: false),
                    beneficiaryAccount = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TRX_ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_accountNumber",
                        column: x => x.accountNumber,
                        principalTable: "Accounts",
                        principalColumn: "accountNumber");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_beneficiaryAccount",
                        column: x => x.beneficiaryAccount,
                        principalTable: "Accounts",
                        principalColumn: "accountNumber");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "accountNumber");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    feedbackMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_userName",
                        column: x => x.userName,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LoanID",
                table: "Accounts",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_companyName",
                table: "Bills",
                column: "companyName");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_paidby",
                table: "Bills",
                column: "paidby");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_userName",
                table: "Feedbacks",
                column: "userName");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_accountNumber",
                table: "Transactions",
                column: "accountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_beneficiaryAccount",
                table: "Transactions",
                column: "beneficiaryAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountNumber",
                table: "Users",
                column: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
