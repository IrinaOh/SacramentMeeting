using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class SpeakersAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeakerAssignment");

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpeakerName = table.Column<string>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    MeetingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingId",
                table: "Speaker",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.CreateTable(
                name: "SpeakerAssignment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedTopic = table.Column<string>(nullable: true),
                    MeetingID = table.Column<int>(nullable: false),
                    SpeakerName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerAssignment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpeakerAssignment_Meeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerAssignment_MeetingID",
                table: "SpeakerAssignment",
                column: "MeetingID");
        }
    }
}
