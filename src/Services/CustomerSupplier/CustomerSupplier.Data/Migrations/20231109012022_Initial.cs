using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerSupplier.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSuppliersAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerSupplierId = table.Column<int>(type: "integer", nullable: false),
                    Road = table.Column<string>(type: "varchar(100)", nullable: false),
                    District = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    State = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSuppliersAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSuppliersAddress_CustomerSuppliers_CustomerSupplier~",
                        column: x => x.CustomerSupplierId,
                        principalTable: "CustomerSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSuppliersContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerSupplierId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSuppliersContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSuppliersContact_CustomerSuppliers_CustomerSupplier~",
                        column: x => x.CustomerSupplierId,
                        principalTable: "CustomerSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSuppliersAddress_CustomerSupplierId",
                table: "CustomerSuppliersAddress",
                column: "CustomerSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSuppliersContact_CustomerSupplierId",
                table: "CustomerSuppliersContact",
                column: "CustomerSupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSuppliersAddress");

            migrationBuilder.DropTable(
                name: "CustomerSuppliersContact");

            migrationBuilder.DropTable(
                name: "CustomerSuppliers");
        }
    }
}
