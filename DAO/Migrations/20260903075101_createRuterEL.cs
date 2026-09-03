using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAO.Migrations
{
    /// <inheritdoc />
    public partial class createRuterEL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scooter",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand = table.Column<string>(type: "text", nullable: false),
                    batterycapacity = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scooter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    starttime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    km = table.Column<double>(type: "double precision", nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: false),
                    appuserid = table.Column<int>(type: "integer", nullable: false),
                    scooterid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip", x => x.id);
                    table.ForeignKey(
                        name: "fk_trip_appuser_appuserid",
                        column: x => x.appuserid,
                        principalTable: "appuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_scooter_scooterid",
                        column: x => x.scooterid,
                        principalTable: "scooter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_trip_appuserid",
                table: "trip",
                column: "appuserid");

            migrationBuilder.CreateIndex(
                name: "ix_trip_scooterid",
                table: "trip",
                column: "scooterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "appuser");

            migrationBuilder.DropTable(
                name: "scooter");
        }
    }
}
