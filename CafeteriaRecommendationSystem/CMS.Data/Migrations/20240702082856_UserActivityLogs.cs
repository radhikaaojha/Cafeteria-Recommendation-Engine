using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class UserActivityLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserActivityLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityLog", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "U/d9KKq9Q/4NIj9oEtW1zNGHs4vwsGkf/+lAnYrmB3Q=", "6K6rPDutIWxdE7XB4xYZtg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "VN5qmm1hknQJmSIRbyVEyo3DOn/xjyKly+DNLpN/52w=", "ouvuH8os3AePFiEYe/L+zg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "31+bvbg+WeJ3sZPCRQTPxNfO67VvoWBVmetH/rep5mo=", "y4z0MYNCqU0QbQCxyRQLig==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "FbuDoxH4QZb7wf9i8O1V8Jcpu8SfWr4ZIokls8XCm6w=", "YWI428yByb5q5kx3V8X5OQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "VAh39hC8S/UnvtjTdtYbkAf2rfbJuaFLUddLDlv81gI=", "si+pG4FLDwY3cuywsRTGZA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "lS2zYe8QjHwVYIouETzt4ZBHlx8T/JK/84xb6JaShg8=", "R9DlsH79YQgQjP//nrYZgQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "AfJ3yx4Tc6CoP21bVxWF+7llrP6BTLVBZc2ilaO9c50=", "SQgDe2P1/yHjXHZNEv6H2g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "VKiUIxmZanR7ZS68gSdmN+pWAV1yBfpCzIjXlGGCTzk=", "YWYX3m2ZyOKlDX2Pb5vEeg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "lvFs09cKgp0jjDC5e2GUAmESqDAh1MffaQlrtLetlTU=", "8x/wjlZ8NEfsONHR7P04yg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "4v5SRgiFNGAZPyfOxKZAddYQFvM18cmpfd1J3MQr+fA=", "NKCcRrKpIlaW1CFK8ZUNfg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivityLog");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "eA0VtkMS0EzSRIdufQW5xvmCx6MyKQsrn7doNjnD5QQ=", "8BDUZ7C5QiLrZSwgIf2POg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "MAWBhwK5cwVEEBF7yJS4nuMvo5YUjCt+l5kqKUuYKeo=", "EuD6MIE7rvzkuE+N47krSQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mn5bRm49ipfLtSoLSLzIz40nHGh6nRS2rmCWEfdE6WM=", "6VUcYI/1bIBjCHiTOQIlJA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "dS0O3+lCjYkr96ROia3d+Z7pWzbpeZg3b25L2KVv3Og=", "xJqEZ6kXB5wOtCzfXFt3lA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5LyaPUcJdl4gEqnkPuzOBMuy2XA7IIpkdmjp9+9t9iQ=", "tojSu1k4pSd5eTOo2BHGUA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "9XWF4nYmNl45rXDHK267fKpDnJogmsYzBo99tWHRND4=", "VzyjFqlyfeN8tJ1CX0Nw0Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "grm78CTLtLN/rlrFoZp5Zashh9QxtO29sW4Kh7oTsbU=", "0XCxJRlb2tJXpxoA0KQbSQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "6Z56R09CEnoQjFwOEbjViDgggV5BJbOGzfL7aIoz3mg=", "V4Up8fE41GnfU05Z6Wod7w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "N782mD//l1gd0TJFnWoifKqrSMJPi4WvhCkC0awjSS8=", "6O7XzEbPnV/e8PE4HIqYLw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "CuJPcRBcEBw/WSbYdpuUMi0JL0umbkXp6WIXciIcHBg=", "Vxwt1HWAfCMiNbNgtiV4Aw==" });
        }
    }
}
