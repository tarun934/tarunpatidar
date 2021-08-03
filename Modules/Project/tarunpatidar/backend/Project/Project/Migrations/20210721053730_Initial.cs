using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class Initial : Migration
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

            //migrationBuilder.CreateTable(
                //name: "AppUsers",
                //columns: table => new
                //{
                //    UserID = table.Column<int>(type: "int", nullable: false)
                //        .Annotation("SqlServer:Identity", "1, 1"),
                //    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                //    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                //    VisitedDays = table.Column<int>(type: "int", nullable: true),
                //    Reputation = table.Column<int>(type: "int", nullable: true),
                //    GitHub = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                //    Twitter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                //    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                //    datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                //    ProfileViews = table.Column<int>(type: "int", nullable: true),
                //    AboutUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                //    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                //},
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_AppUsers", x => x.UserID);
                //});

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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            //migrationBuilder.CreateTable(
            //    name: "Courses",
            //    columns: table => new
            //    {
            //        CourseId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        coursename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Courses = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        CourseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        coursedescription = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        UserID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PKCourseId", x => x.CourseId);
            //        table.ForeignKey(
            //            name: "FK_UserIDCourses",
            //            column: x => x.UserID,
            //            principalTable: "AppUsers",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Fees",
            //    columns: table => new
            //    {
            //        FeeID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: true),
            //        feetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        feedescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PKFeeID", x => x.FeeID);
            //        table.ForeignKey(
            //            name: "FK_UserIDFees",
            //            column: x => x.UserID,
            //            principalTable: "AppUsers",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Schedule",
            //    columns: table => new
            //    {
            //        schId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: true),
            //        schName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        schTime = table.Column<int>(type: "int", nullable: false),
            //        schDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        schDate = table.Column<DateTime>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PKSchID", x => x.schId);
            //        table.ForeignKey(
            //            name: "FK_UserIDSchedule",
            //            column: x => x.UserID,
            //            principalTable: "AppUsers",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Student",
            //    columns: table => new
            //    {
            //        stuid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: true),
            //        stuname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        stuMoblie = table.Column<int>(type: "int", nullable: false),
            //        stuEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        stuAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PKStuID", x => x.stuid);
            //        table.ForeignKey(
            //            name: "FK_UserIDStudent",
            //            column: x => x.UserID,
            //            principalTable: "AppUsers",
            //            principalColumn: "UserID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AppUsers_ApplicationUserId",
            //    table: "AppUsers",
            //    column: "ApplicationUserId");

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_Courses_UserID",
            //    table: "Courses",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Fees_UserID",
            //    table: "Fees",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Schedule_UserID",
            //    table: "Schedule",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Student_UserID",
            //    table: "Student",
            //    column: "UserID");
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

            //migrationBuilder.DropTable(
            //    name: "Courses");

            //migrationBuilder.DropTable(
            //    name: "Fees");

            //migrationBuilder.DropTable(
            //    name: "Schedule");

            //migrationBuilder.DropTable(
            //    name: "Student");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}