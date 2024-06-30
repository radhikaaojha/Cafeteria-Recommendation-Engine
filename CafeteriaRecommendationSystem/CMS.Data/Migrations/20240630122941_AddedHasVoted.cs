using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class AddedHasVoted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasVotedToday",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "2mezete58bz2TRdAZoHwLMocM0qg58SSGwMGIb2sf30=", "uFRuC2zUzUAQ39M0W0Rm5A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "W3UiN9fTFuMCr7yVICSKtPJrZMt2ofStZjV52jKXpVA=", "eUTTOjDw2H0q+1adAKJpdA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Y8zo+y+b1RDVQlnTHkFbtl7/+rhCS6V0fQh30h3MYBU=", "MLXrt8JbSr8UCgMnVBdkIA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ikOB2b3wY7taLNtF8YxT95WBkaZAhNxoqYWhZH1w5fU=", "/Fi1oaYa0giK4K+gbxaHYw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "sSiETLKHrkfJps8+f+aLjR/Y9wR8BQ1Ll8G8W7s2oL0=", "UhgADpvLGraCMB2EkjBhSw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "c+G5tL/DM59DhlPuK3as7YUTGnEG98ZyK+v/4tuD4Z4=", "4kXD8GHYJYdruG7/YjobNg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "usz4AmC5fAsPNLxrOnoJ1Oed8CFkQzPeMB+peyb8/Ic=", "1QmxFQFmbrcfa66OTIn83A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "f54y9NFjTEkYVi9k/SR2/xgTtWpejcNCMwHbV6Xliw4=", "1D3fBXQRkKNRnqT2q77TWw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ovx4488YFHUB1lMHwpI3ZuNyYWKdoKfpxkOXgtP5L7Y=", "wxXG5a+RfDN19eituM+EgQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "MsG8guH8YPE6ZASVa4kwiX3beqeTotWmeGJZO+LcjjA=", "xtLT+i2wikuRjJXIx3YmNA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasVotedToday",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "BfYJXHZtt4M/uQS227cDAZjh6RILbLRucok68rbxHTY=", "fGCU+5GXXKlokYtHIlH9yA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Rfpc06PGKE6EjH6jxtQ3biN1B0cp5RONbuZZoSjXbYM=", "TsrBIyKGOHEWt2QDY1WO1w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "GiFNuWQtryCgLd2RR1WSMl/rLR3IorC5hHxzpOlIsBA=", "bRuCtCosfut1a76wPzOgdg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "OIp1mwNHR2ZTmT+7dRZ0qy1dDAZX6Oewt0zYsXlaFLo=", "9ZdIfZk+LHIS2U2sL1XsYQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Og9NthcojDMVa6j+Upt5F/lcJR0UdSEqDD37/Nz+CsA=", "SQx4qOtPnvwpCnpMe21zmw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "a4ysRcxGNyew8ih6kdXdb1EoV+c+waw2rhBVnBzvRNg=", "VYHVT4QSl1lrBMU0RHhPyA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5csoer9HZELAV4bgVmAl3iClk4eLsDsLytwJ6AC6xOI=", "8Av1MLUjR84iUH/ypDPl1w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "u8auSQXWa01yDiuhLFHqZzSsqcuPDlrMNxxWXuG+syk=", "KUguT8YvpK2rAGw9+WsSPg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mSujXuorr5G+QSG4NxKt6atzmS9owThrPCLtLGG5geU=", "dEs55lWb/s+BIcOPUngxMw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "C9chY1WeYydaZq/I/JVSvwzbPpHGMVg2Y8LNhPjmtXI=", "SUQSuZb7eii9gcs7eZecNg==" });
        }
    }
}
