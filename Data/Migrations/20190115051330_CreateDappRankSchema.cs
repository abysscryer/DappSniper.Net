using Microsoft.EntityFrameworkCore.Migrations;

namespace DappSniper.Net.Data.Migrations
{
    public partial class CreateDappRankSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dapps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: true),
                    LogoPath = table.Column<string>(type: "varchar(64)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", nullable: true),
                    Category = table.Column<int>(nullable: true),
                    Protocol = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dapps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Address = table.Column<string>(type: "varchar(42)", nullable: false),
                    DappId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Address);
                    table.ForeignKey(
                        name: "FK_Contracts_Dapps_DappId",
                        column: x => x.DappId,
                        principalTable: "Dapps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    RecordId = table.Column<string>(nullable: false),
                    No = table.Column<int>(nullable: false),
                    DappId = table.Column<string>(nullable: false),
                    Balance = table.Column<long>(nullable: false),
                    Users24h = table.Column<int>(nullable: false),
                    Volume24h = table.Column<int>(nullable: false),
                    Volume7d = table.Column<int>(nullable: false),
                    Tx24h = table.Column<int>(nullable: false),
                    Tx7d = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranks_Dapps_DappId",
                        column: x => x.DappId,
                        principalTable: "Dapps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranks_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DappId",
                table: "Contracts",
                column: "DappId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_DappId",
                table: "Ranks",
                column: "DappId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_RecordId",
                table: "Ranks",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Dapps");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
