using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DistributionCenterAddUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_distribution_center_document",
                table: "distribution_center");

            migrationBuilder.DropIndex(
                name: "ix_distribution_center_internal_code",
                table: "distribution_center");

            migrationBuilder.DropIndex(
                name: "ix_distribution_center_internal_code_document",
                table: "distribution_center");

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_document",
                table: "distribution_center",
                column: "document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_internal_code",
                table: "distribution_center",
                column: "internal_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_internal_code_document",
                table: "distribution_center",
                columns: new[] { "internal_code", "document" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_distribution_center_document",
                table: "distribution_center");

            migrationBuilder.DropIndex(
                name: "ix_distribution_center_internal_code",
                table: "distribution_center");

            migrationBuilder.DropIndex(
                name: "ix_distribution_center_internal_code_document",
                table: "distribution_center");

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_document",
                table: "distribution_center",
                column: "document");

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_internal_code",
                table: "distribution_center",
                column: "internal_code");

            migrationBuilder.CreateIndex(
                name: "ix_distribution_center_internal_code_document",
                table: "distribution_center",
                columns: new[] { "internal_code", "document" });
        }
    }
}
