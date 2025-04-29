using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c5262558-94d7-4d4b-9a1d-c63b5d59f24d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836"));

            migrationBuilder.CreateTable(
                name: "CompanyBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBrands_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Admin", null },
                    { 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Read", null },
                    { 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Write", null },
                    { 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Create", null },
                    { 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Update", null },
                    { 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Delete", null },
                    { 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Admin", null },
                    { 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Read", null },
                    { 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Write", null },
                    { 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Create", null },
                    { 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Update", null },
                    { 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyBrands.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("1f4ce70d-f8a8-472b-aa3e-5d5138934c1a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 4, 83, 248, 227, 89, 154, 130, 63, 30, 226, 200, 175, 239, 165, 121, 107, 128, 115, 125, 141, 157, 74, 197, 242, 226, 76, 139, 165, 96, 152, 229, 144, 126, 110, 164, 214, 204, 211, 222, 47, 251, 156, 76, 1, 220, 100, 125, 232, 164, 206, 55, 115, 252, 238, 201, 111, 143, 203, 98, 26, 136, 16, 241, 52 }, new byte[] { 75, 49, 219, 54, 252, 90, 180, 40, 33, 171, 52, 114, 9, 27, 164, 205, 127, 225, 169, 182, 137, 107, 240, 99, 237, 66, 186, 15, 121, 111, 145, 124, 31, 229, 19, 72, 118, 17, 7, 253, 49, 210, 161, 29, 186, 194, 129, 17, 254, 193, 37, 0, 35, 74, 40, 86, 33, 168, 140, 45, 237, 105, 95, 156, 117, 4, 99, 163, 166, 99, 242, 138, 151, 115, 149, 234, 188, 188, 76, 103, 167, 223, 110, 136, 7, 65, 100, 73, 31, 59, 119, 23, 202, 190, 43, 122, 166, 33, 200, 4, 61, 227, 49, 79, 178, 125, 239, 158, 188, 235, 144, 204, 141, 208, 173, 34, 196, 219, 175, 164, 57, 249, 67, 150, 107, 8, 127, 165 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0325b9f5-7e21-4e12-9959-8081eb12f9c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1f4ce70d-f8a8-472b-aa3e-5d5138934c1a") });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBrands_CompanyId",
                table: "CompanyBrands",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyBrands");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0325b9f5-7e21-4e12-9959-8081eb12f9c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f4ce70d-f8a8-472b-aa3e-5d5138934c1a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 202, 231, 166, 102, 143, 242, 250, 101, 238, 152, 131, 163, 4, 236, 181, 191, 162, 248, 252, 86, 241, 50, 65, 112, 250, 228, 150, 16, 44, 225, 130, 210, 30, 5, 0, 61, 161, 38, 20, 88, 137, 144, 10, 196, 244, 92, 203, 0, 209, 218, 173, 250, 247, 155, 199, 201, 107, 72, 115, 142, 244, 112, 72, 181 }, new byte[] { 36, 33, 17, 43, 115, 89, 114, 189, 125, 52, 37, 204, 69, 226, 75, 36, 2, 167, 187, 164, 205, 94, 22, 187, 241, 177, 148, 116, 89, 29, 221, 79, 124, 174, 116, 74, 17, 93, 119, 77, 14, 217, 234, 70, 141, 65, 141, 186, 158, 187, 139, 236, 97, 29, 20, 162, 108, 82, 28, 9, 186, 95, 196, 196, 85, 63, 187, 78, 178, 215, 243, 39, 248, 117, 11, 52, 241, 110, 114, 164, 128, 91, 16, 166, 190, 28, 199, 90, 195, 74, 175, 103, 157, 117, 254, 242, 34, 77, 113, 218, 35, 135, 26, 114, 228, 46, 40, 15, 132, 189, 180, 203, 49, 225, 4, 179, 85, 245, 178, 158, 28, 146, 110, 28, 27, 90, 78, 225 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c5262558-94d7-4d4b-9a1d-c63b5d59f24d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836") });
        }
    }
}
