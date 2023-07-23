using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopDAL.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Birth = table.Column<string>(type: "varchar(13)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection_Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Phones = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    WalletPoint = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Form",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Form", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotion_Type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phones = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_Address_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: true),
                    ReduceAmount = table.Column<int>(type: "int", nullable: true),
                    ReduceRate = table.Column<float>(type: "real", nullable: true),
                    ReduceMax = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_PromotionType = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_Promotion_Type_Id_PromotionType",
                        column: x => x.Id_PromotionType,
                        principalTable: "Promotion_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImportPrice = table.Column<int>(type: "int", nullable: false),
                    Reader = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PageSize = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_Publisher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Genre = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Brand = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Collection = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Brand_Id_Brand",
                        column: x => x.Id_Brand,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Collection_Book_Id_Collection",
                        column: x => x.Id_Collection,
                        principalTable: "Collection_Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Genre_Id_Genre",
                        column: x => x.Id_Genre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_Id_Publisher",
                        column: x => x.Id_Publisher,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(13)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phones = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyNotes = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    DeliveryCharges = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_Address = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_PaymentForm = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Delivery_Address_Id_Address",
                        column: x => x.Id_Address,
                        principalTable: "Delivery_Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Payment_Form_Id_PaymentForm",
                        column: x => x.Id_PaymentForm,
                        principalTable: "Payment_Form",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_Promotion",
                columns: table => new
                {
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Promotion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Promotion", x => new { x.Id_Customer, x.Id_Promotion });
                    table.ForeignKey(
                        name: "FK_Customer_Promotion_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Promotion_Promotion_Id_Promotion",
                        column: x => x.Id_Promotion,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book_Author",
                columns: table => new
                {
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Author", x => new { x.Id_Book, x.Id_Author });
                    table.ForeignKey(
                        name: "FK_Book_Author_Author_Id_Author",
                        column: x => x.Id_Author,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Author_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book_Promotion",
                columns: table => new
                {
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Promotion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Promotion", x => new { x.Id_Promotion, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_Book_Promotion_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Promotion_Promotion_Id_Promotion",
                        column: x => x.Id_Promotion,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.Id_Customer, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_Cart_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluate_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluate_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Parents = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Author_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Author",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Book_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Book",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Publisher_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Publisher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Image_Shop_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Shop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => new { x.Id_Customer, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_WishList_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishList_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Book",
                columns: table => new
                {
                    Id_Order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Book", x => new { x.Id_Order, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_Order_Book_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Book_Order_Id_Order",
                        column: x => x.Id_Order,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Promotion",
                columns: table => new
                {
                    Id_Order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Promotion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReduceAmount = table.Column<int>(type: "int", nullable: false),
                    ReduceMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Promotion", x => new { x.Id_Order, x.Id_Promotion });
                    table.ForeignKey(
                        name: "FK_Order_Promotion_Order_Id_Order",
                        column: x => x.Id_Order,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Promotion_Promotion_Id_Promotion",
                        column: x => x.Id_Promotion,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnOrderConfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Id_Order = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnOrderConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnOrderConfiguration_Order_Id_Order",
                        column: x => x.Id_Order,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Book = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Parents = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Book_Id_Book",
                        column: x => x.Id_Book,
                        principalTable: "Book",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Comment_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Customer_Id_Customer",
                        column: x => x.Id_Customer,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Evaluate_Id_Parents",
                        column: x => x.Id_Parents,
                        principalTable: "Evaluate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_Brand",
                table: "Book",
                column: "Id_Brand");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_Collection",
                table: "Book",
                column: "Id_Collection");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_Genre",
                table: "Book",
                column: "Id_Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id_Publisher",
                table: "Book",
                column: "Id_Publisher");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Author_Id_Author",
                table: "Book_Author",
                column: "Id_Author");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Promotion_Id_Book",
                table: "Book_Promotion",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Id_Book",
                table: "Cart",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Id_Book",
                table: "Comment",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Id_Customer",
                table: "Comment",
                column: "Id_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Id_Parents",
                table: "Comment",
                column: "Id_Parents");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Promotion_Id_Promotion",
                table: "Customer_Promotion",
                column: "Id_Promotion");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Address_Id_Customer",
                table: "Delivery_Address",
                column: "Id_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluate_Id_Book",
                table: "Evaluate",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluate_Id_Customer",
                table: "Evaluate",
                column: "Id_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Id_Parents",
                table: "Image",
                column: "Id_Parents");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id_Address",
                table: "Order",
                column: "Id_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id_Customer",
                table: "Order",
                column: "Id_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id_PaymentForm",
                table: "Order",
                column: "Id_PaymentForm");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Book_Id_Book",
                table: "Order_Book",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Promotion_Id_Promotion",
                table: "Order_Promotion",
                column: "Id_Promotion");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_Id_PromotionType",
                table: "Promotion",
                column: "Id_PromotionType");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrderConfiguration_Id_Order",
                table: "ReturnOrderConfiguration",
                column: "Id_Order");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_Id_Book",
                table: "WishList",
                column: "Id_Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Book_Author");

            migrationBuilder.DropTable(
                name: "Book_Promotion");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Customer_Promotion");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Order_Book");

            migrationBuilder.DropTable(
                name: "Order_Promotion");

            migrationBuilder.DropTable(
                name: "ReturnOrderConfiguration");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "Evaluate");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Promotion_Type");

            migrationBuilder.DropTable(
                name: "Delivery_Address");

            migrationBuilder.DropTable(
                name: "Payment_Form");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Collection_Book");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
