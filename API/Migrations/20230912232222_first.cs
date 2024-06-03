using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dt_DetailsLot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInventaire = table.Column<int>(type: "int", nullable: false),
                    IdRayone = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NumberLot = table.Column<int>(type: "int", nullable: false),
                    Libbele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsScanned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dt_DetailsLot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "En_Enseigne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValidationRemiseEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsValidationRetraitEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_En_Enseigne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "In_addinventaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inventaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emplacement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_In_addinventaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "In_Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeExt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_In_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pr_FamilleProduit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr_FamilleProduit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pr_produit",
                columns: table => new
                {
                    CODE_INT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_CREATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIB_ETAT_ARTICLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIBELLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_GRP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_DEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_RAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_FAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_SFAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SFAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_SSFAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSFAM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODE_CAISSE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Ra_Rayone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRayone = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ra_Rayone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ro_Droit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ro_Droit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "En_Magasin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnseigneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_En_Magasin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_En_Magasin_En_Enseigne_EnseigneId",
                        column: x => x.EnseigneId,
                        principalTable: "En_Enseigne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ro_Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnseignesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ro_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ro_Profile_En_Enseigne_EnseignesId",
                        column: x => x.EnseignesId,
                        principalTable: "En_Enseigne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pr_Produit_Inventaire",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    externalVariantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    internalLogisticCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    intMerchStrucNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extMerchStrucNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    merchStructureID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invoicingUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stockUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    averageWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seqvl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr_Produit_Inventaire", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pr_Produit_Inventaire_In_addinventaire_InventaireId",
                        column: x => x.InventaireId,
                        principalTable: "In_addinventaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pr_AlerteProduit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnseigneId = table.Column<int>(type: "int", nullable: false),
                    FamilleProduitId = table.Column<int>(type: "int", nullable: false),
                    NbrJour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr_AlerteProduit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pr_AlerteProduit_En_Enseigne_EnseigneId",
                        column: x => x.EnseigneId,
                        principalTable: "En_Enseigne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pr_AlerteProduit_Pr_FamilleProduit_FamilleProduitId",
                        column: x => x.FamilleProduitId,
                        principalTable: "Pr_FamilleProduit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pr_Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDepartement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeRayon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeFamille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeSousFamille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeSousSousFamille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilleProduitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pr_Produits_Pr_FamilleProduit_FamilleProduitId",
                        column: x => x.FamilleProduitId,
                        principalTable: "Pr_FamilleProduit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "In_Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stockPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorisationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MagasinId = table.Column<int>(type: "int", nullable: true),
                    RayoneId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    NumberEmplacement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_In_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_In_Inventory_En_Magasin_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "En_Magasin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_In_Inventory_Ra_Rayone_RayoneId",
                        column: x => x.RayoneId,
                        principalTable: "Ra_Rayone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ro_DroitProfile",
                columns: table => new
                {
                    DroitId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ro_DroitProfile", x => new { x.ProfileId, x.DroitId });
                    table.ForeignKey(
                        name: "FK_Ro_DroitProfile_Ro_Droit_DroitId",
                        column: x => x.DroitId,
                        principalTable: "Ro_Droit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ro_DroitProfile_Ro_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Ro_Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ro_Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MagasinId = table.Column<int>(type: "int", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ro_Utilisateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ro_Utilisateur_En_Magasin_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "En_Magasin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ro_Utilisateur_Ro_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Ro_Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Em_Emplacement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: true),
                    RayoneId = table.Column<int>(type: "int", nullable: true),
                    TypeInventaire = table.Column<int>(type: "int", nullable: false),
                    NumberEmplacement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Emplacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Em_Emplacement_In_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "In_Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Em_Emplacement_Ra_Rayone_RayoneId",
                        column: x => x.RayoneId,
                        principalTable: "Ra_Rayone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pr_InnovTouchProduit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    CodeFamilleProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleFamilleProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrixInitial = table.Column<double>(type: "float", nullable: false),
                    QteInitiale = table.Column<int>(type: "int", nullable: false),
                    InnovTouch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    DateControl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QteActualise = table.Column<int>(type: "int", nullable: true),
                    MagasinId = table.Column<int>(type: "int", nullable: true),
                    CodeMagasin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemiseApplique = table.Column<bool>(type: "bit", nullable: true),
                    PrixRemise = table.Column<double>(type: "float", nullable: true),
                    PourcentageRemise = table.Column<double>(type: "float", nullable: true),
                    RespRemiseId = table.Column<int>(type: "int", nullable: true),
                    IsRemiseValide = table.Column<bool>(type: "bit", nullable: true),
                    DateValidationRemise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespRemiseValidationId = table.Column<int>(type: "int", nullable: true),
                    QteEtqImprime = table.Column<int>(type: "int", nullable: true),
                    IsRetraitValide = table.Column<bool>(type: "bit", nullable: true),
                    DateValidationRetrait = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespRetraitValidationId = table.Column<int>(type: "int", nullable: true),
                    RespRetraitId = table.Column<int>(type: "int", nullable: true),
                    IsRetire = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr_InnovTouchProduit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_En_Magasin_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "En_Magasin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Pr_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Pr_Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Ro_Utilisateur_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Ro_Utilisateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Ro_Utilisateur_RespRemiseId",
                        column: x => x.RespRemiseId,
                        principalTable: "Ro_Utilisateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Ro_Utilisateur_RespRemiseValidationId",
                        column: x => x.RespRemiseValidationId,
                        principalTable: "Ro_Utilisateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Ro_Utilisateur_RespRetraitId",
                        column: x => x.RespRetraitId,
                        principalTable: "Ro_Utilisateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pr_InnovTouchProduit_Ro_Utilisateur_RespRetraitValidationId",
                        column: x => x.RespRetraitValidationId,
                        principalTable: "Ro_Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Em_Emplacement_InventoryId",
                table: "Em_Emplacement",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Em_Emplacement_RayoneId",
                table: "Em_Emplacement",
                column: "RayoneId");

            migrationBuilder.CreateIndex(
                name: "IX_En_Magasin_EnseigneId",
                table: "En_Magasin",
                column: "EnseigneId");

            migrationBuilder.CreateIndex(
                name: "IX_In_Inventory_MagasinId",
                table: "In_Inventory",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_In_Inventory_RayoneId",
                table: "In_Inventory",
                column: "RayoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_AlerteProduit_EnseigneId",
                table: "Pr_AlerteProduit",
                column: "EnseigneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_AlerteProduit_FamilleProduitId",
                table: "Pr_AlerteProduit",
                column: "FamilleProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_AgentId",
                table: "Pr_InnovTouchProduit",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_MagasinId",
                table: "Pr_InnovTouchProduit",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_ProduitId",
                table: "Pr_InnovTouchProduit",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_RespRemiseId",
                table: "Pr_InnovTouchProduit",
                column: "RespRemiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_RespRemiseValidationId",
                table: "Pr_InnovTouchProduit",
                column: "RespRemiseValidationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_RespRetraitId",
                table: "Pr_InnovTouchProduit",
                column: "RespRetraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_InnovTouchProduit_RespRetraitValidationId",
                table: "Pr_InnovTouchProduit",
                column: "RespRetraitValidationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_Produit_Inventaire_InventaireId",
                table: "Pr_Produit_Inventaire",
                column: "InventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Pr_Produits_FamilleProduitId",
                table: "Pr_Produits",
                column: "FamilleProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ro_DroitProfile_DroitId",
                table: "Ro_DroitProfile",
                column: "DroitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ro_Profile_EnseignesId",
                table: "Ro_Profile",
                column: "EnseignesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ro_Utilisateur_MagasinId",
                table: "Ro_Utilisateur",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_Ro_Utilisateur_ProfileId",
                table: "Ro_Utilisateur",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dt_DetailsLot");

            migrationBuilder.DropTable(
                name: "Em_Emplacement");

            migrationBuilder.DropTable(
                name: "In_Zone");

            migrationBuilder.DropTable(
                name: "Pr_AlerteProduit");

            migrationBuilder.DropTable(
                name: "Pr_InnovTouchProduit");

            migrationBuilder.DropTable(
                name: "Pr_produit");

            migrationBuilder.DropTable(
                name: "Pr_Produit_Inventaire");

            migrationBuilder.DropTable(
                name: "Ro_DroitProfile");

            migrationBuilder.DropTable(
                name: "In_Inventory");

            migrationBuilder.DropTable(
                name: "Pr_Produits");

            migrationBuilder.DropTable(
                name: "Ro_Utilisateur");

            migrationBuilder.DropTable(
                name: "In_addinventaire");

            migrationBuilder.DropTable(
                name: "Ro_Droit");

            migrationBuilder.DropTable(
                name: "Ra_Rayone");

            migrationBuilder.DropTable(
                name: "Pr_FamilleProduit");

            migrationBuilder.DropTable(
                name: "En_Magasin");

            migrationBuilder.DropTable(
                name: "Ro_Profile");

            migrationBuilder.DropTable(
                name: "En_Enseigne");
        }
    }
}
