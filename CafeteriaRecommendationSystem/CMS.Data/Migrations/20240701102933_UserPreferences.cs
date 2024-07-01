using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class UserPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemCharacteristic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemCharacteristic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemCharactersticMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemCharactersticMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItemCharactersticMapping_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemCharactersticMapping_FoodItemCharacteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "FoodItemCharacteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPreference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreference_FoodItemCharacteristic_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "FoodItemCharacteristic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPreference_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SbVPXdMw6sDVfX/iszw9wC7P5hVMiML4dPs5LONtn3E=", "AN70Fee2maYsQdGspeSxwQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "QiN1SNCmXRUI2hfY747c0UddZ5GIG+Xk91BkxSe6J5o=", "4AFOl6+qW+iyrH0LqWmXXw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "xZA+Ij3bDpR38lQYVKrrSRzSvAStogdPHkdtzKVC2nc=", "eIowfVexYTwchbWdK5NenQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mpagDcULR7VyQaqjTlitf/HT9Jf6ipFQk0HwLdJkbHY=", "FPnIZrdKnCFxaT+gPPfRiQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "+TOT/XJV1g3Pi84RcymExv9pf2A2FKjpoOgYSZBD2v0=", "zS049yTs4lA4KeT64azZrw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "JNTSOsbOWz+XQM5jJcZMc5DrU9Q96OoLJteNBN1Mp3k=", "CVmVEvMKPWcHTELPALqFOg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "YIN2KDiHAVG9JSD03PvZvvY07eGoNppz7uIsGB0ZDLM=", "yYQArWEBKEh9ro0fynGBXQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "dxEq7YwHkQSyf84h/BlVHVbE+Asvb9UpyzwBnzXUflw=", "C9ZhdZbrXG2Boawq8f/1gA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "LGEGkov0dY/1ejB+bu3UQAe8GJTy0+fUHUPHOm9hGYI=", "sF/nKKv2oq/7OvjA6vWkig==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "FGGKMtkyEHdB45f+XbdLy4MsVL8Godhv8UW9j1agMYQ=", "ngjhPq2ejwwlCZaIoWa3mg==" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemCharactersticMapping_CharacteristicId",
                table: "FoodItemCharactersticMapping",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemCharactersticMapping_FoodItemId",
                table: "FoodItemCharactersticMapping",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_CharacteristicId",
                table: "UserPreference",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreference_UserId",
                table: "UserPreference",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemCharactersticMapping");

            migrationBuilder.DropTable(
                name: "UserPreference");

            migrationBuilder.DropTable(
                name: "FoodItemCharacteristic");

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
        }
    }
}
