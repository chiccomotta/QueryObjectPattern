using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryObjectPattern.Migrations
{
    public partial class startDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientData",
                columns: table => new
                {
                    ClientId = table.Column<long>(nullable: false),
                    Data = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    UpdatedDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientData", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 30, nullable: true),
                    Cognome = table.Column<string>(maxLength: 30, nullable: true),
                    Matricola = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegulatoryEmailHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<Guid>(nullable: true),
                    EmailSubject = table.Column<string>(maxLength: 1000, nullable: true),
                    EmailBody = table.Column<string>(nullable: true),
                    EmailRecipients = table.Column<string>(maxLength: 2000, nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulatoryEmailHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellOut_ImportTranscoding",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TranscodingType = table.Column<string>(maxLength: 50, nullable: false),
                    SourceValue = table.Column<string>(maxLength: 100, nullable: false),
                    DestinationValue = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOut_ImportTranscoding", x => new { x.TranscodingType, x.SourceValue });
                });

            migrationBuilder.CreateTable(
                name: "Spices",
                columns: table => new
                {
                    SpiceID = table.Column<int>(nullable: false),
                    SpiceMixName = table.Column<string>(maxLength: 64, nullable: true),
                    Supplier = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spices", x => x.SpiceID);
                });

            migrationBuilder.CreateTable(
                name: "Test1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Cognome = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Spices_SpiceId",
                        column: x => x.SpiceId,
                        principalTable: "Spices",
                        principalColumn: "SpiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_SpiceId",
                table: "Books",
                column: "SpiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ClientData");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RegulatoryEmailHistory");

            migrationBuilder.DropTable(
                name: "SellOut_ImportTranscoding");

            migrationBuilder.DropTable(
                name: "Test1");

            migrationBuilder.DropTable(
                name: "Spices");
        }
    }
}
