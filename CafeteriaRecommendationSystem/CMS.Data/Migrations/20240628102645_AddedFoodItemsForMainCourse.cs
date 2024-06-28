using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class AddedFoodItemsForMainCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Chole Rice");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Rajma Rice");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Paneer Roti");

            migrationBuilder.InsertData(
                table: "FoodItem",
                columns: new[] { "Id", "Description", "FoodItemTypeId", "Name", "Price", "SentimentScore", "StatusId" },
                values: new object[,]
                {
                    { 33, "", 4, "Mixed Veg Roti", 150m, 0m, 2 },
                    { 34, "", 4, "Kadhi Rice", 120m, 0m, 2 },
                    { 35, "", 4, "Masoor Dal Rice", 110m, 0m, 2 },
                    { 36, "", 4, "Chicken Curry Rice", 180m, 0m, 2 },
                    { 37, "", 4, "Egg Curry Rice", 160m, 0m, 2 },
                    { 38, "", 4, "Dal Roti", 100m, 0m, 2 },
                    { 39, "", 4, "Mutton Biryani", 100m, 0m, 2 },
                    { 40, "", 4, "Fish Curry Rice", 190m, 0m, 2 },
                    { 41, "", 4, "Mutton Curry Rice", 220m, 0m, 2 },
                    { 42, "", 4, "Vegetable Pulao", 130m, 0m, 2 },
                    { 43, "", 4, "Aloo Gobi Roti", 120m, 0m, 2 },
                    { 44, "", 4, "Baingan Bharta Roti", 130m, 0m, 2 },
                    { 45, "", 4, "Palak Paneer Roti", 150m, 0m, 2 },
                    { 46, "", 4, "Sambar Rice", 100m, 0m, 2 },
                    { 47, "", 4, "Aloo Matar Roti", 120m, 0m, 2 },
                    { 48, "", 4, "Gobi Masala Roti", 140m, 0m, 2 },
                    { 49, "", 4, "Paneer Bhurji Roti", 160m, 0m, 2 },
                    { 50, "", 4, "Chicken Biryani", 200m, 0m, 2 },
                    { 51, "", 4, "Aloo Paratha", 110m, 0m, 2 },
                    { 52, "", 4, "Bhindi Roti", 140m, 0m, 2 }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "BfYJXHZtt4M/uQS227cDAZjh6RILbLRucok68rbxHTY=", "fGCU+5GXXKlokYtHIlH9yA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Rfpc06PGKE6EjH6jxtQ3biN1B0cp5RONbuZZoSjXbYM=", "TsrBIyKGOHEWt2QDY1WO1w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "GiFNuWQtryCgLd2RR1WSMl/rLR3IorC5hHxzpOlIsBA=", "bRuCtCosfut1a76wPzOgdg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "OIp1mwNHR2ZTmT+7dRZ0qy1dDAZX6Oewt0zYsXlaFLo=", "9ZdIfZk+LHIS2U2sL1XsYQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Og9NthcojDMVa6j+Upt5F/lcJR0UdSEqDD37/Nz+CsA=", "SQx4qOtPnvwpCnpMe21zmw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "a4ysRcxGNyew8ih6kdXdb1EoV+c+waw2rhBVnBzvRNg=", "VYHVT4QSl1lrBMU0RHhPyA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5csoer9HZELAV4bgVmAl3iClk4eLsDsLytwJ6AC6xOI=", "8Av1MLUjR84iUH/ypDPl1w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "u8auSQXWa01yDiuhLFHqZzSsqcuPDlrMNxxWXuG+syk=", "KUguT8YvpK2rAGw9+WsSPg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mSujXuorr5G+QSG4NxKt6atzmS9owThrPCLtLGG5geU=", "dEs55lWb/s+BIcOPUngxMw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "C9chY1WeYydaZq/I/JVSvwzbPpHGMVg2Y8LNhPjmtXI=", "SUQSuZb7eii9gcs7eZecNg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Butter Chicken");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Paneer Butter Masala");

            migrationBuilder.UpdateData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Dal Makhani");

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
                columns: new[] { "Password", "Salt" },
                values: new object[] { "8tRUaHlwMPByB7XVpGrwuI8ltZszjE34HMoMz63m0V8=", "3/MQsq3ZyR7wAesMb/QOwQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HMNFaRnLk14xk2fdPzMEgdcYm7kLVFVn0bzs4FUXJhA=", "Ui5zfGAYwUHez9NuBGIabg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "UQChXvZPqFeMqSxMnbxoUsPGDMF4PDCNpG6S4U8iagc=", "cBdjJf4X0PpDXuuFCWt6Qw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mQT0BB9sHGBQDDax2VVnAWIi7ePM0vM3t3kos9JZ+us=", "mHs5X9QOn7B7K5zgs9GQ3w==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "lqvWN9I3lprpxUWlZFBrkB2gaJld5TKwBHnyyXEq/gY=", "JOKC3cdZ8asGT5sBA7UFbQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "42Zsud7cN64dTAdUX9rYy32YDSyLwh1X3s7H8CnA1X4=", "SXycZkxiV2RTSeNTqTDaWw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "D3BeIuJSOf8qVoKLwCrYVprhIyOHG87fxtfWZ4QPR7o=", "v/vCWp1NbS+61Gdj5Z3vZg==" });
        }
    }
}
