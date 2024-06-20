using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "WeeklyMenu",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "WeeklyMenu",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "User",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "User",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Role",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Role",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "NotificationType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "NotificationType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Notification",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Notification",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "MealType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MealType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemFeedback",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemFeedback",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemAvailabilityStatus",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemAvailabilityStatus",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItem",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItem",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getutcdate()");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "WeeklyMenu",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "WeeklyMenu",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "User",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "User",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Role",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Role",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "NotificationType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "NotificationType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Notification",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Notification",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "MealType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "MealType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemType",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemFeedback",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemFeedback",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItemAvailabilityStatus",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItemAvailabilityStatus",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "FoodItem",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "FoodItem",
                type: "datetime2(0)",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldDefaultValueSql: "getdate()");

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
    }
}
