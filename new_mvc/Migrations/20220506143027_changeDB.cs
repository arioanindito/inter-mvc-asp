using Microsoft.EntityFrameworkCore.Migrations;

namespace new_mvc.Migrations
{
    public partial class changeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesSubjectId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "CoursesSubjectId",
                table: "CourseStudent",
                newName: "CoursesCourseId");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "SubjectCode",
                table: "Courses",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourseId",
                table: "CourseStudent",
                column: "CoursesCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourseId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseStudent",
                newName: "CoursesSubjectId");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Courses",
                newName: "SubjectCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesSubjectId",
                table: "CourseStudent",
                column: "CoursesSubjectId",
                principalTable: "Courses",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
