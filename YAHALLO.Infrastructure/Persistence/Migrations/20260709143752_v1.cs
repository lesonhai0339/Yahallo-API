using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    Countries = table.Column<int>(type: "int", nullable: false),
                    Depscription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LifeStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, collation: "Latin1_General_CI_AI"),
                    Countries = table.Column<int>(type: "int", nullable: false),
                    Depscription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LifeStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PhoneCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    FullName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    VietnameseName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    FaxCode = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PendingRegistration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    MatchReason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MatchedSource = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReviewedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewNote = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingRegistration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    RoleCode = table.Column<int>(type: "int", unicode: false, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnTrustEmail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnTrustEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnTrustPhone",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnTrustPhone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, collation: "Latin1_General_CI_AI"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, collation: "Latin1_General_CI_AI"),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, collation: "Latin1_General_CI_AI"),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    PhoneConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LastActiveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvatarThumbnail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BackgroundThumbnail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false),
                    DisLike = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OldPassword",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OldPasswords = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldPassword", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_OldPassword_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserReport = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Plan = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBlacklist",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBlacklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBlacklist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDailyActivity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ChapterCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SearchCount = table.Column<int>(type: "int", nullable: false),
                    ActiveMinutes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    LastActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDailyActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDailyActivity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    BgImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BgOpacity = table.Column<float>(type: "real", nullable: true),
                    BgBlur = table.Column<float>(type: "real", nullable: true),
                    FontFamily = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontSize = table.Column<int>(type: "int", nullable: true),
                    FontWeight = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FontColor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ListView = table.Column<int>(type: "int", nullable: true),
                    PageSize = table.Column<int>(type: "int", nullable: true),
                    ProgressReadMode = table.Column<int>(type: "int", nullable: false),
                    RetentionDays = table.Column<int>(type: "int", nullable: false),
                    MaxEntries = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastUseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoginLocation = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredRefreshToken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThreadOfBlog",
                columns: table => new
                {
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThreadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadOfBlog", x => new { x.ThreadId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_ThreadOfBlog_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThreadOfBlog_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssociateName",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Url1 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Url2 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Url3 = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReportEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachment_Report_ReportEntityId",
                        column: x => x.ReportEntityId,
                        principalTable: "Report",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookmark",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, collation: "Latin1_General_CI_AI"),
                    Descriptions = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmark_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmark_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Index = table.Column<int>(type: "int", unicode: false, nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChapterImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Index = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ResizeUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    ResizeWidth = table.Column<int>(type: "int", nullable: false),
                    ResizeHeight = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterImage_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, collation: "Latin1_General_CI_AI"),
                    SeasonName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Countries = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    MangaThumbnail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MangaBackground = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LastChapterIndex = table.Column<int>(type: "int", nullable: true),
                    LastChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChapterUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MangaGroupId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manga_Chapter_LastChapterId",
                        column: x => x.LastChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manga_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manga_MangaGroup_MangaGroupId",
                        column: x => x.MangaGroupId,
                        principalTable: "MangaGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manga_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CanComment = table.Column<bool>(type: "bit", nullable: false),
                    CanRemove = table.Column<bool>(type: "bit", nullable: false),
                    CanHide = table.Column<bool>(type: "bit", nullable: false),
                    CanLike = table.Column<bool>(type: "bit", nullable: false),
                    CanReply = table.Column<bool>(type: "bit", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DisLikeCount = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CommentType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReplyToCommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentToUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ReplyToCommentId",
                        column: x => x.ReplyToCommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_CommentToUserId",
                        column: x => x.CommentToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => new { x.UserId, x.MangaId });
                    table.ForeignKey(
                        name: "FK_Follow_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MangaArtist",
                columns: table => new
                {
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaArtist", x => new { x.MangaId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_MangaArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MangaArtist_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthor",
                columns: table => new
                {
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthor", x => new { x.MangaId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MangaDailyAnalytics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    FollowerCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaDailyAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangaDailyAnalytics_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MangaTag",
                columns: table => new
                {
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTag", x => new { x.MangaId, x.TagId });
                    table.ForeignKey(
                        name: "FK_MangaTag_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingTo = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToMangaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Chapter_ToChapterId",
                        column: x => x.ToChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Manga_ToMangaId",
                        column: x => x.ToMangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingProgress",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastPage = table.Column<int>(type: "int", nullable: false),
                    LastReadAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingProgress", x => new { x.UserId, x.MangaId, x.ChapterId });
                    table.ForeignKey(
                        name: "FK_ReadingProgress_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingProgress_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingProgress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMangaDailyRead",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMangaDailyRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMangaView",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VisitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMangaView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMangaView_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMangaView_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reaction = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reaction_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reaction_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reaction_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reaction_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reaction_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViewCount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DayCount = table.Column<long>(type: "bigint", nullable: false),
                    MonthCount = table.Column<long>(type: "bigint", nullable: false),
                    YearCount = table.Column<long>(type: "bigint", nullable: false),
                    TotalCount = table.Column<long>(type: "bigint", nullable: false),
                    LastDateModify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMonthModify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastYearModify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewCount_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewCount_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewCount_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewCount_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "FaxCode", "FullName", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "Name", "PhoneCode", "UpdateDate", "VietnameseName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 1, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4889), null, 93, "Afghanistan", null, null, null, "AF", 93, null, "Afghanistan" },
                    { "00000000-0000-0000-0000-000000000002", 2, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4925), null, 358, "Åland Islands", null, null, null, "AX", 358, null, "Quần đảo Åland" },
                    { "00000000-0000-0000-0000-000000000003", 3, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4951), null, 355, "Albania", null, null, null, "AL", 355, null, "Albania" },
                    { "00000000-0000-0000-0000-000000000004", 4, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4957), null, 213, "Algeria", null, null, null, "DZ", 213, null, "Algeria" },
                    { "00000000-0000-0000-0000-000000000005", 5, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4963), null, 1684, "American Samoa", null, null, null, "AS", 1684, null, "Samoa thuộc Mỹ" },
                    { "00000000-0000-0000-0000-000000000006", 6, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4968), null, 376, "Andorra", null, null, null, "AD", 376, null, "Andorra" },
                    { "00000000-0000-0000-0000-000000000007", 7, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4973), null, 244, "Angola", null, null, null, "AO", 244, null, "Angola" },
                    { "00000000-0000-0000-0000-000000000008", 8, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4977), null, 1264, "Anguilla", null, null, null, "AI", 1264, null, "Anguilla" },
                    { "00000000-0000-0000-0000-000000000009", 9, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4982), null, 672, "Antarctica", null, null, null, "AQ", 672, null, "Nam Cực" },
                    { "00000000-0000-0000-0000-000000000010", 10, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4987), null, 1268, "Antigua and Barbuda", null, null, null, "AG", 1268, null, "Antigua và Barbuda" },
                    { "00000000-0000-0000-0000-000000000011", 11, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4992), null, 54, "Argentina", null, null, null, "AR", 54, null, "Argentina" },
                    { "00000000-0000-0000-0000-000000000012", 12, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(4996), null, 374, "Armenia", null, null, null, "AM", 374, null, "Armenia" },
                    { "00000000-0000-0000-0000-000000000013", 13, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5000), null, 297, "Aruba", null, null, null, "AW", 297, null, "Aruba" },
                    { "00000000-0000-0000-0000-000000000014", 14, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5004), null, 61, "Australia", null, null, null, "AU", 61, null, "Úc" },
                    { "00000000-0000-0000-0000-000000000015", 15, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5009), null, 43, "Austria", null, null, null, "AT", 43, null, "Áo" },
                    { "00000000-0000-0000-0000-000000000016", 16, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5013), null, 994, "Azerbaijan", null, null, null, "AZ", 994, null, "Azerbaijan" },
                    { "00000000-0000-0000-0000-000000000017", 17, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5017), null, 1242, "Bahamas", null, null, null, "BS", 1242, null, "Bahamas" },
                    { "00000000-0000-0000-0000-000000000018", 18, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5022), null, 973, "Bahrain", null, null, null, "BH", 973, null, "Bahrain" },
                    { "00000000-0000-0000-0000-000000000019", 19, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5026), null, 880, "Bangladesh", null, null, null, "BD", 880, null, "Bangladesh" },
                    { "00000000-0000-0000-0000-000000000020", 20, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5049), null, 1246, "Barbados", null, null, null, "BB", 1246, null, "Barbados" },
                    { "00000000-0000-0000-0000-000000000021", 21, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5054), null, 375, "Belarus", null, null, null, "BY", 375, null, "Belarus" },
                    { "00000000-0000-0000-0000-000000000022", 22, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5059), null, 32, "Belgium", null, null, null, "BE", 32, null, "Bỉ" },
                    { "00000000-0000-0000-0000-000000000023", 23, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5063), null, 501, "Belize", null, null, null, "BZ", 501, null, "Belize" },
                    { "00000000-0000-0000-0000-000000000024", 24, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5067), null, 229, "Benin", null, null, null, "BJ", 229, null, "Benin" },
                    { "00000000-0000-0000-0000-000000000025", 25, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5071), null, 1441, "Bermuda", null, null, null, "BM", 1441, null, "Bermuda" },
                    { "00000000-0000-0000-0000-000000000026", 26, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5076), null, 975, "Bhutan", null, null, null, "BT", 975, null, "Bhutan" },
                    { "00000000-0000-0000-0000-000000000027", 27, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5080), null, 591, "Bolivia (Plurinational State of)", null, null, null, "BO", 591, null, "Bolivia" },
                    { "00000000-0000-0000-0000-000000000028", 28, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5084), null, 599, "Bonaire, Sint Eustatius and Saba", null, null, null, "BQ", 599, null, "Bonaire, Sint Eustatius và Saba" },
                    { "00000000-0000-0000-0000-000000000029", 29, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5089), null, 387, "Bosnia and Herzegovina", null, null, null, "BA", 387, null, "Bosnia và Herzegovina" },
                    { "00000000-0000-0000-0000-000000000030", 30, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5093), null, 267, "Botswana", null, null, null, "BW", 267, null, "Botswana" },
                    { "00000000-0000-0000-0000-000000000031", 31, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5097), null, 47, "Bouvet Island", null, null, null, "BV", 47, null, "Đảo Bouvet" },
                    { "00000000-0000-0000-0000-000000000032", 32, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5101), null, 55, "Brazil", null, null, null, "BR", 55, null, "Brazil" },
                    { "00000000-0000-0000-0000-000000000033", 33, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5105), null, 246, "British Indian Ocean Territory", null, null, null, "IO", 246, null, "Lãnh thổ Ấn Độ Dương thuộc Anh" },
                    { "00000000-0000-0000-0000-000000000034", 34, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5109), null, 673, "Brunei Darussalam", null, null, null, "BN", 673, null, "Brunei" },
                    { "00000000-0000-0000-0000-000000000035", 35, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5113), null, 359, "Bulgaria", null, null, null, "BG", 359, null, "Bulgaria" },
                    { "00000000-0000-0000-0000-000000000036", 36, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5117), null, 226, "Burkina Faso", null, null, null, "BF", 226, null, "Burkina Faso" },
                    { "00000000-0000-0000-0000-000000000037", 37, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5140), null, 257, "Burundi", null, null, null, "BI", 257, null, "Burundi" },
                    { "00000000-0000-0000-0000-000000000038", 38, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5146), null, 238, "Cabo Verde", null, null, null, "CV", 238, null, "Cabo Verde" },
                    { "00000000-0000-0000-0000-000000000039", 39, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5150), null, 855, "Cambodia", null, null, null, "KH", 855, null, "Campuchia" },
                    { "00000000-0000-0000-0000-000000000040", 40, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5154), null, 237, "Cameroon", null, null, null, "CM", 237, null, "Cameroon" },
                    { "00000000-0000-0000-0000-000000000041", 41, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5158), null, 1, "Canada", null, null, null, "CA", 1, null, "Canada" },
                    { "00000000-0000-0000-0000-000000000042", 42, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5162), null, 1345, "Cayman Islands", null, null, null, "KY", 1345, null, "Quần đảo Cayman" },
                    { "00000000-0000-0000-0000-000000000043", 43, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5166), null, 236, "Central African Republic", null, null, null, "CF", 236, null, "Cộng hòa Trung Phi" },
                    { "00000000-0000-0000-0000-000000000044", 44, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5170), null, 235, "Chad", null, null, null, "TD", 235, null, "Tchad" },
                    { "00000000-0000-0000-0000-000000000045", 45, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5174), null, 56, "Chile", null, null, null, "CL", 56, null, "Chile" },
                    { "00000000-0000-0000-0000-000000000046", 46, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5179), null, 86, "China", null, null, null, "CN", 86, null, "Trung Quốc" },
                    { "00000000-0000-0000-0000-000000000047", 47, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5182), null, 61, "Christmas Island", null, null, null, "CX", 61, null, "Đảo Giáng Sinh" },
                    { "00000000-0000-0000-0000-000000000048", 48, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5187), null, 61, "Cocos (Keeling) Islands", null, null, null, "CC", 61, null, "Quần đảo Cocos" },
                    { "00000000-0000-0000-0000-000000000049", 49, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5190), null, 57, "Colombia", null, null, null, "CO", 57, null, "Colombia" },
                    { "00000000-0000-0000-0000-000000000050", 50, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5194), null, 269, "Comoros", null, null, null, "KM", 269, null, "Comoros" },
                    { "00000000-0000-0000-0000-000000000051", 51, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5198), null, 242, "Congo", null, null, null, "CG", 242, null, "Congo" },
                    { "00000000-0000-0000-0000-000000000052", 52, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5202), null, 243, "Congo (Democratic Republic of the)", null, null, null, "CD", 243, null, "Cộng hòa Dân chủ Congo" },
                    { "00000000-0000-0000-0000-000000000053", 53, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5206), null, 682, "Cook Islands", null, null, null, "CK", 682, null, "Quần đảo Cook" },
                    { "00000000-0000-0000-0000-000000000054", 54, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5224), null, 506, "Costa Rica", null, null, null, "CR", 506, null, "Costa Rica" },
                    { "00000000-0000-0000-0000-000000000055", 55, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5229), null, 225, "Côte d'Ivoire", null, null, null, "CI", 225, null, "Bờ Biển Ngà" },
                    { "00000000-0000-0000-0000-000000000056", 56, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5233), null, 385, "Croatia", null, null, null, "HR", 385, null, "Croatia" },
                    { "00000000-0000-0000-0000-000000000057", 57, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5237), null, 53, "Cuba", null, null, null, "CU", 53, null, "Cuba" },
                    { "00000000-0000-0000-0000-000000000058", 58, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5242), null, 599, "Curaçao", null, null, null, "CW", 599, null, "Curaçao" },
                    { "00000000-0000-0000-0000-000000000059", 59, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5246), null, 357, "Cyprus", null, null, null, "CY", 357, null, "Síp" },
                    { "00000000-0000-0000-0000-000000000060", 60, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5251), null, 420, "Czechia", null, null, null, "CZ", 420, null, "Cộng hòa Séc" },
                    { "00000000-0000-0000-0000-000000000061", 61, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5255), null, 45, "Denmark", null, null, null, "DK", 45, null, "Đan Mạch" },
                    { "00000000-0000-0000-0000-000000000062", 62, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5259), null, 253, "Djibouti", null, null, null, "DJ", 253, null, "Djibouti" },
                    { "00000000-0000-0000-0000-000000000063", 63, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5263), null, 1767, "Dominica", null, null, null, "DM", 1767, null, "Dominica" },
                    { "00000000-0000-0000-0000-000000000064", 64, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5267), null, 1809, "Dominican Republic", null, null, null, "DO", 1809, null, "Cộng hòa Dominica" },
                    { "00000000-0000-0000-0000-000000000065", 65, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5270), null, 593, "Ecuador", null, null, null, "EC", 593, null, "Ecuador" },
                    { "00000000-0000-0000-0000-000000000066", 66, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5274), null, 20, "Egypt", null, null, null, "EG", 20, null, "Ai Cập" },
                    { "00000000-0000-0000-0000-000000000067", 67, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5278), null, 503, "El Salvador", null, null, null, "SV", 503, null, "El Salvador" },
                    { "00000000-0000-0000-0000-000000000068", 68, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5282), null, 240, "Equatorial Guinea", null, null, null, "GQ", 240, null, "Guinea Xích Đạo" },
                    { "00000000-0000-0000-0000-000000000069", 69, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5286), null, 291, "Eritrea", null, null, null, "ER", 291, null, "Eritrea" },
                    { "00000000-0000-0000-0000-000000000070", 70, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5290), null, 372, "Estonia", null, null, null, "EE", 372, null, "Estonia" },
                    { "00000000-0000-0000-0000-000000000071", 71, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5319), null, 251, "Ethiopia", null, null, null, "ET", 251, null, "Ethiopia" },
                    { "00000000-0000-0000-0000-000000000072", 72, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5324), null, 500, "Falkland Islands (Malvinas)", null, null, null, "FK", 500, null, "Quần đảo Falkland" },
                    { "00000000-0000-0000-0000-000000000073", 73, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5328), null, 298, "Faroe Islands", null, null, null, "FO", 298, null, "Quần đảo Faroe" },
                    { "00000000-0000-0000-0000-000000000074", 74, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5332), null, 679, "Fiji", null, null, null, "FJ", 679, null, "Fiji" },
                    { "00000000-0000-0000-0000-000000000075", 75, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5337), null, 358, "Finland", null, null, null, "FI", 358, null, "Phần Lan" },
                    { "00000000-0000-0000-0000-000000000076", 76, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5341), null, 33, "France", null, null, null, "FR", 33, null, "Pháp" },
                    { "00000000-0000-0000-0000-000000000077", 77, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5345), null, 594, "French Guiana", null, null, null, "GF", 594, null, "Guyane thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000078", 78, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5349), null, 689, "French Polynesia", null, null, null, "PF", 689, null, "Polynesia thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000079", 79, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5371), null, 262, "French Southern Territories", null, null, null, "TF", 262, null, "Vùng đất phía Nam thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000080", 80, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5376), null, 241, "Gabon", null, null, null, "GA", 241, null, "Gabon" },
                    { "00000000-0000-0000-0000-000000000081", 81, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5380), null, 220, "Gambia", null, null, null, "GM", 220, null, "Gambia" },
                    { "00000000-0000-0000-0000-000000000082", 82, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5384), null, 995, "Georgia", null, null, null, "GE", 995, null, "Gruzia" },
                    { "00000000-0000-0000-0000-000000000083", 83, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5388), null, 49, "Germany", null, null, null, "DE", 49, null, "Đức" },
                    { "00000000-0000-0000-0000-000000000084", 84, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5393), null, 233, "Ghana", null, null, null, "GH", 233, null, "Ghana" },
                    { "00000000-0000-0000-0000-000000000085", 85, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5396), null, 350, "Gibraltar", null, null, null, "GI", 350, null, "Gibraltar" },
                    { "00000000-0000-0000-0000-000000000086", 86, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5400), null, 30, "Greece", null, null, null, "GR", 30, null, "Hy Lạp" },
                    { "00000000-0000-0000-0000-000000000087", 87, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5404), null, 299, "Greenland", null, null, null, "GL", 299, null, "Greenland" },
                    { "00000000-0000-0000-0000-000000000088", 88, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5434), null, 1473, "Grenada", null, null, null, "GD", 1473, null, "Grenada" },
                    { "00000000-0000-0000-0000-000000000089", 89, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5439), null, 590, "Guadeloupe", null, null, null, "GP", 590, null, "Guadeloupe" },
                    { "00000000-0000-0000-0000-000000000090", 90, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5443), null, 1671, "Guam", null, null, null, "GU", 1671, null, "Guam" },
                    { "00000000-0000-0000-0000-000000000091", 91, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5447), null, 502, "Guatemala", null, null, null, "GT", 502, null, "Guatemala" },
                    { "00000000-0000-0000-0000-000000000092", 92, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5451), null, 44, "Guernsey", null, null, null, "GG", 44, null, "Guernsey" },
                    { "00000000-0000-0000-0000-000000000093", 93, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5455), null, 224, "Guinea", null, null, null, "GN", 224, null, "Guinea" },
                    { "00000000-0000-0000-0000-000000000094", 94, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5459), null, 245, "Guinea-Bissau", null, null, null, "GW", 245, null, "Guinea-Bissau" },
                    { "00000000-0000-0000-0000-000000000095", 95, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5463), null, 592, "Guyana", null, null, null, "GY", 592, null, "Guyana" },
                    { "00000000-0000-0000-0000-000000000096", 96, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5467), null, 509, "Haiti", null, null, null, "HT", 509, null, "Haiti" },
                    { "00000000-0000-0000-0000-000000000097", 97, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5471), null, 672, "Heard Island and McDonald Islands", null, null, null, "HM", 672, null, "Đảo Heard và McDonald" },
                    { "00000000-0000-0000-0000-000000000098", 98, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5475), null, 379, "Holy See", null, null, null, "VA", 379, null, "Tòa Thánh Vatican" },
                    { "00000000-0000-0000-0000-000000000099", 99, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5492), null, 504, "Honduras", null, null, null, "HN", 504, null, "Honduras" },
                    { "00000000-0000-0000-0000-000000000100", 100, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5496), null, 852, "Hong Kong", null, null, null, "HK", 852, null, "Hồng Kông" },
                    { "00000000-0000-0000-0000-000000000101", 101, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5505), null, 36, "Hungary", null, null, null, "HU", 36, null, "Hungary" },
                    { "00000000-0000-0000-0000-000000000102", 102, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5509), null, 354, "Iceland", null, null, null, "IS", 354, null, "Iceland" },
                    { "00000000-0000-0000-0000-000000000103", 103, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5513), null, 91, "India", null, null, null, "IN", 91, null, "Ấn Độ" },
                    { "00000000-0000-0000-0000-000000000104", 104, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5517), null, 62, "Indonesia", null, null, null, "ID", 62, null, "Indonesia" },
                    { "00000000-0000-0000-0000-000000000105", 105, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5540), null, 98, "Iran (Islamic Republic of)", null, null, null, "IR", 98, null, "Iran" },
                    { "00000000-0000-0000-0000-000000000106", 106, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5545), null, 964, "Iraq", null, null, null, "IQ", 964, null, "Iraq" },
                    { "00000000-0000-0000-0000-000000000107", 107, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5549), null, 353, "Ireland", null, null, null, "IE", 353, null, "Ireland" },
                    { "00000000-0000-0000-0000-000000000108", 108, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5554), null, 44, "Isle of Man", null, null, null, "IM", 44, null, "Đảo Man" },
                    { "00000000-0000-0000-0000-000000000109", 109, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5558), null, 972, "Israel", null, null, null, "IL", 972, null, "Israel" },
                    { "00000000-0000-0000-0000-000000000110", 110, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5562), null, 39, "Italy", null, null, null, "IT", 39, null, "Ý" },
                    { "00000000-0000-0000-0000-000000000111", 111, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5566), null, 1876, "Jamaica", null, null, null, "JM", 1876, null, "Jamaica" },
                    { "00000000-0000-0000-0000-000000000112", 112, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5570), null, 81, "Japan", null, null, null, "JP", 81, null, "Nhật Bản" },
                    { "00000000-0000-0000-0000-000000000113", 113, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5575), null, 44, "Jersey", null, null, null, "JE", 44, null, "Jersey" },
                    { "00000000-0000-0000-0000-000000000114", 114, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5579), null, 962, "Jordan", null, null, null, "JO", 962, null, "Jordan" },
                    { "00000000-0000-0000-0000-000000000115", 115, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5583), null, 7, "Kazakhstan", null, null, null, "KZ", 7, null, "Kazakhstan" },
                    { "00000000-0000-0000-0000-000000000116", 116, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5587), null, 254, "Kenya", null, null, null, "KE", 254, null, "Kenya" },
                    { "00000000-0000-0000-0000-000000000117", 117, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5591), null, 686, "Kiribati", null, null, null, "KI", 686, null, "Kiribati" },
                    { "00000000-0000-0000-0000-000000000118", 118, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5595), null, 850, "Korea (Democratic People's Republic of)", null, null, null, "KP", 850, null, "Triều Tiên" },
                    { "00000000-0000-0000-0000-000000000119", 119, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5599), null, 82, "Korea (Republic of)", null, null, null, "KR", 82, null, "Hàn Quốc" },
                    { "00000000-0000-0000-0000-000000000120", 120, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5603), null, 965, "Kuwait", null, null, null, "KW", 965, null, "Kuwait" },
                    { "00000000-0000-0000-0000-000000000121", 121, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5607), null, 996, "Kyrgyzstan", null, null, null, "KG", 996, null, "Kyrgyzstan" },
                    { "00000000-0000-0000-0000-000000000122", 122, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5630), null, 856, "Lao People's Democratic Republic", null, null, null, "LA", 856, null, "Lào" },
                    { "00000000-0000-0000-0000-000000000123", 123, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5645), null, 371, "Latvia", null, null, null, "LV", 371, null, "Latvia" },
                    { "00000000-0000-0000-0000-000000000124", 124, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5649), null, 961, "Lebanon", null, null, null, "LB", 961, null, "Liban" },
                    { "00000000-0000-0000-0000-000000000125", 125, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5653), null, 266, "Lesotho", null, null, null, "LS", 266, null, "Lesotho" },
                    { "00000000-0000-0000-0000-000000000126", 126, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5658), null, 231, "Liberia", null, null, null, "LR", 231, null, "Liberia" },
                    { "00000000-0000-0000-0000-000000000127", 127, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5663), null, 218, "Libya", null, null, null, "LY", 218, null, "Libya" },
                    { "00000000-0000-0000-0000-000000000128", 128, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5667), null, 423, "Liechtenstein", null, null, null, "LI", 423, null, "Liechtenstein" },
                    { "00000000-0000-0000-0000-000000000129", 129, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5672), null, 370, "Lithuania", null, null, null, "LT", 370, null, "Litva" },
                    { "00000000-0000-0000-0000-000000000130", 130, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5676), null, 352, "Luxembourg", null, null, null, "LU", 352, null, "Luxembourg" },
                    { "00000000-0000-0000-0000-000000000131", 131, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5680), null, 853, "Macao", null, null, null, "MO", 853, null, "Ma Cao" },
                    { "00000000-0000-0000-0000-000000000132", 132, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5685), null, 389, "Macedonia (the former Yugoslav Republic of)", null, null, null, "MK", 389, null, "Bắc Macedonia" },
                    { "00000000-0000-0000-0000-000000000133", 133, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5689), null, 261, "Madagascar", null, null, null, "MG", 261, null, "Madagascar" },
                    { "00000000-0000-0000-0000-000000000134", 134, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5693), null, 265, "Malawi", null, null, null, "MW", 265, null, "Malawi" },
                    { "00000000-0000-0000-0000-000000000135", 135, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5697), null, 60, "Malaysia", null, null, null, "MY", 60, null, "Malaysia" },
                    { "00000000-0000-0000-0000-000000000136", 136, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5701), null, 960, "Maldives", null, null, null, "MV", 960, null, "Maldives" },
                    { "00000000-0000-0000-0000-000000000137", 137, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5706), null, 223, "Mali", null, null, null, "ML", 223, null, "Mali" },
                    { "00000000-0000-0000-0000-000000000138", 138, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5709), null, 356, "Malta", null, null, null, "MT", 356, null, "Malta" },
                    { "00000000-0000-0000-0000-000000000139", 139, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5750), null, 692, "Marshall Islands", null, null, null, "MH", 692, null, "Quần đảo Marshall" },
                    { "00000000-0000-0000-0000-000000000140", 140, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5754), null, 596, "Martinique", null, null, null, "MQ", 596, null, "Martinique" },
                    { "00000000-0000-0000-0000-000000000141", 141, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5759), null, 222, "Mauritania", null, null, null, "MR", 222, null, "Mauritania" },
                    { "00000000-0000-0000-0000-000000000142", 142, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5763), null, 230, "Mauritius", null, null, null, "MU", 230, null, "Mauritius" },
                    { "00000000-0000-0000-0000-000000000143", 143, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5768), null, 262, "Mayotte", null, null, null, "YT", 262, null, "Mayotte" },
                    { "00000000-0000-0000-0000-000000000144", 144, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5772), null, 52, "Mexico", null, null, null, "MX", 52, null, "Mexico" },
                    { "00000000-0000-0000-0000-000000000145", 145, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5777), null, 691, "Micronesia (Federated States of)", null, null, null, "FM", 691, null, "Micronesia" },
                    { "00000000-0000-0000-0000-000000000146", 146, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5781), null, 373, "Moldova (Republic of)", null, null, null, "MD", 373, null, "Moldova" },
                    { "00000000-0000-0000-0000-000000000147", 147, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5785), null, 377, "Monaco", null, null, null, "MC", 377, null, "Monaco" },
                    { "00000000-0000-0000-0000-000000000148", 148, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5789), null, 976, "Mongolia", null, null, null, "MN", 976, null, "Mông Cổ" },
                    { "00000000-0000-0000-0000-000000000149", 149, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5794), null, 382, "Montenegro", null, null, null, "ME", 382, null, "Montenegro" },
                    { "00000000-0000-0000-0000-000000000150", 150, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5798), null, 1664, "Montserrat", null, null, null, "MS", 1664, null, "Montserrat" },
                    { "00000000-0000-0000-0000-000000000151", 151, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5806), null, 212, "Morocco", null, null, null, "MA", 212, null, "Maroc" },
                    { "00000000-0000-0000-0000-000000000152", 152, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5810), null, 258, "Mozambique", null, null, null, "MZ", 258, null, "Mozambique" },
                    { "00000000-0000-0000-0000-000000000153", 153, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5814), null, 95, "Myanmar", null, null, null, "MM", 95, null, "Myanmar" },
                    { "00000000-0000-0000-0000-000000000154", 154, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5818), null, 264, "Namibia", null, null, null, "NA", 264, null, "Namibia" },
                    { "00000000-0000-0000-0000-000000000155", 155, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5822), null, 674, "Nauru", null, null, null, "NR", 674, null, "Nauru" },
                    { "00000000-0000-0000-0000-000000000156", 156, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5845), null, 977, "Nepal", null, null, null, "NP", 977, null, "Nepal" },
                    { "00000000-0000-0000-0000-000000000157", 157, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5850), null, 31, "Netherlands", null, null, null, "NL", 31, null, "Hà Lan" },
                    { "00000000-0000-0000-0000-000000000158", 158, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5854), null, 687, "New Caledonia", null, null, null, "NC", 687, null, "New Caledonia" },
                    { "00000000-0000-0000-0000-000000000159", 159, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5858), null, 64, "New Zealand", null, null, null, "NZ", 64, null, "New Zealand" },
                    { "00000000-0000-0000-0000-000000000160", 160, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5862), null, 505, "Nicaragua", null, null, null, "NI", 505, null, "Nicaragua" },
                    { "00000000-0000-0000-0000-000000000161", 161, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5866), null, 227, "Niger", null, null, null, "NE", 227, null, "Niger" },
                    { "00000000-0000-0000-0000-000000000162", 162, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5871), null, 234, "Nigeria", null, null, null, "NG", 234, null, "Nigeria" },
                    { "00000000-0000-0000-0000-000000000163", 163, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5875), null, 683, "Niue", null, null, null, "NU", 683, null, "Niue" },
                    { "00000000-0000-0000-0000-000000000164", 164, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5879), null, 672, "Norfolk Island", null, null, null, "NF", 672, null, "Đảo Norfolk" },
                    { "00000000-0000-0000-0000-000000000165", 165, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5883), null, 1670, "Northern Mariana Islands", null, null, null, "MP", 1670, null, "Quần đảo Bắc Mariana" },
                    { "00000000-0000-0000-0000-000000000166", 166, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5888), null, 47, "Norway", null, null, null, "NO", 47, null, "Na Uy" },
                    { "00000000-0000-0000-0000-000000000167", 167, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5892), null, 968, "Oman", null, null, null, "OM", 968, null, "Oman" },
                    { "00000000-0000-0000-0000-000000000168", 168, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5896), null, 92, "Pakistan", null, null, null, "PK", 92, null, "Pakistan" },
                    { "00000000-0000-0000-0000-000000000169", 169, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5900), null, 680, "Palau", null, null, null, "PW", 680, null, "Palau" },
                    { "00000000-0000-0000-0000-000000000170", 170, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5904), null, 970, "Palestine, State of", null, null, null, "PS", 970, null, "Palestine" },
                    { "00000000-0000-0000-0000-000000000171", 171, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5908), null, 507, "Panama", null, null, null, "PA", 507, null, "Panama" },
                    { "00000000-0000-0000-0000-000000000172", 172, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5912), null, 675, "Papua New Guinea", null, null, null, "PG", 675, null, "Papua New Guinea" },
                    { "00000000-0000-0000-0000-000000000173", 173, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5934), null, 595, "Paraguay", null, null, null, "PY", 595, null, "Paraguay" },
                    { "00000000-0000-0000-0000-000000000174", 174, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5939), null, 51, "Peru", null, null, null, "PE", 51, null, "Peru" },
                    { "00000000-0000-0000-0000-000000000175", 175, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5943), null, 63, "Philippines", null, null, null, "PH", 63, null, "Philippines" },
                    { "00000000-0000-0000-0000-000000000176", 176, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5947), null, 64, "Pitcairn", null, null, null, "PN", 64, null, "Quần đảo Pitcairn" },
                    { "00000000-0000-0000-0000-000000000177", 177, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5951), null, 48, "Poland", null, null, null, "PL", 48, null, "Ba Lan" },
                    { "00000000-0000-0000-0000-000000000178", 178, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5955), null, 351, "Portugal", null, null, null, "PT", 351, null, "Bồ Đào Nha" },
                    { "00000000-0000-0000-0000-000000000179", 179, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5959), null, 1787, "Puerto Rico", null, null, null, "PR", 1787, null, "Puerto Rico" },
                    { "00000000-0000-0000-0000-000000000180", 180, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5963), null, 974, "Qatar", null, null, null, "QA", 974, null, "Qatar" },
                    { "00000000-0000-0000-0000-000000000181", 181, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5968), null, 262, "Réunion", null, null, null, "RE", 262, null, "Réunion" },
                    { "00000000-0000-0000-0000-000000000182", 182, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5971), null, 40, "Romania", null, null, null, "RO", 40, null, "Romania" },
                    { "00000000-0000-0000-0000-000000000183", 183, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5975), null, 7, "Russian Federation", null, null, null, "RU", 7, null, "Nga" },
                    { "00000000-0000-0000-0000-000000000184", 184, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5979), null, 250, "Rwanda", null, null, null, "RW", 250, null, "Rwanda" },
                    { "00000000-0000-0000-0000-000000000185", 185, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5988), null, 590, "Saint Barthélemy", null, null, null, "BL", 590, null, "Saint Barthélemy" },
                    { "00000000-0000-0000-0000-000000000186", 186, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5993), null, 290, "Saint Helena, Ascension and Tristan da Cunha", null, null, null, "SH", 290, null, "Saint Helena" },
                    { "00000000-0000-0000-0000-000000000187", 187, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(5996), null, 1869, "Saint Kitts and Nevis", null, null, null, "KN", 1869, null, "Saint Kitts và Nevis" },
                    { "00000000-0000-0000-0000-000000000188", 188, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6000), null, 1758, "Saint Lucia", null, null, null, "LC", 1758, null, "Saint Lucia" },
                    { "00000000-0000-0000-0000-000000000189", 189, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6004), null, 590, "Saint Martin (French part)", null, null, null, "MF", 590, null, "Saint Martin (phần thuộc Pháp)" },
                    { "00000000-0000-0000-0000-000000000190", 190, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6021), null, 508, "Saint Pierre and Miquelon", null, null, null, "PM", 508, null, "Saint Pierre và Miquelon" },
                    { "00000000-0000-0000-0000-000000000191", 191, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6026), null, 1784, "Saint Vincent and the Grenadines", null, null, null, "VC", 1784, null, "Saint Vincent và Grenadines" },
                    { "00000000-0000-0000-0000-000000000192", 192, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6030), null, 685, "Samoa", null, null, null, "WS", 685, null, "Samoa" },
                    { "00000000-0000-0000-0000-000000000193", 193, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6035), null, 378, "San Marino", null, null, null, "SM", 378, null, "San Marino" },
                    { "00000000-0000-0000-0000-000000000194", 194, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6040), null, 239, "Sao Tome and Principe", null, null, null, "ST", 239, null, "São Tomé và Príncipe" },
                    { "00000000-0000-0000-0000-000000000195", 195, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6044), null, 966, "Saudi Arabia", null, null, null, "SA", 966, null, "Ả Rập Xê Út" },
                    { "00000000-0000-0000-0000-000000000196", 196, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6049), null, 221, "Senegal", null, null, null, "SN", 221, null, "Senegal" },
                    { "00000000-0000-0000-0000-000000000197", 197, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6053), null, 381, "Serbia", null, null, null, "RS", 381, null, "Serbia" },
                    { "00000000-0000-0000-0000-000000000198", 198, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6057), null, 248, "Seychelles", null, null, null, "SC", 248, null, "Seychelles" },
                    { "00000000-0000-0000-0000-000000000199", 199, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6061), null, 232, "Sierra Leone", null, null, null, "SL", 232, null, "Sierra Leone" },
                    { "00000000-0000-0000-0000-000000000200", 200, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6065), null, 65, "Singapore", null, null, null, "SG", 65, null, "Singapore" },
                    { "00000000-0000-0000-0000-000000000201", 201, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6069), null, 1721, "Sint Maarten (Dutch part)", null, null, null, "SX", 1721, null, "Sint Maarten (phần thuộc Hà Lan)" },
                    { "00000000-0000-0000-0000-000000000202", 202, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6073), null, 421, "Slovakia", null, null, null, "SK", 421, null, "Slovakia" },
                    { "00000000-0000-0000-0000-000000000203", 203, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6076), null, 386, "Slovenia", null, null, null, "SI", 386, null, "Slovenia" },
                    { "00000000-0000-0000-0000-000000000204", 204, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6080), null, 677, "Solomon Islands", null, null, null, "SB", 677, null, "Quần đảo Solomon" },
                    { "00000000-0000-0000-0000-000000000205", 205, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6084), null, 252, "Somalia", null, null, null, "SO", 252, null, "Somalia" },
                    { "00000000-0000-0000-0000-000000000206", 206, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6088), null, 27, "South Africa", null, null, null, "ZA", 27, null, "Nam Phi" },
                    { "00000000-0000-0000-0000-000000000207", 207, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6116), null, 500, "South Georgia and the South Sandwich Islands", null, null, null, "GS", 500, null, "Nam Georgia và Quần đảo Nam Sandwich" },
                    { "00000000-0000-0000-0000-000000000208", 208, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6121), null, 211, "South Sudan", null, null, null, "SS", 211, null, "Nam Sudan" },
                    { "00000000-0000-0000-0000-000000000209", 209, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6126), null, 34, "Spain", null, null, null, "ES", 34, null, "Tây Ban Nha" },
                    { "00000000-0000-0000-0000-000000000210", 210, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6130), null, 94, "Sri Lanka", null, null, null, "LK", 94, null, "Sri Lanka" },
                    { "00000000-0000-0000-0000-000000000211", 211, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6134), null, 249, "Sudan", null, null, null, "SD", 249, null, "Sudan" },
                    { "00000000-0000-0000-0000-000000000212", 212, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6138), null, 597, "Suriname", null, null, null, "SR", 597, null, "Suriname" },
                    { "00000000-0000-0000-0000-000000000213", 213, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6143), null, 47, "Svalbard and Jan Mayen", null, null, null, "SJ", 47, null, "Svalbard và Jan Mayen" },
                    { "00000000-0000-0000-0000-000000000214", 214, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6147), null, 268, "Swaziland", null, null, null, "SZ", 268, null, "Eswatini" },
                    { "00000000-0000-0000-0000-000000000215", 215, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6151), null, 46, "Sweden", null, null, null, "SE", 46, null, "Thụy Điển" },
                    { "00000000-0000-0000-0000-000000000216", 216, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6155), null, 41, "Switzerland", null, null, null, "CH", 41, null, "Thụy Sĩ" },
                    { "00000000-0000-0000-0000-000000000217", 217, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6159), null, 963, "Syrian Arab Republic", null, null, null, "SY", 963, null, "Syria" },
                    { "00000000-0000-0000-0000-000000000218", 218, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6163), null, 886, "Taiwan, Province of China", null, null, null, "TW", 886, null, "Đài Loan" },
                    { "00000000-0000-0000-0000-000000000219", 219, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6167), null, 992, "Tajikistan", null, null, null, "TJ", 992, null, "Tajikistan" },
                    { "00000000-0000-0000-0000-000000000220", 220, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6171), null, 255, "Tanzania, United Republic of", null, null, null, "TZ", 255, null, "Tanzania" },
                    { "00000000-0000-0000-0000-000000000221", 221, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6175), null, 66, "Thailand", null, null, null, "TH", 66, null, "Thái Lan" },
                    { "00000000-0000-0000-0000-000000000222", 222, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6179), null, 670, "Timor-Leste", null, null, null, "TL", 670, null, "Đông Timor" },
                    { "00000000-0000-0000-0000-000000000223", 223, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6183), null, 228, "Togo", null, null, null, "TG", 228, null, "Togo" },
                    { "00000000-0000-0000-0000-000000000224", 224, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6213), null, 690, "Tokelau", null, null, null, "TK", 690, null, "Tokelau" },
                    { "00000000-0000-0000-0000-000000000225", 225, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6218), null, 676, "Tonga", null, null, null, "TO", 676, null, "Tonga" },
                    { "00000000-0000-0000-0000-000000000226", 226, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6228), null, 1868, "Trinidad and Tobago", null, null, null, "TT", 1868, null, "Trinidad và Tobago" },
                    { "00000000-0000-0000-0000-000000000227", 227, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6232), null, 216, "Tunisia", null, null, null, "TN", 216, null, "Tunisia" },
                    { "00000000-0000-0000-0000-000000000228", 228, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6236), null, 90, "Turkey", null, null, null, "TR", 90, null, "Thổ Nhĩ Kỳ" },
                    { "00000000-0000-0000-0000-000000000229", 229, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6240), null, 993, "Turkmenistan", null, null, null, "TM", 993, null, "Turkmenistan" },
                    { "00000000-0000-0000-0000-000000000230", 230, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6244), null, 1649, "Turks and Caicos Islands", null, null, null, "TC", 1649, null, "Quần đảo Turks và Caicos" },
                    { "00000000-0000-0000-0000-000000000231", 231, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6248), null, 688, "Tuvalu", null, null, null, "TV", 688, null, "Tuvalu" },
                    { "00000000-0000-0000-0000-000000000232", 232, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6252), null, 256, "Uganda", null, null, null, "UG", 256, null, "Uganda" },
                    { "00000000-0000-0000-0000-000000000233", 233, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6257), null, 380, "Ukraine", null, null, null, "UA", 380, null, "Ukraine" },
                    { "00000000-0000-0000-0000-000000000234", 234, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6261), null, 971, "United Arab Emirates", null, null, null, "AE", 971, null, "Các Tiểu vương quốc Ả Rập Thống nhất" },
                    { "00000000-0000-0000-0000-000000000235", 235, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6265), null, 44, "United Kingdom of Great Britain and Northern Ireland", null, null, null, "GB", 44, null, "Vương quốc Anh" },
                    { "00000000-0000-0000-0000-000000000236", 236, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6269), null, 1, "United States of America", null, null, null, "US", 1, null, "Hoa Kỳ" },
                    { "00000000-0000-0000-0000-000000000237", 237, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6273), null, 1, "United States Minor Outlying Islands", null, null, null, "UM", 1, null, "Các đảo nhỏ xa của Hoa Kỳ" },
                    { "00000000-0000-0000-0000-000000000238", 238, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6277), null, 598, "Uruguay", null, null, null, "UY", 598, null, "Uruguay" },
                    { "00000000-0000-0000-0000-000000000239", 239, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6281), null, 998, "Uzbekistan", null, null, null, "UZ", 998, null, "Uzbekistan" },
                    { "00000000-0000-0000-0000-000000000240", 240, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6285), null, 678, "Vanuatu", null, null, null, "VU", 678, null, "Vanuatu" },
                    { "00000000-0000-0000-0000-000000000241", 241, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6310), null, 58, "Venezuela (Bolivarian Republic of)", null, null, null, "VE", 58, null, "Venezuela" },
                    { "00000000-0000-0000-0000-000000000242", 242, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6315), null, 84, "Viet Nam", null, null, null, "VN", 84, null, "Việt Nam" },
                    { "00000000-0000-0000-0000-000000000243", 243, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6320), null, 1284, "Virgin Islands (British)", null, null, null, "VG", 1284, null, "Quần đảo Virgin thuộc Anh" },
                    { "00000000-0000-0000-0000-000000000244", 244, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6324), null, 1340, "Virgin Islands (U.S.)", null, null, null, "VI", 1340, null, "Quần đảo Virgin thuộc Mỹ" },
                    { "00000000-0000-0000-0000-000000000245", 245, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6328), null, 681, "Wallis and Futuna", null, null, null, "WF", 681, null, "Wallis và Futuna" },
                    { "00000000-0000-0000-0000-000000000246", 246, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6333), null, 212, "Western Sahara", null, null, null, "EH", 212, null, "Tây Sahara" },
                    { "00000000-0000-0000-0000-000000000247", 247, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6336), null, 967, "Yemen", null, null, null, "YE", 967, null, "Yemen" },
                    { "00000000-0000-0000-0000-000000000248", 248, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6341), null, 260, "Zambia", null, null, null, "ZM", 260, null, "Zambia" },
                    { "00000000-0000-0000-0000-000000000249", 249, new DateTime(2026, 7, 9, 14, 37, 51, 711, DateTimeKind.Utc).AddTicks(6345), null, 263, "Zimbabwe", null, null, null, "ZW", 263, null, "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociateName_MangaId",
                table: "AssociateName",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_BlogId",
                table: "Attachment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CommentId",
                table: "Attachment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ReportEntityId",
                table: "Attachment",
                column: "ReportEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_BlogId",
                table: "Bookmark",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_ChapterId",
                table: "Bookmark",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_MangaId",
                table: "Bookmark",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_UserId",
                table: "Bookmark",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_Id_Index",
                table: "Chapter",
                columns: new[] { "Id", "Index" },
                unique: true,
                filter: "[DeleteDate] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_MangaId",
                table: "Chapter",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterImage_ChapterId_Index",
                table: "ChapterImage",
                columns: new[] { "ChapterId", "Index" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogId",
                table: "Comment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ChapterId_ParentId_CreateDate",
                table: "Comment",
                columns: new[] { "ChapterId", "ParentId", "CreateDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentToUserId",
                table: "Comment",
                column: "CommentToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MangaId_ParentId_CreateDate",
                table: "Comment",
                columns: new[] { "MangaId", "ParentId", "CreateDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReplyToCommentId",
                table: "Comment",
                column: "ReplyToCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId_CreateDate",
                table: "Comment",
                columns: new[] { "UserId", "CreateDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Country_Code",
                table: "Country",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_PhoneCode",
                table: "Country",
                column: "PhoneCode");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_MangaId",
                table: "Follow",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_CountryId",
                table: "Manga",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_LastChapterId",
                table: "Manga",
                column: "LastChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaGroupId",
                table: "Manga",
                column: "MangaGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_Name",
                table: "Manga",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_UserId",
                table: "Manga",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaArtist_ArtistId",
                table: "MangaArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthor_AuthorId",
                table: "MangaAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaDailyAnalytics_MangaId_Date",
                table: "MangaDailyAnalytics",
                columns: new[] { "MangaId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_TagId",
                table: "MangaTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingRegistration_Email",
                table: "PendingRegistration",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ToChapterId",
                table: "Rating",
                column: "ToChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ToMangaId",
                table: "Rating",
                column: "ToMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ToUserId",
                table: "Rating",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_BlogId",
                table: "Reaction",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ChapterId",
                table: "Reaction",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_MangaId",
                table: "Reaction",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_UserId",
                table: "Reaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingProgress_ChapterId",
                table: "ReadingProgress",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingProgress_MangaId",
                table: "ReadingProgress",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingProgress_UserId_LastReadAt",
                table: "ReadingProgress",
                columns: new[] { "UserId", "LastReadAt" })
                .Annotation("SqlServer:Include", new[] { "MangaId", "ChapterId", "LastPage" });

            migrationBuilder.CreateIndex(
                name: "IX_Report_Title",
                table: "Report",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId",
                table: "Subscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId_Status",
                table: "Subscription",
                columns: new[] { "UserId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Id",
                table: "Tag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThreadOfBlog_BlogId",
                table: "ThreadOfBlog",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_UnTrustEmail_Email",
                table: "UnTrustEmail",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnTrustPhone_Phone",
                table: "UnTrustPhone",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBlacklist_UserId",
                table: "UserBlacklist",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDailyActivity_UserId_Date",
                table: "UserDailyActivity",
                columns: new[] { "UserId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_ChapterId",
                table: "UserMangaDailyRead",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_MangaId_Date",
                table: "UserMangaDailyRead",
                columns: new[] { "MangaId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_UserId_ChapterId_Date",
                table: "UserMangaDailyRead",
                columns: new[] { "UserId", "ChapterId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaView_MangaId",
                table: "UserMangaView",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaView_UserId_MangaId_ViewedAt",
                table: "UserMangaView",
                columns: new[] { "UserId", "MangaId", "ViewedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaView_VisitorId_MangaId_ViewedAt",
                table: "UserMangaView",
                columns: new[] { "VisitorId", "MangaId", "ViewedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreateDate",
                table: "Users",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_Id_UserId",
                table: "UserSettings",
                columns: new[] { "Id", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RefreshToken",
                table: "UserToken",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCount_BlogId",
                table: "ViewCount",
                column: "BlogId",
                unique: true,
                filter: "[BlogId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCount_ChapterId",
                table: "ViewCount",
                column: "ChapterId",
                unique: true,
                filter: "[ChapterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCount_CommentId",
                table: "ViewCount",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCount_MangaId",
                table: "ViewCount",
                column: "MangaId",
                unique: true,
                filter: "[MangaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociateName_Manga_MangaId",
                table: "AssociateName",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Comment_CommentId",
                table: "Attachment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Chapter_ChapterId",
                table: "Bookmark",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Manga_MangaId",
                table: "Bookmark",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Manga_MangaId",
                table: "Chapter",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Manga_MangaId",
                table: "Chapter");

            migrationBuilder.DropTable(
                name: "AssociateName");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Bookmark");

            migrationBuilder.DropTable(
                name: "ChapterImage");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "MangaArtist");

            migrationBuilder.DropTable(
                name: "MangaAuthor");

            migrationBuilder.DropTable(
                name: "MangaDailyAnalytics");

            migrationBuilder.DropTable(
                name: "MangaTag");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OldPassword");

            migrationBuilder.DropTable(
                name: "PendingRegistration");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "ReadingProgress");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "ThreadOfBlog");

            migrationBuilder.DropTable(
                name: "UnTrustEmail");

            migrationBuilder.DropTable(
                name: "UnTrustPhone");

            migrationBuilder.DropTable(
                name: "UserBlacklist");

            migrationBuilder.DropTable(
                name: "UserDailyActivity");

            migrationBuilder.DropTable(
                name: "UserMangaDailyRead");

            migrationBuilder.DropTable(
                name: "UserMangaView");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "ViewCount");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Manga");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "MangaGroup");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
