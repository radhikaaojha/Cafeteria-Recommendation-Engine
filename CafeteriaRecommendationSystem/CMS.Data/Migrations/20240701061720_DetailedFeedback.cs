using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class DetailedFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailedFoodItemFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedFoodItemFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedFoodItemFeedback_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedFoodItemFeedback_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "DetailedFeedback" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "eKk2ImDDwtMZKgz1eE7W5n8B1Z+s2zz+0hAGHHDbOVM=", "t5LNtxy+EHJ4QnogCvR1Sg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "IF1e3YyYWWJxHuG3i/cacWn1G/8YGY4wXkfaePzlxT0=", "2SBNak6kMWMx98Ss38wl+w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "JxenBTGHvdUEWd2Kg6mIfuE1yp2kk1OFdp2brru7IKE=", "48RSIpD9Tg4xYlCGH3iPcA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "GzNN+Ub+boP1xA+TSf0RuTgL5ZUx8ep/pBpes+a6WsY=", "X4D6DhV4PvAfAfUomt8XUg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "hgQsQyOSvEIk2Sc+2LRYSbRd1/3gA1Wa7ywbhBc+H18=", "QXB4p/pVkrXo19UJqlMYkw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "JOlTmD/9Q/0WjAuyxoE/53trpCmbx09gM7eVAHLGB/A=", "NEUHTX+b0qYVpqhnwbfR4Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "WWfz8rqV6WjYQdhIgAtHD5rsEt4LAOlrpe0/QOgUmxQ=", "xPCmMtNgkH7I7Hc3Ar+nwA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "fQjKRI657xGiS57txP4l8Bay3X8vDlZpI0+pkMWe9/I=", "LEXfORcWclIBnV8ESyAcCQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Z9IkM+2g5fO3mTxMZBTSU4qogYtalFCOoDe9xx/Fpps=", "ecu6QbD5DcNfl58aAdvzgQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "gUtiwKyLNu1Xe+2p+iVHCfDsHxGdcu5Km9zHC9FVptU=", "pst+XYlTOPuxFZgDNLDYJQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_DetailedFoodItemFeedback_FoodItemId",
                table: "DetailedFoodItemFeedback",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedFoodItemFeedback_UserId",
                table: "DetailedFoodItemFeedback",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailedFoodItemFeedback");

            migrationBuilder.DeleteData(
                table: "NotificationType",
                keyColumn: "Id",
                keyValue: 7);

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
    }
}
