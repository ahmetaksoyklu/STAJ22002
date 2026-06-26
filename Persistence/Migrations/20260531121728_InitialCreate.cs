using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_bapbirim_ondegerlendirme_uyesi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    eposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    birim_id = table.Column<int>(type: "int", nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapbirim_ondegerlendirme_uyesi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_baphakem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    eposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    unvan = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    kurum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_baphakem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapkomisyonu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    eposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gorev = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapkomisyonu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapproje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ozet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yurutucu_user_id = table.Column<int>(type: "int", nullable: false),
                    proje_tipi_id = table.Column<int>(type: "int", nullable: false),
                    durum = table.Column<int>(type: "int", nullable: false),
                    baslangic_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bitis_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapproje", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_birimler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    birim_adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    birim_kodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_birimler", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_dosya_deposu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sira_no = table.Column<int>(type: "int", nullable: false),
                    dosya_adi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    dosya_tipi = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_dosya_deposu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_form_sablonlari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kod = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_form_sablonlari", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_hazir_mesajlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    baslik = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    konu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hazir_mesajlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_log_kaydi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullanici = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    controller = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    islem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ip_adresi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_log_kaydi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mesajlar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kimden = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    kime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    konu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    okundu_mu = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    silindi_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mesajlar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_oturum_kaydi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ip_adresi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    basarili_mi = table.Column<bool>(type: "bit", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_oturum_kaydi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_proje_tipleri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_proje_tipleri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sorun_bildirimleri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    konu = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ip_adresi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    durum = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sorun_bildirimleri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    aktif_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapbirim_ondegerlendirme_raporu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    kurul_uyesi_id = table.Column<int>(type: "int", nullable: false),
                    form_kodu = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    cevaplar_json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degerlendirme_sonucu = table.Column<int>(type: "int", nullable: false),
                    gerekce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapbirim_ondegerlendirme_raporu", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapbirim_ondegerlendirme_raporu_tbl_bapbirim_ondegerlendirme_uyesi_kurul_uyesi_id",
                        column: x => x.kurul_uyesi_id,
                        principalTable: "tbl_bapbirim_ondegerlendirme_uyesi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_bapbirim_ondegerlendirme_raporu_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapdetaylibutce",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    butce_kalemi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    talep_edilen_tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapdetaylibutce", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapdetaylibutce_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapekbutce_talebi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    talep_edilen_tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    kabul_edilen_tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    gerekce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    karar = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    karar_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapekbutce_talebi", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapekbutce_talebi_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapeksure_talebi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    talep_edilen_sure = table.Column<int>(type: "int", nullable: false),
                    gerekce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    karar = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    karar_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapeksure_talebi", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapeksure_talebi_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapharcama",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    butce_kalemi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    belge_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    harcama_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapharcama", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapharcama_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapkomisyonu_karar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    komisyon_uyesi_id = table.Column<int>(type: "int", nullable: false),
                    karar_tipi = table.Column<int>(type: "int", nullable: false),
                    karar_metni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gerekce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    karar_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapkomisyonu_karar", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapkomisyonu_karar_tbl_bapkomisyonu_komisyon_uyesi_id",
                        column: x => x.komisyon_uyesi_id,
                        principalTable: "tbl_bapkomisyonu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_bapkomisyonu_karar_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapproformafatura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    firma_adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapproformafatura", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapproformafatura_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapproje_arastirmacilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    eposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    kurum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    gorev = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    katki_orani = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapproje_arastirmacilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapproje_arastirmacilar_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapproje_raporu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    rapor_kodu = table.Column<int>(type: "int", nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    hakeme_gonderildi_mi = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    gonderim_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    hakem_onayi = table.Column<bool>(type: "bit", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapproje_raporu", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapproje_raporu_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_baptekniksartname",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    baslik = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_baptekniksartname", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_baptekniksartname_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_bapyayin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    yayin_basligi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    dergi_adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    doi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    yayin_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dosya_yolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_bapyayin", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_bapyayin_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_projehakem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proje_id = table.Column<int>(type: "int", nullable: false),
                    hakem_id = table.Column<int>(type: "int", nullable: false),
                    hakemlik_durumu = table.Column<int>(type: "int", nullable: false),
                    davet_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cevap_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    degerlendirme_tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_projehakem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_projehakem_tbl_baphakem_hakem_id",
                        column: x => x.hakem_id,
                        principalTable: "tbl_baphakem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_projehakem_tbl_bapproje_proje_id",
                        column: x => x.proje_id,
                        principalTable: "tbl_bapproje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_form_sorulari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_sablonu_id = table.Column<int>(type: "int", nullable: false),
                    soru_metni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cevap_tipi = table.Column<int>(type: "int", nullable: false),
                    sira_no = table.Column<int>(type: "int", nullable: false),
                    zorunlu_mu = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_form_sorulari", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_form_sorulari_tbl_form_sablonlari_form_sablonu_id",
                        column: x => x.form_sablonu_id,
                        principalTable: "tbl_form_sablonlari",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sorun_yanitlari",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sorun_bildirimi_id = table.Column<int>(type: "int", nullable: false),
                    yanitlayan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    yanit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sorun_yanitlari", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_sorun_yanitlari_tbl_sorun_bildirimleri_sorun_bildirimi_id",
                        column: x => x.sorun_bildirimi_id,
                        principalTable: "tbl_sorun_bildirimleri",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapbirim_ondegerlendirme_raporu_kurul_uyesi_id",
                table: "tbl_bapbirim_ondegerlendirme_raporu",
                column: "kurul_uyesi_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapbirim_ondegerlendirme_raporu_proje_id",
                table: "tbl_bapbirim_ondegerlendirme_raporu",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapbirim_ondegerlendirme_uyesi_birim_id",
                table: "tbl_bapbirim_ondegerlendirme_uyesi",
                column: "birim_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapbirim_ondegerlendirme_uyesi_eposta",
                table: "tbl_bapbirim_ondegerlendirme_uyesi",
                column: "eposta");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapdetaylibutce_proje_id",
                table: "tbl_bapdetaylibutce",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapekbutce_talebi_proje_id",
                table: "tbl_bapekbutce_talebi",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapeksure_talebi_proje_id",
                table: "tbl_bapeksure_talebi",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_baphakem_eposta",
                table: "tbl_baphakem",
                column: "eposta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapharcama_butce_kalemi",
                table: "tbl_bapharcama",
                column: "butce_kalemi");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapharcama_proje_id",
                table: "tbl_bapharcama",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapkomisyonu_eposta",
                table: "tbl_bapkomisyonu",
                column: "eposta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapkomisyonu_karar_komisyon_uyesi_id",
                table: "tbl_bapkomisyonu_karar",
                column: "komisyon_uyesi_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapkomisyonu_karar_proje_id",
                table: "tbl_bapkomisyonu_karar",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproformafatura_proje_id",
                table: "tbl_bapproformafatura",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproje_durum",
                table: "tbl_bapproje",
                column: "durum");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproje_arastirmacilar_proje_id",
                table: "tbl_bapproje_arastirmacilar",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproje_arastirmacilar_proje_id_eposta",
                table: "tbl_bapproje_arastirmacilar",
                columns: new[] { "proje_id", "eposta" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproje_raporu_proje_id",
                table: "tbl_bapproje_raporu",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapproje_raporu_proje_id_rapor_kodu",
                table: "tbl_bapproje_raporu",
                columns: new[] { "proje_id", "rapor_kodu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_baptekniksartname_proje_id",
                table: "tbl_baptekniksartname",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapyayin_doi",
                table: "tbl_bapyayin",
                column: "doi");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bapyayin_proje_id",
                table: "tbl_bapyayin",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_birimler_birim_kodu",
                table: "tbl_birimler",
                column: "birim_kodu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_dosya_deposu_dosya_tipi",
                table: "tbl_dosya_deposu",
                column: "dosya_tipi");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_form_sablonlari_kod",
                table: "tbl_form_sablonlari",
                column: "kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_form_sorulari_form_sablonu_id",
                table: "tbl_form_sorulari",
                column: "form_sablonu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_form_sorulari_form_sablonu_id_sira_no",
                table: "tbl_form_sorulari",
                columns: new[] { "form_sablonu_id", "sira_no" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_log_kaydi_created_date",
                table: "tbl_log_kaydi",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mesajlar_kimden",
                table: "tbl_mesajlar",
                column: "kimden");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mesajlar_kime",
                table: "tbl_mesajlar",
                column: "kime");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_oturum_kaydi_created_date",
                table: "tbl_oturum_kaydi",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_oturum_kaydi_email",
                table: "tbl_oturum_kaydi",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_proje_tipleri_ad",
                table: "tbl_proje_tipleri",
                column: "ad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_projehakem_hakem_id",
                table: "tbl_projehakem",
                column: "hakem_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_projehakem_hakemlik_durumu",
                table: "tbl_projehakem",
                column: "hakemlik_durumu");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_projehakem_proje_id",
                table: "tbl_projehakem",
                column: "proje_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_projehakem_proje_id_hakem_id",
                table: "tbl_projehakem",
                columns: new[] { "proje_id", "hakem_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_sorun_yanitlari_sorun_bildirimi_id",
                table: "tbl_sorun_yanitlari",
                column: "sorun_bildirimi_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_email",
                table: "tbl_users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_bapbirim_ondegerlendirme_raporu");

            migrationBuilder.DropTable(
                name: "tbl_bapdetaylibutce");

            migrationBuilder.DropTable(
                name: "tbl_bapekbutce_talebi");

            migrationBuilder.DropTable(
                name: "tbl_bapeksure_talebi");

            migrationBuilder.DropTable(
                name: "tbl_bapharcama");

            migrationBuilder.DropTable(
                name: "tbl_bapkomisyonu_karar");

            migrationBuilder.DropTable(
                name: "tbl_bapproformafatura");

            migrationBuilder.DropTable(
                name: "tbl_bapproje_arastirmacilar");

            migrationBuilder.DropTable(
                name: "tbl_bapproje_raporu");

            migrationBuilder.DropTable(
                name: "tbl_baptekniksartname");

            migrationBuilder.DropTable(
                name: "tbl_bapyayin");

            migrationBuilder.DropTable(
                name: "tbl_birimler");

            migrationBuilder.DropTable(
                name: "tbl_dosya_deposu");

            migrationBuilder.DropTable(
                name: "tbl_form_sorulari");

            migrationBuilder.DropTable(
                name: "tbl_hazir_mesajlar");

            migrationBuilder.DropTable(
                name: "tbl_log_kaydi");

            migrationBuilder.DropTable(
                name: "tbl_mesajlar");

            migrationBuilder.DropTable(
                name: "tbl_oturum_kaydi");

            migrationBuilder.DropTable(
                name: "tbl_proje_tipleri");

            migrationBuilder.DropTable(
                name: "tbl_projehakem");

            migrationBuilder.DropTable(
                name: "tbl_sorun_yanitlari");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_bapbirim_ondegerlendirme_uyesi");

            migrationBuilder.DropTable(
                name: "tbl_bapkomisyonu");

            migrationBuilder.DropTable(
                name: "tbl_form_sablonlari");

            migrationBuilder.DropTable(
                name: "tbl_baphakem");

            migrationBuilder.DropTable(
                name: "tbl_bapproje");

            migrationBuilder.DropTable(
                name: "tbl_sorun_bildirimleri");
        }
    }
}
