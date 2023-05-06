using Microsoft.EntityFrameworkCore.Migrations;

namespace College.Migrations
{
    public partial class FeeRemittanceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feeremittance",
                columns: table => new
                {
                    FeeRemittanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    totalpaid = table.Column<int>(nullable: false),
                    remaining = table.Column<int>(nullable: false),
                    nowpaying = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feeremittance", x => x.FeeRemittanceId);
                    table.ForeignKey(
                        name: "FK_feeremittance_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feeremittance_Student_studentid",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feeremittance_CourseId",
                table: "feeremittance",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_feeremittance_studentid",
                table: "feeremittance",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feeremittance");
        }
    }
}
