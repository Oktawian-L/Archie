using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptoAPI.Migrations
{
    public partial class TickerStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TickerStorage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    low = table.Column<decimal>(nullable: false),
                    high = table.Column<decimal>(nullable: false),
                    vwap = table.Column<decimal>(nullable: false),
                    volume = table.Column<decimal>(nullable: false),
                    last = table.Column<decimal>(nullable: false),
                    ask = table.Column<decimal>(nullable: false),
                    bid = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TickerStorage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TickerStorage");
        }
    }
}
