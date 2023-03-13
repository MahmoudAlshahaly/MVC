using Microsoft.EntityFrameworkCore.Migrations;

namespace Day2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degree = table.Column<int>(type: "int", nullable: false),
                    mindegree = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.id);
                    table.ForeignKey(
                        name: "FK_instructors_departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "trainees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainees", x => x.id);
                    table.ForeignKey(
                        name: "FK_trainees_departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    Coursesid = table.Column<int>(type: "int", nullable: false),
                    Instructorsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.Coursesid, x.Instructorsid });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_courses_Coursesid",
                        column: x => x.Coursesid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_instructors_Instructorsid",
                        column: x => x.Instructorsid,
                        principalTable: "instructors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "courseResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Trainee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_courseResults_courses_Course_id",
                        column: x => x.Course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_courseResults_trainees_Trainee_id",
                        column: x => x.Trainee_id,
                        principalTable: "trainees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_Instructorsid",
                table: "CourseInstructor",
                column: "Instructorsid");

            migrationBuilder.CreateIndex(
                name: "IX_courseResults_Course_id",
                table: "courseResults",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_courseResults_Trainee_id",
                table: "courseResults",
                column: "Trainee_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_Department_id",
                table: "courses",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_Department_id",
                table: "instructors",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_Department_id",
                table: "trainees",
                column: "Department_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "courseResults");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "trainees");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
