using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Bateeq.Service.Pos.Lib.Migrations
{
    public partial class initial_SalesReport1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    _CreatedUtc = table.Column<DateTime>(nullable: false),
                    _CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    _LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _IsDeleted = table.Column<bool>(nullable: false),
                    _DeletedUtc = table.Column<DateTime>(nullable: false),
                    _DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    ItemCode = table.Column<string>(maxLength: 255, nullable: true),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<string>(maxLength: 255, nullable: true),
                    Category = table.Column<string>(maxLength: 255, nullable: true),
                    Collection = table.Column<string>(maxLength: 255, nullable: true),
                    SeasonCode = table.Column<string>(maxLength: 255, nullable: true),
                    SeasonYear = table.Column<string>(maxLength: 255, nullable: true),
                    ItemArticleRealizationOrder = table.Column<string>(maxLength: 255, nullable: true),
                    TransactionNo = table.Column<string>(maxLength: 255, nullable: true),
                    ItemName = table.Column<string>(maxLength: 255, nullable: true),
                    Color = table.Column<string>(maxLength: 255, nullable: true),
                    Size = table.Column<string>(maxLength: 255, nullable: true),
                    Style = table.Column<string>(maxLength: 255, nullable: true),
                    Group = table.Column<string>(maxLength: 255, nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    OriginalCost = table.Column<double>(nullable: false),
                    Gross = table.Column<double>(nullable: false),
                    Nett = table.Column<double>(nullable: false),
                    Discount1 = table.Column<double>(nullable: false),
                    Discount2 = table.Column<double>(nullable: false),
                    DiscountNominal = table.Column<double>(nullable: false),
                    SpecialDiscount = table.Column<double>(nullable: false),
                    TotalOriCost = table.Column<double>(nullable: false),
                    TotalGross = table.Column<double>(nullable: false),
                    TotalNett = table.Column<double>(nullable: false),
                    Margin = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesReports");
        }
    }
}
