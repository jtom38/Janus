using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Janus.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MainContact = table.Column<string>(nullable: true),
                    DateTimeLogged = table.Column<DateTime>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComputerIDs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    RAM = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    SkuNumber = table.Column<string>(nullable: true),
                    BiosManufacturer = table.Column<string>(nullable: true),
                    BiosName = table.Column<string>(nullable: true),
                    BiosVersion = table.Column<string>(nullable: true),
                    BiosStatus = table.Column<string>(nullable: true),
                    BiosSerialNumber = table.Column<string>(nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerIDs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IpAddressV4 = table.Column<string>(nullable: true),
                    IpAddressV6 = table.Column<string>(nullable: true),
                    MacAddress = table.Column<string>(nullable: true),
                    SubNet = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true),
                    DNS01 = table.Column<string>(nullable: true),
                    DNS02 = table.Column<string>(nullable: true),
                    DhcpEnabled = table.Column<bool>(nullable: false),
                    DhcpServer = table.Column<string>(nullable: true),
                    DateTimeAdded = table.Column<DateTime>(nullable: true),
                    ComputerID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DnsDomain = table.Column<string>(nullable: true),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    TenantID = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TenantIDs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    DateLogged = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantIDs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketComments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    PostedBy = table.Column<string>(nullable: true),
                    DateTimeCreated = table.Column<string>(nullable: true),
                    TicketID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HardDrives",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileSystem = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<string>(nullable: true),
                    TotalSpace = table.Column<string>(nullable: true),
                    DateTimeAdded = table.Column<string>(nullable: true),
                    DateTimeEdited = table.Column<string>(nullable: true),
                    ComputerID = table.Column<Guid>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false),
                    ComputerIDID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HardDrives_ComputerIDs_ComputerIDID",
                        column: x => x.ComputerIDID,
                        principalTable: "ComputerIDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WindowsUpdates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ComputerIDID = table.Column<Guid>(nullable: true),
                    HotFixID = table.Column<string>(nullable: true),
                    InstalledOn = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    DateTimeAdded = table.Column<DateTime>(nullable: false),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowsUpdates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WindowsUpdates_ComputerIDs_ComputerIDID",
                        column: x => x.ComputerIDID,
                        principalTable: "ComputerIDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    DateTimeEdited = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateTimeStarted = table.Column<DateTime>(nullable: false),
                    DateTimeFinished = table.Column<DateTime>(nullable: false),
                    TicketOwner = table.Column<string>(nullable: true),
                    TicketNumber = table.Column<int>(nullable: false),
                    SubmittedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ComputerID = table.Column<Guid>(nullable: true),
                    StatusID = table.Column<Guid>(nullable: true),
                    CategoryID = table.Column<Guid>(nullable: true),
                    SubCategoryID = table.Column<Guid>(nullable: true),
                    TenantID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_ComputerIDs_ComputerID",
                        column: x => x.ComputerID,
                        principalTable: "ComputerIDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Categories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardDrives_ComputerIDID",
                table: "HardDrives",
                column: "ComputerIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryID",
                table: "Tickets",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ComputerID",
                table: "Tickets",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusID",
                table: "Tickets",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SubCategoryID",
                table: "Tickets",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WindowsUpdates_ComputerIDID",
                table: "WindowsUpdates",
                column: "ComputerIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "HardDrives");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.DropTable(
                name: "TenantIDs");

            migrationBuilder.DropTable(
                name: "TicketComments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "WindowsUpdates");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "ComputerIDs");
        }
    }
}
