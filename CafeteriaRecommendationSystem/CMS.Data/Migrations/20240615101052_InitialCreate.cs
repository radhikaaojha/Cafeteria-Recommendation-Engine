using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemAvailabilityStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemAvailabilityStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    SentimentScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_FoodItemAvailabilityStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "FoodItemAvailabilityStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItems_FoodItemTypes_FoodItemTypeId",
                        column: x => x.FoodItemTypeId,
                        principalTable: "FoodItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(320)", nullable: false),
                    Password = table.Column<string>(type: "char(60)", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<string>(type: "char(30)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfVotes = table.Column<int>(type: "int", nullable: false),
                    MealTypeId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMenus_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklyMenus_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItemFeedbacks_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemFeedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItemAvailabilityStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OutOfStock" },
                    { 2, "Available" },
                    { 3, "OnHold" }
                });

            migrationBuilder.InsertData(
                table: "FoodItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizers" },
                    { 2, "Salads" },
                    { 3, "Sandwiches" },
                    { 4, "MainCourses" },
                    { 5, "Desserts" },
                    { 6, "Beverages" }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "NewFoodItemAdded" },
                    { 2, "FoodItemRemoved" },
                    { 3, "FoodItemPriceUpdated" },
                    { 4, "FoodItemAvailabilityUpdated" },
                    { 5, "FoodItemVoting" },
                    { 6, "FinalMenu" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Chef" },
                    { 3, "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemFeedbacks_FoodItemId",
                table: "FoodItemFeedbacks",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemFeedbacks_UserId",
                table: "FoodItemFeedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodItemTypeId",
                table: "FoodItems",
                column: "FoodItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_StatusId",
                table: "FoodItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenus_FoodItemId",
                table: "WeeklyMenus",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenus_MealTypeId",
                table: "WeeklyMenus",
                column: "MealTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemFeedbacks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "WeeklyMenus");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "FoodItemAvailabilityStatuses");

            migrationBuilder.DropTable(
                name: "FoodItemTypes");
        }
    }
}
