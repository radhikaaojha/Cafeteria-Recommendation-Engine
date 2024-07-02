using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class SeedDataForFoodCharacterstic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "UserPreference",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "FoodItem",
                columns: new[] { "Id", "Description", "FoodItemTypeId", "Name", "Price", "SentimentScore", "StatusId" },
                values: new object[,]
                {
                    { 31, "", 5, "Lotus Biscoff Pastry", 80m, 0m, 2 },
                    { 32, "", 5, "Tiramisu", 90m, 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "FoodItemCharacteristic",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vegetarian" },
                    { 2, "Non Vegetarian" },
                    { 3, "Eggetarian" },
                    { 4, "High Spicy" },
                    { 5, "Medium Spicy" },
                    { 6, "Low Spicy" },
                    { 7, "North Indian Cuisine" },
                    { 8, "South Indian Cuisine" },
                    { 9, "Other Cuisine" },
                    { 10, "Not a sweet tooth" },
                    { 11, "Sweet tooth" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "aN5SsS8yP1l+8rsIi92WVynE/37xVWWcHCWz1SWEJmI=", "gyhviKz+ZjEFYri282cuug==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "jf3BWc1DIOD8esKu5cHRPbO8DOaLMgy+4azCA9dbsEc=", "9nshvKcSOfRvDUyOtpKjJA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "d/tHYi//B0WyD/ftcyPHzu6Qjrwt20GwKiYbdO7bSeA=", "HQnKFpr/6SZ2YBOiHA15tg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ZbqTSOkOA9oF2zVJMpfmvRDds4Gyl/wyyOrfdN4Ze1I=", "LnaujqluKETpTbrcyNiIvQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "K9eHBjTVJk1QU7c+SWcstqyUQOaXulk98ts81Q/mSZU=", "LvcgRnZIYxRSwLJvakcKsQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "bm6M7pIUL0ryrYJB95xaxEnD6vuxyuTXG6jDB7Jo5GM=", "OMX7vQNXC0lE8H3+8Pw/CA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "TiS/Lz++brcsbVwQQGK5850bc9lshOfMW6m0NoFW7E8=", "hrzwePRtzV/7S5ikU6dPog==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "rcQS2SiyQX2kM0vjoUrgTBZZDlQuvRmAuc7uMwkRbbI=", "EvPszER0Ko/wAjdgXukqEg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "L7slSjATxTH0XFb8AbuRriEnLnk0JdB7mvkfBw6N7PU=", "hBPJN/QDTYXB6oBYR6VSBA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ZPDPFL0kN8FUn/RjOJjbo9kSTDhR1KxGN8mUTvjw9wQ=", "2XIML4B7lAFlbbrQGJRR/A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItemCharacteristic",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "UserPreference");

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
        }
    }
}
