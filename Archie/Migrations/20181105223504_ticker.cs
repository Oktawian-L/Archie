using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Archie.Migrations
{
    public partial class ticker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ask = table.Column<decimal>(nullable: false),
                    bid = table.Column<decimal>(nullable: false),
                    high = table.Column<decimal>(nullable: false),
                    last = table.Column<decimal>(nullable: false),
                    low = table.Column<decimal>(nullable: false),
                    volume = table.Column<decimal>(nullable: false),
                    vwap = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                });

   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickers");

         
        }
    }
}
