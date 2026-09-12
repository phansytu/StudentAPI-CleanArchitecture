using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipBoMonLopHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maBM = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    tenMon = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    tenLop = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Tên Lớp"),
                    chuyenNganh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "Tên chuyên ngành"),
                    boMonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.id);
                    table.ForeignKey(
                        name: "FK__LopHoc__boMonId",
                        column: x => x.boMonId,
                        principalTable: "BoMon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    msv = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    hoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    ngaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    diemTb = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    lopHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.id);
                    table.ForeignKey(
                        name: "FK__SinhVien__lopHoc",
                        column: x => x.lopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_boMonId",
                table: "LopHoc",
                column: "boMonId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_lopHocId",
                table: "SinhVien",
                column: "lopHocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "BoMon");
        }
    }
}
