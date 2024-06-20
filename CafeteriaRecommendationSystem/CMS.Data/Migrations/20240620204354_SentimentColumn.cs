using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class SentimentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodItem",
                type: "varchar(200)",
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
                values: new object[] { "eYTiNwG9FJY6Xhhle6bKiWWxVkTHtBUmC3NoyJJgcOA=", "OuD6yNagyk5m/Y9p0c7HKg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "/rADvVlLUvUpUGuPSAg9Sm7c6ld+C7/SFb16kO0j/fk=", "oqocVNItMkkyG7RH60THOQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "M9sWP+yXBME/nEHAzzSi6I3Wiq8qy0pB9EWrOTonE60=", "0rwU6MpsgI9SWtNvboicUA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "9c+VTJkzSI0yLhbUQfjlaP1ZOGv14XjJNIlKpgp0bCo=", "4D9MJoDl/6atOFo7A6qCYg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "r/UlXA4IL1dOMicF/QLnU4Mp2QTdmNW8BFxn1PpcWHw=", "ulcWz8x+zabdpKr1G92XuA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "17uymNtAbOWPCvV1adFvccnoLFMkv3nnFFSW3gcf5x0=", "cJ4RtImpHIedYUj+89BudA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "jUgfAXN6HnQbBwbMrcazlclgf7O1EylnsxHKyrHNJ3g=", "Et0wMnXdk584tKT9+5Jhjg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "w/voO+/XZlgxIKGpDn/gqrC5Lfw5G0+VlNGn4QN58lQ=", "bCOuecbf/UmAr7uuA0FgXA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "weDqMjBylCYxMdWtf2nCmmy48WhwmE+bqr2lY8S5wqI=", "M8n347xqiX/XfWFxCB4Rgg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "4CfuYM07BbfGKQORggjseYB/oh0z7zlgI/oqzeZNRuE=", "zocDTimyS8Cdtu5dIuxV/w==" });
        }
    }
}
