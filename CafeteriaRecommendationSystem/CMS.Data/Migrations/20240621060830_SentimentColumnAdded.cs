using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class SentimentColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodItem",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SentimentScore",
                table: "FoodItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "c1Zt9Ij+sikId7QofYXG/+opIVhhgndRSCQ/fwqCq44=", "MECbhUEf+TBjAUkEcvD1dg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "43yPmmQ2jeBBTnfW9Fz9b06Atj9YhuqtZgWsX6lLAPs=", "5286udjQPlGbS8z3C6b0PA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Pc082kLN+nrg2XiLOS7MqAIXwQcDu0XAF+nf/WCMe3g=", "SUBqQXY6Kn5ZAAu0fKbKfg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "khlqINfGz44orynDyzgSJY/FCkV3PwS42X9Hen6HBwY=", "VQWh1pbixxpE82HsRAthdQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "6zlxYwI2n+wswV4Oh04ARQsUiggZO4shNASouu9PVBk=", "KpoFRUKmI9cZLaa7h0o7Gw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ANssCwq+KV9tge6OCnUtYa/u9Oql7qT2RzouytXD9e0=", "bWQv1SEJU+i7iJhbqt3Nrw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "IPz3Z54kwhqhg1FtUvhz9B45oU010Cg0KtD8c0qFugA=", "MXCZYwMuXuAQWmPENb6Qxw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "bZNj9w0JE3zWjcZOcZ7lPR6V1NtKXJYD/7fqilYZK18=", "gz2pdUp9rHMut/KQPxZyDA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1EqAL4HXIWxUV88KVxu/Y9tLDe90xPOPPeIvWUk7nAo=", "I5YJYPamP4sRoPP58eXEPQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "TT4ict7pkKEpBtkdYp02RsgDWVYcDq6bKI0MMBFVi2c=", "pNSssqXuxwFAxYCltQAnZg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "SentimentScore",
                table: "FoodItem");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "g3350b+q9zNXxyWIb4ohRZj5ZI5jeGNRhSY02Oytp4M=", "xj6VDvkGu8V1kSsoUOKHFQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1fNTnTXfY3OaSLYqdrYrCHyS1I7OwM2DFe9pI99E/So=", "nCHFVpRnSPwswcAYZkhANQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "RiIz15/i7U/trPUCYJEJLRPqVgRWKIMhp+0RXRTBhco=", "Ry1tFcG7d4IQzmwqEx4ZoA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "VeT1PcpijOQyuXVw4UCzGCcSPfUfEV4oash5h8yi1lg=", "B5JUbDBR/zgUFmq11Xv8+Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "KjI0OzVcyy160Y7Uk1thk88tck2TLL5M+yepDsfIl3k=", "wFqnf9rOHcx1yV67zaILCg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "G52doBo5FNyC28xvl3qdXwRydBzuwP6/aN5nM4hn3gc=", "VWnJIAmCO0pEFcUoMBFnFg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mvlY9KuIEgYLHJ1gDmxhuOp4nC0UCFBtzpXN4DFIvEM=", "4YEZjYvFqbn5lduLujzERw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "9L8rcAoqISGpk4N/NGKRMc6+DcKyTvxkjdQWzV0nGkk=", "abPfuU1TGdtkvyeKLBW+7A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "/6cQUZZ4xNYQBKbcF9iGm/i2HO/FFi0e7umrQHl8RzY=", "sA6wZTk8oHgU1SNLxzWK7Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "vRTualSSQ7rhR3J6C6mJMV3pcr59AdWach0F+7LNzi4=", "A6pXniK7x8587X/lElRJVg==" });
        }
    }
}
