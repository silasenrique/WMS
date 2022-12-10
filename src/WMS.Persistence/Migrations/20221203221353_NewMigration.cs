using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "distribution_center",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    internalcode = table.Column<string>(name: "internal_code", type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    document = table.Column<string>(type: "text", nullable: false),
                    datecreated = table.Column<DateTimeOffset>(name: "date_created", type: "timestamp with time zone", nullable: false),
                    dateupdated = table.Column<DateTimeOffset>(name: "date_updated", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_distribution_center", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distribution_center");
        }
    }
}
