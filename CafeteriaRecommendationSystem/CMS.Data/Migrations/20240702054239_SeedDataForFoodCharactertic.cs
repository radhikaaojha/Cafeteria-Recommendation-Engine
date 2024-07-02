using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class SeedDataForFoodCharactertic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodItemCharactersticMapping",
                columns: new[] { "Id", "CharacteristicId", "FoodItemId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 4, 1 },
                    { 3, 7, 1 },
                    { 4, 1, 2 },
                    { 5, 5, 2 },
                    { 6, 7, 2 },
                    { 7, 1, 3 },
                    { 8, 6, 3 },
                    { 9, 7, 3 },
                    { 10, 1, 4 },
                    { 11, 4, 4 },
                    { 12, 8, 4 },
                    { 13, 1, 5 },
                    { 14, 5, 5 },
                    { 15, 7, 5 },
                    { 16, 1, 6 },
                    { 17, 6, 6 },
                    { 18, 1, 7 },
                    { 19, 6, 7 },
                    { 20, 1, 8 },
                    { 21, 6, 8 },
                    { 22, 1, 9 },
                    { 23, 6, 9 },
                    { 24, 1, 10 },
                    { 25, 1, 11 },
                    { 26, 5, 11 },
                    { 27, 9, 11 },
                    { 28, 10, 11 },
                    { 29, 1, 12 },
                    { 30, 4, 12 },
                    { 31, 9, 12 },
                    { 32, 10, 12 },
                    { 33, 2, 13 },
                    { 34, 3, 13 },
                    { 35, 9, 13 },
                    { 36, 10, 13 },
                    { 37, 2, 14 },
                    { 38, 3, 14 },
                    { 39, 9, 14 },
                    { 40, 10, 14 },
                    { 41, 1, 15 },
                    { 42, 4, 15 }
                });

            migrationBuilder.InsertData(
                table: "FoodItemCharactersticMapping",
                columns: new[] { "Id", "CharacteristicId", "FoodItemId" },
                values: new object[,]
                {
                    { 43, 9, 15 },
                    { 44, 10, 15 },
                    { 45, 1, 16 },
                    { 46, 4, 16 },
                    { 47, 1, 17 },
                    { 48, 4, 17 },
                    { 49, 1, 18 },
                    { 50, 4, 18 },
                    { 51, 1, 19 },
                    { 52, 4, 19 },
                    { 53, 2, 20 },
                    { 54, 3, 20 },
                    { 55, 1, 21 },
                    { 56, 5, 21 },
                    { 57, 1, 22 },
                    { 58, 5, 22 },
                    { 59, 1, 23 },
                    { 60, 5, 23 },
                    { 61, 1, 24 },
                    { 62, 5, 24 },
                    { 63, 1, 25 },
                    { 64, 5, 25 },
                    { 65, 1, 26 },
                    { 66, 6, 26 },
                    { 67, 1, 27 },
                    { 68, 6, 27 },
                    { 69, 1, 28 },
                    { 70, 6, 28 },
                    { 71, 1, 29 },
                    { 72, 6, 29 },
                    { 73, 1, 30 },
                    { 74, 6, 30 },
                    { 75, 3, 31 },
                    { 76, 11, 31 },
                    { 77, 3, 32 },
                    { 78, 11, 32 },
                    { 79, 1, 33 },
                    { 80, 7, 33 },
                    { 81, 1, 34 },
                    { 82, 7, 34 },
                    { 83, 1, 35 },
                    { 84, 7, 35 }
                });

            migrationBuilder.InsertData(
                table: "FoodItemCharactersticMapping",
                columns: new[] { "Id", "CharacteristicId", "FoodItemId" },
                values: new object[,]
                {
                    { 85, 2, 36 },
                    { 86, 7, 36 },
                    { 87, 3, 37 },
                    { 88, 7, 37 },
                    { 89, 1, 38 },
                    { 90, 7, 38 },
                    { 91, 2, 39 },
                    { 92, 7, 39 },
                    { 93, 2, 40 },
                    { 94, 7, 40 },
                    { 95, 2, 41 },
                    { 96, 7, 41 },
                    { 97, 1, 42 },
                    { 98, 7, 42 },
                    { 99, 1, 43 },
                    { 100, 7, 43 },
                    { 101, 1, 44 },
                    { 102, 7, 44 },
                    { 103, 1, 45 },
                    { 104, 7, 45 },
                    { 105, 1, 46 },
                    { 106, 8, 46 },
                    { 107, 1, 47 },
                    { 108, 7, 47 },
                    { 109, 1, 48 },
                    { 110, 7, 48 },
                    { 111, 1, 49 },
                    { 112, 7, 49 },
                    { 113, 2, 50 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "FoodItemCharactersticMapping",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "O5yyelwdVQ0zppcTuAGGJtep6U55reqO2KJIFfiUHCk=", "42TRG1vxli4EGalEw6I/jA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "50Ng46J61yPCnAqm8leAY88z0maUUFAzDXK2d5CPdVU=", "QKR+cGXy4fLh2klb/vqZkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "FUn/ZfIYaWXUwi2xFA0KXX/FXYFsUzgtJBuAvUJIcr8=", "s2sZ4X8jbUyjqQ/E0S87lQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "S4iQumeGEt9DHMk6gx5EcB2fi2lMQ5F6dkOU4Q/tMCE=", "zleWf1TBQ/8U85Dpig0vXg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SDEnXyiCUF+Ant1kvMcHPJdTdyoOvZEDpW206AoxKoU=", "ASR73xWSqgALlc5CPGVW0g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "RSaNYU+J44s/6PlLaytdGFaTx/nkCX2iHw9dDA3Y4dw=", "SiLpZ1HslJZO00IVzCoK3A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "6wkwMLBGmrkZTkjpHgDYhcbJ8TKdIkURriydRJyvZxw=", "wxvgdPL+pc5HA0J2yRAcuw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "oIdnypbcxvZHDn0DJXNwVI1xgx6uXUnVGE3NfTRyFu4=", "X9UYC27uLr5hQoyrhgSNrw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "9ucwyXN2fbQHdpEWZ8nvIKji1bRDkL5/HhZvOT9+z5Y=", "za03UAqSGeNxuaRRGNDGjQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Ke2kQcLG2x5uSupu0LDJUas9h0putUYlZCKVEN7lm0s=", "EWDZBnrPFbqgXNugLYaoiA==" });
        }
    }
}
