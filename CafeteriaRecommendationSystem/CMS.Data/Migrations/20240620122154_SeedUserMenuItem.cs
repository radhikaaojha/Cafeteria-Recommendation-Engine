using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    public partial class SeedUserMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemFeedbacks_FoodItems_FoodItemId",
                table: "FoodItemFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemFeedbacks_Users_UserId",
                table: "FoodItemFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodItemAvailabilityStatuses_StatusId",
                table: "FoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodItemTypes_FoodItemTypeId",
                table: "FoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyMenus_FoodItems_FoodItemId",
                table: "WeeklyMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyMenus_MealTypes_MealTypeId",
                table: "WeeklyMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeeklyMenus",
                table: "WeeklyMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTypes",
                table: "NotificationTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealTypes",
                table: "MealTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemTypes",
                table: "FoodItemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemFeedbacks",
                table: "FoodItemFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemAvailabilityStatuses",
                table: "FoodItemAvailabilityStatuses");

            migrationBuilder.RenameTable(
                name: "WeeklyMenus",
                newName: "WeeklyMenu");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "NotificationTypes",
                newName: "NotificationType");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "MealTypes",
                newName: "MealType");

            migrationBuilder.RenameTable(
                name: "FoodItemTypes",
                newName: "FoodItemType");

            migrationBuilder.RenameTable(
                name: "FoodItems",
                newName: "FoodItem");

            migrationBuilder.RenameTable(
                name: "FoodItemFeedbacks",
                newName: "FoodItemFeedback");

            migrationBuilder.RenameTable(
                name: "FoodItemAvailabilityStatuses",
                newName: "FoodItemAvailabilityStatus");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyMenus_MealTypeId",
                table: "WeeklyMenu",
                newName: "IX_WeeklyMenu_MealTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyMenus_FoodItemId",
                table: "WeeklyMenu",
                newName: "IX_WeeklyMenu_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notification",
                newName: "IX_Notification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notification",
                newName: "IX_Notification_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItems_StatusId",
                table: "FoodItem",
                newName: "IX_FoodItem_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItems_FoodItemTypeId",
                table: "FoodItem",
                newName: "IX_FoodItem_FoodItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemFeedbacks_UserId",
                table: "FoodItemFeedback",
                newName: "IX_FoodItemFeedback_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemFeedbacks_FoodItemId",
                table: "FoodItemFeedback",
                newName: "IX_FoodItemFeedback_FoodItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeeklyMenu",
                table: "WeeklyMenu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationType",
                table: "NotificationType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealType",
                table: "MealType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemType",
                table: "FoodItemType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemFeedback",
                table: "FoodItemFeedback",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemAvailabilityStatus",
                table: "FoodItemAvailabilityStatus",
                column: "Id");

            migrationBuilder.InsertData(
                table: "FoodItem",
                columns: new[] { "Id", "Description", "FoodItemTypeId", "Name", "Price", "SentimentScore", "StatusId" },
                values: new object[,]
                {
                    { 1, "", 1, "Samosa", 50m, 0m, 2 },
                    { 2, "", 1, "Pakora", 55m, 0m, 2 },
                    { 3, "", 1, "Aloo Tikki", 60m, 0m, 2 },
                    { 4, "", 1, "Paneer Tikka", 95m, 0m, 2 },
                    { 5, "", 1, "Bhel Puri", 50m, 0m, 2 },
                    { 6, "", 2, "Kachumber Salad", 60m, 0m, 2 },
                    { 7, "", 2, "Green Salad", 50m, 0m, 2 },
                    { 8, "", 2, "Sprout Salad", 65m, 0m, 2 },
                    { 9, "", 2, "Chickpea Salad", 70m, 0m, 2 },
                    { 10, "", 2, "Cucumber Raita", 55m, 0m, 2 },
                    { 11, "", 3, "Vegetable Sandwich", 75m, 0m, 2 },
                    { 12, "", 3, "Paneer Sandwich", 85m, 0m, 2 },
                    { 13, "", 3, "Chicken Sandwich", 90m, 0m, 2 },
                    { 14, "", 3, "Egg Sandwich", 80m, 0m, 2 },
                    { 15, "", 3, "Cheese Sandwich", 85m, 0m, 2 },
                    { 16, "", 4, "Butter Chicken", 150m, 0m, 2 },
                    { 17, "", 4, "Paneer Butter Masala", 130m, 0m, 2 },
                    { 18, "", 4, "Dal Makhani", 100m, 0m, 2 },
                    { 19, "", 4, "Chole Bhature", 110m, 0m, 2 },
                    { 20, "", 4, "Biryani", 120m, 0m, 2 },
                    { 21, "", 5, "Gulab Jamun", 50m, 0m, 2 },
                    { 22, "", 5, "Rasgulla", 60m, 0m, 2 },
                    { 23, "", 5, "Jalebi", 55m, 0m, 2 },
                    { 24, "", 5, "Kheer", 65m, 0m, 2 },
                    { 25, "", 5, "Halwa", 70m, 0m, 2 },
                    { 26, "", 6, "Masala Chai", 30m, 0m, 2 },
                    { 27, "", 6, "Lassi", 40m, 0m, 2 },
                    { 28, "", 6, "Nimbu Pani", 35m, 0m, 2 },
                    { 29, "", 6, "Mango Shake", 50m, 0m, 2 },
                    { 30, "", 6, "Coconut Water", 45m, 0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "FoodItemAvailabilityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Unavailable" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId", "Salt" },
                values: new object[,]
                {
                    { 1, "admin1@example.com", "Admin", "yvLpZAL+3Q6ejx28gzzXqzzHlVi40dPrkABVebWXrww=", 1, "rOtp4Nf5on5wfECJv2q3cw==" },
                    { 2, "admin2@example.com", "Admin", "DOkaLgeHet2zg86HYjRsRLXcSe1sbePNXnA9rl1k8gw=", 1, "TLYvaIXVMOtrp8lTOx0mLg==" },
                    { 3, "admin3@example.com", "Admin", "neKcjUntnAYFnsBoRPOAM8SYj99Z4h1WZdZwMX8GRCE=", 1, "g0waRgeGY+gwq105NpJKaw==" },
                    { 4, "user1@example.com", "Radhika", "ATB+JH+mt2/I9SjOLjBAvKU3F1jZTGNw297P8rkDctE=", 2, "8udmGoroRpvwgTsfj03f6A==" },
                    { 5, "user2@example.com", "Raghvendra", "ba8j1yIljT+IwXkBzMdTcH6Xa6D3PpJ1JTNBmKs3tGA=", 2, "X70vGFqf1CgGHopITKgNVA==" },
                    { 6, "user3@example.com", "Rakshita", "9mDDAtXI/gOTmafkUPLf/TdeHcXhiJt4T5cfXvMI6LM=", 2, "e21X9zGDAKWS5zfDL5pvIQ==" },
                    { 7, "user4@example.com", "Mukul", "j5K1V+cFVfbyZUOiD+hHf8yZnbUsZBv/UvCPbC6UNRk=", 2, "5zUU91Ps3INTcpD2P7Njxw==" },
                    { 8, "chef1@example.com", "Amit", "7M15ky8uFCfph0fs0EbU109LwTZnaDxzR6NCbM2mcLo=", 3, "KmJ3fOEjVmervdkSIcK9cg==" },
                    { 9, "chef2@example.com", "Ashit", "moVtRF4YMYODweG1JmFwm9dCeIIQ9Y/0Vr9qJ20s1fw=", 3, "XgXOFSNgrOWpu/22+mCxbA==" },
                    { 10, "chef3@example.com", "Ankit", "+TDH08u7ThvpiHU3mrtvKDfsPSJujKKsieWEDwtNVbw=", 3, "b8slQ1oC9cTRItyXqxCP2w==" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_Name",
                table: "FoodItem",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_FoodItemAvailabilityStatus_StatusId",
                table: "FoodItem",
                column: "StatusId",
                principalTable: "FoodItemAvailabilityStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_FoodItemType_FoodItemTypeId",
                table: "FoodItem",
                column: "FoodItemTypeId",
                principalTable: "FoodItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemFeedback_FoodItem_FoodItemId",
                table: "FoodItemFeedback",
                column: "FoodItemId",
                principalTable: "FoodItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemFeedback_User_UserId",
                table: "FoodItemFeedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_NotificationType_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId",
                principalTable: "NotificationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyMenu_FoodItem_FoodItemId",
                table: "WeeklyMenu",
                column: "FoodItemId",
                principalTable: "FoodItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyMenu_MealType_MealTypeId",
                table: "WeeklyMenu",
                column: "MealTypeId",
                principalTable: "MealType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_FoodItemAvailabilityStatus_StatusId",
                table: "FoodItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_FoodItemType_FoodItemTypeId",
                table: "FoodItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemFeedback_FoodItem_FoodItemId",
                table: "FoodItemFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItemFeedback_User_UserId",
                table: "FoodItemFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_NotificationType_NotificationTypeId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyMenu_FoodItem_FoodItemId",
                table: "WeeklyMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_WeeklyMenu_MealType_MealTypeId",
                table: "WeeklyMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeeklyMenu",
                table: "WeeklyMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationType",
                table: "NotificationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealType",
                table: "MealType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemType",
                table: "FoodItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemFeedback",
                table: "FoodItemFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItemAvailabilityStatus",
                table: "FoodItemAvailabilityStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem");

            migrationBuilder.DropIndex(
                name: "IX_FoodItem_Name",
                table: "FoodItem");

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FoodItemAvailabilityStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "WeeklyMenu",
                newName: "WeeklyMenus");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "NotificationType",
                newName: "NotificationTypes");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "MealType",
                newName: "MealTypes");

            migrationBuilder.RenameTable(
                name: "FoodItemType",
                newName: "FoodItemTypes");

            migrationBuilder.RenameTable(
                name: "FoodItemFeedback",
                newName: "FoodItemFeedbacks");

            migrationBuilder.RenameTable(
                name: "FoodItemAvailabilityStatus",
                newName: "FoodItemAvailabilityStatuses");

            migrationBuilder.RenameTable(
                name: "FoodItem",
                newName: "FoodItems");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyMenu_MealTypeId",
                table: "WeeklyMenus",
                newName: "IX_WeeklyMenus_MealTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_WeeklyMenu_FoodItemId",
                table: "WeeklyMenus",
                newName: "IX_WeeklyMenus_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "Notifications",
                newName: "IX_Notifications_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemFeedback_UserId",
                table: "FoodItemFeedbacks",
                newName: "IX_FoodItemFeedbacks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItemFeedback_FoodItemId",
                table: "FoodItemFeedbacks",
                newName: "IX_FoodItemFeedbacks_FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItem_StatusId",
                table: "FoodItems",
                newName: "IX_FoodItems_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItem_FoodItemTypeId",
                table: "FoodItems",
                newName: "IX_FoodItems_FoodItemTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeeklyMenus",
                table: "WeeklyMenus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTypes",
                table: "NotificationTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealTypes",
                table: "MealTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemTypes",
                table: "FoodItemTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemFeedbacks",
                table: "FoodItemFeedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItemAvailabilityStatuses",
                table: "FoodItemAvailabilityStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItems",
                table: "FoodItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemFeedbacks_FoodItems_FoodItemId",
                table: "FoodItemFeedbacks",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItemFeedbacks_Users_UserId",
                table: "FoodItemFeedbacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodItemAvailabilityStatuses_StatusId",
                table: "FoodItems",
                column: "StatusId",
                principalTable: "FoodItemAvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodItemTypes_FoodItemTypeId",
                table: "FoodItems",
                column: "FoodItemTypeId",
                principalTable: "FoodItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_NotificationTypes_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId",
                principalTable: "NotificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyMenus_FoodItems_FoodItemId",
                table: "WeeklyMenus",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklyMenus_MealTypes_MealTypeId",
                table: "WeeklyMenus",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
