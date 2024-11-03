﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Numarataj.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresTespit",
                columns: table => new
                {
                    BelgeNoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaddeSokak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisKapi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKapi2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    İcKapiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BagimsizBolge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EskiAdres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BlokAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsYeriUnvani = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IcKapiSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsyeriSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pafta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parsel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresTespit", x => x.BelgeNoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "OzelIsyeri",
                columns: table => new
                {
                    BelgeNoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaddeSokak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisKapi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKapi2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    İcKapiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BagimsizBolge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EskiAdres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BlokAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsYeriUnvani = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IcKapiSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsyeriSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pafta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parsel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzelIsyeri", x => x.BelgeNoId);
                });

            migrationBuilder.CreateTable(
                name: "ResmiKurum",
                columns: table => new
                {
                    BelgeNoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaddeSokak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisKapi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKapi2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    İcKapiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BagimsizBolge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EskiAdres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BlokAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsYeriUnvani = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IcKapiSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsyeriSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pafta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parsel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResmiKurum", x => x.BelgeNoId);
                });

            migrationBuilder.CreateTable(
                name: "SahaCalismasi",
                columns: table => new
                {
                    BelgeNoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaddeSokak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisKapi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKapi2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    İcKapiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BagimsizBolge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EskiAdres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BlokAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsYeriUnvani = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IcKapiSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsyeriSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pafta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parsel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SahaCalismasi", x => x.BelgeNoId);
                });

            migrationBuilder.CreateTable(
                name: "YeniBina",
                columns: table => new
                {
                    BelgeNoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mahalle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaddeSokak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisKapi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisKapi2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    İcKapiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BagimsizBolge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EskiAdres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BlokAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsYeriUnvani = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IcKapiSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsyeriSayisi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Pafta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Parsel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeniBina", x => x.BelgeNoId);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresTespit");

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
                name: "OzelIsyeri");

            migrationBuilder.DropTable(
                name: "ResmiKurum");

            migrationBuilder.DropTable(
                name: "SahaCalismasi");

            migrationBuilder.DropTable(
                name: "YeniBina");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
