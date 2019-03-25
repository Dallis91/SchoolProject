using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSubmitted = table.Column<string>(nullable: true),
                    Deadline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ApplicationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientPriority = table.Column<int>(nullable: false),
                    OurPriority = table.Column<int>(nullable: false),
                    AppointedTo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Attachments = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
