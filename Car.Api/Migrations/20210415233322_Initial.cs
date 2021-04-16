using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CompanyPersons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 453, DateTimeKind.Local).AddTicks(8902), new DateTime(2021, 4, 16, 2, 33, 21, 453, DateTimeKind.Local).AddTicks(8934), "$2a$11$ns/Lu/fYbT1V1xO1uQe8YedejQ87i2E2G.QosnG57JiFqo9VDcA1e" });

            migrationBuilder.InsertData(
                table: "CompanyPersons",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "Password" },
                values: new object[] { 2, new DateTime(2021, 4, 16, 2, 33, 21, 659, DateTimeKind.Local).AddTicks(8629), "super@super.com", true, new DateTime(2021, 4, 16, 2, 33, 21, 659, DateTimeKind.Local).AddTicks(8660), "SuperAdmin", "$2a$11$ItzpzlvG0DF8PB7CMnM4MehUtM45Xbjsu5RJ8Z1/HAZIWvZr3a0jm" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 233, DateTimeKind.Local).AddTicks(7409), new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "ModifiedDate", "Name" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1809), "test2@test.com", new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1816), "test2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "PhoneNumber", "TaxNo" },
                values: new object[,]
                {
                    { 3, "Zonguldak/Merkez", new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1819), "test3@test.com", true, new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1820), "test3", "0539851524", "232424" },
                    { 4, "Bolu/Merkez", new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1822), "test4@test.com", true, new DateTime(2021, 4, 16, 2, 33, 21, 235, DateTimeKind.Local).AddTicks(1823), "test4", "0554551524", "6543656" }
                });

            migrationBuilder.UpdateData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 241, DateTimeKind.Local).AddTicks(9140), new DateTime(2021, 4, 16, 2, 33, 21, 241, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "Stock" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3302), new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3310), 1000 });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "BuyPrice", "CreatedDate", "IsActive", "ModifiedDate", "PartCode", "PartType", "SellPrice", "Stock", "TaxRate", "TaxStatus", "VehicleId" },
                values: new object[] { 4, 50m, new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3318), true, new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3320), "S11", "Silecek", 65m, 1000, 10m, "Yüksek", 2 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2165), new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2175), new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CreatedDate", "IsActive", "Model", "ModifiedDate" },
                values: new object[,]
                {
                    { 3, "Audi", new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2178), true, "Quadrado", new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2176) },
                    { 4, "Tofaş", new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2180), true, "Şahin", new DateTime(2021, 4, 16, 2, 33, 21, 239, DateTimeKind.Local).AddTicks(2179) }
                });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "BuyPrice", "CreatedDate", "IsActive", "ModifiedDate", "PartCode", "PartType", "SellPrice", "Stock", "TaxRate", "TaxStatus", "VehicleId" },
                values: new object[] { 3, 200m, new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3314), true, new DateTime(2021, 4, 16, 2, 33, 21, 242, DateTimeKind.Local).AddTicks(3316), "J34", "Jant", 400m, 1000, 25m, "Yüksek", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanyPersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "CompanyPersons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Password" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 939, DateTimeKind.Local).AddTicks(4059), new DateTime(2021, 4, 15, 15, 32, 49, 939, DateTimeKind.Local).AddTicks(4083), "$2a$11$Ul6UsthmfxbXu5NKdh4lZecrTY0DNFNWJhrfhtMn2s6T.BeagrLZa" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 770, DateTimeKind.Local).AddTicks(3190), new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "ModifiedDate", "Name" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4593), "tes2@test.com", new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4598), "tes2" });

            migrationBuilder.UpdateData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(6214), new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "VehicleParts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "Stock" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(9621), new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(9628), 30 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5297), new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5306), new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5304) });
        }
    }
}
