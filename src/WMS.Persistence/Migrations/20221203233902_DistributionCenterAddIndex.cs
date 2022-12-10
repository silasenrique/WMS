using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DistributionCenterAddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "distribution_center",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "internal_code",
                table: "distribution_center",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_updated",
                table: "distribution_center",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                table: "distribution_center",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "distribution_center",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "internal_code",
                table: "distribution_center",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_updated",
                table: "distribution_center",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_created",
                table: "distribution_center",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
