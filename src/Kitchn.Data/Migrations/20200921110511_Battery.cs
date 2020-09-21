using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchn.Data.Migrations
{
	public partial class Battery : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Batteries",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(nullable: true),
					Location = table.Column<string>(nullable: true),
					Type = table.Column<string>(nullable: true),
					LastCharged = table.Column<DateTime>(nullable: true),
					Rechargeable = table.Column<bool>(nullable: true),
					ExpiryDate = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Batteries", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Batteries");
		}
	}
}
