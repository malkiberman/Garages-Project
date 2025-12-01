using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Garages.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MisparMosah = table.Column<int>(type: "integer", nullable: false),
                    ShemMosah = table.Column<string>(type: "text", nullable: true),
                    CodSugMosah = table.Column<int>(type: "integer", nullable: false),
                    SugMosah = table.Column<string>(type: "text", nullable: true),
                    Ktovet = table.Column<string>(type: "text", nullable: true),
                    Yishuv = table.Column<string>(type: "text", nullable: true),
                    Telephone = table.Column<string>(type: "text", nullable: true),
                    Mikud = table.Column<int>(type: "integer", nullable: false),
                    CodMiktzoa = table.Column<int>(type: "integer", nullable: false),
                    Miktzoa = table.Column<string>(type: "text", nullable: true),
                    MenahelMiktzoa = table.Column<string>(type: "text", nullable: true),
                    RashamHavarot = table.Column<long>(type: "bigint", nullable: false),
                    Testime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
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
