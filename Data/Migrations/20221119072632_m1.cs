using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1_v3.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SignatureGUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    ResolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ResolutionAbstract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.ResolutionId);
                    table.ForeignKey(
                        name: "FK_Resolutions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Resolutions_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "Resolutions",
                        principalColumn: "ResolutionId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "94373447-5760-4c73-a702-433248762bcc", "Member", "MEMBER" },
                    { "cd615706-9af4-4d4e-8212-b9a45de28a6f", "a1ee65e8-f37c-4a29-b456-1d3d1c3c6cdc", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SignatureGUID", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "31432085-85bc-4648-8a82-e8ff8b5671cc", 0, "104aecdd-d84e-4c01-a36f-e283c584dfd8", "ApplicationUser", "33@33.33", true, "Bob", "Sims", false, null, null, "33@33.33", "AQAAAAEAACcQAAAAEH6f4Pzr9xZwyfrrG8QFRAvIJrZILKCoaQtUdJ+Nq727dRVKIsgkhwFYe0pgLR/ETw==", null, false, "e0451bbb-3f9c-4f9f-9000-897d7cc9ee4c", "4c63e0f6-c9ab-48b0-b50a-6639d47e952c", false, "33@33.33" },
                    { "4bb81b94-441b-43ee-bb4a-ee8ebeb50fdf", 0, "76551c69-c4eb-49c2-ace6-da0f139f9dbb", "ApplicationUser", "comp4976@outlook.com", false, "Medhat", "Elmasry", false, null, null, "COMP4976@OUTLOOK.COM", "AQAAAAEAACcQAAAAEPY4rFRvX2w8NIuUfHtGWggwrTj7b/p/zzb51QcKcU2alokWMz5zA1TzuhDcnc4Z2w==", null, false, "db72f978-4d8a-4e94-97c6-43fe886dce97", "56ece414-f78a-4087-8f0d-2c2a581ac65c", false, "comp4976@outlook.com" },
                    { "6af8ed9c-0bac-40ac-aff2-f5d005dced65", 0, "820aeb2e-b534-4e4a-8758-83ed6144a2a0", "ApplicationUser", "11@11.11", true, "Pat", "John", false, null, null, "11@11.11", "AQAAAAEAACcQAAAAEN7h+3RRLoL6qpa/Hz/9a1XZJZc59NkVsl4TDNXz/E87stdQUzaSvYZ+6FnwK5EOpg==", null, false, "a06fb0e4-e47f-42f4-9e3d-9b9a1c33c94f", "20216312-7877-4654-b904-8e6e05b24892", false, "11@11.11" },
                    { "9dc5073e-28a1-40ab-ad05-4da15c3692a3", 0, "ca645e1e-c3c1-4197-aeec-103bb56ce5a5", "ApplicationUser", "aa@aa.aa", true, "Admin", "Administrator", false, null, null, "AA@AA.AA", "AQAAAAEAACcQAAAAEHe0IXk2qmJ6tvGzP5t013H/wxiUNXsSFF7aTtAW+ybXJV49d2aewni1yhQNbxevKg==", null, false, "b245b190-94a9-4c02-882a-8dac354271ad", "1e0dd39e-7f7c-4432-a315-b86a9c888590", false, "aa@aa.aa" },
                    { "a41390e5-790c-488f-8639-1db213da8375", 0, "912bf26c-682f-4164-a9e3-34c0a4ad26fa", "ApplicationUser", "44@44.44", true, "Eddy", "Glen", false, null, null, "44@44.44", "AQAAAAEAACcQAAAAEL5WCYGMci/BcdLEH1FRZJ0/mVpQznJPV6Cgx7OZjAL9Xcc7FnOaDXKBRuCHR/SbGQ==", null, false, "21a17c8f-654c-4666-9459-03077c711360", "eef1de33-3751-4228-96f5-6fd6726da577", false, "44@44.44" },
                    { "fda8e4f5-6011-4f3b-9677-7eb8872e9f82", 0, "71ba83a3-bafd-4825-91b3-0e6f0c8dd023", "ApplicationUser", "22@22.22", true, "Sue", "Fox", false, null, null, "22@22.22", "AQAAAAEAACcQAAAAEC+pVqz8bokNR/hZrCrRLdbUpLVOoRchx0GP4rpA9j4i83Yw+uE8cnmUpF8rlKFVdg==", null, false, "78e3848b-9b28-4af5-8100-70a672b993de", "9b523f95-37ea-4d4f-b75c-670d70364c22", false, "22@22.22" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "31432085-85bc-4648-8a82-e8ff8b5671cc" },
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "4bb81b94-441b-43ee-bb4a-ee8ebeb50fdf" },
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "6af8ed9c-0bac-40ac-aff2-f5d005dced65" },
                    { "cd615706-9af4-4d4e-8212-b9a45de28a6f", "9dc5073e-28a1-40ab-ad05-4da15c3692a3" },
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "a41390e5-790c-488f-8639-1db213da8375" },
                    { "a934212f-941e-4150-80ac-d675fbd79dde", "fda8e4f5-6011-4f3b-9677-7eb8872e9f82" }
                });

            migrationBuilder.InsertData(
                table: "Resolutions",
                columns: new[] { "ResolutionId", "ResolutionAbstract", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("48342a2b-4c07-4b19-8c52-9cd2077edb35"), "Abstract3", 2, "31432085-85bc-4648-8a82-e8ff8b5671cc" },
                    { new Guid("a69d7016-23c5-4520-ab41-bf4167c3866e"), "Abstract2", 1, "fda8e4f5-6011-4f3b-9677-7eb8872e9f82" },
                    { new Guid("ad483ad4-d93c-4b8f-b524-98316aad19a6"), "Abstract4", 3, "a41390e5-790c-488f-8639-1db213da8375" },
                    { new Guid("ec7bf106-f607-4f33-aba8-aa2001c0073b"), "Abstract1", 0, "6af8ed9c-0bac-40ac-aff2-f5d005dced65" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Link", "Message", "ResolutionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c1131d8-e45b-458b-a153-31aa3b933151"), "www.microsoft.ca", 0, new Guid("48342a2b-4c07-4b19-8c52-9cd2077edb35"), "31432085-85bc-4648-8a82-e8ff8b5671cc" },
                    { new Guid("5e502112-f9ae-4339-98d6-ae24b14917a6"), "www.amazon.ca", 1, new Guid("ad483ad4-d93c-4b8f-b524-98316aad19a6"), "a41390e5-790c-488f-8639-1db213da8375" },
                    { new Guid("a32d462e-bd7b-4ba4-8a41-4439869ef844"), "www.google.ca", 0, new Guid("ec7bf106-f607-4f33-aba8-aa2001c0073b"), "6af8ed9c-0bac-40ac-aff2-f5d005dced65" },
                    { new Guid("c906addc-3edb-4803-aa1a-a5c2ce1f32c3"), "www.apple.ca", 1, new Guid("a69d7016-23c5-4520-ab41-bf4167c3866e"), "fda8e4f5-6011-4f3b-9677-7eb8872e9f82" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ResolutionId",
                table: "Feedbacks",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_UserId",
                table: "Resolutions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
