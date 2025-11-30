using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Garages.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    _id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mispar_mosah = table.Column<int>(type: "integer", nullable: false),
                    shem_mosah = table.Column<string>(type: "text", nullable: false),
                    cod_sug_mosah = table.Column<int>(type: "integer", nullable: false),
                    sug_mosah = table.Column<string>(type: "text", nullable: false),
                    ktovet = table.Column<string>(type: "text", nullable: false),
                    yishuv = table.Column<string>(type: "text", nullable: false),
                    telephone = table.Column<string>(type: "text", nullable: false),
                    mikud = table.Column<int>(type: "integer", nullable: false),
                    cod_miktzoa = table.Column<int>(type: "integer", nullable: false),
                    miktzoa = table.Column<string>(type: "text", nullable: false),
                    menahel_miktzoa = table.Column<string>(type: "text", nullable: false),
                    rasham_havarot = table.Column<long>(type: "bigint", nullable: false),
                    TESTIME = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x._id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");
        }
    }
}
