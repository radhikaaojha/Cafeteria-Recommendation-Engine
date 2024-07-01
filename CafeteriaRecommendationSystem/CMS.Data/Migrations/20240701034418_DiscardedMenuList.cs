using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class DiscardedMenuList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppActivityLog",
                columns: table => new
                {
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppActivityLog", x => x.ActionName);
                });

            migrationBuilder.InsertData(
                table: "FoodItemAvailabilityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Discarded" },
                    { 6, "Removed" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "wFjBAs2TycIyp0YczBePjqnb4bdcZHVqA183EbZ/lcg=", "h0482lqEHWB2XsBC0XibYQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "kYtXoaGSd69AEjjnmm0+cUExK890domuQuui+jDg6GA=", "gMOuyH8MnaGz6THTGqThtA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "f4n2NV7fMPc/b0U4+IG/Wuj1LIBIvjaDOZPaCvu55bk=", "KD3tYTATY8wi5nCC2UtJrA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mRKKBJbxIe09CATLRECbHZg9f03rLpLesn9T5okdkLo=", "URvqTRvzbShWWqLH8NMaxQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "nPrH6EHYnBAJkfrg+QVaI5EelJFdnnwHc/j2D5yfhOg=", "gLGy0Yqgm2Bcpn7Wi54YFQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "XIEv0RhGZ8EzbAMLmGedO15qkQRmXVPE7PW9QxtVewk=", "D8/J38MEXPQ7wvgTFKXV/Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "nsnFeec+euamxC1RnwjnqoPKlWf1xeta+YA+f4QWqzI=", "fnzubQzINBanSmQZR26+8A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "GJaMJo5HnXHlHqtcgsYEhSeDcpu1HinTYe2Bkho7oGM=", "yNbFaoDrOSRuxU/J4um5kg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "WvmI4IQ9/SjX5N/AQZFDRkhJSuO/KGCXJMgdHNunLJc=", "ojoS/bjqhds+SyO9N1vLqA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "kYWN5pyzOAtqkStB1BBcO48wXl1fGccYXjWfa7MpnPU=", "PORGlTIpHz/WyGdCBOKGYQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppActivityLog");

            migrationBuilder.DeleteData(
                table: "FoodItemAvailabilityStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodItemAvailabilityStatus",
                keyColumn: "Id",
                keyValue: 6);

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
    }
}
