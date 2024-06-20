using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class NotificationMessageMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Sv7YT1kyKHJZ7O1KG9Ei+fDZXlq6U/mUkvWgufyTnEQ=", "Iy5DZgZCA/Cqy4YVF0tOvA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "8Di74DZt4l7nHPTJqn992CGJaU66U8X6Ofk2MSVECiM=", "E19oX4X8tq7xjWQudnv6Tw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "8CiwQTKqDh6cxItgsg6ZxVZN/qVHiW6STcmPldlDAu8=", "A45lL8w5GMcskzrKV45YLQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "YOtIc4YyJ915ooT2b02rf/Yngdr0zWLYXzjS4/B6kQw=", "SAkMVlPEIhKLxI7v7Lf+JA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "u/gsd5eWhSI9/cr9YsxiLLn9asNidV+alt//tCuTJwA=", "AhRGgMABRCfg4tWZ+BanKA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "GqhtV7D5UerqhRSl2PIC6O9BC68FFg8xTGDsd2jyvdI=", "oIYskfcbwt5KZevLl9kW3w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SlflMjk3ecYxcvxXHiDd3wNLFFuIYKXf+4vUcmQhz50=", "yhYVJh7X/mV6FnIv1wKyfg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "XCqMKQnVI4fhHyL06WerZ2pYHLzNhEUmmjAcOXEf70M=", "p/R78vpdb2hQFaJAS3VeQQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "45ES+A5lJsrPrwP16DqZQyBrp+YRogE/5fmKOPMgxqU=", "sP4SK1MYaOPT9ssRLHGfnA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "kclQWqHOYOCAPfTNfVCzarfwKhXRtm/xMvhMN9bL+so=", "VUMQcVB6OoCqoCxD09pFHg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "d+CcEFoy6pZir640MEREf9bzspJaD7bMV3L2SYvSQ8U=", "lLySdtfvTWFDBZ/bZGFK9w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ZASFHaXWrELjl0JGYA1Z5yhFLFWKF33O8pLTd9bZ5Oc=", "ZpC6Rs4A3j3cu0o+OAD+XQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "8WXdCkc19dMu1TIVTqPdThjw27+k/3K2bqH88VOd7hA=", "2LVy0H0E7jwRIl/Lc5Vx2w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "gv60Gmd2qKCwW651v8Fhyv+8R7nvfEMwms+7mioKD4s=", "jL+XJCxx1q3VPF/PWk0/Tg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "sjbvewZQbwBqCZwCTJ9slA8KprHSfg7CSK01ktuFjjc=", "kvK+UhZe5nbfKB2k/5P+NA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mehUIgeDpJpbCm2M7xiA2ZuAU4NU6NQ17C3/cxMLOFQ=", "KVXH8awcq2pB37yGnYL0rQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "lvip6syt0XEKSvzm1AGl5GsgSVB8JCax/V4dad6/gW0=", "0bF8d3qMaaGTnUwPjSbbRA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "XDTCjlIcvAAYSPPNULfZ0JfJjGJyxlWdBSVkEHqamYw=", "pa3EF20J2ojCqa532a85sg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "71yJtNMJwxuLfqOTktmCJl1AE9L9mv0I8adR4JtJsQE=", "lD1UAaGhRpHZ15tDMHYKLg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "lKGimeRlMaOAbbUu+L+uJcqhWE9U48NMYzXGJMWyXXE=", "Xd9NH+xb7N4RPDeSAw2prg==" });
        }
    }
}
