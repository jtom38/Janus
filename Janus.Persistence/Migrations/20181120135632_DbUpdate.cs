using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Janus.Persistence.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardDrives_ComputerIDs_ComputerIDID",
                table: "HardDrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_SubCategoryID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WindowsUpdates_ComputerIDs_ComputerIDID",
                table: "WindowsUpdates");

            migrationBuilder.DropIndex(
                name: "IX_HardDrives_ComputerIDID",
                table: "HardDrives");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "TicketComments");

            migrationBuilder.DropColumn(
                name: "ComputerIDID",
                table: "HardDrives");

            migrationBuilder.RenameColumn(
                name: "ComputerIDID",
                table: "WindowsUpdates",
                newName: "ComputerID");

            migrationBuilder.RenameIndex(
                name: "IX_WindowsUpdates_ComputerIDID",
                table: "WindowsUpdates",
                newName: "IX_WindowsUpdates_ComputerID");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantID",
                table: "Status",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ComputerID",
                table: "Network",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ComputerID",
                table: "HardDrives",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "HardDriveID",
                table: "ComputerIDs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NetworkID",
                table: "ComputerIDs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TicketID",
                table: "ComputerIDs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WindowsUpdatesID",
                table: "ComputerIDs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_TicketID",
                table: "TicketComments",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Network_ComputerID",
                table: "Network",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_HardDrives_ComputerID",
                table: "HardDrives",
                column: "ComputerID");

            migrationBuilder.AddForeignKey(
                name: "FK_HardDrives_ComputerIDs_ComputerID",
                table: "HardDrives",
                column: "ComputerID",
                principalTable: "ComputerIDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Network_ComputerIDs_ComputerID",
                table: "Network",
                column: "ComputerID",
                principalTable: "ComputerIDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketID",
                table: "TicketComments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_SubCategories_SubCategoryID",
                table: "Tickets",
                column: "SubCategoryID",
                principalTable: "SubCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WindowsUpdates_ComputerIDs_ComputerID",
                table: "WindowsUpdates",
                column: "ComputerID",
                principalTable: "ComputerIDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardDrives_ComputerIDs_ComputerID",
                table: "HardDrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Network_ComputerIDs_ComputerID",
                table: "Network");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketID",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_SubCategories_SubCategoryID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WindowsUpdates_ComputerIDs_ComputerID",
                table: "WindowsUpdates");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_TicketComments_TicketID",
                table: "TicketComments");

            migrationBuilder.DropIndex(
                name: "IX_Network_ComputerID",
                table: "Network");

            migrationBuilder.DropIndex(
                name: "IX_HardDrives_ComputerID",
                table: "HardDrives");

            migrationBuilder.DropColumn(
                name: "HardDriveID",
                table: "ComputerIDs");

            migrationBuilder.DropColumn(
                name: "NetworkID",
                table: "ComputerIDs");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "ComputerIDs");

            migrationBuilder.DropColumn(
                name: "WindowsUpdatesID",
                table: "ComputerIDs");

            migrationBuilder.RenameColumn(
                name: "ComputerID",
                table: "WindowsUpdates",
                newName: "ComputerIDID");

            migrationBuilder.RenameIndex(
                name: "IX_WindowsUpdates_ComputerID",
                table: "WindowsUpdates",
                newName: "IX_WindowsUpdates_ComputerIDID");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantID",
                table: "TicketComments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "TenantID",
                table: "Status",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "ComputerID",
                table: "Network",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ComputerID",
                table: "HardDrives",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComputerIDID",
                table: "HardDrives",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardDrives_ComputerIDID",
                table: "HardDrives",
                column: "ComputerIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_HardDrives_ComputerIDs_ComputerIDID",
                table: "HardDrives",
                column: "ComputerIDID",
                principalTable: "ComputerIDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categories_SubCategoryID",
                table: "Tickets",
                column: "SubCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WindowsUpdates_ComputerIDs_ComputerIDID",
                table: "WindowsUpdates",
                column: "ComputerIDID",
                principalTable: "ComputerIDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
