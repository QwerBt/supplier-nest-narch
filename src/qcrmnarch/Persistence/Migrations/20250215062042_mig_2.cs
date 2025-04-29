using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("19e9437d-05e1-44e0-ba2e-3125690fd79c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d6f9de0-071b-4661-9450-25066aac861c"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 202, 231, 166, 102, 143, 242, 250, 101, 238, 152, 131, 163, 4, 236, 181, 191, 162, 248, 252, 86, 241, 50, 65, 112, 250, 228, 150, 16, 44, 225, 130, 210, 30, 5, 0, 61, 161, 38, 20, 88, 137, 144, 10, 196, 244, 92, 203, 0, 209, 218, 173, 250, 247, 155, 199, 201, 107, 72, 115, 142, 244, 112, 72, 181 }, new byte[] { 36, 33, 17, 43, 115, 89, 114, 189, 125, 52, 37, 204, 69, 226, 75, 36, 2, 167, 187, 164, 205, 94, 22, 187, 241, 177, 148, 116, 89, 29, 221, 79, 124, 174, 116, 74, 17, 93, 119, 77, 14, 217, 234, 70, 141, 65, 141, 186, 158, 187, 139, 236, 97, 29, 20, 162, 108, 82, 28, 9, 186, 95, 196, 196, 85, 63, 187, 78, 178, 215, 243, 39, 248, 117, 11, 52, 241, 110, 114, 164, 128, 91, 16, 166, 190, 28, 199, 90, 195, 74, 175, 103, 157, 117, 254, 242, 34, 77, 113, 218, 35, 135, 26, 114, 228, 46, 40, 15, 132, 189, 180, 203, 49, 225, 4, 179, 85, 245, 178, 158, 28, 146, 110, 28, 27, 90, 78, 225 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c5262558-94d7-4d4b-9a1d-c63b5d59f24d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c5262558-94d7-4d4b-9a1d-c63b5d59f24d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5af8ccb7-5d85-4599-9d59-5cbf948af836"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2d6f9de0-071b-4661-9450-25066aac861c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 176, 200, 121, 6, 215, 146, 1, 131, 202, 61, 15, 168, 102, 126, 203, 61, 85, 254, 73, 112, 128, 49, 23, 115, 86, 151, 90, 50, 221, 55, 1, 97, 248, 55, 33, 37, 2, 201, 96, 23, 81, 252, 105, 171, 120, 115, 147, 4, 11, 219, 88, 18, 7, 129, 41, 236, 109, 207, 53, 58, 73, 55, 156, 253 }, new byte[] { 235, 112, 188, 73, 3, 111, 146, 31, 66, 152, 97, 24, 135, 104, 79, 37, 106, 8, 134, 233, 149, 203, 24, 234, 165, 68, 218, 177, 233, 58, 152, 73, 9, 69, 92, 235, 8, 251, 77, 159, 51, 93, 168, 23, 0, 79, 120, 41, 84, 75, 38, 207, 173, 199, 184, 13, 208, 179, 251, 150, 55, 192, 111, 125, 82, 62, 220, 181, 45, 117, 150, 167, 210, 42, 104, 8, 92, 217, 254, 244, 1, 240, 92, 108, 181, 104, 94, 228, 244, 209, 255, 83, 29, 163, 121, 251, 64, 177, 188, 118, 218, 165, 116, 179, 1, 47, 237, 127, 137, 105, 148, 184, 225, 171, 246, 65, 120, 157, 111, 161, 116, 135, 210, 127, 79, 142, 138, 159 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("19e9437d-05e1-44e0-ba2e-3125690fd79c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2d6f9de0-071b-4661-9450-25066aac861c") });
        }
    }
}
