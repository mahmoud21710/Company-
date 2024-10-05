using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.G04.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class nnnnnnnnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependent_Employees_ParentId",
                table: "Dependent");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Departments_DepartmentsId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependent",
                table: "Dependent");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Dependent",
                newName: "Dependents");

            migrationBuilder.RenameIndex(
                name: "IX_Project_DepartmentsId",
                table: "Projects",
                newName: "IX_Projects_DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Dependent_ParentId",
                table: "Dependents",
                newName: "IX_Dependents_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Cairo",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_ParentId",
                table: "Dependents",
                column: "ParentId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_DepartmentsId",
                table: "Projects",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_ParentId",
                table: "Dependents");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_DepartmentsId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Dependents",
                newName: "Dependent");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_DepartmentsId",
                table: "Project",
                newName: "IX_Project_DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Dependents_ParentId",
                table: "Dependent",
                newName: "IX_Dependent_ParentId");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Cairo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependent",
                table: "Dependent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependent_Employees_ParentId",
                table: "Dependent",
                column: "ParentId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Departments_DepartmentsId",
                table: "Project",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
