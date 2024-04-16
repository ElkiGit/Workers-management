using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesServer.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRolesList_EmployeeList_EmployeeId",
                table: "EmployeeRolesList");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRolesList_RoleList_RoleId",
                table: "EmployeeRolesList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleList",
                table: "RoleList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRolesList",
                table: "EmployeeRolesList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeList",
                table: "EmployeeList");

            migrationBuilder.RenameTable(
                name: "RoleList",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "EmployeeRolesList",
                newName: "EmployeeRoles");

            migrationBuilder.RenameTable(
                name: "EmployeeList",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRolesList_RoleId",
                table: "EmployeeRoles",
                newName: "IX_EmployeeRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Role_RoleId",
                table: "EmployeeRoles",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Employee_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRoles_Role_RoleId",
                table: "EmployeeRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRoles",
                table: "EmployeeRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "RoleList");

            migrationBuilder.RenameTable(
                name: "EmployeeRoles",
                newName: "EmployeeRolesList");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "EmployeeList");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRoles_RoleId",
                table: "EmployeeRolesList",
                newName: "IX_EmployeeRolesList_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleList",
                table: "RoleList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRolesList",
                table: "EmployeeRolesList",
                columns: new[] { "EmployeeId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeList",
                table: "EmployeeList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRolesList_EmployeeList_EmployeeId",
                table: "EmployeeRolesList",
                column: "EmployeeId",
                principalTable: "EmployeeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRolesList_RoleList_RoleId",
                table: "EmployeeRolesList",
                column: "RoleId",
                principalTable: "RoleList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
