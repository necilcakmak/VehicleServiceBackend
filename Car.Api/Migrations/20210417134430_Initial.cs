using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Payment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyPersonId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_CompanyPersons_CompanyPersonId",
                        column: x => x.CompanyPersonId,
                        principalTable: "CompanyPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleParts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    VehiclePartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_VehicleParts_VehiclePartId",
                        column: x => x.VehiclePartId,
                        principalTable: "VehicleParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyPersons",
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 17, 16, 44, 29, 857, DateTimeKind.Local).AddTicks(8893), "admin@admin.com", true, new DateTime(2021, 4, 17, 16, 44, 29, 857, DateTimeKind.Local).AddTicks(8930), "Admin", "$2a$11$p5VU9g5QyHZ9wap7F.QNIOwDOR4e88DwzVUpCAqLf3zwlyKnK4Acy", "Admin" },
                    { 2, new DateTime(2021, 4, 17, 16, 44, 30, 16, DateTimeKind.Local).AddTicks(5272), "super@super.com", true, new DateTime(2021, 4, 17, 16, 44, 30, 16, DateTimeKind.Local).AddTicks(5303), "SuperAdmin", "$2a$11$orQASH7UgrvfB2M197p9oOy9UzSVLcbFoud3f.YXUSrf6S4ov347O", "Super" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "PhoneNumber", "TaxNo" },
                values: new object[,]
                {
                    { 1, "Düzce/Akçakoca", new DateTime(2021, 4, 17, 16, 44, 29, 680, DateTimeKind.Local).AddTicks(9969), "test@test.com", true, new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(8835), "test", "0533423424", "123456" },
                    { 2, "Düzce/Merkez", new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9307), "test2@test.com", true, new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9311), "test2", "0539851524", "654321" },
                    { 3, "Zonguldak/Merkez", new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9313), "test3@test.com", true, new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9315), "test3", "0539851524", "232424" },
                    { 4, "Bolu/Merkez", new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9317), "test4@test.com", true, new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9318), "test4", "0554551524", "6543656" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CreatedDate", "IsActive", "Model", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Ford", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1414), true, "Focus", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(470) },
                    { 2, "Volvo", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1422), true, "S60", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1420) },
                    { 3, "Audi", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1425), true, "Quadrado", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1424) },
                    { 4, "Tofaş", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1428), true, "Şahin", new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1427) }
                });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "BuyPrice", "CreatedDate", "IsActive", "ModifiedDate", "PartCode", "PartType", "SellPrice", "Stock", "TaxRate", "TaxStatus", "VehicleId" },
                values: new object[,]
                {
                    { 1, 300m, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(4568), true, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(4574), "A81", "Akü", 400m, 50, 18m, "Yüksek", 1 },
                    { 2, 700m, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8047), true, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8052), "C54", "Cam", 850m, 1000, 15m, "Orta", 2 },
                    { 4, 50m, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8060), true, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8061), "S11", "Silecek", 65m, 1000, 10m, "Yüksek", 2 },
                    { 3, 200m, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8056), true, new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8058), "J34", "Jant", 400m, 1000, 25m, "Yüksek", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPersons_Email",
                table: "CompanyPersons",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                table: "InvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_VehiclePartId",
                table: "InvoiceProducts",
                column: "VehiclePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyPersonId",
                table: "Invoices",
                column: "CompanyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleParts_VehicleId",
                table: "VehicleParts",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProducts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "VehicleParts");

            migrationBuilder.DropTable(
                name: "CompanyPersons");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
