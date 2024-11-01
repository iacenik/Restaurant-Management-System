using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorilers",
                columns: table => new
                {
                    Kategori_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorilers", x => x.Kategori_Id);
                });

            migrationBuilder.CreateTable(
                name: "Masalars",
                columns: table => new
                {
                    Masa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masa_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masa_Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masalars", x => x.Masa_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rollers",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollers", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "Servisers",
                columns: table => new
                {
                    Servis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servis_Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategori_Id = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisers", x => x.Servis_Id);
                    table.ForeignKey(
                        name: "FK_Servisers_Kategorilers_Kategori_Id",
                        column: x => x.Kategori_Id,
                        principalTable: "Kategorilers",
                        principalColumn: "Kategori_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisers",
                columns: table => new
                {
                    Siparis_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Masa_Id = table.Column<int>(type: "int", nullable: false),
                    Acilis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kapanis = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisers", x => x.Siparis_Id);
                    table.ForeignKey(
                        name: "FK_Siparisers_Masalars_Masa_Id",
                        column: x => x.Masa_Id,
                        principalTable: "Masalars",
                        principalColumn: "Masa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personellers",
                columns: table => new
                {
                    Personel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masa_Id = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personellers", x => x.Personel_Id);
                    table.ForeignKey(
                        name: "FK_Personellers_Masalars_Masa_Id",
                        column: x => x.Masa_Id,
                        principalTable: "Masalars",
                        principalColumn: "Masa_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personellers_Rollers_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rollers",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adisyons",
                columns: table => new
                {
                    Adisyon_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Siparis_Id = table.Column<int>(type: "int", nullable: false),
                    Servis_Id = table.Column<int>(type: "int", nullable: true),
                    Adet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adisyons", x => x.Adisyon_Id);
                    table.ForeignKey(
                        name: "FK_Adisyons_Servisers_Servis_Id",
                        column: x => x.Servis_Id,
                        principalTable: "Servisers",
                        principalColumn: "Servis_Id");
                    table.ForeignKey(
                        name: "FK_Adisyons_Siparisers_Siparis_Id",
                        column: x => x.Siparis_Id,
                        principalTable: "Siparisers",
                        principalColumn: "Siparis_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adisyons_Servis_Id",
                table: "Adisyons",
                column: "Servis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Adisyons_Siparis_Id",
                table: "Adisyons",
                column: "Siparis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personellers_Masa_Id",
                table: "Personellers",
                column: "Masa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personellers_Rol_Id",
                table: "Personellers",
                column: "Rol_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servisers_Kategori_Id",
                table: "Servisers",
                column: "Kategori_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisers_Masa_Id",
                table: "Siparisers",
                column: "Masa_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adisyons");

            migrationBuilder.DropTable(
                name: "Personellers");

            migrationBuilder.DropTable(
                name: "Servisers");

            migrationBuilder.DropTable(
                name: "Siparisers");

            migrationBuilder.DropTable(
                name: "Rollers");

            migrationBuilder.DropTable(
                name: "Kategorilers");

            migrationBuilder.DropTable(
                name: "Masalars");
        }
    }
}
