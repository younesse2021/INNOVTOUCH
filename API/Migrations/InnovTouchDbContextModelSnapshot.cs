﻿// <auto-generated />
using System;
using DAL.InnovTouch.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(InnovTouchDbContext))]
    partial class InnovTouchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Entite.Enseigne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsValidationRemiseEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValidationRetraitEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("En_Enseigne");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Entite.Magasin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnseigneId")
                        .HasColumnType("int");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnseigneId");

                    b.ToTable("En_Magasin");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.AddInventaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emplacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("inventaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("In_addinventaire");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.DetailsLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdInventaire")
                        .HasColumnType("int");

                    b.Property<int>("IdRayone")
                        .HasColumnType("int");

                    b.Property<bool>("IsScanned")
                        .HasColumnType("bit");

                    b.Property<string>("Libbele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberLot")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dt_DetailsLot");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Emplacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("NumberEmplacement")
                        .HasColumnType("int");

                    b.Property<int?>("RayoneId")
                        .HasColumnType("int");

                    b.Property<int>("TypeInventaire")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("RayoneId");

                    b.ToTable("Em_Emplacement");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MagasinId")
                        .HasColumnType("int");

                    b.Property<int>("NumberEmplacement")
                        .HasColumnType("int");

                    b.Property<int?>("RayoneId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stockPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("valorisationDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MagasinId");

                    b.HasIndex("RayoneId");

                    b.ToTable("In_Inventory");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.ProduitInfo", b =>
                {
                    b.Property<string>("CODE_CAISSE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_DEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_FAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_GRP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_INT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_RAY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_SFAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_SSFAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DATE_CREATION")
                        .HasColumnType("datetime2");

                    b.Property<string>("DEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ETAT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GRP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LIBELLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LIB_ETAT_ARTICLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SFAM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSFAM")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pr_produit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.ProduitList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventaireId")
                        .HasColumnType("int");

                    b.Property<string>("averageWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extMerchStrucNode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("externalVariantCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("intMerchStrucNode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("internalLogisticCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invoicingUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("merchStructureID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salePrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seqvl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stockUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("InventaireId");

                    b.ToTable("Pr_Produit_Inventaire");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRayone")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ra_Rayone");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codeExt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("locationsAvailable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("In_Zone");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.AlerteProduit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnseigneId")
                        .HasColumnType("int");

                    b.Property<int>("FamilleProduitId")
                        .HasColumnType("int");

                    b.Property<int>("NbrJour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnseigneId");

                    b.HasIndex("FamilleProduitId");

                    b.ToTable("Pr_AlerteProduit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.FamilleProduit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pr_FamilleProduit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.InnovTouchProduit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("CodeFamilleProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeMagasin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateControl")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateValidationRemise")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateValidationRetrait")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InnovTouch")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRemiseApplique")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRemiseValide")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRetire")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRetraitValide")
                        .HasColumnType("bit");

                    b.Property<string>("LibelleFamilleProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibelleProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MagasinId")
                        .HasColumnType("int");

                    b.Property<double?>("PourcentageRemise")
                        .HasColumnType("float");

                    b.Property<double>("PrixInitial")
                        .HasColumnType("float");

                    b.Property<double?>("PrixRemise")
                        .HasColumnType("float");

                    b.Property<int?>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int?>("QteActualise")
                        .HasColumnType("int");

                    b.Property<int?>("QteEtqImprime")
                        .HasColumnType("int");

                    b.Property<int>("QteInitiale")
                        .HasColumnType("int");

                    b.Property<int?>("RespRemiseId")
                        .HasColumnType("int");

                    b.Property<int?>("RespRemiseValidationId")
                        .HasColumnType("int");

                    b.Property<int?>("RespRetraitId")
                        .HasColumnType("int");

                    b.Property<int?>("RespRetraitValidationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("MagasinId");

                    b.HasIndex("ProduitId");

                    b.HasIndex("RespRemiseId");

                    b.HasIndex("RespRemiseValidationId");

                    b.HasIndex("RespRetraitId");

                    b.HasIndex("RespRetraitValidationId");

                    b.ToTable("Pr_InnovTouchProduit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeDepartement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeFamille")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeRayon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeSousFamille")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeSousSousFamille")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateMaj")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FamilleProduitId")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FamilleProduitId");

                    b.ToTable("Pr_Produits");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Droit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ro_Droit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.DroitProfile", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("DroitId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId", "DroitId");

                    b.HasIndex("DroitId");

                    b.ToTable("Ro_DroitProfile");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnseignesId")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnseignesId");

                    b.ToTable("Ro_Profile");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MagasinId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MagasinId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Ro_Utilisateur");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Entite.Magasin", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Enseigne", null)
                        .WithMany("Magasins")
                        .HasForeignKey("EnseigneId");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Emplacement", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone", "Rayone")
                        .WithMany()
                        .HasForeignKey("RayoneId");

                    b.Navigation("Inventory");

                    b.Navigation("Rayone");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.Inventory", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Magasin", "Magasin")
                        .WithMany()
                        .HasForeignKey("MagasinId");

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Inventaire.Rayone", "Rayone")
                        .WithMany()
                        .HasForeignKey("RayoneId");

                    b.Navigation("Magasin");

                    b.Navigation("Rayone");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.ProduitList", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Inventaire.AddInventaire", "AddInfentaire")
                        .WithMany("Produits")
                        .HasForeignKey("InventaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddInfentaire");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.AlerteProduit", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Enseigne", "Enseigne")
                        .WithMany("AlerteProduits")
                        .HasForeignKey("EnseigneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Produits.FamilleProduit", "FamilleProduit")
                        .WithMany("AlerteProduits")
                        .HasForeignKey("FamilleProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enseigne");

                    b.Navigation("FamilleProduit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.InnovTouchProduit", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", "Agent")
                        .WithMany("InnovTouchProduits")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Magasin", "Magasin")
                        .WithMany()
                        .HasForeignKey("MagasinId");

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Produits.Produit", "Produit")
                        .WithMany("InnovTouchProduits")
                        .HasForeignKey("ProduitId");

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", "RespRemise")
                        .WithMany("InnovTouchProduitsRemise")
                        .HasForeignKey("RespRemiseId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", "RespRemiseValidation")
                        .WithMany("InnovTouchProduitsValideRemise")
                        .HasForeignKey("RespRemiseValidationId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", "RespRetrait")
                        .WithMany("InnovTouchProduitsRetrait")
                        .HasForeignKey("RespRetraitId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", "RespRetraitValidation")
                        .WithMany("InnovTouchProduitsValideRetrait")
                        .HasForeignKey("RespRetraitValidationId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Agent");

                    b.Navigation("Magasin");

                    b.Navigation("Produit");

                    b.Navigation("RespRemise");

                    b.Navigation("RespRemiseValidation");

                    b.Navigation("RespRetrait");

                    b.Navigation("RespRetraitValidation");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.Produit", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Produits.FamilleProduit", "FamilleProduit")
                        .WithMany("Produits")
                        .HasForeignKey("FamilleProduitId");

                    b.Navigation("FamilleProduit");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.DroitProfile", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Droit", "Droit")
                        .WithMany("DroitsProfiles")
                        .HasForeignKey("DroitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Profile", "Profile")
                        .WithMany("DroitsProfiles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Droit");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Profile", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Enseigne", "Enseignes")
                        .WithMany()
                        .HasForeignKey("EnseignesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enseignes");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", b =>
                {
                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Entite.Magasin", "Magasin")
                        .WithMany()
                        .HasForeignKey("MagasinId");

                    b.HasOne("DAL.InnovTouch.DOMAIN.Models.Role.Profile", null)
                        .WithMany("Utilisateurs")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Magasin");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Entite.Enseigne", b =>
                {
                    b.Navigation("AlerteProduits");

                    b.Navigation("Magasins");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Inventaire.AddInventaire", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.FamilleProduit", b =>
                {
                    b.Navigation("AlerteProduits");

                    b.Navigation("Produits");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Produits.Produit", b =>
                {
                    b.Navigation("InnovTouchProduits");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Droit", b =>
                {
                    b.Navigation("DroitsProfiles");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Profile", b =>
                {
                    b.Navigation("DroitsProfiles");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("DAL.InnovTouch.DOMAIN.Models.Role.Utilisateur", b =>
                {
                    b.Navigation("InnovTouchProduits");

                    b.Navigation("InnovTouchProduitsRemise");

                    b.Navigation("InnovTouchProduitsRetrait");

                    b.Navigation("InnovTouchProduitsValideRemise");

                    b.Navigation("InnovTouchProduitsValideRetrait");
                });
#pragma warning restore 612, 618
        }
    }
}
