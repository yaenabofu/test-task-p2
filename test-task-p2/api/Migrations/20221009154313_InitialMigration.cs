using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Snils = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thirdname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId1 = table.Column<int>(type: "int", nullable: true),
                    WorkerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specialties_Professions_ProfessionId1",
                        column: x => x.ProfessionId1,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specialties_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specialties_Workers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    WorkerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Workers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Терапевт", "Терапевт" },
                    { 2, "Кардиолог", "Кардиолог" },
                    { 3, "Офтальмолог", "Офтальмолог" },
                    { 4, "Аллерголог", "Аллерголог" },
                    { 5, "Водитель автобуса", "Водитель автобуса" },
                    { 6, "Пилот самолета", "Пилот самолета" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Birthday", "Name", "Snils", "Surname", "Thirdname" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 9, 20, 43, 11, 742, DateTimeKind.Local).AddTicks(4831), "Иван", "snils1", "Иванов", "Иванович" },
                    { 2, new DateTime(2022, 10, 9, 20, 43, 11, 743, DateTimeKind.Local).AddTicks(9724), "Name", "snils1", "Surname", "Thirdname" },
                    { 3, new DateTime(2022, 10, 9, 20, 43, 11, 743, DateTimeKind.Local).AddTicks(9767), "John", "snils1", "Doe", "Bismark" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "ProfessionId", "ProfessionId1", "WorkerId", "WorkerId1" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null },
                    { 2, 2, null, 1, null },
                    { 3, 3, null, 2, null },
                    { 4, 4, null, 2, null },
                    { 5, 5, null, 3, null },
                    { 6, 6, null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "WorkShifts",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "WorkerId", "WorkerId1" },
                values: new object[,]
                {
                    { 1, "Смена 1", new DateTime(2022, 10, 9, 22, 43, 11, 744, DateTimeKind.Local).AddTicks(2743), "Смена 1", new DateTime(2022, 10, 9, 20, 43, 11, 744, DateTimeKind.Local).AddTicks(2393), 1, null },
                    { 2, "Смена 2", new DateTime(2022, 10, 10, 1, 43, 11, 744, DateTimeKind.Local).AddTicks(7722), "Смена 2", new DateTime(2022, 10, 9, 23, 43, 11, 744, DateTimeKind.Local).AddTicks(7692), 1, null },
                    { 3, "Смена 3", new DateTime(2022, 10, 9, 22, 43, 11, 744, DateTimeKind.Local).AddTicks(7746), "Смена 3", new DateTime(2022, 10, 9, 20, 43, 11, 744, DateTimeKind.Local).AddTicks(7744), 2, null },
                    { 4, "Смена 3", new DateTime(2022, 10, 10, 1, 43, 11, 744, DateTimeKind.Local).AddTicks(7749), "Смена 3", new DateTime(2022, 10, 9, 23, 43, 11, 744, DateTimeKind.Local).AddTicks(7748), 2, null },
                    { 5, "Смена 4", new DateTime(2022, 10, 9, 22, 43, 11, 744, DateTimeKind.Local).AddTicks(7753), "Смена 4", new DateTime(2022, 10, 9, 20, 43, 11, 744, DateTimeKind.Local).AddTicks(7752), 3, null },
                    { 6, "Смена 5", new DateTime(2022, 10, 10, 1, 43, 11, 744, DateTimeKind.Local).AddTicks(7757), "Смена 5", new DateTime(2022, 10, 9, 23, 43, 11, 744, DateTimeKind.Local).AddTicks(7755), 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_ProfessionId",
                table: "Specialties",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_ProfessionId1",
                table: "Specialties",
                column: "ProfessionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_WorkerId",
                table: "Specialties",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_WorkerId1",
                table: "Specialties",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_WorkerId",
                table: "WorkShifts",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_WorkerId1",
                table: "WorkShifts",
                column: "WorkerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
