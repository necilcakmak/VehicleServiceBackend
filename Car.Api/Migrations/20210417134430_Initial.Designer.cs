// <auto-generated />
using System;
using Car.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Car.Api.Migrations
{
    [DbContext(typeof(CarContext))]
    [Migration("20210417134430_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Car.Entities.Concrete.CompanyPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CompanyPersons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 857, DateTimeKind.Local).AddTicks(8893),
                            Email = "admin@admin.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 857, DateTimeKind.Local).AddTicks(8930),
                            Name = "Admin",
                            Password = "$2a$11$p5VU9g5QyHZ9wap7F.QNIOwDOR4e88DwzVUpCAqLf3zwlyKnK4Acy",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 30, 16, DateTimeKind.Local).AddTicks(5272),
                            Email = "super@super.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 30, 16, DateTimeKind.Local).AddTicks(5303),
                            Name = "SuperAdmin",
                            Password = "$2a$11$orQASH7UgrvfB2M197p9oOy9UzSVLcbFoud3f.YXUSrf6S4ov347O",
                            Role = "Super"
                        });
                });

            modelBuilder.Entity("Car.Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TaxNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Düzce/Akçakoca",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 680, DateTimeKind.Local).AddTicks(9969),
                            Email = "test@test.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(8835),
                            Name = "test",
                            PhoneNumber = "0533423424",
                            TaxNo = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Düzce/Merkez",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9307),
                            Email = "test2@test.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9311),
                            Name = "test2",
                            PhoneNumber = "0539851524",
                            TaxNo = "654321"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Zonguldak/Merkez",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9313),
                            Email = "test3@test.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9315),
                            Name = "test3",
                            PhoneNumber = "0539851524",
                            TaxNo = "232424"
                        },
                        new
                        {
                            Id = 4,
                            Adress = "Bolu/Merkez",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9317),
                            Email = "test4@test.com",
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 681, DateTimeKind.Local).AddTicks(9318),
                            Name = "test4",
                            PhoneNumber = "0554551524",
                            TaxNo = "6543656"
                        });
                });

            modelBuilder.Entity("Car.Entities.Concrete.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyPersonId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Car.Entities.Concrete.InvoiceProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehiclePartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("VehiclePartId");

                    b.ToTable("InvoiceProducts");
                });

            modelBuilder.Entity("Car.Entities.Concrete.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Ford",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1414),
                            IsActive = true,
                            Model = "Focus",
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(470)
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Volvo",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1422),
                            IsActive = true,
                            Model = "S60",
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1420)
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Audi",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1425),
                            IsActive = true,
                            Model = "Quadrado",
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1424)
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Tofaş",
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1428),
                            IsActive = true,
                            Model = "Şahin",
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 685, DateTimeKind.Local).AddTicks(1427)
                        });
                });

            modelBuilder.Entity("Car.Entities.Concrete.VehiclePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PartCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PartType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TaxStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleParts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuyPrice = 300m,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(4568),
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(4574),
                            PartCode = "A81",
                            PartType = "Akü",
                            SellPrice = 400m,
                            Stock = 50,
                            TaxRate = 18m,
                            TaxStatus = "Yüksek",
                            VehicleId = 1
                        },
                        new
                        {
                            Id = 2,
                            BuyPrice = 700m,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8047),
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8052),
                            PartCode = "C54",
                            PartType = "Cam",
                            SellPrice = 850m,
                            Stock = 1000,
                            TaxRate = 15m,
                            TaxStatus = "Orta",
                            VehicleId = 2
                        },
                        new
                        {
                            Id = 3,
                            BuyPrice = 200m,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8056),
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8058),
                            PartCode = "J34",
                            PartType = "Jant",
                            SellPrice = 400m,
                            Stock = 1000,
                            TaxRate = 25m,
                            TaxStatus = "Yüksek",
                            VehicleId = 3
                        },
                        new
                        {
                            Id = 4,
                            BuyPrice = 50m,
                            CreatedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8060),
                            IsActive = true,
                            ModifiedDate = new DateTime(2021, 4, 17, 16, 44, 29, 687, DateTimeKind.Local).AddTicks(8061),
                            PartCode = "S11",
                            PartType = "Silecek",
                            SellPrice = 65m,
                            Stock = 1000,
                            TaxRate = 10m,
                            TaxStatus = "Yüksek",
                            VehicleId = 2
                        });
                });

            modelBuilder.Entity("Car.Entities.Concrete.Invoice", b =>
                {
                    b.HasOne("Car.Entities.Concrete.CompanyPerson", "CompanyPerson")
                        .WithMany()
                        .HasForeignKey("CompanyPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car.Entities.Concrete.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyPerson");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Car.Entities.Concrete.InvoiceProduct", b =>
                {
                    b.HasOne("Car.Entities.Concrete.Invoice", "Invoice")
                        .WithMany("InvoiceProducts")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car.Entities.Concrete.VehiclePart", "VehiclePart")
                        .WithMany()
                        .HasForeignKey("VehiclePartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("VehiclePart");
                });

            modelBuilder.Entity("Car.Entities.Concrete.VehiclePart", b =>
                {
                    b.HasOne("Car.Entities.Concrete.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Car.Entities.Concrete.Invoice", b =>
                {
                    b.Navigation("InvoiceProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
