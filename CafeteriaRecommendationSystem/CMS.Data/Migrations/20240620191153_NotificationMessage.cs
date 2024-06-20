using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class NotificationMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notification",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "yvLpZAL+3Q6ejx28gzzXqzzHlVi40dPrkABVebWXrww=", "rOtp4Nf5on5wfECJv2q3cw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "DOkaLgeHet2zg86HYjRsRLXcSe1sbePNXnA9rl1k8gw=", "TLYvaIXVMOtrp8lTOx0mLg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "neKcjUntnAYFnsBoRPOAM8SYj99Z4h1WZdZwMX8GRCE=", "g0waRgeGY+gwq105NpJKaw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ATB+JH+mt2/I9SjOLjBAvKU3F1jZTGNw297P8rkDctE=", "8udmGoroRpvwgTsfj03f6A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "ba8j1yIljT+IwXkBzMdTcH6Xa6D3PpJ1JTNBmKs3tGA=", "X70vGFqf1CgGHopITKgNVA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "9mDDAtXI/gOTmafkUPLf/TdeHcXhiJt4T5cfXvMI6LM=", "e21X9zGDAKWS5zfDL5pvIQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "j5K1V+cFVfbyZUOiD+hHf8yZnbUsZBv/UvCPbC6UNRk=", "5zUU91Ps3INTcpD2P7Njxw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "7M15ky8uFCfph0fs0EbU109LwTZnaDxzR6NCbM2mcLo=", "KmJ3fOEjVmervdkSIcK9cg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "moVtRF4YMYODweG1JmFwm9dCeIIQ9Y/0Vr9qJ20s1fw=", "XgXOFSNgrOWpu/22+mCxbA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "+TDH08u7ThvpiHU3mrtvKDfsPSJujKKsieWEDwtNVbw=", "b8slQ1oC9cTRItyXqxCP2w==" });
        }
    }
}
