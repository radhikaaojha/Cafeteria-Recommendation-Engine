using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class UpdatedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "e08M1G8IZnUjuePlljTbCGjA3FHo7b9DUqYRrD+95AY=", "HGkSgjm+DprRRSgY0eocBQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "eDOASERDmHZjJU/69Lld7JgkHA7iIIt8a6QpWCx+208=", "Ed0UPCgLruHL01QNqBz1sQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Eb79BS9HgzuLvwuur/oTqFh3hKRuoZ4PuVu0Ekw+x48=", "HCZ144IFLqOG4eMDXhqZ5Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "8tRUaHlwMPByB7XVpGrwuI8ltZszjE34HMoMz63m0V8=", 3, "3/MQsq3ZyR7wAesMb/QOwQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "HMNFaRnLk14xk2fdPzMEgdcYm7kLVFVn0bzs4FUXJhA=", 3, "Ui5zfGAYwUHez9NuBGIabg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "UQChXvZPqFeMqSxMnbxoUsPGDMF4PDCNpG6S4U8iagc=", 3, "cBdjJf4X0PpDXuuFCWt6Qw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "mQT0BB9sHGBQDDax2VVnAWIi7ePM0vM3t3kos9JZ+us=", 3, "mHs5X9QOn7B7K5zgs9GQ3w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "lqvWN9I3lprpxUWlZFBrkB2gaJld5TKwBHnyyXEq/gY=", 2, "JOKC3cdZ8asGT5sBA7UFbQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "42Zsud7cN64dTAdUX9rYy32YDSyLwh1X3s7H8CnA1X4=", 2, "SXycZkxiV2RTSeNTqTDaWw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "D3BeIuJSOf8qVoKLwCrYVprhIyOHG87fxtfWZ4QPR7o=", 2, "v/vCWp1NbS+61Gdj5Z3vZg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "khlqINfGz44orynDyzgSJY/FCkV3PwS42X9Hen6HBwY=", 2, "VQWh1pbixxpE82HsRAthdQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "6zlxYwI2n+wswV4Oh04ARQsUiggZO4shNASouu9PVBk=", 2, "KpoFRUKmI9cZLaa7h0o7Gw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "ANssCwq+KV9tge6OCnUtYa/u9Oql7qT2RzouytXD9e0=", 2, "bWQv1SEJU+i7iJhbqt3Nrw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "IPz3Z54kwhqhg1FtUvhz9B45oU010Cg0KtD8c0qFugA=", 2, "MXCZYwMuXuAQWmPENb6Qxw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "bZNj9w0JE3zWjcZOcZ7lPR6V1NtKXJYD/7fqilYZK18=", 3, "gz2pdUp9rHMut/KQPxZyDA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "1EqAL4HXIWxUV88KVxu/Y9tLDe90xPOPPeIvWUk7nAo=", 3, "I5YJYPamP4sRoPP58eXEPQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "RoleId", "Salt" },
                values: new object[] { "TT4ict7pkKEpBtkdYp02RsgDWVYcDq6bKI0MMBFVi2c=", 3, "pNSssqXuxwFAxYCltQAnZg==" });
        }
    }
}
