using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iso2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iso3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonecode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Native = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emoji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentIndustryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Industries_Industries_ParentIndustryId",
                        column: x => x.ParentIndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobFunctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_JobFunctions_JobFunctionId",
                        column: x => x.JobFunctionId,
                        principalTable: "JobFunctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationValues_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyImages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyServices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionInvoices",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionInvoices", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionInvoices_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionOffers",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOffers", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionOffers_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionOrders",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOrders", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionOrders_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionWaybills",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionWaybills", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionWaybills_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionDetailId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionInvoiceDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionInvoiceDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionInvoiceDetails_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionOfferDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false),
                    AdditionalOfferInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOfferDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionOfferDetails_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionOrderDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOrderDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionOrderDetails_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionWaybillDetails",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionWaybillDetails", x => x.TransactionDetailId);
                    table.ForeignKey(
                        name: "FK_TransactionWaybillDetails_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    SpecificationValueId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSpecifications_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSpecifications_SpecificationValues_SpecificationValueId",
                        column: x => x.SpecificationValueId,
                        principalTable: "SpecificationValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemUoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UomId = table.Column<int>(type: "int", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemUoms_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemUoms_Uoms_UomId",
                        column: x => x.UomId,
                        principalTable: "Uoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentCategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metaller ve alaşımlar", "Metal Malzemeler", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Plastik ve polimer bazlı malzemeler", "Plastik ve Polimer Malzemeler", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahşap bazlı malzemeler", "Ahşap ve Ahşap Ürünleri", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seramik ve cam malzemeler", "Seramik ve Cam Malzemeler", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İnşaat ve yapı malzemeleri", "İnşaat Malzemeleri", null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kimyasal maddeler ve ürünler", "Kimya ve Kimyasal Malzemeler", null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekstil ve kumaş ürünleri", "Tekstil ve Tekstil Ürünleri", null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik ve elektrik bileşenleri", "Elektronik ve Elektrik Malzemeleri", null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Enerji üretim ve depolama malzemeleri", "Enerji Malzemeleri", null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Otomotiv sektörü için malzemeler", "Otomotiv Malzemeleri", null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tıbbi cihazlar ve sağlık ürünleri", "Tıbbi ve Sağlık Malzemeleri", null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ambalaj sektörüne yönelik malzemeler", "Ambalaj Malzemeleri", null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarım makineleri ve ürünleri", "Tarım ve Tarım Malzemeleri", null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havacılık ve uzay teknolojileri", "Havacılık ve Uzay Malzemeleri", null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Özel ve ileri teknoloji malzemeler", "Diğer Özel Malzemeler", null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Capital", "CreatedDate", "Currency", "DeletedDate", "Emoji", "Iso2", "Iso3", "Name", "Native", "Phonecode", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Kabul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AFN", null, null, "AF", "AFG", "Afghanistan", "?????????", "93", null },
                    { 2, "Mariehamn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "AX", "ALA", "Aland Islands", "Åland", "+358-18", null },
                    { 3, "Tirana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL", null, null, "AL", "ALB", "Albania", "Shqipëria", "355", null },
                    { 4, "Algiers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DZD", null, null, "DZ", "DZA", "Algeria", "???????", "213", null },
                    { 5, "Pago Pago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "AS", "ASM", "American Samoa", "American Samoa", "+1-684", null },
                    { 6, "Andorra la Vella", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "AD", "AND", "Andorra", "Andorra", "376", null },
                    { 7, "Luanda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AOA", null, null, "AO", "AGO", "Angola", "Angola", "244", null },
                    { 8, "The Valley", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "AI", "AIA", "Anguilla", "Anguilla", "+1-264", null },
                    { 9, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AAD", null, null, "AQ", "ATA", "Antarctica", "Antarctica", "672", null },
                    { 10, "St. John's", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "AG", "ATG", "Antigua And Barbuda", "Antigua and Barbuda", "+1-268", null },
                    { 11, "Buenos Aires", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARS", null, null, "AR", "ARG", "Argentina", "Argentina", "54", null },
                    { 12, "Yerevan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD", null, null, "AM", "ARM", "Armenia", "????????", "374", null },
                    { 13, "Oranjestad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AWG", null, null, "AW", "ABW", "Aruba", "Aruba", "297", null },
                    { 14, "Canberra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "AU", "AUS", "Australia", "Australia", "61", null },
                    { 15, "Vienna", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "AT", "AUT", "Austria", "Österreich", "43", null },
                    { 16, "Baku", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZN", null, null, "AZ", "AZE", "Azerbaijan", "Az?rbaycan", "994", null },
                    { 17, "Nassau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BSD", null, null, "BS", "BHS", "The Bahamas", "Bahamas", "+1-242", null },
                    { 18, "Manama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHD", null, null, "BH", "BHR", "Bahrain", "????????", "973", null },
                    { 19, "Dhaka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BDT", null, null, "BD", "BGD", "Bangladesh", "Bangladesh", "880", null },
                    { 20, "Bridgetown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BBD", null, null, "BB", "BRB", "Barbados", "Barbados", "+1-246", null },
                    { 21, "Minsk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BYN", null, null, "BY", "BLR", "Belarus", "?????????", "375", null },
                    { 22, "Brussels", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "BE", "BEL", "Belgium", "België", "32", null },
                    { 23, "Belmopan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZD", null, null, "BZ", "BLZ", "Belize", "Belize", "501", null },
                    { 24, "Porto-Novo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "BJ", "BEN", "Benin", "Bénin", "229", null },
                    { 25, "Hamilton", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMD", null, null, "BM", "BMU", "Bermuda", "Bermuda", "+1-441", null },
                    { 26, "Thimphu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BTN", null, null, "BT", "BTN", "Bhutan", "?brug-yul", "975", null },
                    { 27, "Sucre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOB", null, null, "BO", "BOL", "Bolivia", "Bolivia", "591", null },
                    { 28, "Sarajevo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAM", null, null, "BA", "BIH", "Bosnia and Herzegovina", "Bosna i Hercegovina", "387", null },
                    { 29, "Gaborone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BWP", null, null, "BW", "BWA", "Botswana", "Botswana", "267", null },
                    { 30, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", null, null, "BV", "BVT", "Bouvet Island", "Bouvetøya", "0055", null },
                    { 31, "Brasilia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRL", null, null, "BR", "BRA", "Brazil", "Brasil", "55", null },
                    { 32, "Diego Garcia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "IO", "IOT", "British Indian Ocean Territory", "British Indian Ocean Territory", "246", null },
                    { 33, "Bandar Seri Begawan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BND", null, null, "BN", "BRN", "Brunei", "Negara Brunei Darussalam", "673", null },
                    { 34, "Sofia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BGN", null, null, "BG", "BGR", "Bulgaria", "????????", "359", null },
                    { 35, "Ouagadougou", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "BF", "BFA", "Burkina Faso", "Burkina Faso", "226", null },
                    { 36, "Bujumbura", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIF", null, null, "BI", "BDI", "Burundi", "Burundi", "257", null },
                    { 37, "Phnom Penh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KHR", null, null, "KH", "KHM", "Cambodia", "Kâmp?chéa", "855", null },
                    { 38, "Yaounde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "CM", "CMR", "Cameroon", "Cameroon", "237", null },
                    { 39, "Ottawa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAD", null, null, "CA", "CAN", "Canada", "Canada", "1", null },
                    { 40, "Praia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CVE", null, null, "CV", "CPV", "Cape Verde", "Cabo Verde", "238", null },
                    { 41, "George Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KYD", null, null, "KY", "CYM", "Cayman Islands", "Cayman Islands", "+1-345", null },
                    { 42, "Bangui", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "CF", "CAF", "Central African Republic", "Ködörösêse tî Bêafrîka", "236", null },
                    { 43, "N'Djamena", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "TD", "TCD", "Chad", "Tchad", "235", null },
                    { 44, "Santiago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLP", null, null, "CL", "CHL", "Chile", "Chile", "56", null },
                    { 45, "Beijing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNY", null, null, "CN", "CHN", "China", "??", "86", null },
                    { 46, "Flying Fish Cove", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "CX", "CXR", "Christmas Island", "Christmas Island", "61", null },
                    { 47, "West Island", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "CC", "CCK", "Cocos (Keeling) Islands", "Cocos (Keeling) Islands", "61", null },
                    { 48, "Bogotá", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "COP", null, null, "CO", "COL", "Colombia", "Colombia", "57", null },
                    { 49, "Moroni", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KMF", null, null, "KM", "COM", "Comoros", "Komori", "269", null },
                    { 50, "Brazzaville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "CG", "COG", "Congo", "République du Congo", "242", null },
                    { 51, "Kinshasa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CDF", null, null, "CD", "COD", "Democratic Republic of the Congo", "République démocratique du Congo", "243", null },
                    { 52, "Avarua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", null, null, "CK", "COK", "Cook Islands", "Cook Islands", "682", null },
                    { 53, "San Jose", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRC", null, null, "CR", "CRI", "Costa Rica", "Costa Rica", "506", null },
                    { 54, "Yamoussoukro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "CI", "CIV", "Cote D'Ivoire (Ivory Coast)", null, "225", null },
                    { 55, "Zagreb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HRK", null, null, "HR", "HRV", "Croatia", "Hrvatska", "385", null },
                    { 56, "Havana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUP", null, null, "CU", "CUB", "Cuba", "Cuba", "53", null },
                    { 57, "Nicosia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "CY", "CYP", "Cyprus", "??????", "357", null },
                    { 58, "Prague", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZK", null, null, "CZ", "CZE", "Czech Republic", "?eská republika", "420", null },
                    { 59, "Copenhagen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", null, null, "DK", "DNK", "Denmark", "Danmark", "45", null },
                    { 60, "Djibouti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJF", null, null, "DJ", "DJI", "Djibouti", "Djibouti", "253", null },
                    { 61, "Roseau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "DM", "DMA", "Dominica", "Dominica", "+1-767", null },
                    { 62, "Santo Domingo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOP", null, null, "DO", "DOM", "Dominican Republic", "República Dominicana", "+1-809 and 1-829", null },
                    { 63, "Dili", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "TL", "TLS", "East Timor", "Timor-Leste", "670", null },
                    { 64, "Quito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "EC", "ECU", "Ecuador", "Ecuador", "593", null },
                    { 65, "Cairo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EGP", null, null, "EG", "EGY", "Egypt", "??", "20", null },
                    { 66, "San Salvador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "SV", "SLV", "El Salvador", "El Salvador", "503", null },
                    { 67, "Malabo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "GQ", "GNQ", "Equatorial Guinea", "Guinea Ecuatorial", "240", null },
                    { 68, "Asmara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERN", null, null, "ER", "ERI", "Eritrea", "??", "291", null },
                    { 69, "Tallinn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "EE", "EST", "Estonia", "Eesti", "372", null },
                    { 70, "Addis Ababa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETB", null, null, "ET", "ETH", "Ethiopia", "?????", "251", null },
                    { 71, "Stanley", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FKP", null, null, "FK", "FLK", "Falkland Islands", "Falkland Islands", "500", null },
                    { 72, "Torshavn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", null, null, "FO", "FRO", "Faroe Islands", "Føroyar", "298", null },
                    { 73, "Suva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FJD", null, null, "FJ", "FJI", "Fiji Islands", "Fiji", "679", null },
                    { 74, "Helsinki", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "FI", "FIN", "Finland", "Suomi", "358", null },
                    { 75, "Paris", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "FR", "FRA", "France", "France", "33", null },
                    { 76, "Cayenne", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "GF", "GUF", "French Guiana", "Guyane française", "594", null },
                    { 77, "Papeete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XPF", null, null, "PF", "PYF", "French Polynesia", "Polynésie française", "689", null },
                    { 78, "Port-aux-Francais", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "TF", "ATF", "French Southern Territories", "Territoire des Terres australes et antarctiques fr", "262", null },
                    { 79, "Libreville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", null, null, "GA", "GAB", "Gabon", "Gabon", "241", null },
                    { 80, "Banjul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GMD", null, null, "GM", "GMB", "Gambia The", "Gambia", "220", null },
                    { 81, "Tbilisi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEL", null, null, "GE", "GEO", "Georgia", "??????????", "995", null },
                    { 82, "Berlin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "DE", "DEU", "Germany", "Deutschland", "49", null },
                    { 83, "Accra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHS", null, null, "GH", "GHA", "Ghana", "Ghana", "233", null },
                    { 84, "Gibraltar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GIP", null, null, "GI", "GIB", "Gibraltar", "Gibraltar", "350", null },
                    { 85, "Athens", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "GR", "GRC", "Greece", "??????", "30", null },
                    { 86, "Nuuk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", null, null, "GL", "GRL", "Greenland", "Kalaallit Nunaat", "299", null },
                    { 87, "St. George's", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "GD", "GRD", "Grenada", "Grenada", "+1-473", null },
                    { 88, "Basse-Terre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "GP", "GLP", "Guadeloupe", "Guadeloupe", "590", null },
                    { 89, "Hagatna", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "GU", "GUM", "Guam", "Guam", "+1-671", null },
                    { 90, "Guatemala City", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTQ", null, null, "GT", "GTM", "Guatemala", "Guatemala", "502", null },
                    { 91, "St Peter Port", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", null, null, "GG", "GGY", "Guernsey and Alderney", "Guernsey", "+44-1481", null },
                    { 92, "Conakry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GNF", null, null, "GN", "GIN", "Guinea", "Guinée", "224", null },
                    { 93, "Bissau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "GW", "GNB", "Guinea-Bissau", "Guiné-Bissau", "245", null },
                    { 94, "Georgetown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GYD", null, null, "GY", "GUY", "Guyana", "Guyana", "592", null },
                    { 95, "Port-au-Prince", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTG", null, null, "HT", "HTI", "Haiti", "Haïti", "509", null },
                    { 96, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "HM", "HMD", "Heard Island and McDonald Islands", "Heard Island and McDonald Islands", "672", null },
                    { 97, "Tegucigalpa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HNL", null, null, "HN", "HND", "Honduras", "Honduras", "504", null },
                    { 98, "Hong Kong", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HKD", null, null, "HK", "HKG", "Hong Kong S.A.R.", "??", "852", null },
                    { 99, "Budapest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HUF", null, null, "HU", "HUN", "Hungary", "Magyarország", "36", null },
                    { 100, "Reykjavik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISK", null, null, "IS", "ISL", "Iceland", "Ísland", "354", null },
                    { 101, "New Delhi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INR", null, null, "IN", "IND", "India", "???", "91", null },
                    { 102, "Jakarta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IDR", null, null, "ID", "IDN", "Indonesia", "Indonesia", "62", null },
                    { 103, "Tehran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRR", null, null, "IR", "IRN", "Iran", "?????", "98", null },
                    { 104, "Baghdad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IQD", null, null, "IQ", "IRQ", "Iraq", "??????", "964", null },
                    { 105, "Dublin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "IE", "IRL", "Ireland", "Éire", "353", null },
                    { 106, "Jerusalem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", null, null, "IL", "ISR", "Israel", "??????????", "972", null },
                    { 107, "Rome", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "IT", "ITA", "Italy", "Italia", "39", null },
                    { 108, "Kingston", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JMD", null, null, "JM", "JAM", "Jamaica", "Jamaica", "+1-876", null },
                    { 109, "Tokyo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPY", null, null, "JP", "JPN", "Japan", "??", "81", null },
                    { 110, "Saint Helier", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", null, null, "JE", "JEY", "Jersey", "Jersey", "+44-1534", null },
                    { 111, "Amman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JOD", null, null, "JO", "JOR", "Jordan", "??????", "962", null },
                    { 112, "Astana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KZT", null, null, "KZ", "KAZ", "Kazakhstan", "?????????", "7", null },
                    { 113, "Nairobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KES", null, null, "KE", "KEN", "Kenya", "Kenya", "254", null },
                    { 114, "Tarawa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "KI", "KIR", "Kiribati", "Kiribati", "686", null },
                    { 115, "Pyongyang", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KPW", null, null, "KP", "PRK", "North Korea", "??", "850", null },
                    { 116, "Seoul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KRW", null, null, "KR", "KOR", "South Korea", "???", "82", null },
                    { 117, "Kuwait City", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KWD", null, null, "KW", "KWT", "Kuwait", "??????", "965", null },
                    { 118, "Bishkek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KGS", null, null, "KG", "KGZ", "Kyrgyzstan", "??????????", "996", null },
                    { 119, "Vientiane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LAK", null, null, "LA", "LAO", "Laos", "??????", "856", null },
                    { 120, "Riga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "LV", "LVA", "Latvia", "Latvija", "371", null },
                    { 121, "Beirut", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LBP", null, null, "LB", "LBN", "Lebanon", "?????", "961", null },
                    { 122, "Maseru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LSL", null, null, "LS", "LSO", "Lesotho", "Lesotho", "266", null },
                    { 123, "Monrovia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LRD", null, null, "LR", "LBR", "Liberia", "Liberia", "231", null },
                    { 124, "Tripolis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LYD", null, null, "LY", "LBY", "Libya", "??????", "218", null },
                    { 125, "Vaduz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", null, null, "LI", "LIE", "Liechtenstein", "Liechtenstein", "423", null },
                    { 126, "Vilnius", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "LT", "LTU", "Lithuania", "Lietuva", "370", null },
                    { 127, "Luxembourg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "LU", "LUX", "Luxembourg", "Luxembourg", "352", null },
                    { 128, "Macao", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MOP", null, null, "MO", "MAC", "Macau S.A.R.", "??", "853", null },
                    { 129, "Skopje", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKD", null, null, "MK", "MKD", "North Macedonia", "??????? ??????????", "389", null },
                    { 130, "Antananarivo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGA", null, null, "MG", "MDG", "Madagascar", "Madagasikara", "261", null },
                    { 131, "Lilongwe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MWK", null, null, "MW", "MWI", "Malawi", "Malawi", "265", null },
                    { 132, "Kuala Lumpur", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYR", null, null, "MY", "MYS", "Malaysia", "Malaysia", "60", null },
                    { 133, "Male", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MVR", null, null, "MV", "MDV", "Maldives", "Maldives", "960", null },
                    { 134, "Bamako", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "ML", "MLI", "Mali", "Mali", "223", null },
                    { 135, "Valletta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "MT", "MLT", "Malta", "Malta", "356", null },
                    { 136, "Douglas, Isle of Man", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", null, null, "IM", "IMN", "Man (Isle of)", "Isle of Man", "+44-1624", null },
                    { 137, "Majuro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "MH", "MHL", "Marshall Islands", "M?aje?", "692", null },
                    { 138, "Fort-de-France", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "MQ", "MTQ", "Martinique", "Martinique", "596", null },
                    { 139, "Nouakchott", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MRO", null, null, "MR", "MRT", "Mauritania", "?????????", "222", null },
                    { 140, "Port Louis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MUR", null, null, "MU", "MUS", "Mauritius", "Maurice", "230", null },
                    { 141, "Mamoudzou", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "YT", "MYT", "Mayotte", "Mayotte", "262", null },
                    { 142, "Ciudad de México", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MXN", null, null, "MX", "MEX", "Mexico", "México", "52", null },
                    { 143, "Palikir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "FM", "FSM", "Micronesia", "Micronesia", "691", null },
                    { 144, "Chisinau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MDL", null, null, "MD", "MDA", "Moldova", "Moldova", "373", null },
                    { 145, "Monaco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "MC", "MCO", "Monaco", "Monaco", "377", null },
                    { 146, "Ulan Bator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MNT", null, null, "MN", "MNG", "Mongolia", "?????? ???", "976", null },
                    { 147, "Podgorica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "ME", "MNE", "Montenegro", "???? ????", "382", null },
                    { 148, "Plymouth", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "MS", "MSR", "Montserrat", "Montserrat", "+1-664", null },
                    { 149, "Rabat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAD", null, null, "MA", "MAR", "Morocco", "??????", "212", null },
                    { 150, "Maputo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MZN", null, null, "MZ", "MOZ", "Mozambique", "Moçambique", "258", null },
                    { 151, "Nay Pyi Taw", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MMK", null, null, "MM", "MMR", "Myanmar", "??????", "95", null },
                    { 152, "Windhoek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAD", null, null, "NA", "NAM", "Namibia", "Namibia", "264", null },
                    { 153, "Yaren", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "NR", "NRU", "Nauru", "Nauru", "674", null },
                    { 154, "Kathmandu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NPR", null, null, "NP", "NPL", "Nepal", "???", "977", null },
                    { 155, "Kralendijk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "BQ", "BES", "Bonaire, Sint Eustatius and Saba", "Caribisch Nederland", "599", null },
                    { 156, "Amsterdam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "NL", "NLD", "Netherlands", "Nederland", "31", null },
                    { 157, "Noumea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XPF", null, null, "NC", "NCL", "New Caledonia", "Nouvelle-Calédonie", "687", null },
                    { 158, "Wellington", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", null, null, "NZ", "NZL", "New Zealand", "New Zealand", "64", null },
                    { 159, "Managua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIO", null, null, "NI", "NIC", "Nicaragua", "Nicaragua", "505", null },
                    { 160, "Niamey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "NE", "NER", "Niger", "Niger", "227", null },
                    { 161, "Abuja", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NGN", null, null, "NG", "NGA", "Nigeria", "Nigeria", "234", null },
                    { 162, "Alofi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", null, null, "NU", "NIU", "Niue", "Niu?", "683", null },
                    { 163, "Kingston", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "NF", "NFK", "Norfolk Island", "Norfolk Island", "672", null },
                    { 164, "Saipan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "MP", "MNP", "Northern Mariana Islands", "Northern Mariana Islands", "+1-670", null },
                    { 165, "Oslo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", null, null, "NO", "NOR", "Norway", "Norge", "47", null },
                    { 166, "Muscat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMR", null, null, "OM", "OMN", "Oman", "???", "968", null },
                    { 167, "Islamabad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKR", null, null, "PK", "PAK", "Pakistan", "Pakistan", "92", null },
                    { 168, "Melekeok", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "PW", "PLW", "Palau", "Palau", "680", null },
                    { 169, "East Jerusalem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", null, null, "PS", "PSE", "Palestinian Territory Occupied", "??????", "970", null },
                    { 170, "Panama City", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAB", null, null, "PA", "PAN", "Panama", "Panamá", "507", null },
                    { 171, "Port Moresby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PGK", null, null, "PG", "PNG", "Papua new Guinea", "Papua Niugini", "675", null },
                    { 172, "Asuncion", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PYG", null, null, "PY", "PRY", "Paraguay", "Paraguay", "595", null },
                    { 173, "Lima", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PEN", null, null, "PE", "PER", "Peru", "Perú", "51", null },
                    { 174, "Manila", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHP", null, null, "PH", "PHL", "Philippines", "Pilipinas", "63", null },
                    { 175, "Adamstown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", null, null, "PN", "PCN", "Pitcairn Island", "Pitcairn Islands", "870", null },
                    { 176, "Warsaw", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLN", null, null, "PL", "POL", "Poland", "Polska", "48", null },
                    { 177, "Lisbon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "PT", "PRT", "Portugal", "Portugal", "351", null },
                    { 178, "San Juan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "PR", "PRI", "Puerto Rico", "Puerto Rico", "+1-787 and 1-939", null },
                    { 179, "Doha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "QAR", null, null, "QA", "QAT", "Qatar", "???", "974", null },
                    { 180, "Saint-Denis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "RE", "REU", "Reunion", "La Réunion", "262", null },
                    { 181, "Bucharest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RON", null, null, "RO", "ROU", "Romania", "România", "40", null },
                    { 182, "Moscow", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUB", null, null, "RU", "RUS", "Russia", "??????", "7", null },
                    { 183, "Kigali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RWF", null, null, "RW", "RWA", "Rwanda", "Rwanda", "250", null },
                    { 184, "Jamestown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SHP", null, null, "SH", "SHN", "Saint Helena", "Saint Helena", "290", null },
                    { 185, "Basseterre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "KN", "KNA", "Saint Kitts And Nevis", "Saint Kitts and Nevis", "+1-869", null },
                    { 186, "Castries", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "LC", "LCA", "Saint Lucia", "Saint Lucia", "+1-758", null },
                    { 187, "Saint-Pierre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "PM", "SPM", "Saint Pierre and Miquelon", "Saint-Pierre-et-Miquelon", "508", null },
                    { 188, "Kingstown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", null, null, "VC", "VCT", "Saint Vincent And The Grenadines", "Saint Vincent and the Grenadines", "+1-784", null },
                    { 189, "Gustavia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "BL", "BLM", "Saint-Barthelemy", "Saint-Barthélemy", "590", null },
                    { 190, "Marigot", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "MF", "MAF", "Saint-Martin (French part)", "Saint-Martin", "590", null },
                    { 191, "Apia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WST", null, null, "WS", "WSM", "Samoa", "Samoa", "685", null },
                    { 192, "San Marino", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "SM", "SMR", "San Marino", "San Marino", "378", null },
                    { 193, "Sao Tome", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "STD", null, null, "ST", "STP", "Sao Tome and Principe", "São Tomé e Príncipe", "239", null },
                    { 194, "Riyadh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAR", null, null, "SA", "SAU", "Saudi Arabia", "??????? ??????? ????????", "966", null },
                    { 195, "Dakar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "SN", "SEN", "Senegal", "Sénégal", "221", null },
                    { 196, "Belgrade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RSD", null, null, "RS", "SRB", "Serbia", "??????", "381", null },
                    { 197, "Victoria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCR", null, null, "SC", "SYC", "Seychelles", "Seychelles", "248", null },
                    { 198, "Freetown", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLL", null, null, "SL", "SLE", "Sierra Leone", "Sierra Leone", "232", null },
                    { 199, "Singapur", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SGD", null, null, "SG", "SGP", "Singapore", "Singapore", "65", null },
                    { 200, "Bratislava", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "SK", "SVK", "Slovakia", "Slovensko", "421", null },
                    { 201, "Ljubljana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "SI", "SVN", "Slovenia", "Slovenija", "386", null },
                    { 202, "Honiara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SBD", null, null, "SB", "SLB", "Solomon Islands", "Solomon Islands", "677", null },
                    { 203, "Mogadishu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOS", null, null, "SO", "SOM", "Somalia", "Soomaaliya", "252", null },
                    { 204, "Pretoria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAR", null, null, "ZA", "ZAF", "South Africa", "South Africa", "27", null },
                    { 205, "Grytviken", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", null, null, "GS", "SGS", "South Georgia", "South Georgia", "500", null },
                    { 206, "Juba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSP", null, null, "SS", "SSD", "South Sudan", "South Sudan", "211", null },
                    { 207, "Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "ES", "ESP", "Spain", "España", "34", null },
                    { 208, "Colombo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LKR", null, null, "LK", "LKA", "Sri Lanka", "?r? la?k?va", "94", null },
                    { 209, "Khartoum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDG", null, null, "SD", "SDN", "Sudan", "???????", "249", null },
                    { 210, "Paramaribo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRD", null, null, "SR", "SUR", "Suriname", "Suriname", "597", null },
                    { 211, "Longyearbyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", null, null, "SJ", "SJM", "Svalbard And Jan Mayen Islands", "Svalbard og Jan Mayen", "47", null },
                    { 212, "Mbabane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SZL", null, null, "SZ", "SWZ", "Swaziland", "Swaziland", "268", null },
                    { 213, "Stockholm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEK", null, null, "SE", "SWE", "Sweden", "Sverige", "46", null },
                    { 214, "Bern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", null, null, "CH", "CHE", "Switzerland", "Schweiz", "41", null },
                    { 215, "Damascus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SYP", null, null, "SY", "SYR", "Syria", "?????", "963", null },
                    { 216, "Taipei", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TWD", null, null, "TW", "TWN", "Taiwan", "??", "886", null },
                    { 217, "Dushanbe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJS", null, null, "TJ", "TJK", "Tajikistan", "??????????", "992", null },
                    { 218, "Dodoma", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TZS", null, null, "TZ", "TZA", "Tanzania", "Tanzania", "255", null },
                    { 219, "Bangkok", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "THB", null, null, "TH", "THA", "Thailand", "?????????", "66", null },
                    { 220, "Lome", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", null, null, "TG", "TGO", "Togo", "Togo", "228", null },
                    { 221, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", null, null, "TK", "TKL", "Tokelau", "Tokelau", "690", null },
                    { 222, "Nuku'alofa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOP", null, null, "TO", "TON", "Tonga", "Tonga", "676", null },
                    { 223, "Port of Spain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TTD", null, null, "TT", "TTO", "Trinidad And Tobago", "Trinidad and Tobago", "+1-868", null },
                    { 224, "Tunis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TND", null, null, "TN", "TUN", "Tunisia", "???", "216", null },
                    { 225, "Ankara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRY", null, null, "TR", "TUR", "Turkey", "Türkiye", "90", null },
                    { 226, "Ashgabat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TMT", null, null, "TM", "TKM", "Turkmenistan", "Türkmenistan", "993", null },
                    { 227, "Cockburn Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "TC", "TCA", "Turks And Caicos Islands", "Turks and Caicos Islands", "+1-649", null },
                    { 228, "Funafuti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", null, null, "TV", "TUV", "Tuvalu", "Tuvalu", "688", null },
                    { 229, "Kampala", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGX", null, null, "UG", "UGA", "Uganda", "Uganda", "256", null },
                    { 230, "Kyiv", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UAH", null, null, "UA", "UKR", "Ukraine", "???????", "380", null },
                    { 231, "Abu Dhabi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AED", null, null, "AE", "ARE", "United Arab Emirates", "???? ???????? ??????? ???????", "971", null },
                    { 232, "London", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", null, null, "GB", "GBR", "United Kingdom", "United Kingdom", "44", null },
                    { 233, "Washington", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "US", "USA", "United States", "United States", "1", null },
                    { 234, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "UM", "UMI", "United States Minor Outlying Islands", "United States Minor Outlying Islands", "1", null },
                    { 235, "Montevideo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UYU", null, null, "UY", "URY", "Uruguay", "Uruguay", "598", null },
                    { 236, "Tashkent", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZS", null, null, "UZ", "UZB", "Uzbekistan", "O‘zbekiston", "998", null },
                    { 237, "Port Vila", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VUV", null, null, "VU", "VUT", "Vanuatu", "Vanuatu", "678", null },
                    { 238, "Vatican City", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "VA", "VAT", "Vatican City State (Holy See)", "Vaticano", "379", null },
                    { 239, "Caracas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VES", null, null, "VE", "VEN", "Venezuela", "Venezuela", "58", null },
                    { 240, "Hanoi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VND", null, null, "VN", "VNM", "Vietnam", "Vi?t Nam", "84", null },
                    { 241, "Road Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "VG", "VGB", "Virgin Islands (British)", "British Virgin Islands", "+1-284", null },
                    { 242, "Charlotte Amalie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", null, null, "VI", "VIR", "Virgin Islands (US)", "United States Virgin Islands", "+1-340", null },
                    { 243, "Mata Utu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XPF", null, null, "WF", "WLF", "Wallis And Futuna Islands", "Wallis et Futuna", "681", null },
                    { 244, "El-Aaiun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAD", null, null, "EH", "ESH", "Western Sahara", "??????? ???????", "212", null },
                    { 245, "Sanaa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YER", null, null, "YE", "YEM", "Yemen", "???????", "967", null },
                    { 246, "Lusaka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZMW", null, null, "ZM", "ZMB", "Zambia", "Zambia", "260", null },
                    { 247, "Harare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZWL", null, null, "ZW", "ZWE", "Zimbabwe", "Zimbabwe", "263", null },
                    { 248, "Pristina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", null, null, "XK", "XKX", "Kosovo", "Republika e Kosovës", "383", null },
                    { 249, "Willemstad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANG", null, null, "CW", "CUW", "Curaçao", "Curaçao", "599", null },
                    { 250, "Philipsburg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANG", null, null, "SX", "SXM", "Sint Maarten (Dutch part)", "Sint Maarten", "1721", null }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "ParentIndustryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havacılık ve Savunma", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarım ve Ormancılık", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Otomotiv", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İş Hizmetleri", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kimyasallar", null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yapı", null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dağıtım, Toptan, Perakende", null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eğitim", null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektrik Ekipmanları", null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik", null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mühendislik ve Teknik Hizmetler", null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gıda, İçecek, Tütün", null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hükümet ve Askeriye", null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Makineler", null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Üretim (belirtilmemiş)", null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tıbbi ve Sağlık", null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metaller - Ham, Şekillendirilmiş, Üretilmiş", null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Madencilik, Petrol ve Gaz, Taş Ocağı", null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diğer", null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kağıt, Kağıt Ürünleri ve Baskı", null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Plastikler ve Kauçuk", null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekstil, Giyim, Deri", null, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taşımacılık ve Lojistik", null, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kamu Hizmetleri ve Telekomünikasyon", null, null }
                });

            migrationBuilder.InsertData(
                table: "JobFunctions",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mühendislik / Tasarım", null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tedarik Zinciri / Tedarik / Lojistik", null },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Üretim / Operasyonlar", null },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Genel Müdürlük", null },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Satış ve Pazarlama", null },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Diğer", null }
                });

            migrationBuilder.InsertData(
                table: "JobLevels",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Executive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Yönetici ", null },
                    { 2, "Director", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Koordinatör", null },
                    { 3, "Manager", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Müdür", null },
                    { 4, "Individual", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Bireysel Katkıda Bulunan", null },
                    { 5, "Owner", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mal sahibi", null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.GoogleLogin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Admin", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Read", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Write", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Create", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Update", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transactions.Delete", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Admin", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Read", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Write", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Create", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Update", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TransactionDetails.Delete", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Admin", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Read", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Write", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Create", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Update", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Categories.Delete", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Admin", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Read", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Write", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Create", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Update", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Delete", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Admin", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Read", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Write", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Create", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Update", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Delete", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Admin", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Read", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Write", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Create", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Update", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyContacts.Delete", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Admin", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Read", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Write", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Create", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Update", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyUsers.Delete", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Admin", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Read", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Write", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Create", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Update", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Delete", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Admin", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Read", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Write", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Create", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Update", null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemUoms.Delete", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Admin", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Read", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Write", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Create", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Update", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uoms.Delete", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Admin", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Read", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Write", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Create", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Update", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyImages.Delete", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Admin", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Read", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Write", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Create", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Update", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ProductImages.Delete", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Admin", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Read", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Write", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Create", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Update", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Delete", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Admin", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Read", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Write", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Create", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Update", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Delete", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Admin", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Read", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Write", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Create", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Update", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Delete", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Admin", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Read", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Write", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Create", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Update", null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Delete", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Admin", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Read", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Write", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Create", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Update", null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Items.Delete", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Admin", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Read", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Write", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Create", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Update", null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Delete", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Admin", null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Read", null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Write", null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Create", null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Update", null },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyServices.Delete", null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Admin", null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Read", null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Write", null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Create", null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Update", null },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Services.Delete", null },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Admin", null },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Read", null },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Write", null },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Create", null },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Update", null },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Delete", null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Admin", null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Read", null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Write", null },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Create", null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Update", null },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Delete", null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Admin", null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Read", null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Write", null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Create", null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Update", null },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Regions.Delete", null },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Admin", null },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Read", null },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Write", null },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Create", null },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Update", null },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Delete", null },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Admin", null },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Read", null },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Write", null },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Create", null },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Update", null },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Delete", null },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Admin", null },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Read", null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Write", null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Create", null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Update", null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Towns.Delete", null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Admin", null },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Read", null },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Write", null },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Create", null },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Update", null },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Delete", null },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Admin", null },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Read", null },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Write", null },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Create", null },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Update", null },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cities.Delete", null },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Admin", null },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Read", null },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Write", null },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Create", null },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Update", null },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Industries.Delete", null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Admin", null },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Read", null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Write", null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Create", null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Update", null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobFunctions.Delete", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Admin", null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Read", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Write", null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Create", null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Update", null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Delete", null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Admin", null },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Read", null },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Write", null },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Create", null },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Update", null },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Disciplines.Delete", null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Admin", null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Read", null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Write", null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Create", null },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Update", null },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "JobLevels.Delete", null },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Admin", null },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Read", null },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Write", null },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Create", null },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Update", null },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Roles.Delete", null },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Admin", null },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Read", null },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Write", null },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Create", null },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Update", null },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserRoles.Delete", null },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Admin", null },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Read", null },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Write", null },
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Create", null },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Update", null },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyAddresses.Delete", null },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Admin", null },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Read", null },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Write", null },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Create", null },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Update", null },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Countries.Delete", null },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Admin", null },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Read", null },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Write", null },
                    { 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Create", null },
                    { 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Update", null },
                    { 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Delete", null },
                    { 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Admin", null },
                    { 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Read", null },
                    { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Write", null },
                    { 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Create", null },
                    { 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Update", null },
                    { 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SpecificationValues.Delete", null },
                    { 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Admin", null },
                    { 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Read", null },
                    { 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Write", null },
                    { 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Create", null },
                    { 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Update", null },
                    { 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ItemSpecifications.Delete", null },
                    { 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Admin", null },
                    { 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Read", null },
                    { 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Write", null },
                    { 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Create", null },
                    { 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Update", null },
                    { 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Specifications.Delete", null },
                    { 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Admin", null },
                    { 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Read", null },
                    { 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Write", null },
                    { 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Create", null },
                    { 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Update", null },
                    { 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CompanyCategories.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Alıcı", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Tedarikçi", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Diğer", null }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şekil", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Renk", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malzeme", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ölçü", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0ee7c3a9-c87e-40a3-b13a-e85f443715fb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", null, null, new byte[] { 120, 74, 240, 17, 217, 28, 44, 64, 208, 233, 39, 236, 152, 88, 0, 216, 165, 224, 132, 73, 37, 24, 111, 214, 67, 73, 15, 167, 3, 10, 65, 98, 167, 133, 89, 45, 242, 107, 168, 254, 81, 185, 233, 187, 160, 199, 228, 145, 5, 106, 188, 235, 215, 71, 212, 169, 80, 116, 42, 141, 183, 5, 174, 122 }, new byte[] { 184, 218, 241, 205, 147, 49, 225, 12, 203, 112, 179, 21, 122, 82, 27, 11, 6, 163, 211, 169, 127, 17, 242, 57, 113, 248, 176, 130, 171, 36, 68, 234, 141, 6, 116, 96, 242, 80, 101, 165, 152, 253, 162, 73, 156, 162, 5, 209, 150, 112, 65, 236, 192, 91, 86, 20, 87, 206, 167, 139, 41, 94, 133, 148, 219, 64, 123, 179, 228, 132, 253, 204, 82, 126, 200, 160, 118, 199, 232, 151, 21, 15, 15, 162, 171, 18, 65, 114, 41, 123, 253, 85, 43, 230, 253, 225, 242, 254, 22, 101, 223, 16, 91, 36, 44, 212, 158, 174, 205, 81, 195, 252, 175, 19, 91, 67, 235, 7, 94, 29, 248, 168, 33, 205, 236, 165, 111, 169 }, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentCategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paslanmaz çelik, yapı çeliği", "Çelik", 1, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alüminyum ürünleri", "Alüminyum", 1, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bakır malzemeleri", "Bakır", 1, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pirinç alaşımları", "Pirinç", 1, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bronz malzemeleri", "Bronz", 1, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demir döküm, çelik döküm", "Döküm Malzemeleri", 1, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metal bazlı kablolar", "Tel ve Kablo Malzemeleri", 1, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PVC, PE, PP, ABS", "Termoplastikler", 2, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Epoksi, polyester, poliüretan", "Termosetler", 2, null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğal ve sentetik kauçuk", "Kauçuk Malzemeler", 2, null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cam elyaf, karbon fiber", "Kompozit Malzemeler", 2, null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çam, meşe, kayın", "Kereste", 3, null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahşap levhalar", "Kontrplak", 3, null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mobilya yapım malzemeleri", "MDF ve Sunta", 3, null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahşap yüzey kaplamaları", "Ahşap Kaplamalar", 3, null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İç ve dış kaplamalar", "Seramik Karolar", 4, null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Düz cam, temperli cam, lamine cam", "Cam Malzemeler", 4, null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüksek sıcaklığa dayanıklı seramikler", "Refrakter Malzemeler", 4, null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Binalar ve altyapılar için", "Çimento ve Beton Ürünleri", 5, null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Duvar malzemeleri", "Tuğla ve Briket", 5, null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Strafor, taş yünü, cam yünü", "Yalıtım Malzemeleri", 5, null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiremit, çelik çatı, membranlar", "Çatı Malzemeleri", 5, null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İç ve dış boya malzemeleri", "Boya ve Kaplamalar", 5, null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Asitler, bazlar, çözücüler", "Endüstriyel Kimyasallar", 6, null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Farklı endüstriyel uygulamalar", "Yapıştırıcılar ve Sızdırmazlık Malzemeleri", 6, null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boyama işlemleri için", "Boya ve Kaplama Kimyasalları", 6, null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ev ve endüstriyel kullanımlar", "Temizlik Kimyasalları", 6, null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pamuk, yün, ipek", "Doğal Lifler", 7, null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Polyester, naylon, akrilik", "Sentetik Lifler", 7, null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Örme, dokuma, non-woven", "Tekstil Kumaşları", 7, null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boya, apre malzemeleri", "Tekstil Kimyasalları", 7, null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gelişmiş nanoteknoloji malzemeleri", "Nanomalzemeler", 15, null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şekil hafızalı alaşımlar, piezoelektrik malzemeler", "Akıllı Malzemeler", 15, null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çevre dostu malzemeler", "Biyobozunur Malzemeler", 15, null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Direnç, kapasitör, entegre devreler", "Elektronik Komponentler", 8, null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektrik bağlantı ekipmanları", "Kablo ve Bağlantı Elemanları", 8, null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Enerji depolama çözümleri", "Piller ve Bataryalar", 8, null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik devre elemanları", "Yarı İletken Malzemeler", 8, null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güneş panelleri, rüzgar türbini parçaları", "Yenilenebilir Enerji Malzemeleri", 9, null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boru, vana, pompa", "Petrol ve Gaz Endüstrisi Malzemeleri", 9, null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lityum iyon piller, yakıt hücreleri", "Enerji Depolama Malzemeleri", 9, null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Motor parçaları, şasi, aksesuarlar", "Otomotiv Parçaları", 10, null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Araç lastikleri ve jantlar", "Lastik ve Jantlar", 10, null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Araç içi elektronik sistemler", "Otomotiv Elektroniği", 10, null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hastane ve sağlık ekipmanları", "Tıbbi Cihazlar ve Ekipmanlar", 11, null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ameliyat ve tıbbi müdahale ekipmanları", "Cerrahi Malzemeler", 11, null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tıbbi kullanım için tekstil", "Medikal Tekstil Ürünleri", 11, null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Biyomedikal uygulamalar için malzemeler", "Biyomalzemeler", 11, null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karton kutu, kağıt torba", "Karton ve Kağıt Ambalaj", 12, null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Poşet, şişe, kutu", "Plastik Ambalaj", 12, null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Teneke kutu, alüminyum folyo", "Metal Ambalaj", 12, null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cam şişeler ve kaplar", "Cam Ambalaj", 12, null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarım sektörüne yönelik makineler", "Tarım Makineleri ve Ekipmanları", 13, null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarım için kimyasal ve organik gübreler", "Gübre ve Toprak Düzenleyiciler", 13, null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarımsal sulama çözümleri", "Sulama Sistemleri", 13, null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sera yapımı ve ekipmanları", "Sera Malzemeleri", 13, null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karbon fiber, aramid fiber", "Kompozit Malzemeler", 14, null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havacılık ve uzay için özel alaşımlar", "Yüksek Performanslı Alaşımlar", 14, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "Description", "JobFunctionId", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Electrical", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Elektrik", null },
                    { 2, "Mechanical", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Mekanik", null },
                    { 3, "Industrial", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Endüstri", null },
                    { 4, "Design", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Tasarım", null },
                    { 5, "Civil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "İnşaat", null },
                    { 6, "Architectural", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Mimari", null },
                    { 7, "ComputerScience", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Bilgisayar Bilimi", null },
                    { 8, "Aerospace", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Havacılık ve Uzay", null },
                    { 9, "Environmental", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Çevre", null },
                    { 10, "Chemical", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Kimya", null },
                    { 11, "Consulting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Danışmanlık", null },
                    { 12, "Other", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, "Diğer", null },
                    { 13, "SupplyChain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Tedarik Zinciri", null },
                    { 14, "Purchasing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Satın Alma", null },
                    { 15, "Procurement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Tedarik", null },
                    { 16, "Logistics", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Lojistik", null },
                    { 17, "Transportation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Toplu Taşıma", null },
                    { 18, "Warehousing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Depolama", null },
                    { 19, "Distribution", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Dağıtım", null },
                    { 20, "Inventory", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Envanter", null },
                    { 21, "Materials", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Malzemeler", null },
                    { 22, "Consulting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, "Danışmanlık", null },
                    { 23, "ProductEngineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Üretim Mühendisliği", null },
                    { 24, "ProductManagement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Üretim Yönetimi", null },
                    { 25, "Quality", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Kalite Kontrol", null },
                    { 26, "Operations", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Operasyonlar", null },
                    { 27, "MaintenanceRepair", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Bakım & Onarım", null },
                    { 28, "Consulting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, "Danışmanlık", null },
                    { 29, "ManagementEngineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, "Mühendislik Yönetimi", null },
                    { 30, "ManagementProcurement", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, "Tedarik Yönetimi", null },
                    { 31, "ManagementOperations", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, "Operasyon Yönetimi", null },
                    { 32, "Management IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, "BT", null },
                    { 33, "Sales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, "Satış", null },
                    { 34, "SalesMarketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, "Pazarlama", null },
                    { 35, "SalesSalesMarketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, "Satış ve Pazarlama", null },
                    { 36, "SalesAgency", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, "Acenteler", null },
                    { 37, "SalesConsultant", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, "Danışmanlık", null },
                    { 38, "Other Consultant", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, "Danışman", null },
                    { 39, "Other Student", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, "Öğrenci", null },
                    { 40, "Other Retired", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, "Emekli", null },
                    { 41, "Other Educator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, "Eğitimci", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akdeniz Bölgesi", null },
                    { 2, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğu Anadolu Bölgesi", null },
                    { 3, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ege Bölgesi", null },
                    { 4, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güneydoğu Anadolu Bölgesi", null },
                    { 5, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İç Anadolu Bölgesi", null },
                    { 6, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karadeniz Bölgesi", null },
                    { 7, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marmara Bölgesi", null }
                });

            migrationBuilder.InsertData(
                table: "SpecificationValues",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "SpecificationId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yuvarlak", 1, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kare", 1, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dikdörtgen", 1, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarı", 2, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metalik", 2, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siyah", 2, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşil", 2, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Metal", 3, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çelik", 3, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yün", 3, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muflon", 3, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "30/50", 4, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "70/90", 4, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "90/120", 4, null }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e3905771-2d9e-4f0e-9490-b28ace7e5896"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0ee7c3a9-c87e-40a3-b13a-e85f443715fb") });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "RegionId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adana", 1, null },
                    { 2, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adıyaman", 4, null },
                    { 3, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Afyonkarahisar", 3, null },
                    { 4, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağrı", 2, null },
                    { 5, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amasya", 6, null },
                    { 6, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ankara", 5, null },
                    { 7, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Antalya", 1, null },
                    { 8, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Artvin", 6, null },
                    { 9, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydın", 3, null },
                    { 10, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Balıkesir", 7, null },
                    { 11, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilecik", 7, null },
                    { 12, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bingöl", 2, null },
                    { 13, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bitlis", 2, null },
                    { 14, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bolu", 6, null },
                    { 15, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Burdur", 1, null },
                    { 16, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bursa", 7, null },
                    { 17, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çanakkale", 7, null },
                    { 18, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çankırı", 5, null },
                    { 19, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çorum", 6, null },
                    { 20, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Denizli", 3, null },
                    { 21, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diyarbakır", 4, null },
                    { 22, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edirne", 7, null },
                    { 23, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elazığ", 2, null },
                    { 24, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erzincan", 2, null },
                    { 25, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erzurum", 2, null },
                    { 26, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eskişehir", 5, null },
                    { 27, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gaziantep", 4, null },
                    { 28, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Giresun", 6, null },
                    { 29, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gümüşhane", 6, null },
                    { 30, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hakkari", 2, null },
                    { 31, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hatay", 1, null },
                    { 32, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Isparta", 1, null },
                    { 33, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mersin", 1, null },
                    { 34, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İstanbul", 7, null },
                    { 35, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İzmir", 3, null },
                    { 36, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kars", 2, null },
                    { 37, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kastamonu", 6, null },
                    { 38, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kayseri", 5, null },
                    { 39, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırklareli", 7, null },
                    { 40, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırşehir", 5, null },
                    { 41, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kocaeli", 7, null },
                    { 42, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Konya", 5, null },
                    { 43, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kütahya", 3, null },
                    { 44, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malatya", 2, null },
                    { 45, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Manisa", 3, null },
                    { 46, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kahramanmaraş", 1, null },
                    { 47, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mardin", 4, null },
                    { 48, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muğla", 3, null },
                    { 49, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muş", 2, null },
                    { 50, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nevşehir", 5, null },
                    { 51, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Niğde", 5, null },
                    { 52, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ordu", 6, null },
                    { 53, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rize", 6, null },
                    { 54, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sakarya", 7, null },
                    { 55, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samsun", 6, null },
                    { 56, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siirt", 4, null },
                    { 57, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sinop", 6, null },
                    { 58, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sivas", 5, null },
                    { 59, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekirdağ", 7, null },
                    { 60, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tokat", 6, null },
                    { 61, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trabzon", 6, null },
                    { 62, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tunceli", 2, null },
                    { 63, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şanlıurfa", 4, null },
                    { 64, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uşak", 3, null },
                    { 65, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Van", 2, null },
                    { 66, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yozgat", 5, null },
                    { 67, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zonguldak", 6, null },
                    { 68, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aksaray", 5, null },
                    { 69, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayburt", 6, null },
                    { 70, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karaman", 5, null },
                    { 71, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırıkkale", 5, null },
                    { 72, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Batman", 4, null },
                    { 73, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şırnak", 4, null },
                    { 74, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bartın", 6, null },
                    { 75, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ardahan", 2, null },
                    { 76, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iğdır", 2, null },
                    { 77, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yalova", 7, null },
                    { 78, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karabük", 6, null },
                    { 79, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kilis", 4, null },
                    { 80, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Osmaniye", 1, null },
                    { 81, 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Düzce", 6, null }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CityId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aladağ(Karsantı)", null },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ceyhan", null },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çukurova", null },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feke", null },
                    { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İmamoğlu", null },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karaisalı", null },
                    { 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karataş", null },
                    { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kozan", null },
                    { 9, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pozantı", null },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saimbeyli", null },
                    { 11, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıçam", null },
                    { 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seyhan", null },
                    { 13, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tufanbeyli", null },
                    { 14, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yumurtalık", null },
                    { 15, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüreğir", null },
                    { 16, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adıyaman", null },
                    { 17, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Besni", null },
                    { 18, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çelikhan", null },
                    { 19, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gerger", null },
                    { 20, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölbaşı", null },
                    { 21, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kahta", null },
                    { 22, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samsat", null },
                    { 23, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sincik", null },
                    { 24, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tut", null },
                    { 25, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Afyonkarahisar", null },
                    { 26, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başmakçı", null },
                    { 27, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayat", null },
                    { 28, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bolvadin", null },
                    { 29, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çay", null },
                    { 30, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çobanlar", null },
                    { 31, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dazkırı", null },
                    { 32, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dinar", null },
                    { 33, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emirdağ", null },
                    { 34, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evciler", null },
                    { 35, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hocalar", null },
                    { 36, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İhsaniye", null },
                    { 37, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İscehisar", null },
                    { 38, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kızılören", null },
                    { 39, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sandıklı", null },
                    { 40, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sincanlı(Sinanpaşa)", null },
                    { 41, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sultandağı", null },
                    { 42, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şuhut", null },
                    { 43, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağrı", null },
                    { 44, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diyadin", null },
                    { 45, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğubeyazıt", null },
                    { 46, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eleşkirt", null },
                    { 47, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hamur", null },
                    { 48, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Patnos", null },
                    { 49, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taşlıçay", null },
                    { 50, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tutak", null },
                    { 51, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amasya", null },
                    { 52, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Göynücek", null },
                    { 53, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gümüşhacıköy", null },
                    { 54, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hamamözü", null },
                    { 55, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Merzifon", null },
                    { 56, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suluova", null },
                    { 57, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taşova", null },
                    { 58, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akyurt", null },
                    { 59, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altındağ", null },
                    { 60, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayaş", null },
                    { 61, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bala", null },
                    { 62, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beypazarı", null },
                    { 63, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamlıdere", null },
                    { 64, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çankaya", null },
                    { 65, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çubuk", null },
                    { 66, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elmadağ", null },
                    { 67, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Etimesgut", null },
                    { 68, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evren", null },
                    { 69, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölbaşı", null },
                    { 70, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güdül", null },
                    { 71, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Haymana", null },
                    { 72, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kalecik", null },
                    { 73, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kazan", null },
                    { 74, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keçiören", null },
                    { 75, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kızılcahamam", null },
                    { 76, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mamak", null },
                    { 77, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nallıhan", null },
                    { 78, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Polatlı", null },
                    { 79, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pursaklar", null },
                    { 80, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sincan", null },
                    { 81, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şereflikoçhisar", null },
                    { 82, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenimahalle", null },
                    { 83, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akseki", null },
                    { 84, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aksu", null },
                    { 85, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alanya", null },
                    { 86, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Döşemealtı", null },
                    { 87, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elmalı", null },
                    { 88, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Finike", null },
                    { 89, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gazipaşa", null },
                    { 90, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gündoğmuş", null },
                    { 91, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İbradı(Aydınkent)", null },
                    { 92, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kale(Demre)", null },
                    { 93, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kaş", null },
                    { 94, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kemer", null },
                    { 95, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kepez", null },
                    { 96, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Konyaaltı", null },
                    { 97, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Korkuteli", null },
                    { 98, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kumluca", null },
                    { 99, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Manavgat", null },
                    { 100, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muratpaşa", null },
                    { 101, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Serik", null },
                    { 102, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ardanuç", null },
                    { 103, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arhavi", null },
                    { 104, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Artvin", null },
                    { 105, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borçka", null },
                    { 106, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hopa", null },
                    { 107, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Murgul(Göktaş)", null },
                    { 108, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şavşat", null },
                    { 109, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yusufeli", null },
                    { 110, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydın", null },
                    { 111, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozdoğan", null },
                    { 112, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Buharkent(Çubukdağı)", null },
                    { 113, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çine", null },
                    { 114, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Didim(Yenihisar)", null },
                    { 115, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Germencik", null },
                    { 116, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İncirliova", null },
                    { 117, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karacasu", null },
                    { 118, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karpuzlu", null },
                    { 119, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Koçarlı", null },
                    { 120, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köşk", null },
                    { 121, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kuşadası", null },
                    { 122, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kuyucak", null },
                    { 123, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nazilli", null },
                    { 124, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Söke", null },
                    { 125, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sultanhisar", null },
                    { 126, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenipazar", null },
                    { 127, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayvalık", null },
                    { 128, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Balıkesir", null },
                    { 129, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Balya", null },
                    { 130, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bandırma", null },
                    { 131, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bigadiç", null },
                    { 132, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Burhaniye", null },
                    { 133, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dursunbey", null },
                    { 134, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edremit", null },
                    { 135, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erdek", null },
                    { 136, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gömeç", null },
                    { 137, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gönen", null },
                    { 138, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havran", null },
                    { 139, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İvrindi", null },
                    { 140, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kepsut", null },
                    { 141, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Manyas", null },
                    { 142, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marmara", null },
                    { 143, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Savaştepe", null },
                    { 144, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sındırgı", null },
                    { 145, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Susurluk", null },
                    { 146, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilecik", null },
                    { 147, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozüyük", null },
                    { 148, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölpazarı", null },
                    { 149, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İnhisar", null },
                    { 150, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Osmaneli", null },
                    { 151, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazaryeri", null },
                    { 152, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Söğüt", null },
                    { 153, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenipazar", null },
                    { 154, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adaklı", null },
                    { 155, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bingöl", null },
                    { 156, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Genç", null },
                    { 157, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karlıova", null },
                    { 158, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kığı", null },
                    { 159, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Solhan", null },
                    { 160, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yayladere", null },
                    { 161, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yedisu", null },
                    { 162, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adilcevaz", null },
                    { 163, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahlat", null },
                    { 164, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bitlis", null },
                    { 165, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güroymak", null },
                    { 166, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizan", null },
                    { 167, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mutki", null },
                    { 168, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tatvan", null },
                    { 169, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bolu", null },
                    { 170, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dörtdivan", null },
                    { 171, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gerede", null },
                    { 172, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Göynük", null },
                    { 173, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kıbrıscık", null },
                    { 174, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mengen", null },
                    { 175, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mudurnu", null },
                    { 176, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seben", null },
                    { 177, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeniçağa", null },
                    { 178, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağlasun", null },
                    { 179, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altınyayla(Dirmil)", null },
                    { 180, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bucak", null },
                    { 181, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Burdur", null },
                    { 182, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çavdır", null },
                    { 183, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çeltikçi", null },
                    { 184, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölhisar", null },
                    { 185, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karamanlı", null },
                    { 186, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kemer", null },
                    { 187, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tefenni", null },
                    { 188, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşilova", null },
                    { 189, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Büyükorhan", null },
                    { 190, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gemlik", null },
                    { 191, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gürsu", null },
                    { 192, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Harmancık", null },
                    { 193, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İnegöl", null },
                    { 194, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İznik", null },
                    { 195, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karacabey", null },
                    { 196, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keles", null },
                    { 197, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kestel", null },
                    { 198, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mudanya", null },
                    { 199, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mustafakemalpaşa", null },
                    { 200, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nilüfer", null },
                    { 201, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orhaneli", null },
                    { 202, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orhangazi", null },
                    { 203, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Osmangazi", null },
                    { 204, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenişehir", null },
                    { 205, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yıldırım", null },
                    { 206, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayvacık", null },
                    { 207, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayramiç", null },
                    { 208, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Biga", null },
                    { 209, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozcaada", null },
                    { 210, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çan", null },
                    { 211, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çanakkale", null },
                    { 212, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eceabat", null },
                    { 213, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ezine", null },
                    { 214, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gelibolu", null },
                    { 215, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gökçeada(İmroz)", null },
                    { 216, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lapseki", null },
                    { 217, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenice", null },
                    { 218, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Atkaracalar", null },
                    { 219, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayramören", null },
                    { 220, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çankırı", null },
                    { 221, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çerkeş", null },
                    { 222, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eldivan", null },
                    { 223, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ilgaz", null },
                    { 224, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kızılırmak", null },
                    { 225, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Korgun", null },
                    { 226, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kurşunlu", null },
                    { 227, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orta", null },
                    { 228, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şabanözü", null },
                    { 229, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yapraklı", null },
                    { 230, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alaca", null },
                    { 231, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayat", null },
                    { 232, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boğazkale", null },
                    { 233, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çorum", null },
                    { 234, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dodurga", null },
                    { 235, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İskilip", null },
                    { 236, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kargı", null },
                    { 237, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laçin", null },
                    { 238, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mecitözü", null },
                    { 239, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Oğuzlar(Karaören)", null },
                    { 240, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ortaköy", null },
                    { 241, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Osmancık", null },
                    { 242, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sungurlu", null },
                    { 243, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uğurludağ", null },
                    { 244, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Acıpayam", null },
                    { 245, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akköy", null },
                    { 246, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Babadağ", null },
                    { 247, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Baklan", null },
                    { 248, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bekilli", null },
                    { 249, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beyağaç", null },
                    { 250, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozkurt", null },
                    { 251, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Buldan", null },
                    { 252, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çal", null },
                    { 253, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çameli", null },
                    { 254, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çardak", null },
                    { 255, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çivril", null },
                    { 256, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Denizli", null },
                    { 257, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güney", null },
                    { 258, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Honaz", null },
                    { 259, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kale", null },
                    { 260, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarayköy", null },
                    { 261, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Serinhisar", null },
                    { 262, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tavas", null },
                    { 263, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bağlar", null },
                    { 264, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bismil", null },
                    { 265, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çermik", null },
                    { 266, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çınar", null },
                    { 267, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çüngüş", null },
                    { 268, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dicle", null },
                    { 269, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eğil", null },
                    { 270, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergani", null },
                    { 271, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hani", null },
                    { 272, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hazro", null },
                    { 273, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kayapınar", null },
                    { 274, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kocaköy", null },
                    { 275, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kulp", null },
                    { 276, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lice", null },
                    { 277, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvan", null },
                    { 278, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sur", null },
                    { 279, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenişehir", null },
                    { 280, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edirne", null },
                    { 281, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Enez", null },
                    { 282, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havsa", null },
                    { 283, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İpsala", null },
                    { 284, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keşan", null },
                    { 285, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lalapaşa", null },
                    { 286, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meriç", null },
                    { 287, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Süleoğlu(Süloğlu)", null },
                    { 288, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uzunköprü", null },
                    { 289, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağın", null },
                    { 290, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alacakaya", null },
                    { 291, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arıcak", null },
                    { 292, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Baskil", null },
                    { 293, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elazığ", null },
                    { 294, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karakoçan", null },
                    { 295, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keban", null },
                    { 296, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kovancılar", null },
                    { 297, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maden", null },
                    { 298, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Palu", null },
                    { 299, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sivrice", null },
                    { 300, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çayırlı", null },
                    { 301, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erzincan", null },
                    { 302, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İliç(Ilıç)", null },
                    { 303, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kemah", null },
                    { 304, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kemaliye", null },
                    { 305, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Otlukbeli", null },
                    { 306, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Refahiye", null },
                    { 307, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tercan", null },
                    { 308, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Üzümlü", null },
                    { 309, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aşkale", null },
                    { 310, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aziziye(Ilıca)", null },
                    { 311, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çat", null },
                    { 312, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hınıs", null },
                    { 313, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Horasan", null },
                    { 314, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İspir", null },
                    { 315, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karaçoban", null },
                    { 316, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karayazı", null },
                    { 317, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köprüköy", null },
                    { 318, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Narman", null },
                    { 319, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Oltu", null },
                    { 320, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Olur", null },
                    { 321, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Palandöken", null },
                    { 322, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pasinler", null },
                    { 323, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazaryolu", null },
                    { 324, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şenkaya", null },
                    { 325, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekman", null },
                    { 326, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tortum", null },
                    { 327, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uzundere", null },
                    { 328, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yakutiye", null },
                    { 329, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alpu", null },
                    { 330, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beylikova", null },
                    { 331, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çifteler", null },
                    { 332, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Günyüzü", null },
                    { 333, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Han", null },
                    { 334, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İnönü", null },
                    { 335, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mahmudiye", null },
                    { 336, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mihalgazi", null },
                    { 337, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mihalıçcık", null },
                    { 338, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Odunpazarı", null },
                    { 339, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıcakaya", null },
                    { 340, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seyitgazi", null },
                    { 341, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sivrihisar", null },
                    { 342, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tepebaşı", null },
                    { 343, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Araban", null },
                    { 344, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İslahiye", null },
                    { 345, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karkamış", null },
                    { 346, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nizip", null },
                    { 347, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nurdağı", null },
                    { 348, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Oğuzeli", null },
                    { 349, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şahinbey", null },
                    { 350, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şehitkamil", null },
                    { 351, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yavuzeli", null },
                    { 352, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alucra", null },
                    { 353, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bulancak", null },
                    { 354, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamoluk", null },
                    { 355, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çanakçı", null },
                    { 356, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dereli", null },
                    { 357, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğankent", null },
                    { 358, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Espiye", null },
                    { 359, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eynesil", null },
                    { 360, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Giresun", null },
                    { 361, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Görele", null },
                    { 362, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güce", null },
                    { 363, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keşap", null },
                    { 364, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Piraziz", null },
                    { 365, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şebinkarahisar", null },
                    { 366, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tirebolu", null },
                    { 367, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yağlıdere", null },
                    { 368, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gümüşhane", null },
                    { 369, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kelkit", null },
                    { 370, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köse", null },
                    { 371, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kürtün", null },
                    { 372, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şiran", null },
                    { 373, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Torul", null },
                    { 374, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çukurca", null },
                    { 375, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hakkari", null },
                    { 376, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şemdinli", null },
                    { 377, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüksekova", null },
                    { 378, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altınözü", null },
                    { 379, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Antakya", null },
                    { 380, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Belen", null },
                    { 381, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dörtyol", null },
                    { 382, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erzin", null },
                    { 383, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hassa", null },
                    { 384, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İskenderun", null },
                    { 385, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırıkhan", null },
                    { 386, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kumlu", null },
                    { 387, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reyhanlı", null },
                    { 388, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Samandağ", null },
                    { 389, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yayladağı", null },
                    { 390, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aksu", null },
                    { 391, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Atabey", null },
                    { 392, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eğridir(Eğirdir)", null },
                    { 393, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gelendost", null },
                    { 394, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gönen", null },
                    { 395, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Isparta", null },
                    { 396, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keçiborlu", null },
                    { 397, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Senirkent", null },
                    { 398, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sütçüler", null },
                    { 399, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şarkikaraağaç", null },
                    { 400, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uluborlu", null },
                    { 401, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yalvaç", null },
                    { 402, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenişarbademli", null },
                    { 403, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akdeniz", null },
                    { 404, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anamur", null },
                    { 405, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydıncık", null },
                    { 406, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozyazı", null },
                    { 407, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamlıyayla", null },
                    { 408, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erdemli", null },
                    { 409, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gülnar (Gülpınar)", null },
                    { 410, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mezitli", null },
                    { 411, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mut", null },
                    { 412, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silifke", null },
                    { 413, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tarsus", null },
                    { 414, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Toroslar", null },
                    { 415, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenişehir", null },
                    { 416, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adalar", null },
                    { 417, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arnavutköy", null },
                    { 418, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ataşehir", null },
                    { 419, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avcılar", null },
                    { 420, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bağcılar", null },
                    { 421, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bahçelievler", null },
                    { 422, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bakırköy", null },
                    { 423, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başakşehir", null },
                    { 424, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayrampaşa", null },
                    { 425, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beşiktaş", null },
                    { 426, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beykoz", null },
                    { 427, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beylikdüzü", null },
                    { 428, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beyoğlu", null },
                    { 429, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Büyükçekmece", null },
                    { 430, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çatalca", null },
                    { 431, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çekmeköy", null },
                    { 432, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Esenler", null },
                    { 433, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Esenyurt", null },
                    { 434, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eyüp", null },
                    { 435, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fatih", null },
                    { 436, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gaziosmanpaşa", null },
                    { 437, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güngören", null },
                    { 438, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kadıköy", null },
                    { 439, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kağıthane", null },
                    { 440, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kartal", null },
                    { 441, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Küçükçekmece", null },
                    { 442, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maltepe", null },
                    { 443, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pendik", null },
                    { 444, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sancaktepe", null },
                    { 445, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıyer", null },
                    { 446, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silivri", null },
                    { 447, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sultanbeyli", null },
                    { 448, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sultangazi", null },
                    { 449, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şile", null },
                    { 450, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şişli", null },
                    { 451, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tuzla", null },
                    { 452, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ümraniye", null },
                    { 453, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Üsküdar", null },
                    { 454, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zeytinburnu", null },
                    { 455, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aliağa", null },
                    { 456, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Balçova", null },
                    { 457, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayındır", null },
                    { 458, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayraklı", null },
                    { 459, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bergama", null },
                    { 460, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beydağ", null },
                    { 461, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bornova", null },
                    { 462, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Buca", null },
                    { 463, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cumaovası(Menderes)", null },
                    { 464, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çeşme", null },
                    { 465, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çiğli", null },
                    { 466, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dikili", null },
                    { 467, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Foça", null },
                    { 468, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gaziemir", null },
                    { 469, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güzelbahçe", null },
                    { 470, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karabağlar", null },
                    { 471, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karaburun", null },
                    { 472, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karşıyaka", null },
                    { 473, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kemalpaşa", null },
                    { 474, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kınık", null },
                    { 475, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiraz", null },
                    { 476, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Konak", null },
                    { 477, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Menemen", null },
                    { 478, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Narlıdere", null },
                    { 479, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ödemiş", null },
                    { 480, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seferihisar", null },
                    { 481, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Selçuk", null },
                    { 482, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tire", null },
                    { 483, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Torbalı", null },
                    { 484, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Urla", null },
                    { 485, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akyaka", null },
                    { 486, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arpaçay", null },
                    { 487, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Digor", null },
                    { 488, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kağızman", null },
                    { 489, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kars", null },
                    { 490, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıkamış", null },
                    { 491, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Selim", null },
                    { 492, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Susuz", null },
                    { 493, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Abana", null },
                    { 494, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağlı", null },
                    { 495, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Araç", null },
                    { 496, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azdavay", null },
                    { 497, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozkurt", null },
                    { 498, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cide", null },
                    { 499, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çatalzeytin", null },
                    { 500, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Daday", null },
                    { 501, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Devrekani", null },
                    { 502, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğanyurt", null },
                    { 503, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hanönü(Gökçeağaç)", null },
                    { 504, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İhsangazi", null },
                    { 505, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İnebolu", null },
                    { 506, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kastamonu", null },
                    { 507, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Küre", null },
                    { 508, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pınarbaşı", null },
                    { 509, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seydiler", null },
                    { 510, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şenpazar", null },
                    { 511, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taşköprü", null },
                    { 512, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tosya", null },
                    { 513, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akkışla", null },
                    { 514, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bünyan", null },
                    { 515, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Develi", null },
                    { 516, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Felahiye", null },
                    { 517, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hacılar", null },
                    { 518, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İncesu", null },
                    { 519, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kocasinan", null },
                    { 520, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Melikgazi", null },
                    { 521, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Özvatan(Çukur)", null },
                    { 522, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pınarbaşı", null },
                    { 523, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıoğlan", null },
                    { 524, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarız", null },
                    { 525, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Talas", null },
                    { 526, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tomarza", null },
                    { 527, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yahyalı", null },
                    { 528, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşilhisar", null },
                    { 529, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Babaeski", null },
                    { 530, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demirköy", null },
                    { 531, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırklareli", null },
                    { 532, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kofçaz", null },
                    { 533, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lüleburgaz", null },
                    { 534, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pehlivanköy", null },
                    { 535, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pınarhisar", null },
                    { 536, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vize", null },
                    { 537, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akçakent", null },
                    { 538, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akpınar", null },
                    { 539, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boztepe", null },
                    { 540, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çiçekdağı", null },
                    { 541, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kaman", null },
                    { 542, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırşehir", null },
                    { 543, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mucur", null },
                    { 544, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başiskele", null },
                    { 545, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çayırova", null },
                    { 546, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Darıca", null },
                    { 547, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derince", null },
                    { 548, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dilovası", null },
                    { 549, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gebze", null },
                    { 550, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölcük", null },
                    { 551, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İzmit", null },
                    { 552, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kandıra", null },
                    { 553, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karamürsel", null },
                    { 554, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kartepe", null },
                    { 555, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tütünçiftlik", null },
                    { 556, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahırlı", null },
                    { 557, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akören", null },
                    { 558, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akşehir", null },
                    { 559, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altınekin", null },
                    { 560, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beyşehir", null },
                    { 561, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozkır", null },
                    { 562, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cihanbeyli", null },
                    { 563, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çeltik", null },
                    { 564, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çumra", null },
                    { 565, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derbent", null },
                    { 566, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derebucak", null },
                    { 567, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğanhisar", null },
                    { 568, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emirgazi", null },
                    { 569, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ereğli", null },
                    { 570, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güneysınır", null },
                    { 571, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hadim", null },
                    { 572, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Halkapınar", null },
                    { 573, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hüyük", null },
                    { 574, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ilgın", null },
                    { 575, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kadınhanı", null },
                    { 576, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karapınar", null },
                    { 577, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karatay", null },
                    { 578, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kulu", null },
                    { 579, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meram", null },
                    { 580, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarayönü", null },
                    { 581, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Selçuklu", null },
                    { 582, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seydişehir", null },
                    { 583, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taşkent", null },
                    { 584, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tuzlukçu", null },
                    { 585, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yalıhüyük", null },
                    { 586, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yunak", null },
                    { 587, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altıntaş", null },
                    { 588, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aslanapa", null },
                    { 589, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çavdarhisar", null },
                    { 590, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Domaniç", null },
                    { 591, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dumlupınar", null },
                    { 592, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emet", null },
                    { 593, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gediz", null },
                    { 594, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hisarcık", null },
                    { 595, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kütahya", null },
                    { 596, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazarlar", null },
                    { 597, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Simav", null },
                    { 598, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şaphane", null },
                    { 599, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tavşanlı", null },
                    { 600, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tunçbilek", null },
                    { 601, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akçadağ", null },
                    { 602, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arapkir", null },
                    { 603, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arguvan", null },
                    { 604, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Battalgazi", null },
                    { 605, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Darende", null },
                    { 606, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğanşehir", null },
                    { 607, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğanyol", null },
                    { 608, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hekimhan", null },
                    { 609, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kale", null },
                    { 610, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kuluncak", null },
                    { 611, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malatya", null },
                    { 612, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pötürge", null },
                    { 613, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yazıhan", null },
                    { 614, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşilyurt", null },
                    { 615, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ahmetli", null },
                    { 616, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akhisar", null },
                    { 617, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alaşehir", null },
                    { 618, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demirci", null },
                    { 619, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölmarmara", null },
                    { 620, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gördes", null },
                    { 621, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırkağaç", null },
                    { 622, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köprübaşı", null },
                    { 623, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kula", null },
                    { 624, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Manisa", null },
                    { 625, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Salihli", null },
                    { 626, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıgöl", null },
                    { 627, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saruhanlı", null },
                    { 628, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Selendi", null },
                    { 629, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Soma", null },
                    { 630, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turgutlu", null },
                    { 631, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Afşin", null },
                    { 632, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Andırın", null },
                    { 633, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çağlayancerit", null },
                    { 634, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ekinözü", null },
                    { 635, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elbistan", null },
                    { 636, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Göksun", null },
                    { 637, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kahramanmaraş", null },
                    { 638, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nurhak", null },
                    { 639, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazarcık", null },
                    { 640, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Türkoğlu", null },
                    { 641, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dargeçit", null },
                    { 642, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derik", null },
                    { 643, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kızıltepe", null },
                    { 644, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mardin", null },
                    { 645, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mazıdağı", null },
                    { 646, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Midyat(Estel)", null },
                    { 647, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nusaybin", null },
                    { 648, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ömerli", null },
                    { 649, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Savur", null },
                    { 650, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşilli", null },
                    { 651, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bodrum", null },
                    { 652, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dalaman", null },
                    { 653, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Datça", null },
                    { 654, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fethiye", null },
                    { 655, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kavaklıdere", null },
                    { 656, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köyceğiz", null },
                    { 657, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marmaris", null },
                    { 658, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Milas", null },
                    { 659, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muğla", null },
                    { 660, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ortaca", null },
                    { 661, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ula", null },
                    { 662, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yatağan", null },
                    { 663, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bulanık", null },
                    { 664, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hasköy", null },
                    { 665, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Korkut", null },
                    { 666, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malazgirt", null },
                    { 667, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muş", null },
                    { 668, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Varto", null },
                    { 669, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Acıgöl", null },
                    { 670, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avanos", null },
                    { 671, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derinkuyu", null },
                    { 672, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gülşehir", null },
                    { 673, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hacıbektaş", null },
                    { 674, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kozaklı", null },
                    { 675, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nevşehir", null },
                    { 676, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürgüp", null },
                    { 677, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altunhisar", null },
                    { 678, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bor", null },
                    { 679, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamardı", null },
                    { 680, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çiftlik(Özyurt)", null },
                    { 681, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Niğde", null },
                    { 682, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ulukışla", null },
                    { 683, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akkuş", null },
                    { 684, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aybastı", null },
                    { 685, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamaş", null },
                    { 686, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çatalpınar", null },
                    { 687, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çaybaşı", null },
                    { 688, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fatsa", null },
                    { 689, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölköy", null },
                    { 690, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gülyalı", null },
                    { 691, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gürgentepe", null },
                    { 692, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İkizce", null },
                    { 693, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kabataş", null },
                    { 694, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karadüz(Kabadüz)", null },
                    { 695, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Korgan", null },
                    { 696, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kumru", null },
                    { 697, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mesudiye", null },
                    { 698, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ordu", null },
                    { 699, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Perşembe", null },
                    { 700, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ulubey", null },
                    { 701, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ünye", null },
                    { 702, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ardeşen", null },
                    { 703, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çamlıhemşin", null },
                    { 704, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çayeli", null },
                    { 705, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Derepazarı", null },
                    { 706, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fındıklı", null },
                    { 707, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güneysu", null },
                    { 708, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hemşin", null },
                    { 709, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İkizdere", null },
                    { 710, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İyidere", null },
                    { 711, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kalkandere", null },
                    { 712, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazar", null },
                    { 713, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rize", null },
                    { 714, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adapazarı", null },
                    { 715, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akyazı", null },
                    { 716, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arifiye", null },
                    { 717, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erenler", null },
                    { 718, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ferizli", null },
                    { 719, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Geyve", null },
                    { 720, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hendek", null },
                    { 721, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karapürçek", null },
                    { 722, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karasu", null },
                    { 723, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kaynarca", null },
                    { 724, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kocaali", null },
                    { 725, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pamukova", null },
                    { 726, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sapanca", null },
                    { 727, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Serdivan", null },
                    { 728, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Söğütlü", null },
                    { 729, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Taraklı", null },
                    { 730, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "19 Mayıs(Ballıca)", null },
                    { 731, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alaçam", null },
                    { 732, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Asarcık", null },
                    { 733, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Atakum", null },
                    { 734, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayvacık", null },
                    { 735, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bafra", null },
                    { 736, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Canik", null },
                    { 737, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çarşamba", null },
                    { 738, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Havza", null },
                    { 739, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İlkadım", null },
                    { 740, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kavak", null },
                    { 741, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ladik", null },
                    { 742, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Salıpazarı", null },
                    { 743, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekkeköy", null },
                    { 744, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Terme", null },
                    { 745, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vezirköprü", null },
                    { 746, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yakakent", null },
                    { 747, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydınlar", null },
                    { 748, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Baykan", null },
                    { 749, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eruh", null },
                    { 750, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kurtalan", null },
                    { 751, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pervari", null },
                    { 752, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siirt", null },
                    { 753, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şirvan", null },
                    { 754, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayancık", null },
                    { 755, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boyabat", null },
                    { 756, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dikmen", null },
                    { 757, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durağan", null },
                    { 758, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erfelek", null },
                    { 759, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gerze", null },
                    { 760, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saraydüzü", null },
                    { 761, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sinop", null },
                    { 762, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Türkeli", null },
                    { 763, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akıncılar", null },
                    { 764, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altınyayla", null },
                    { 765, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Divriği", null },
                    { 766, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doğanşar", null },
                    { 767, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gemerek", null },
                    { 768, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölova", null },
                    { 769, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gürün", null },
                    { 770, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hafik", null },
                    { 771, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İmranlı", null },
                    { 772, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kangal", null },
                    { 773, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Koyulhisar", null },
                    { 774, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sivas", null },
                    { 775, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suşehri", null },
                    { 776, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şarkışla", null },
                    { 777, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ulaş", null },
                    { 778, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yıldızeli", null },
                    { 779, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zara", null },
                    { 780, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çerkezköy", null },
                    { 781, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çorlu", null },
                    { 782, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hayrabolu", null },
                    { 783, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Malkara", null },
                    { 784, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marmaraereğlisi", null },
                    { 785, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muratlı", null },
                    { 786, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saray", null },
                    { 787, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şarköy", null },
                    { 788, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tekirdağ", null },
                    { 789, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Almus", null },
                    { 790, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Artova", null },
                    { 791, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başçiftlik", null },
                    { 792, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erbaa", null },
                    { 793, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Niksar", null },
                    { 794, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazar", null },
                    { 795, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Reşadiye", null },
                    { 796, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sulusaray", null },
                    { 797, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tokat", null },
                    { 798, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turhal", null },
                    { 799, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeşilyurt", null },
                    { 800, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zile", null },
                    { 801, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akçaabat", null },
                    { 802, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Araklı", null },
                    { 803, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arsin", null },
                    { 804, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beşikdüzü", null },
                    { 805, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çarşıbaşı", null },
                    { 806, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çaykara", null },
                    { 807, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dernekpazarı", null },
                    { 808, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Düzköy", null },
                    { 809, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hayrat", null },
                    { 810, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Köprübaşı", null },
                    { 811, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maçka", null },
                    { 812, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Of", null },
                    { 813, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sürmene", null },
                    { 814, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şalpazarı", null },
                    { 815, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tonya", null },
                    { 816, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trabzon", null },
                    { 817, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vakfıkebir", null },
                    { 818, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yomra", null },
                    { 819, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çemişgezek", null },
                    { 820, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hozat", null },
                    { 821, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mazgirt", null },
                    { 822, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nazımiye", null },
                    { 823, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ovacık", null },
                    { 824, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pertek", null },
                    { 825, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pülümür", null },
                    { 826, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tunceli", null },
                    { 827, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akçakale", null },
                    { 828, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Birecik", null },
                    { 829, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bozova", null },
                    { 830, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ceylanpınar", null },
                    { 831, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Halfeti", null },
                    { 832, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Harran", null },
                    { 833, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hilvan", null },
                    { 834, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siverek", null },
                    { 835, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suruç", null },
                    { 836, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şanlıurfa", null },
                    { 837, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viranşehir", null },
                    { 838, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Banaz", null },
                    { 839, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eşme", null },
                    { 840, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karahallı", null },
                    { 841, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sivaslı", null },
                    { 842, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ulubey", null },
                    { 843, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uşak", null },
                    { 844, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bahçesaray", null },
                    { 845, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başkale", null },
                    { 846, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çaldıran", null },
                    { 847, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çatak", null },
                    { 848, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edremit(Gümüşdere)", null },
                    { 849, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Erciş", null },
                    { 850, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gevaş", null },
                    { 851, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gürpınar", null },
                    { 852, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Muradiye", null },
                    { 853, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Özalp", null },
                    { 854, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saray", null },
                    { 855, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Van", null },
                    { 856, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akdağmadeni", null },
                    { 857, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydıncık", null },
                    { 858, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boğazlıyan", null },
                    { 859, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çandır", null },
                    { 860, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çayıralan", null },
                    { 861, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çekerek", null },
                    { 862, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kadışehri", null },
                    { 863, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saraykent", null },
                    { 864, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıkaya", null },
                    { 865, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sorgun", null },
                    { 866, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şefaatli", null },
                    { 867, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenifakılı", null },
                    { 868, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yerköy", null },
                    { 869, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yozgat", null },
                    { 870, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alaplı", null },
                    { 871, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çaycuma", null },
                    { 872, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Devrek", null },
                    { 873, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gökçebey", null },
                    { 874, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karadenizereğli", null },
                    { 875, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zonguldak", null },
                    { 876, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ağaçören", null },
                    { 877, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aksaray", null },
                    { 878, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eskil", null },
                    { 879, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gülağaç(Ağaçlı)", null },
                    { 880, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güzelyurt", null },
                    { 881, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ortaköy", null },
                    { 882, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıyahşi", null },
                    { 883, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aydıntepe", null },
                    { 884, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bayburt", null },
                    { 885, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demirözü", null },
                    { 886, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayrancı", null },
                    { 887, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Başyayla", null },
                    { 888, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ermenek", null },
                    { 889, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karaman", null },
                    { 890, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kazımkarabekir", null },
                    { 891, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sarıveliler", null },
                    { 892, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bahşili", null },
                    { 893, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Balışeyh", null },
                    { 894, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çelebi", null },
                    { 895, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Delice", null },
                    { 896, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karakeçili", null },
                    { 897, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Keskin", null },
                    { 898, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kırıkkale", null },
                    { 899, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sulakyurt", null },
                    { 900, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yahşihan", null },
                    { 901, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Batman", null },
                    { 902, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beşiri", null },
                    { 903, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gercüş", null },
                    { 904, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hasankeyf", null },
                    { 905, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kozluk", null },
                    { 906, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sason", null },
                    { 907, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beytüşşebap", null },
                    { 908, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cizre", null },
                    { 909, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Güçlükonak", null },
                    { 910, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İdil", null },
                    { 911, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silopi", null },
                    { 912, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Şırnak", null },
                    { 913, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uludere", null },
                    { 914, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amasra", null },
                    { 915, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bartın", null },
                    { 916, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kurucaşile", null },
                    { 917, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ulus", null },
                    { 918, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ardahan", null },
                    { 919, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çıldır", null },
                    { 920, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Damal", null },
                    { 921, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Göle", null },
                    { 922, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hanak", null },
                    { 923, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Posof", null },
                    { 924, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aralık", null },
                    { 925, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Iğdır", null },
                    { 926, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karakoyunlu", null },
                    { 927, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tuzluca", null },
                    { 928, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Altınova", null },
                    { 929, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Armutlu", null },
                    { 930, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çınarcık", null },
                    { 931, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çiftlikköy", null },
                    { 932, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Termal", null },
                    { 933, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yalova", null },
                    { 934, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eflani", null },
                    { 935, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eskipazar", null },
                    { 936, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Karabük", null },
                    { 937, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ovacık", null },
                    { 938, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Safranbolu", null },
                    { 939, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yenice", null },
                    { 940, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Elbeyli", null },
                    { 941, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kilis", null },
                    { 942, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Musabeyli", null },
                    { 943, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Polateli", null },
                    { 944, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bahçe", null },
                    { 945, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Düziçi", null },
                    { 946, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hasanbeyli", null },
                    { 947, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kadirli", null },
                    { 948, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Osmaniye", null },
                    { 949, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sumbas", null },
                    { 950, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Toprakkale", null },
                    { 951, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Akçakoca", null },
                    { 952, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cumayeri", null },
                    { 953, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Çilimli", null },
                    { 954, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Düzce", null },
                    { 955, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gölyaka", null },
                    { 956, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gümüşova", null },
                    { 957, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kaynaşlı", null },
                    { 958, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yığılca", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CityId",
                table: "CompanyAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyId",
                table: "CompanyAddresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CountryId",
                table: "CompanyAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_TownId",
                table: "CompanyAddresses",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_CategoryId",
                table: "CompanyCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCategories_CompanyId",
                table: "CompanyCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_CompanyId",
                table: "CompanyContacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompanyId",
                table: "CompanyImages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_ServiceId",
                table: "CompanyServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UserId",
                table: "CompanyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_JobFunctionId",
                table: "Disciplines",
                column: "JobFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_ParentIndustryId",
                table: "Industries",
                column: "ParentIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TransactionDetailId",
                table: "Items",
                column: "TransactionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecifications_ItemId",
                table: "ItemSpecifications",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecifications_SpecificationId",
                table: "ItemSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecifications_SpecificationValueId",
                table: "ItemSpecifications",
                column: "SpecificationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUoms_ItemId",
                table: "ItemUoms",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUoms_UomId",
                table: "ItemUoms",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ItemId",
                table: "ProductImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_SpecificationId",
                table: "SpecificationValues",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CityId",
                table: "Towns",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_TransactionId",
                table: "TransactionDetails",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompanyId",
                table: "Transactions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAddresses");

            migrationBuilder.DropTable(
                name: "CompanyCategories");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropTable(
                name: "CompanyImages");

            migrationBuilder.DropTable(
                name: "CompanyServices");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "ItemSpecifications");

            migrationBuilder.DropTable(
                name: "ItemUoms");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TransactionInvoiceDetails");

            migrationBuilder.DropTable(
                name: "TransactionInvoices");

            migrationBuilder.DropTable(
                name: "TransactionOfferDetails");

            migrationBuilder.DropTable(
                name: "TransactionOffers");

            migrationBuilder.DropTable(
                name: "TransactionOrderDetails");

            migrationBuilder.DropTable(
                name: "TransactionOrders");

            migrationBuilder.DropTable(
                name: "TransactionWaybillDetails");

            migrationBuilder.DropTable(
                name: "TransactionWaybills");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "JobFunctions");

            migrationBuilder.DropTable(
                name: "SpecificationValues");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Uoms");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
