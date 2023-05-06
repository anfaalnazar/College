using Microsoft.EntityFrameworkCore.Migrations;

namespace College.Migrations
{
    public partial class AddCourseAndStudentCourseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(maxLength: 50, nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Fees = table.Column<int>(nullable: false),
                    Is_Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "studentcourse",
                columns: table => new
                {
                    StudentCourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Is_Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentcourse", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_studentcourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentcourse_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentcourse_CourseId",
                table: "studentcourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_studentcourse_StudentId",
                table: "studentcourse",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentcourse");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
