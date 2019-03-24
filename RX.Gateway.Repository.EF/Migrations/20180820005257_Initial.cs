using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RX.Gateway.Repository.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acquiriers",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquiriers", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "AntiFrauds",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiFrauds", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRegistries",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(nullable: false),
                    ShopkeeperId = table.Column<Guid>(nullable: false),
                    CreditCardNumber = table.Column<string>(type: "varchar(200)", nullable: true),
                    Brand = table.Column<int>(nullable: false),
                    ExpMonth = table.Column<int>(nullable: false),
                    ExpYear = table.Column<int>(nullable: false),
                    HolderName = table.Column<string>(nullable: true),
                    AmountInCents = table.Column<long>(nullable: false),
                    InstallmentCount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    AcquirierId = table.Column<Guid>(nullable: false),
                    AntiFraudId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRegistries", x => x.ObjectID);
                });

            migrationBuilder.CreateTable(
                name: "Shopkeepers",
                columns: table => new
                {
                    ObjectID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StoreObjectID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopkeepers", x => x.ObjectID);
                    table.ForeignKey(
                        name: "FK_Shopkeepers_Stores_StoreObjectID",
                        column: x => x.StoreObjectID,
                        principalTable: "Stores",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreAcquirier",
                columns: table => new
                {
                    StoreObjectID = table.Column<Guid>(nullable: false),
                    AcquirierObjectID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAcquirier", x => new { x.StoreObjectID, x.AcquirierObjectID });
                    table.ForeignKey(
                        name: "FK_StoreAcquirier_Acquiriers_AcquirierObjectID",
                        column: x => x.AcquirierObjectID,
                        principalTable: "Acquiriers",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreAcquirier_Stores_StoreObjectID",
                        column: x => x.StoreObjectID,
                        principalTable: "Stores",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreAntiFraud",
                columns: table => new
                {
                    StoreObjectID = table.Column<Guid>(nullable: false),
                    AntiFraudObjectID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAntiFraud", x => new { x.StoreObjectID, x.AntiFraudObjectID });
                    table.ForeignKey(
                        name: "FK_StoreAntiFraud_AntiFrauds_AntiFraudObjectID",
                        column: x => x.AntiFraudObjectID,
                        principalTable: "AntiFrauds",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreAntiFraud_Stores_StoreObjectID",
                        column: x => x.StoreObjectID,
                        principalTable: "Stores",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopkeeperAcquirierCredcardBrand",
                columns: table => new
                {
                    ShopkeeperID = table.Column<Guid>(nullable: false),
                    AcquirierID = table.Column<Guid>(nullable: false),
                    CreditCardBrand = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopkeeperAcquirierCredcardBrand", x => new { x.ShopkeeperID, x.AcquirierID, x.CreditCardBrand });
                    table.ForeignKey(
                        name: "FK_ShopkeeperAcquirierCredcardBrand_Acquiriers_AcquirierID",
                        column: x => x.AcquirierID,
                        principalTable: "Acquiriers",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopkeeperAcquirierCredcardBrand_Shopkeepers_ShopkeeperID",
                        column: x => x.ShopkeeperID,
                        principalTable: "Shopkeepers",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopkeeperAcquirierCredcardBrand_AcquirierID",
                table: "ShopkeeperAcquirierCredcardBrand",
                column: "AcquirierID");

            migrationBuilder.CreateIndex(
                name: "IX_Shopkeepers_StoreObjectID",
                table: "Shopkeepers",
                column: "StoreObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAcquirier_AcquirierObjectID",
                table: "StoreAcquirier",
                column: "AcquirierObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAntiFraud_AntiFraudObjectID",
                table: "StoreAntiFraud",
                column: "AntiFraudObjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopkeeperAcquirierCredcardBrand");

            migrationBuilder.DropTable(
                name: "StoreAcquirier");

            migrationBuilder.DropTable(
                name: "StoreAntiFraud");

            migrationBuilder.DropTable(
                name: "TransactionRegistries");

            migrationBuilder.DropTable(
                name: "Shopkeepers");

            migrationBuilder.DropTable(
                name: "Acquiriers");

            migrationBuilder.DropTable(
                name: "AntiFrauds");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
