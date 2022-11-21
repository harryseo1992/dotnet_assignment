using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1_v3.Data.Migrations
{
    public partial class seedingUpdateFinal : Migration
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
                    { "4a65288b-cae5-495e-bcf4-f15d9b76d6dd", "0735fb30-0e42-4a31-b168-a0875a2df2bf", "Admin", "ADMIN" },
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "4d9e1367-f5ba-4661-b057-110d9193d763", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SignatureGUID", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "068d969d-26df-49f2-822d-b217ab5c67dd", 0, "9377c934-f27e-4467-9f5f-b87e219feeac", "ApplicationUser", "comp4976@outlook.com", false, "Medhat", "Elmasry", false, null, null, "COMP4976@OUTLOOK.COM", "AQAAAAEAACcQAAAAEOp7nx9kyg7ES99zATRv1ifjjhpgkCI0bjYgm+6IpUEy3iwZsjGvh/Disb8aF6t+pA==", null, false, "ba32b2a9-d643-4b72-bb6e-3f8d6a9b179d", "2fbc1c15-14f6-4ef2-a7b7-aebcb6b2eda1", false, "comp4976@outlook.com" },
                    { "36abd8f9-4a73-49e0-b56e-57187be189e3", 0, "47905e72-a399-4dab-8a33-ee69ffd83fa2", "ApplicationUser", "11@11.11", true, "Pat", "John", false, null, null, "11@11.11", "AQAAAAEAACcQAAAAEBYsdSMS1Chd81phDvzeISas88x/klMJVJg3QjB4j2eJrYsbrWEH79N2qxcD3OuYLw==", null, false, "b4ac74af-198c-4c8e-937b-3359cb7b5247", "d7baffd3-d330-410a-91b1-f25f9885cf39", false, "11@11.11" },
                    { "7a9c7811-25c5-41be-95f9-63343ef85d16", 0, "e55d0316-1db3-48d4-a307-488e100cfe7e", "ApplicationUser", "22@22.22", true, "Sue", "Fox", false, null, null, "22@22.22", "AQAAAAEAACcQAAAAEK3A2bbUH/GgAfTNXcUJD5azzFHmn1Oj9goDK+lBBUCTNqZpV69mYDT2XlnOCZeXNg==", null, false, "6bc99793-b7d3-45fb-89a1-9a1b44563d13", "efe2a3aa-4f74-49e1-be9b-bddd9243f6f8", false, "22@22.22" },
                    { "9d739ef4-95b5-4874-9218-c4da3feeb5dd", 0, "ed1424f0-99d3-4f81-8025-23e35332642c", "ApplicationUser", "44@44.44", true, "Eddy", "Glen", false, null, null, "44@44.44", "AQAAAAEAACcQAAAAEJX+rRZKVQ9BclY5pEdXHjOySbs68IyFvIoDrbgNiguABR177Au2dHNuSGeGYTDo7w==", null, false, "f9d66631-f1a1-44dc-9d92-ce8e0d651622", "c7a473d4-0a79-43df-8c9a-030b6585e063", false, "44@44.44" },
                    { "a5032dce-7ed6-460f-84f5-4d923f28ffde", 0, "2596ee57-7bd4-4ae4-ac06-17dc785a62dd", "ApplicationUser", "33@33.33", true, "Bob", "Sims", false, null, null, "33@33.33", "AQAAAAEAACcQAAAAEEGccW7gNQ/bIQXU8My3WQoiYzwzHrpjZsziJA0VN0WFLfhHp/bNve6zu/F3XtwKAw==", null, false, "efcd0273-2839-45ec-bcd5-81a451dc5d70", "fedea933-357e-4425-9ca0-988c5182fb60", false, "33@33.33" },
                    { "d0006598-08aa-4dc3-9a71-7ace54bca36d", 0, "095355bc-2d23-4d63-8565-d3b37cda3adf", "ApplicationUser", "aa@aa.aa", true, "Admin", "Administrator", false, null, null, "AA@AA.AA", "AQAAAAEAACcQAAAAEEwGIuH+Fe8rfjyhHXTYAVl8IinjVlUr39IRrYPQtzykcGXME7SjPeb/0J/G6qA8TQ==", null, false, "7e45f89e-7d83-444d-932a-e49f85b0bcad", "c284c601-cd56-4a66-a463-ee3861a2b939", false, "aa@aa.aa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "068d969d-26df-49f2-822d-b217ab5c67dd" },
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "36abd8f9-4a73-49e0-b56e-57187be189e3" },
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "7a9c7811-25c5-41be-95f9-63343ef85d16" },
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "9d739ef4-95b5-4874-9218-c4da3feeb5dd" },
                    { "4eb3b282-6f1c-4de8-a9c8-0e65d50c7c0e", "a5032dce-7ed6-460f-84f5-4d923f28ffde" },
                    { "4a65288b-cae5-495e-bcf4-f15d9b76d6dd", "d0006598-08aa-4dc3-9a71-7ace54bca36d" }
                });

            migrationBuilder.InsertData(
                table: "Resolutions",
                columns: new[] { "ResolutionId", "ResolutionAbstract", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("7cfcfe6e-8e77-46d6-9ef4-dcc16ec20065"), "Abstract1", 0, "36abd8f9-4a73-49e0-b56e-57187be189e3" },
                    { new Guid("a53b5f28-60b5-4d70-991e-a9bd476b8b9b"), "Abstract2", 1, "7a9c7811-25c5-41be-95f9-63343ef85d16" },
                    { new Guid("f678a5b4-2be4-4ab1-a708-535e1558472b"), "Abstract4", 3, "9d739ef4-95b5-4874-9218-c4da3feeb5dd" },
                    { new Guid("fb9c5742-2ab8-428a-a281-2c2985c673a1"), "Abstract3", 2, "a5032dce-7ed6-460f-84f5-4d923f28ffde" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Link", "Message", "ResolutionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1933c839-6205-4a39-ad2c-8db6a19222cc"), "www.google.ca", 0, new Guid("7cfcfe6e-8e77-46d6-9ef4-dcc16ec20065"), "36abd8f9-4a73-49e0-b56e-57187be189e3" },
                    { new Guid("9b63d1a3-a449-4fd7-ad48-1e5b8685e27f"), "www.amazon.ca", 1, new Guid("f678a5b4-2be4-4ab1-a708-535e1558472b"), "9d739ef4-95b5-4874-9218-c4da3feeb5dd" },
                    { new Guid("df08baa6-0ed4-4706-a9d4-cd99748c1ae8"), "www.apple.ca", 1, new Guid("a53b5f28-60b5-4d70-991e-a9bd476b8b9b"), "7a9c7811-25c5-41be-95f9-63343ef85d16" },
                    { new Guid("fd913b3a-81f4-4f9e-9877-f0f5b922846e"), "www.microsoft.ca", 0, new Guid("fb9c5742-2ab8-428a-a281-2c2985c673a1"), "a5032dce-7ed6-460f-84f5-4d923f28ffde" }
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
