using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Api.Migrations
{
    public partial class InitialCreate : Migration
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
                columns: new[] { "Id", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "Password" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 15, 32, 49, 939, DateTimeKind.Local).AddTicks(4059), "admin@admin.com", true, new DateTime(2021, 4, 15, 15, 32, 49, 939, DateTimeKind.Local).AddTicks(4083), "Admin", "$2a$11$Ul6UsthmfxbXu5NKdh4lZecrTY0DNFNWJhrfhtMn2s6T.BeagrLZa" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adress", "CreatedDate", "Email", "IsActive", "ModifiedDate", "Name", "PhoneNumber", "TaxNo" },
                values: new object[,]
                {
                    { 1, "Düzce/Akçakoca", new DateTime(2021, 4, 15, 15, 32, 49, 770, DateTimeKind.Local).AddTicks(3190), "test@test.com", true, new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4078), "test", "0533423424", "123456" },
                    { 2, "Düzce/Merkez", new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4593), "tes2@test.com", true, new DateTime(2021, 4, 15, 15, 32, 49, 771, DateTimeKind.Local).AddTicks(4598), "tes2", "0539851524", "654321" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CreatedDate", "IsActive", "Model", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Ford", new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5297), true, "Focus", new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(4422) },
                    { 2, "Volvo", new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5306), true, "S60", new DateTime(2021, 4, 15, 15, 32, 49, 774, DateTimeKind.Local).AddTicks(5304) }
                });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "BuyPrice", "CreatedDate", "IsActive", "ModifiedDate", "PartCode", "PartType", "SellPrice", "Stock", "TaxRate", "TaxStatus", "VehicleId" },
                values: new object[] { 1, 300m, new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(6214), true, new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(6226), "A81", "Akü", 400m, 50, 18m, "Yüksek", 1 });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "BuyPrice", "CreatedDate", "IsActive", "ModifiedDate", "PartCode", "PartType", "SellPrice", "Stock", "TaxRate", "TaxStatus", "VehicleId" },
                values: new object[] { 2, 700m, new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(9621), true, new DateTime(2021, 4, 15, 15, 32, 49, 776, DateTimeKind.Local).AddTicks(9628), "C54", "Cam", 850m, 30, 15m, "Orta", 2 });

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
