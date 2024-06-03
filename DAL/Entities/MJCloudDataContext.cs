using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Entities
{
    public partial class MJCloudDataContext : DbContext
    {
        public MJCloudDataContext()
        {
        }

        public MJCloudDataContext(DbContextOptions<MJCloudDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdresseArticle> AdresseArticle { get; set; }
        public virtual DbSet<AllowedAdusers> AllowedAdusers { get; set; }
        public virtual DbSet<ArticleInfo> ArticleInfo { get; set; }
        public virtual DbSet<ArticleInfoEan> ArticleInfoEan { get; set; }
        public virtual DbSet<ArticleInfoSite> ArticleInfoSite { get; set; }
        public virtual DbSet<ArticleInfoSite15> ArticleInfoSite15 { get; set; }
        public virtual DbSet<ArticleRupture> ArticleRupture { get; set; }
        public virtual DbSet<ArticlesRapprochementInfo> ArticlesRapprochementInfo { get; set; }
        public virtual DbSet<Assossiation> Assossiation { get; set; }
        public virtual DbSet<BalanceOrders> BalanceOrders { get; set; }
        public virtual DbSet<CaCategorie> CaCategorie { get; set; }
        public virtual DbSet<CapacityOrderInfo> CapacityOrderInfo { get; set; }
        public virtual DbSet<Catalogue> Catalogue { get; set; }
        public virtual DbSet<ChangementCatalogueEcom> ChangementCatalogueEcom { get; set; }
        public virtual DbSet<CommandeLex> CommandeLex { get; set; }
        public virtual DbSet<ConnexionUser> ConnexionUser { get; set; }
        public virtual DbSet<Creneau> Creneau { get; set; }
        public virtual DbSet<CreneauCapacityDefaultSite> CreneauCapacityDefaultSite { get; set; }
        public virtual DbSet<CreneauCapacitySpecifSite> CreneauCapacitySpecifSite { get; set; }
        public virtual DbSet<CreneauLivraisonExpress> CreneauLivraisonExpress { get; set; }
        public virtual DbSet<CreneauxLivraison> CreneauxLivraison { get; set; }
        public virtual DbSet<KaalixOrderHeader> KaalixOrderHeader { get; set; }
        public virtual DbSet<KeyValParam> KeyValParam { get; set; }
        public virtual DbSet<LivraisonEnRetard> LivraisonEnRetard { get; set; }
        public virtual DbSet<Livreur> Livreur { get; set; }
        public virtual DbSet<MissionDetail> MissionDetail { get; set; }
        public virtual DbSet<MissionHeader> MissionHeader { get; set; }
        public virtual DbSet<NotAdressed> NotAdressed { get; set; }
        public virtual DbSet<OrderControlDetail> OrderControlDetail { get; set; }
        public virtual DbSet<OrderControlHeader> OrderControlHeader { get; set; }
        public virtual DbSet<OrderControlProductEan> OrderControlProductEan { get; set; }
        public virtual DbSet<OrderControlSecurity> OrderControlSecurity { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }
        public virtual DbSet<OrderHeaderLight> OrderHeaderLight { get; set; }
        public virtual DbSet<PolyRegion> PolyRegion { get; set; }
        public virtual DbSet<RatingCommande> RatingCommande { get; set; }
        public virtual DbSet<RatingLivraison> RatingLivraison { get; set; }
        public virtual DbSet<RefStatusMission> RefStatusMission { get; set; }
        public virtual DbSet<ReferenceClient> ReferenceClient { get; set; }
        public virtual DbSet<ReferenceClientAddress> ReferenceClientAddress { get; set; }
        public virtual DbSet<ReferenceClientChild> ReferenceClientChild { get; set; }
        public virtual DbSet<Rupture> Rupture { get; set; }
        public virtual DbSet<Rupture1> Rupture1 { get; set; }
        public virtual DbSet<Sheet1> Sheet1 { get; set; }
        public virtual DbSet<SiteAdresse> SiteAdresse { get; set; }
        public virtual DbSet<SiteCapacityDefault> SiteCapacityDefault { get; set; }
        public virtual DbSet<SiteCapacitySpecif> SiteCapacitySpecif { get; set; }
        public virtual DbSet<SiteCorrespondance> SiteCorrespondance { get; set; }
        public virtual DbSet<SiteLex> SiteLex { get; set; }
        public virtual DbSet<SitePolygon> SitePolygon { get; set; }
        public virtual DbSet<SitePolygonLex> SitePolygonLex { get; set; }
        public virtual DbSet<StocksWyndInfo> StocksWyndInfo { get; set; }
        public virtual DbSet<SubstitutionGroup> SubstitutionGroup { get; set; }
        public virtual DbSet<TraceKaalixApi> TraceKaalixApi { get; set; }
        public virtual DbSet<TraceWyndApi> TraceWyndApi { get; set; }
        public virtual DbSet<VDashbordEvolCaSite> VDashbordEvolCaSite { get; set; }
        public virtual DbSet<WyndDisabledArticle> WyndDisabledArticle { get; set; }
        public virtual DbSet<WyndDisabledArticleHistorique> WyndDisabledArticleHistorique { get; set; }
        public virtual DbSet<WyndOrderCreneauCapacity> WyndOrderCreneauCapacity { get; set; }
        public virtual DbSet<WyndOrderDetail> WyndOrderDetail { get; set; }
        public virtual DbSet<WyndOrderDetailArch> WyndOrderDetailArch { get; set; }
        public virtual DbSet<WyndOrderHeader> WyndOrderHeader { get; set; }
        public virtual DbSet<WyndOrderHeaderArch> WyndOrderHeaderArch { get; set; }
        public virtual DbSet<WyndRatingClient> WyndRatingClient { get; set; }
        public virtual DbSet<WyndRatingCommande> WyndRatingCommande { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mjcloudsqlsrv.database.windows.net;Database=mj_cloud_db;Trusted_Connection=False;User id=mj_cloud_sa_2020;password=MJ!!1919SA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdresseArticle>(entity =>
            {
                entity.HasKey(e => new { e.SiteCode, e.Cexrart });

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");

                entity.Property(e => e.Cexrart).HasColumnName("CEXRART");

                entity.Property(e => e.CodeAdresse)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CodeArticleEan)
                    .IsRequired()
                    .HasColumnName("CodeArticleEAN")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateMaj)
                    .HasColumnName("DateMAJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dept).HasColumnName("DEPT");

                entity.Property(e => e.Fam).HasColumnName("FAM");

                entity.Property(e => e.Libart)
                    .IsRequired()
                    .HasColumnName("LIBART")
                    .HasMaxLength(200);

                entity.Property(e => e.Ray).HasColumnName("RAY");

                entity.Property(e => e.Sfam).HasColumnName("SFAM");

                entity.Property(e => e.Ssfam).HasColumnName("SSFAM");

                entity.Property(e => e.Ub).HasColumnName("UB");
            });

            modelBuilder.Entity<AllowedAdusers>(entity =>
            {
                entity.ToTable("AllowedADUsers");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<ArticleInfo>(entity =>
            {
                entity.HasKey(e => e.Codeart)
                    .HasName("PK__tmp_ms_x__EC429DB95A54BC1B");

                entity.Property(e => e.Codeart)
                    .HasColumnName("CODEART")
                    .ValueGeneratedNever();

                entity.Property(e => e.Artdegr).HasColumnName("ARTDEGR");

                entity.Property(e => e.BalancePiece)
                    .IsRequired()
                    .HasColumnName("BALANCE_PIECE")
                    .HasMaxLength(20);

                entity.Property(e => e.BalancePoids)
                    .IsRequired()
                    .HasColumnName("BALANCE_POIDS")
                    .HasMaxLength(20);

                entity.Property(e => e.CategoryNiv1Id).HasColumnName("CATEGORY_NIV1_ID");

                entity.Property(e => e.CategoryNiv1Lib).HasColumnName("CATEGORY_NIV1_LIB");

                entity.Property(e => e.CategoryNiv2Id).HasColumnName("CATEGORY_NIV2_ID");

                entity.Property(e => e.CategoryNiv2Lib).HasColumnName("CATEGORY_NIV2_LIB");

                entity.Property(e => e.CategoryNiv3Id).HasColumnName("CATEGORY_NIV3_ID");

                entity.Property(e => e.CategoryNiv3Lib).HasColumnName("CATEGORY_NIV3_LIB");

                entity.Property(e => e.CodeArticlePere).HasColumnName("CODE_ARTICLE_PERE");

                entity.Property(e => e.CodePack).HasColumnName("CODE_PACK");

                entity.Property(e => e.CodeUnite).HasColumnName("CODE_UNITE");

                entity.Property(e => e.Codeetat).HasColumnName("CODEETAT");

                entity.Property(e => e.CoeffPack).HasColumnName("COEFF_PACK");

                entity.Property(e => e.CoeffUnite).HasColumnName("COEFF_UNITE");

                entity.Property(e => e.Dateupdate)
                    .HasColumnName("DATEUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Departement)
                    .IsRequired()
                    .HasColumnName("DEPARTEMENT");

                entity.Property(e => e.Dept).HasColumnName("DEPT");

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasColumnName("EAN");

                entity.Property(e => e.EanArticlePere).HasColumnName("EAN_ARTICLE_PERE");

                entity.Property(e => e.Fam).HasColumnName("FAM");

                entity.Property(e => e.Famille)
                    .IsRequired()
                    .HasColumnName("FAMILLE");

                entity.Property(e => e.FlagIsActifEcom).HasColumnName("FLAG_IS_ACTIF_ECOM");

                entity.Property(e => e.Lblart)
                    .IsRequired()
                    .HasColumnName("LBLART");

                entity.Property(e => e.LibelleArticlePere).HasColumnName("LIBELLE_ARTICLE_PERE");

                entity.Property(e => e.LibellePack).HasColumnName("LIBELLE_PACK");

                entity.Property(e => e.LibelleUnite).HasColumnName("LIBELLE_UNITE");

                entity.Property(e => e.NewPrice)
                    .HasColumnName("NEW_PRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Onlin)
                    .IsRequired()
                    .HasColumnName("ONLIN");

                entity.Property(e => e.Picture).HasColumnName("PICTURE");

                entity.Property(e => e.PluArticle).HasColumnName("PLU_ARTICLE");

                entity.Property(e => e.PluArticlePere)
                    .IsRequired()
                    .HasColumnName("plu_article_pere");

                entity.Property(e => e.PotAmount).HasColumnName("POT_AMOUNT");

                entity.Property(e => e.PvPerm)
                    .HasColumnName("PV_PERM")
                    .HasColumnType("money");

                entity.Property(e => e.Ray).HasColumnName("RAY");

                entity.Property(e => e.Rayon)
                    .IsRequired()
                    .HasColumnName("RAYON");

                entity.Property(e => e.Sfam).HasColumnName("SFAM");

                entity.Property(e => e.Sfamille)
                    .IsRequired()
                    .HasColumnName("SFAMILLE");

                entity.Property(e => e.Ssfam).HasColumnName("SSFAM");

                entity.Property(e => e.Ssfamille).HasColumnName("SSFAMILLE");

                entity.Property(e => e.Ttva).HasColumnName("TTVA");

                entity.Property(e => e.TypeArticle)
                    .IsRequired()
                    .HasColumnName("TYPE_ARTICLE");

                entity.Property(e => e.Ub).HasColumnName("UB");

                entity.Property(e => e.WyndArticleUuid)
                    .HasColumnName("WyndArticleUUID")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ArticleInfoEan>(entity =>
            {
                entity.HasKey(e => new { e.Codeart, e.Ean })
                    .HasName("PK_ArtileEANInfo");

                entity.ToTable("ArticleInfoEAN");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.Ean)
                    .HasColumnName("EAN")
                    .HasMaxLength(20);

                entity.Property(e => e.Dateupdate)
                    .HasColumnName("DATEUPDATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodeartNavigation)
                    .WithMany(p => p.ArticleInfoEan)
                    .HasForeignKey(d => d.Codeart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleInfoEAN_ToArticleInfo");
            });

            modelBuilder.Entity<ArticleInfoSite>(entity =>
            {
                entity.HasKey(e => new { e.CodeSite, e.Codeart })
                    .HasName("PK_ArticleParSiteInfo");

                entity.HasIndex(e => new { e.Codeart, e.CodeSite })
                    .HasName("index_ArticleInfoSite__code_site");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.DateStock)
                    .HasColumnName("DATE_STOCK")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateupdate)
                    .HasColumnName("DATEUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereCommande)
                    .HasColumnName("DTDERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereReception)
                    .HasColumnName("DTDERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereVente)
                    .HasColumnName("DTDERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteStock).HasColumnName("QTE_STOCK");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Seuil).HasColumnName("SEUIL");
            });

            modelBuilder.Entity<ArticleInfoSite15>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArticleInfoSite_15");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.DateStock)
                    .HasColumnName("DATE_STOCK")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateupdate)
                    .HasColumnName("DATEUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereCommande)
                    .HasColumnName("DTDERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereReception)
                    .HasColumnName("DTDERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereVente)
                    .HasColumnName("DTDERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteStock).HasColumnName("QTE_STOCK");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Seuil).HasColumnName("SEUIL");
            });

            modelBuilder.Entity<ArticleRupture>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ArticleRupture", "capacity");

                entity.Property(e => e.CategoryNiv1Lib).HasColumnName("CATEGORY_NIV1_LIB");

                entity.Property(e => e.CategoryNiv2Lib).HasColumnName("CATEGORY_NIV2_LIB");

                entity.Property(e => e.CategoryNiv3Lib).HasColumnName("CATEGORY_NIV3_LIB");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(4000);

                entity.Property(e => e.Lblart)
                    .IsRequired()
                    .HasColumnName("LBLART");

                entity.Property(e => e.Libsite).HasColumnName("LIBSITE");
            });

            modelBuilder.Entity<ArticlesRapprochementInfo>(entity =>
            {
                entity.Property(e => e.AttributEnVente).HasColumnName("Attribut_En_Vente");

                entity.Property(e => e.CodeInterne).HasColumnName("Code_interne_");

                entity.Property(e => e.CodeWynd).HasColumnName("Code_Wynd");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Ean).HasColumnName("EAN");

                entity.Property(e => e.LibelleEcomm).HasColumnName("Libelle_Ecomm");

                entity.Property(e => e.PrixDeVente).HasColumnName("Prix_De_Vente");

                entity.Property(e => e.Tva).HasColumnName("TVA");
            });

            modelBuilder.Entity<Assossiation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("assossiation", "capacity");

                entity.Property(e => e.ActionType).HasColumnName("action_type");

                entity.Property(e => e.CbAmount).HasColumnName("cb_amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasMaxLength(4000);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerUuid).HasColumnName("customer_uuid");

                entity.Property(e => e.FidelityAmount).HasColumnName("fidelity_amount");

                entity.Property(e => e.StatutDon).HasColumnName("statut_don");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("uuid")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BalanceOrders>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__BalanceO__7F427930B7EE4072");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasMaxLength(50);

                entity.Property(e => e.ActionType).HasColumnName("action_type");

                entity.Property(e => e.CbAmount).HasColumnName("cb_amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerUuid).HasColumnName("customer_uuid");

                entity.Property(e => e.FidelityAmount).HasColumnName("fidelity_amount");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.ReceiverUuid).HasColumnName("receiver_uuid");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            });

            modelBuilder.Entity<CaCategorie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CA_CATEGORIE", "capacity");

                entity.Property(e => e.Ca).HasColumnName("CA");

                entity.Property(e => e.CaApls).HasColumnName("CA_APLS");

                entity.Property(e => e.CaMarche).HasColumnName("CA_MARCHE");

                entity.Property(e => e.CaPem).HasColumnName("CA_PEM");

                entity.Property(e => e.CaPgc).HasColumnName("CA_PGC");

                entity.Property(e => e.DateLivraison)
                    .HasColumnName("date_livraison")
                    .HasColumnType("date");

                entity.Property(e => e.Flp).HasColumnName("FLP");

                entity.Property(e => e.NbCmd).HasColumnName("NB_CMD");

                entity.Property(e => e.NbCmdApls).HasColumnName("NB_CMD_APLS");

                entity.Property(e => e.NbCmdMarche).HasColumnName("NB_CMD_MARCHE");

                entity.Property(e => e.NbCmdPem).HasColumnName("NB_CMD_PEM");

                entity.Property(e => e.NbCmdPgc).HasColumnName("NB_CMD_PGC");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<CapacityOrderInfo>(entity =>
            {
                entity.HasKey(e => e.OrderWyndUuid)
                    .HasName("PK__Capacity__3288C8790D8F3863");

                entity.ToTable("CapacityOrderInfo", "capacity");

                entity.Property(e => e.OrderWyndUuid)
                    .HasColumnName("OrderWyndUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateFinal).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderWyndLabel)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");
            });

            modelBuilder.Entity<Catalogue>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("catalogue", "capacity");

                entity.Property(e => e.Categorie)
                    .IsRequired()
                    .HasColumnName("categorie")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DateStock)
                    .HasColumnName("date_stock")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dept)
                    .IsRequired()
                    .HasColumnName("dept");

                entity.Property(e => e.DerniereCommande)
                    .HasColumnName("DERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DerniereReception)
                    .HasColumnName("DERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DerniereVente)
                    .HasColumnName("DERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisponibiltéAppli)
                    .IsRequired()
                    .HasColumnName("Disponibilté_Appli")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Famille)
                    .IsRequired()
                    .HasColumnName("famille");

                entity.Property(e => e.FlagWynd).HasColumnName("flag_wynd");

                entity.Property(e => e.Gencode)
                    .IsRequired()
                    .HasColumnName("gencode");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle");

                entity.Property(e => e.Qte).HasColumnName("qte");

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Rayon)
                    .IsRequired()
                    .HasColumnName("rayon");

                entity.Property(e => e.Seuil).HasColumnName("seuil");

                entity.Property(e => e.Sfamille)
                    .IsRequired()
                    .HasColumnName("sfamille");

                entity.Property(e => e.Site).HasColumnName("site");

                entity.Property(e => e.Ssfamille).HasColumnName("ssfamille");

                entity.Property(e => e.Ub).HasColumnName("ub");
            });

            modelBuilder.Entity<ChangementCatalogueEcom>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ChangementCatalogueEcom", "capacity");

                entity.Property(e => e.AncienPrix).HasColumnName("Ancien_prix");

                entity.Property(e => e.AttributEnVente).HasColumnName("Attribut_En_Vente");

                entity.Property(e => e.ChangementPrixDeVente).HasColumnName("Changement_Prix_de_Vente");

                entity.Property(e => e.CodeInterne).HasColumnName("Code_interne_");

                entity.Property(e => e.CodeWynd).HasColumnName("Code_Wynd");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Departement)
                    .IsRequired()
                    .HasColumnName("DEPARTEMENT");

                entity.Property(e => e.DraftTrueToValidatedFalse).HasColumnName("DRAFT-True-To-VALIDATED-False");

                entity.Property(e => e.DraftTrueToValidatedTrue).HasColumnName("DRAFT-True-To-VALIDATED-True");

                entity.Property(e => e.DraftTrueToday).HasColumnName("DRAFT-True-today");

                entity.Property(e => e.Ean).HasColumnName("EAN");

                entity.Property(e => e.Famille)
                    .IsRequired()
                    .HasColumnName("FAMILLE");

                entity.Property(e => e.HorsAssortiment).HasColumnName("Hors_assortiment");

                entity.Property(e => e.Lblart)
                    .IsRequired()
                    .HasColumnName("LBLART");

                entity.Property(e => e.LibelleEcomm).HasColumnName("Libelle_Ecomm");

                entity.Property(e => e.PrixDeVente).HasColumnName("Prix_De_Vente");

                entity.Property(e => e.Rayon)
                    .IsRequired()
                    .HasColumnName("RAYON");

                entity.Property(e => e.Sfamille)
                    .IsRequired()
                    .HasColumnName("SFAMILLE");

                entity.Property(e => e.Ssfamille).HasColumnName("SSFAMILLE");

                entity.Property(e => e.Stock1).HasColumnName("stock_1");

                entity.Property(e => e.Stock10).HasColumnName("stock_10");

                entity.Property(e => e.Stock118).HasColumnName("stock_118");

                entity.Property(e => e.Stock12).HasColumnName("stock_12");

                entity.Property(e => e.Stock13).HasColumnName("stock_13");

                entity.Property(e => e.Stock14).HasColumnName("stock_14");

                entity.Property(e => e.Stock15).HasColumnName("stock_15");

                entity.Property(e => e.Stock155).HasColumnName("stock_155");

                entity.Property(e => e.Stock17).HasColumnName("stock_17");

                entity.Property(e => e.Stock2).HasColumnName("stock_2");

                entity.Property(e => e.Stock25).HasColumnName("stock_25");

                entity.Property(e => e.Stock39).HasColumnName("stock_39");

                entity.Property(e => e.Stock4).HasColumnName("stock_4");

                entity.Property(e => e.Stock5).HasColumnName("stock_5");

                entity.Property(e => e.Stock6).HasColumnName("stock_6");

                entity.Property(e => e.Stock7).HasColumnName("stock_7");

                entity.Property(e => e.Stock8).HasColumnName("stock_8");

                entity.Property(e => e.Stock9).HasColumnName("stock_9");

                entity.Property(e => e.Tva).HasColumnName("TVA");

                entity.Property(e => e.Ub).HasColumnName("UB");

                entity.Property(e => e.ValidatedFalseToValidatedTrue).HasColumnName("VALIDATED-False-To-VALIDATED-True");

                entity.Property(e => e.ValidatedTrueToValidatedFalse).HasColumnName("VALIDATED-True-To-VALIDATED-false");

                entity.Property(e => e.ValidatedTrueToday).HasColumnName("VALIDATED-True-today");
            });

            modelBuilder.Entity<CommandeLex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CommandeLEX", "capacity");

                entity.Property(e => e.CodeSite).HasColumnName("code_site");

                entity.Property(e => e.Destinationcode)
                    .IsRequired()
                    .HasColumnName("destinationcode")
                    .HasMaxLength(200);

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasMaxLength(300);

                entity.Property(e => e.Statut)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ConnexionUser>(entity =>
            {
                entity.ToTable("connexion_user", "ecom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.AdresseIp).HasColumnName("adresse_ip");

                entity.Property(e => e.Appareil).HasColumnName("appareil");

                entity.Property(e => e.DateCreation)
                    .HasColumnName("date_creation")
                    .HasColumnType("datetime");

                entity.Property(e => e.Navigateur).HasColumnName("navigateur");

                entity.Property(e => e.Pays).HasColumnName("pays");

                entity.Property(e => e.Platforme).HasColumnName("platforme");

                entity.Property(e => e.Utilisateur).HasColumnName("utilisateur");
            });

            modelBuilder.Entity<Creneau>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("creneau", "capacity");

                entity.Property(e => e.CodeSite).HasColumnName("code_site");

                entity.Property(e => e.Creneau1)
                    .IsRequired()
                    .HasColumnName("creneau")
                    .HasMaxLength(27)
                    .IsUnicode(false);

                entity.Property(e => e.DateLivPrevue)
                    .HasColumnName("date_liv_prevue")
                    .HasColumnType("date");

                entity.Property(e => e.DateLivraisonEffective)
                    .HasColumnName("date_livraison_effective")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePreparation)
                    .HasColumnName("date_preparation")
                    .HasColumnType("datetime");

                entity.Property(e => e.Destinationcode)
                    .IsRequired()
                    .HasColumnName("destinationcode")
                    .HasMaxLength(200);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart).HasColumnType("datetime");

                entity.Property(e => e.LivraisonRespectee).HasColumnName("livraison_respectee");

                entity.Property(e => e.PreparationNonRespectee).HasColumnName("preparation_non_respectee");

                entity.Property(e => e.PreparationRespectee).HasColumnName("preparation_respectee");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasMaxLength(300);

                entity.Property(e => e.Statut)
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreneauCapacityDefaultSite>(entity =>
            {
                entity.HasKey(e => new { e.SiteCode, e.CreneauId });

                entity.ToTable("CreneauCapacityDefaultSite", "capacity");

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");

                entity.Property(e => e.CreneauId).HasMaxLength(10);

                entity.HasOne(d => d.Creneau)
                    .WithMany(p => p.CreneauCapacityDefaultSite)
                    .HasForeignKey(d => d.CreneauId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreneauCapacityDefaultSite_ToCreneauxLivraison");
            });

            modelBuilder.Entity<CreneauCapacitySpecifSite>(entity =>
            {
                entity.HasKey(e => new { e.SiteCode, e.DateSpecif, e.CreneauId });

                entity.ToTable("CreneauCapacitySpecifSite", "capacity");

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");

                entity.Property(e => e.DateSpecif).HasColumnType("date");

                entity.Property(e => e.CreneauId).HasMaxLength(10);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.HasOne(d => d.Creneau)
                    .WithMany(p => p.CreneauCapacitySpecifSite)
                    .HasForeignKey(d => d.CreneauId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreneauCapacitySpecifSite_ToCreneauxLivraison");
            });

            modelBuilder.Entity<CreneauLivraisonExpress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("creneau_LivraisonExpress", "capacity");

                entity.Property(e => e.CodeSite).HasColumnName("code_site");

                entity.Property(e => e.Creneau).HasColumnName("creneau");

                entity.Property(e => e.DateLivPrevue)
                    .HasColumnName("date_liv_prevue")
                    .HasColumnType("date");

                entity.Property(e => e.DateLivraisonEffective)
                    .HasColumnName("date_livraison_effective")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePreparation)
                    .HasColumnName("date_preparation")
                    .HasColumnType("datetime");

                entity.Property(e => e.Destinationcode)
                    .IsRequired()
                    .HasColumnName("destinationcode")
                    .HasMaxLength(200);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart).HasColumnType("datetime");

                entity.Property(e => e.LivraisonRespectee).HasColumnName("livraison_respectee");

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PreparationNonRespectee).HasColumnName("preparation_non_respectee");

                entity.Property(e => e.PreparationRespectee).HasColumnName("preparation_respectee");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasMaxLength(300);

                entity.Property(e => e.Statut)
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreneauxLivraison>(entity =>
            {
                entity.ToTable("CreneauxLivraison", "capacity");

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.TypeLivraison)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<KaalixOrderHeader>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__tmp_ms_x__7F427930E203F891");

                entity.ToTable("KaalixOrderHeader", "kaalix");

                entity.HasIndex(e => e.Uuid)
                    .HasName("index1");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.ChannelUuid)
                    .HasColumnName("ChannelUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerFirstname)
                    .IsRequired()
                    .HasColumnName("customer_firstname");

                entity.Property(e => e.CustomerFullName).HasColumnName("customer_fullName");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerLastname)
                    .IsRequired()
                    .HasColumnName("customer_lastname");

                entity.Property(e => e.CustomerUuid)
                    .HasColumnName("customer_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.DatePreparationFinish).HasColumnType("datetime");

                entity.Property(e => e.DatePreparationStart).HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJobUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddressAddressInline).HasColumnName("delivery_address_address_inline");

                entity.Property(e => e.DeliveryAddressCity).HasColumnName("delivery_address_city");

                entity.Property(e => e.DeliveryAddressComplement).HasColumnName("delivery_address_complement");

                entity.Property(e => e.DeliveryAddressDoor).HasColumnName("delivery_address_door");

                entity.Property(e => e.DeliveryAddressFloor).HasColumnName("delivery_address_floor");

                entity.Property(e => e.DeliveryAddressLatitude)
                    .HasColumnName("delivery_address_latitude")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryAddressLongitude)
                    .HasColumnName("delivery_address_longitude")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryAddressPostalCode).HasColumnName("delivery_address_postal_code");

                entity.Property(e => e.DeliveryAddressStreetName).HasColumnName("delivery_address_street_name");

                entity.Property(e => e.DeliveryAddressStreetNumber).HasColumnName("delivery_address_street_number");

                entity.Property(e => e.DeliveryAddressTelephone)
                    .HasColumnName("delivery_address_telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.DestinationCode)
                    .HasColumnName("destination_code")
                    .HasMaxLength(200);

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.DestinationLabel)
                    .HasColumnName("destination_label")
                    .HasMaxLength(300);

                entity.Property(e => e.DestinationUuid)
                    .HasColumnName("destination_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart)
                    .HasColumnName("due_date_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntityErpStoreId).HasColumnName("entity__erp_store_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityLabel)
                    .HasColumnName("entity_label")
                    .HasMaxLength(300);

                entity.Property(e => e.EntityUuid)
                    .HasColumnName("entity_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.Env)
                    .HasColumnName("env")
                    .HasMaxLength(10);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KaalixDeliveryCompletedAt)
                    .HasColumnName("kaalix_delivery_completedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.KaalixProviderId)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_id");

                entity.Property(e => e.KaalixProviderLocationLatitude).HasColumnName("kaalix_provider_location_latitude");

                entity.Property(e => e.KaalixProviderLocationLongitude).HasColumnName("kaalix_provider_location_longitude");

                entity.Property(e => e.KaalixProviderName)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_name");

                entity.Property(e => e.KaalixProviderPhone)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_phone");

                entity.Property(e => e.KaalixReferenceId).HasColumnName("kaalix_reference_id");

                entity.Property(e => e.Label).HasColumnName("label");

                entity.Property(e => e.OpId).HasColumnName("OP_id");

                entity.Property(e => e.OpLabel).HasColumnName("OP_label");

                entity.Property(e => e.OpStatusCode).HasColumnName("OP_status_code");

                entity.Property(e => e.OpUuid)
                    .HasColumnName("OP_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.PickerUuid).HasMaxLength(300);

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.ShipDateTimeLastUpdate)
                    .HasColumnName("Ship_dateTimeLastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenDelivrered)
                    .HasColumnName("Ship_dateTimeWhenDelivrered")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenInTransport)
                    .HasColumnName("Ship_dateTimeWhenInTransport")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipJobUpdateDate)
                    .HasColumnName("Ship_JobUpdateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteCorrespondanceLatitude).HasColumnName("SiteCorrespondance_latitude");

                entity.Property(e => e.SiteCorrespondanceLongitude).HasColumnName("SiteCorrespondance_longitude");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnName("status_code");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserUuid)
                    .IsRequired()
                    .HasColumnName("user_uuid");
            });

            modelBuilder.Entity<KeyValParam>(entity =>
            {
                entity.HasKey(e => e.ParamKey)
                    .HasName("PK__KeyValPa__2A9EA4F5F6B37C9E");

                entity.Property(e => e.ParamKey).HasMaxLength(100);

                entity.Property(e => e.ParamValue).IsRequired();
            });

            modelBuilder.Entity<LivraisonEnRetard>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Livraison_en_retard", "capacity");

                entity.Property(e => e.Client).IsRequired();

                entity.Property(e => e.DateDeCréation)
                    .HasColumnName("date de création")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeMaj)
                    .HasColumnName("date de Maj")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDebutLivraison)
                    .HasColumnName("Date_debut_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateFinLivraison)
                    .HasColumnName("Date_fin_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLivraisonEffective)
                    .HasColumnName("date_livraison_effective")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePriseLivraison)
                    .HasColumnName("date_prise_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJob).HasColumnType("datetime");

                entity.Property(e => e.DeliveryLat).HasMaxLength(50);

                entity.Property(e => e.DeliveryLon).HasMaxLength(50);

                entity.Property(e => e.LivraisonResepecte).HasColumnName("livraison resepecte");

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.Statut)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.VilleMagasin)
                    .IsRequired()
                    .HasColumnName("ville_Magasin")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livreur>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Livreur", "kaalix");

                entity.Property(e => e.ChannelUuid)
                    .HasColumnName("ChannelUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CommandeAvecAnnulation).HasColumnName("Commande_avec_Annulation");

                entity.Property(e => e.CommandeAvecRupture).HasColumnName("Commande_avec_Rupture");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerFirstname)
                    .IsRequired()
                    .HasColumnName("customer_firstname");

                entity.Property(e => e.CustomerFullName).HasColumnName("customer_fullName");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerLastname)
                    .IsRequired()
                    .HasColumnName("customer_lastname");

                entity.Property(e => e.CustomerUuid)
                    .HasColumnName("customer_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.DatePreparationFinish).HasColumnType("datetime");

                entity.Property(e => e.DatePreparationStart).HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJobUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddressAddressInline).HasColumnName("delivery_address_address_inline");

                entity.Property(e => e.DeliveryAddressCity).HasColumnName("delivery_address_city");

                entity.Property(e => e.DeliveryAddressComplement).HasColumnName("delivery_address_complement");

                entity.Property(e => e.DeliveryAddressDoor).HasColumnName("delivery_address_door");

                entity.Property(e => e.DeliveryAddressFloor).HasColumnName("delivery_address_floor");

                entity.Property(e => e.DeliveryAddressLatitude)
                    .HasColumnName("delivery_address_latitude")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryAddressLongitude)
                    .HasColumnName("delivery_address_longitude")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryAddressPostalCode).HasColumnName("delivery_address_postal_code");

                entity.Property(e => e.DeliveryAddressStreetName).HasColumnName("delivery_address_street_name");

                entity.Property(e => e.DeliveryAddressStreetNumber).HasColumnName("delivery_address_street_number");

                entity.Property(e => e.DeliveryAddressTelephone)
                    .HasColumnName("delivery_address_telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.DestinationCode)
                    .HasColumnName("destination_code")
                    .HasMaxLength(200);

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.DestinationLabel)
                    .HasColumnName("destination_label")
                    .HasMaxLength(300);

                entity.Property(e => e.DestinationUuid)
                    .HasColumnName("destination_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart)
                    .HasColumnName("due_date_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntityErpStoreId).HasColumnName("entity__erp_store_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityLabel)
                    .HasColumnName("entity_label")
                    .HasMaxLength(300);

                entity.Property(e => e.EntityUuid)
                    .HasColumnName("entity_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.Env)
                    .HasColumnName("env")
                    .HasMaxLength(10);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KaalixProviderId)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_id");

                entity.Property(e => e.KaalixProviderLocationLatitude).HasColumnName("kaalix_provider_location_latitude");

                entity.Property(e => e.KaalixProviderLocationLongitude).HasColumnName("kaalix_provider_location_longitude");

                entity.Property(e => e.KaalixProviderName)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_name");

                entity.Property(e => e.KaalixProviderPhone)
                    .IsRequired()
                    .HasColumnName("kaalix_provider_phone");

                entity.Property(e => e.KaalixReferenceId).HasColumnName("kaalix_reference_id");

                entity.Property(e => e.Label).HasColumnName("label");

                entity.Property(e => e.LivraionLexRespecté).HasColumnName("livraion_LEX_respecté");

                entity.Property(e => e.MinTempsTrajetLex).HasColumnName("min_temps_trajet_LEX");

                entity.Property(e => e.NbArticles).HasColumnName("NB_Articles");

                entity.Property(e => e.NbRupture).HasColumnName("NB_rupture");

                entity.Property(e => e.NbSubstitution).HasColumnName("NB_substitution");

                entity.Property(e => e.OpId).HasColumnName("OP_id");

                entity.Property(e => e.OpLabel).HasColumnName("OP_label");

                entity.Property(e => e.OpStatusCode).HasColumnName("OP_status_code");

                entity.Property(e => e.OpUuid)
                    .HasColumnName("OP_uuid")
                    .HasMaxLength(300);

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.PhoneLivreur)
                    .IsRequired()
                    .HasColumnName("phone_livreur");

                entity.Property(e => e.PickerUuid).HasMaxLength(300);

                entity.Property(e => e.RatingCommandeRating1).HasColumnName("Rating_Commande_rating_1");

                entity.Property(e => e.RatingCommandeRating2).HasColumnName("Rating_Commande_rating_2");

                entity.Property(e => e.RatingLivraisonRating1).HasColumnName("Rating_Livraison_rating_1");

                entity.Property(e => e.RatingLivraisonRating2).HasColumnName("Rating_Livraison_rating_2");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.ShipDateTimeLastUpdate)
                    .HasColumnName("Ship_dateTimeLastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenDelivrered)
                    .HasColumnName("Ship_dateTimeWhenDelivrered")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenInTransport)
                    .HasColumnName("Ship_dateTimeWhenInTransport")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipJobUpdateDate)
                    .HasColumnName("Ship_JobUpdateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteCorrespondanceLatitude).HasColumnName("SiteCorrespondance_latitude");

                entity.Property(e => e.SiteCorrespondanceLongitude).HasColumnName("SiteCorrespondance_longitude");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnName("status_code");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserUuid)
                    .IsRequired()
                    .HasColumnName("user_uuid");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("uuid")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<MissionDetail>(entity =>
            {
                entity.Property(e => e.DateScanPoids).HasColumnType("datetime");

                entity.HasOne(d => d.MissionHeader)
                    .WithMany(p => p.MissionDetail)
                    .HasForeignKey(d => d.MissionHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MissionDe__Missi__0EC32C7A");
            });

            modelBuilder.Entity<MissionHeader>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ReservedById).HasColumnName("ReservedByID");

                entity.Property(e => e.ReservedByUuid)
                    .HasColumnName("ReservedByUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SiteCodeWyndNavigation)
                    .WithMany(p => p.MissionHeader)
                    .HasForeignKey(d => d.SiteCodeWynd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MissionHe__SiteC__5555A4F4");

                entity.HasOne(d => d.Statut)
                    .WithMany(p => p.MissionHeader)
                    .HasForeignKey(d => d.StatutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mission__StatutI__0BE6BFCF");
            });

            modelBuilder.Entity<NotAdressed>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("not_adressed", "capacity");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Dept)
                    .IsRequired()
                    .HasColumnName("dept");

                entity.Property(e => e.Famille)
                    .IsRequired()
                    .HasColumnName("famille");

                entity.Property(e => e.Gencode)
                    .IsRequired()
                    .HasColumnName("gencode");

                entity.Property(e => e.LibMag)
                    .IsRequired()
                    .HasColumnName("lib_mag")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle");

                entity.Property(e => e.Mag).HasColumnName("mag");

                entity.Property(e => e.Rayon)
                    .IsRequired()
                    .HasColumnName("rayon");

                entity.Property(e => e.Sfamille)
                    .IsRequired()
                    .HasColumnName("sfamille");

                entity.Property(e => e.Ssfamille).HasColumnName("ssfamille");

                entity.Property(e => e.Ub).HasColumnName("ub");
            });

            modelBuilder.Entity<OrderControlDetail>(entity =>
            {
                entity.HasKey(e => new { e.Uuid, e.HeaderUuid });

                entity.ToTable("OrderControlDetail", "control");

                entity.HasIndex(e => e.HeaderUuid)
                    .HasName("nci_wi_OrderControlDetail_1B323A93B231D33EAC7DE8922364A356");

                entity.Property(e => e.Uuid).HasMaxLength(300);

                entity.Property(e => e.HeaderUuid).HasMaxLength(300);

                entity.Property(e => e.DateControl).HasColumnType("datetime");

                entity.Property(e => e.HeaderReference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.OriginalProductUuid).HasMaxLength(300);

                entity.Property(e => e.ProductUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.HeaderUu)
                    .WithMany(p => p.OrderControlDetail)
                    .HasForeignKey(d => d.HeaderUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderControlDetail_ToOrderControlHeader");
            });

            modelBuilder.Entity<OrderControlHeader>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("OrderControlHeader", "control");

                entity.Property(e => e.Uuid).HasMaxLength(300);

                entity.Property(e => e.ClientUsername).IsRequired();

                entity.Property(e => e.CreatedByUsername).IsRequired();

                entity.Property(e => e.DateControl).HasColumnType("datetime");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateCreationOrder).HasColumnType("datetime");

                entity.Property(e => e.OrderNumber).IsRequired();

                entity.Property(e => e.PickerUsername).IsRequired();

                entity.Property(e => e.PrepBillReference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PrepBillUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");
            });

            modelBuilder.Entity<OrderControlProductEan>(entity =>
            {
                entity.ToTable("OrderControlProductEAN", "control");

                entity.HasIndex(e => new { e.DetailUuid, e.HeaderUuid })
                    .HasName("nci_wi_OrderControlProductEAN_121E4B6F28A02F27E54D57EE44372F2C");

                entity.Property(e => e.DetailUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasColumnName("EAN")
                    .HasMaxLength(20);

                entity.Property(e => e.HeaderUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.OrderControlDetail)
                    .WithMany(p => p.OrderControlProductEan)
                    .HasForeignKey(d => new { d.DetailUuid, d.HeaderUuid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderControlProductEAN_ToOrderControlDetail");
            });

            modelBuilder.Entity<OrderControlSecurity>(entity =>
            {
                entity.ToTable("OrderControlSecurity", "control");

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasColumnName("EAN");

                entity.Property(e => e.HeaderUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.HeaderUu)
                    .WithMany(p => p.OrderControlSecurity)
                    .HasForeignKey(d => d.HeaderUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderControlSecurity_ToOrderControlHeader");
            });

            modelBuilder.Entity<OrderHeader>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderHeader", "capacity");

                entity.Property(e => e.ChannelUuid)
                    .HasColumnName("ChannelUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.ClickColect).HasColumnName("Click_colect");

                entity.Property(e => e.Client).IsRequired();

                entity.Property(e => e.CommandeAvecAnnulation).HasColumnName("Commande_avec_Annulation");

                entity.Property(e => e.CommandeAvecRupture).HasColumnName("Commande_avec_Rupture");

                entity.Property(e => e.CommandeAvecSubstitution).HasColumnName("Commande_avec_Substitution");

                entity.Property(e => e.CommandeCompleteAvecSubstitution).HasColumnName("Commande_complete_avec_Substitution");

                entity.Property(e => e.CommandeCompleteSansSubstitution).HasColumnName("Commande_complete_sans_Substitution");

                entity.Property(e => e.CommandeExpress).HasColumnName("Commande_Express");

                entity.Property(e => e.CommandeStandard).HasColumnName("Commande_Standard");

                entity.Property(e => e.DateDeCréation)
                    .HasColumnName("date de création")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeLivraison)
                    .HasColumnName("date_de_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeLivraisonPrévue)
                    .HasColumnName("Date de livraison prévue")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeMaj)
                    .HasColumnName("date de Maj")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDebutLivraison)
                    .HasColumnName("date_debut_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateFinLivraison)
                    .HasColumnName("date_Fin_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLivraisonEffective).HasColumnName("date_livraison_effective");

                entity.Property(e => e.DatePreparationFinish).HasColumnType("datetime");

                entity.Property(e => e.DatePreparationStart).HasColumnType("datetime");

                entity.Property(e => e.DatePriseLivraison)
                    .HasColumnName("date_prise_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJob).HasColumnType("datetime");

                entity.Property(e => e.DeliveryLat).HasMaxLength(50);

                entity.Property(e => e.DeliveryLon).HasMaxLength(50);

                entity.Property(e => e.LivraionEnRetard).HasColumnName("livraion_en_retard");

                entity.Property(e => e.LivraionLexRespecté).HasColumnName("livraion_LEX_respecté");

                entity.Property(e => e.LivraionRespecté).HasColumnName("livraion_respecté");

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.MinRetardLiv).HasColumnName("min_retard_liv");

                entity.Property(e => e.MinTempsTrajet).HasColumnName("min_temps_trajet");

                entity.Property(e => e.MinTempsTrajetLex).HasColumnName("min_temps_trajet_LEX");

                entity.Property(e => e.NbAnnulation).HasColumnName("NB_annulation");

                entity.Property(e => e.NbArticles).HasColumnName("NB_Articles");

                entity.Property(e => e.NbRupture).HasColumnName("NB_rupture");

                entity.Property(e => e.NbRuptureSubstituable).HasColumnName("NB_rupture_substituable");

                entity.Property(e => e.NbSubstitution).HasColumnName("NB_substitution");

                entity.Property(e => e.PickerUuid).HasMaxLength(300);

                entity.Property(e => e.Rating1).HasColumnName("rating_1");

                entity.Property(e => e.Rating2).HasColumnName("rating_2");

                entity.Property(e => e.Rating3).HasColumnName("rating_3");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.RuptureNonTolere).HasColumnName("rupture_non_tolere");

                entity.Property(e => e.RuptureTolere).HasColumnName("rupture_tolere");

                entity.Property(e => e.RuptureZero).HasColumnName("rupture_zero");

                entity.Property(e => e.SousTotal).HasColumnName("Sous Total");

                entity.Property(e => e.Statut)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotalExpress).HasColumnName("sub_total_Express");

                entity.Property(e => e.SubTotalStandard).HasColumnName("sub_total_Standard");

                entity.Property(e => e.TauxAnnulation)
                    .HasColumnName("taux_Annulation")
                    .HasColumnType("numeric(24, 12)");

                entity.Property(e => e.TauxRupture)
                    .HasColumnName("taux_rupture")
                    .HasColumnType("numeric(24, 12)");

                entity.Property(e => e.TauxRuptureSubstituable)
                    .HasColumnName("taux_rupture_substituable")
                    .HasColumnType("numeric(24, 12)");

                entity.Property(e => e.TauxSubstitution)
                    .HasColumnName("taux_substitution")
                    .HasColumnType("numeric(24, 12)");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UrbanShip).HasColumnName("Urban_ship");

                entity.Property(e => e.VilleMagasin)
                    .IsRequired()
                    .HasColumnName("ville_Magasin")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderHeaderLight>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderHeader_Light", "capacity");

                entity.Property(e => e.Client).IsRequired();

                entity.Property(e => e.DateDeCréation)
                    .HasColumnName("date de création")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeLivraison)
                    .HasColumnName("date_de_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeLivraisonPrévue)
                    .HasColumnName("Date de livraison prévue")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateDeMaj)
                    .HasColumnName("date de Maj")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLivraisonEffective)
                    .HasColumnName("date_livraison_effective")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePriseLivraison)
                    .HasColumnName("date_prise_livraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJob).HasColumnType("datetime");

                entity.Property(e => e.DeliveryLat).HasMaxLength(50);

                entity.Property(e => e.DeliveryLon).HasMaxLength(50);

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.SousTotal).HasColumnName("Sous Total");

                entity.Property(e => e.Statut)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.VilleMagasin)
                    .IsRequired()
                    .HasColumnName("ville_Magasin")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PolyRegion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("poly_region", "ecom");

                entity.Property(e => e.CodeRegion)
                    .HasColumnName("code_region")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LibRegion)
                    .HasColumnName("lib_region")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RatingCommande>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RatingCommande", "capacity");

                entity.Property(e => e.Commentaire).HasColumnName("commentaire");

                entity.Property(e => e.CustomerEmail).HasColumnName("CUSTOMER_EMAIL");

                entity.Property(e => e.CustomerFullname)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_FULLNAME");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_PHONE");

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_UUID");

                entity.Property(e => e.EntityLabel)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderReference)
                    .IsRequired()
                    .HasColumnName("ORDER_REFERENCE");

                entity.Property(e => e.OrderUuid)
                    .IsRequired()
                    .HasColumnName("ORDER_UUID");

                entity.Property(e => e.Rating1).HasColumnName("rating_1");

                entity.Property(e => e.Rating2).HasColumnName("rating_2");

                entity.Property(e => e.Rating3).HasColumnName("rating_3");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("RATING_DATE")
                    .HasMaxLength(4000);

                entity.Property(e => e.RatingNull).HasColumnName("rating_null");
            });

            modelBuilder.Entity<RatingLivraison>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("RatingLivraison", "capacity");

                entity.Property(e => e.Commentaire).HasColumnName("commentaire");

                entity.Property(e => e.CustomerEmail).HasColumnName("CUSTOMER_EMAIL");

                entity.Property(e => e.CustomerFullname)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_FULLNAME");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_PHONE");

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_UUID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(4000);

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderReference)
                    .IsRequired()
                    .HasColumnName("ORDER_REFERENCE");

                entity.Property(e => e.OrderUuid)
                    .IsRequired()
                    .HasColumnName("ORDER_UUID");

                entity.Property(e => e.Rating1).HasColumnName("rating_1");

                entity.Property(e => e.Rating2).HasColumnName("rating_2");

                entity.Property(e => e.Rating3).HasColumnName("rating_3");

                entity.Property(e => e.RatingNull).HasColumnName("rating_null");
            });

            modelBuilder.Entity<RefStatusMission>(entity =>
            {
                entity.ToTable("REF_StatusMission");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ReferenceClient>(entity =>
            {
                entity.ToTable("ReferenceClient", "ecom");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Addresses).HasColumnName("addresses");

                entity.Property(e => e.AttributeApplicationMobile).HasColumnName("attribute_Application_mobile");

                entity.Property(e => e.AttributeLangueDePreference).HasColumnName("attribute_Langue_de_preference");

                entity.Property(e => e.AttributeMaxxingSynchroAt).HasColumnName("attribute_maxxing_synchro_at");

                entity.Property(e => e.AttributeOptinEmail).HasColumnName("attribute_Optin_email");

                entity.Property(e => e.AttributeOptinPush).HasColumnName("attribute_Optin_push");

                entity.Property(e => e.AttributeOptinSms).HasColumnName("attribute_Optin_sms");

                entity.Property(e => e.AttributeQuartier).HasColumnName("attribute_Quartier");

                entity.Property(e => e.AttributeQuartierLabel).HasColumnName("attribute_Quartier_label");

                entity.Property(e => e.AttributeTelechargementApplicationMobile).HasColumnName("attribute_Telechargement_application_mobile");

                entity.Property(e => e.AttributeTypeCarte).HasColumnName("attribute_Type_Carte");

                entity.Property(e => e.AttributeVille).HasColumnName("attribute_Ville");

                entity.Property(e => e.AttributeVilleLabel).HasColumnName("attribute_Ville_label");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Cohorts).HasColumnName("cohorts");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.CompanyName).HasColumnName("company_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreationChannel).HasColumnName("creation_channel");

                entity.Property(e => e.CustomerDivision).HasColumnName("customer_division");

                entity.Property(e => e.Default).HasColumnName("default");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EntityId).HasColumnName("entityId");

                entity.Property(e => e.EntityUuid).HasColumnName("entityUuid");

                entity.Property(e => e.ExternalId).HasColumnName("external_id");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HonorificPrefix).HasColumnName("honorific_prefix");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsGuest).HasColumnName("is_guest");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.MaxxingAccountKey).HasColumnName("maxxing_account_key");

                entity.Property(e => e.MaxxingCard).HasColumnName("maxxing_card");

                entity.Property(e => e.MaxxingCustomerKey).HasColumnName("maxxing_customer_key");

                entity.Property(e => e.MaxxingCustomerType).HasColumnName("maxxing_customer_type");

                entity.Property(e => e.MaxxingLogin).HasColumnName("maxxing_login");

                entity.Property(e => e.OriginalEntityId).HasColumnName("original_entityId");

                entity.Property(e => e.OriginalEntityUuid).HasColumnName("original_entityUuid");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.Property(e => e.VatNumber).HasColumnName("vat_number");

                entity.Property(e => e.WafasalafId).HasColumnName("wafasalaf_id");
            });

            modelBuilder.Entity<ReferenceClientAddress>(entity =>
            {
                entity.ToTable("ReferenceClient_Address", "ecom");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressInline).HasColumnName("address_inline");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CompanyName).HasColumnName("company_name");

                entity.Property(e => e.Complement).HasColumnName("complement");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.CountryUuid).HasColumnName("countryUuid");

                entity.Property(e => e.DefaultLabel).HasColumnName("default_label");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.Door).HasColumnName("door");

                entity.Property(e => e.EntranceCode).HasColumnName("entrance_code");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.HonorificPrefix).HasColumnName("honorific_prefix");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Mail).HasColumnName("mail");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.Telephone).HasColumnName("telephone");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.Property(e => e.VatNumber).HasColumnName("vat_number");

                entity.HasOne(d => d.ReferenceClient)
                    .WithMany(p => p.ReferenceClientAddress)
                    .HasForeignKey(d => d.ReferenceClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferenceClient_Address_ToReferenceClient");
            });

            modelBuilder.Entity<ReferenceClientChild>(entity =>
            {
                entity.ToTable("ReferenceClient_Child", "ecom");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.MaxxingChildrenId).HasColumnName("maxxing_children_id");

                entity.HasOne(d => d.ReferenceClient)
                    .WithMany(p => p.ReferenceClientChild)
                    .HasForeignKey(d => d.ReferenceClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReferenceClient_Child_ToReferenceClient");
            });

            modelBuilder.Entity<Rupture>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("rupture", "capacity");

                entity.Property(e => e.Categorie)
                    .IsRequired()
                    .HasColumnName("categorie")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Commandé).HasColumnName("commandé");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entitylabel)
                    .IsRequired()
                    .HasColumnName("entitylabel")
                    .HasMaxLength(300);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("LABEL");

                entity.Property(e => e.Pareto)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PreparationState)
                    .IsRequired()
                    .HasColumnName("preparation_state");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductexternalId).HasColumnName("productexternal_id");

                entity.Property(e => e.QteStock).HasColumnName("qte_stock");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rayon).HasColumnName("rayon");

                entity.Property(e => e.Rupture1).HasColumnName("Rupture");

                entity.Property(e => e.Statuscode)
                    .IsRequired()
                    .HasColumnName("statuscode")
                    .HasMaxLength(200);

                entity.Property(e => e.Statut)
                    .HasColumnName("statut")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UuidOrder)
                    .IsRequired()
                    .HasColumnName("uuid_order")
                    .HasMaxLength(300);

                entity.Property(e => e.WyndOrderHeaderReference)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Rupture1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("rupture_1", "capacity");

                entity.Property(e => e.Categorie)
                    .IsRequired()
                    .HasColumnName("categorie")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Commandé).HasColumnName("commandé");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entitylabel)
                    .IsRequired()
                    .HasColumnName("entitylabel")
                    .HasMaxLength(300);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("LABEL");

                entity.Property(e => e.Pareto)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PreparationState)
                    .IsRequired()
                    .HasColumnName("preparation_state");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductexternalId).HasColumnName("productexternal_id");

                entity.Property(e => e.QteStock).HasColumnName("qte_stock");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rayon).HasColumnName("rayon");

                entity.Property(e => e.Statuscode)
                    .IsRequired()
                    .HasColumnName("statuscode")
                    .HasMaxLength(200);

                entity.Property(e => e.Statut)
                    .HasColumnName("statut")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UuidOrder)
                    .IsRequired()
                    .HasColumnName("uuid_order")
                    .HasMaxLength(300);

                entity.Property(e => e.WyndOrderHeaderReference)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Sheet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("'Sheet 1$'");

                entity.Property(e => e.Codeart)
                    .HasColumnName("CODEART")
                    .HasMaxLength(255);

                entity.Property(e => e.Codesite).HasColumnName("CODESITE");

                entity.Property(e => e.DateStock)
                    .HasColumnName("DATE_STOCK")
                    .HasMaxLength(255);

                entity.Property(e => e.Dateupdate)
                    .HasColumnName("DATEUPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereCommande)
                    .HasColumnName("DTDERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereReception)
                    .HasColumnName("DTDERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereVente)
                    .HasColumnName("DTDERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteStock).HasColumnName("QTE_STOCK");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Seuil).HasColumnName("SEUIL");
            });

            modelBuilder.Entity<SiteAdresse>(entity =>
            {
                entity.HasKey(e => new { e.SiteCode, e.CodeAdresse });

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");

                entity.Property(e => e.CodeAdresse).HasMaxLength(300);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateMaj)
                    .HasColumnName("DateMAJ")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SiteCapacityDefault>(entity =>
            {
                entity.HasKey(e => e.SiteCode)
                    .HasName("PK__SiteCapa__BE2497AF1A184955");

                entity.ToTable("SiteCapacityDefault", "capacity");

                entity.Property(e => e.SiteCode)
                    .HasColumnName("SiteCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CapacityAm).HasColumnName("CapacityAM");

                entity.Property(e => e.CapacityPm).HasColumnName("CapacityPM");
            });

            modelBuilder.Entity<SiteCapacitySpecif>(entity =>
            {
                entity.HasKey(e => e.SiteCode)
                    .HasName("PK__SiteCapa__BE2497AF6BBE168F");

                entity.ToTable("SiteCapacitySpecif", "capacity");

                entity.Property(e => e.SiteCode)
                    .HasColumnName("SiteCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedByUsername).IsRequired();

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSpecif).HasColumnType("date");

                entity.Property(e => e.NewCapacityAm).HasColumnName("NewCapacityAM");

                entity.Property(e => e.NewCapacityPm).HasColumnName("NewCapacityPM");
            });

            modelBuilder.Entity<SiteCorrespondance>(entity =>
            {
                entity.HasKey(e => e.SiteCodeWynd)
                    .HasName("PK__tmp_ms_x__431D937D61F73E69");

                entity.HasIndex(e => e.SiteCode)
                    .HasName("index_SiteCorrespondance__code_site");

                entity.Property(e => e.SiteCodeWynd).ValueGeneratedNever();

                entity.Property(e => e.DateMaj)
                    .HasColumnName("DateMAJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpCaisse).HasColumnName("IP_CAISSE");

                entity.Property(e => e.Isclickandcollect).HasColumnName("ISCLICKANDCOLLECT");

                entity.Property(e => e.Lat).HasColumnName("LAT");

                entity.Property(e => e.Libsite).HasColumnName("LIBSITE");

                entity.Property(e => e.Lon).HasColumnName("LON");

                entity.Property(e => e.MaxCapacity).HasColumnName("MAX_CAPACITY");

                entity.Property(e => e.Rayon).HasColumnName("RAYON");

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");

                entity.Property(e => e.TypeCaisse).HasColumnName("Type_CAISSE");
            });

            modelBuilder.Entity<SiteLex>(entity =>
            {
                entity.ToTable("SiteLEX", "ecom");

                entity.HasOne(d => d.SiteCodeWyndNavigation)
                    .WithMany(p => p.SiteLex)
                    .HasForeignKey(d => d.SiteCodeWynd)
                    .HasConstraintName("FK__SiteLEX__SiteCod__731B1205");
            });

            modelBuilder.Entity<SitePolygon>(entity =>
            {
                entity.ToTable("SitePolygon", "ecom");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SiteCodeWyndNavigation)
                    .WithMany(p => p.SitePolygon)
                    .HasForeignKey(d => d.SiteCodeWynd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SitePolygon_ToSite");
            });

            modelBuilder.Entity<SitePolygonLex>(entity =>
            {
                entity.ToTable("SitePolygonLEX", "ecom");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.SiteCodeWyndNavigation)
                    .WithMany(p => p.SitePolygonLex)
                    .HasForeignKey(d => d.SiteCodeWynd)
                    .HasConstraintName("FK__SitePolyg__SiteC__5832119F");
            });

            modelBuilder.Entity<StocksWyndInfo>(entity =>
            {
                entity.ToTable("StocksWyndInfo", "ecom");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductUuid).HasColumnName("ProductUUID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.Property(e => e.WarehouseUuid).HasColumnName("WarehouseUUID");

                entity.HasOne(d => d.SiteCodeWyndNavigation)
                    .WithMany(p => p.StocksWyndInfo)
                    .HasForeignKey(d => d.SiteCodeWynd)
                    .HasConstraintName("FK__StocksWyn__SiteC__1387E197");
            });

            modelBuilder.Entity<SubstitutionGroup>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Codeart })
                    .HasName("PK__tmp_ms_x__BCD0C5DCC60B4246");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.HasOne(d => d.CodeartNavigation)
                    .WithMany(p => p.SubstitutionGroup)
                    .HasForeignKey(d => d.Codeart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubstitutionGroup_ToArticlelnfo");
            });

            modelBuilder.Entity<TraceKaalixApi>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__Trace_Ka__65A475E76A32D872");

                entity.ToTable("Trace_Kaalix_API");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(300);

                entity.Property(e => e.CodeResponse)
                    .IsRequired()
                    .HasColumnName("Code_Response");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateDebut)
                    .HasColumnName("Date_Debut")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateFin)
                    .HasColumnName("Date_Fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsSuccessCanceled).HasColumnName("IsSuccess_Canceled");

                entity.Property(e => e.IsSuccessCreatedUpdated).HasColumnName("IsSuccess_Created_Updated");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Response).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TraceWyndApi>(entity =>
            {
                entity.ToTable("Trace_Wynd_API");

                entity.HasIndex(e => e.DateOperation)
                    .HasName("index_trace_wynd_api_dateOperation");

                entity.Property(e => e.AppVersion).IsRequired();

                entity.Property(e => e.DateOperation).HasColumnType("datetime");

                entity.Property(e => e.Env)
                    .IsRequired()
                    .HasColumnName("ENV")
                    .HasMaxLength(50);

                entity.Property(e => e.Method).HasMaxLength(50);

                entity.Property(e => e.PhoneId).IsRequired();

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL");

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<VDashbordEvolCaSite>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_DashbordEvolCA_Site");

                entity.Property(e => e.J).HasColumnType("date");

                entity.Property(e => e.Magasin)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<WyndDisabledArticle>(entity =>
            {
                entity.ToTable("WyndDisabledArticle", "ecom");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.DateDisable).HasColumnType("datetime");

                entity.HasOne(d => d.CodeartNavigation)
                    .WithMany(p => p.WyndDisabledArticle)
                    .HasForeignKey(d => d.Codeart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WyndDisab__CODEA__21D600EE");
            });

            modelBuilder.Entity<WyndDisabledArticleHistorique>(entity =>
            {
                entity.ToTable("WyndDisabledArticleHistorique", "ecom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codeart).HasColumnName("CODEART");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CodeartNavigation)
                    .WithMany(p => p.WyndDisabledArticleHistorique)
                    .HasForeignKey(d => d.Codeart)
                    .HasConstraintName("FK__WyndDisab__CODEA__24B26D99");
            });

            modelBuilder.Entity<WyndOrderCreneauCapacity>(entity =>
            {
                entity.HasKey(e => e.OrderWyndUuid)
                    .HasName("PK__tmp_ms_x__3288C879FE2C1EDD");

                entity.ToTable("WyndOrderCreneauCapacity", "capacity");

                entity.Property(e => e.OrderWyndUuid)
                    .HasColumnName("OrderWyndUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateDebutLivraison).HasColumnType("datetime");

                entity.Property(e => e.DateFinLivraison).HasColumnType("datetime");

                entity.Property(e => e.DateMiseAjour)
                    .HasColumnName("DateMiseAJour")
                    .HasColumnType("datetime");

                entity.Property(e => e.SiteCode).HasColumnName("SiteCode");
            });

            modelBuilder.Entity<WyndOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.WyndOrderDetailUuid, e.WyndOrderHeaderUuid });

                entity.ToTable("WyndOrderDetail", "capacity");

                entity.HasIndex(e => e.WyndOrderHeaderReference)
                    .HasName("IX_WyndOrderDetail_Reference");

                entity.HasIndex(e => new { e.Label, e.Price, e.ProductExternalId, e.WyndOrderHeaderReference, e.WyndOrderHeaderUuid, e.Quantity })
                    .HasName("nci_wi_WyndOrderDetail_90DB070A6E7C303810C9A9E86EE557D9");

                entity.Property(e => e.WyndOrderDetailUuid)
                    .HasColumnName("WyndOrderDetailUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.WyndOrderHeaderUuid)
                    .HasColumnName("WyndOrderHeaderUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.DtderniereCommande)
                    .HasColumnName("DTDERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereReception)
                    .HasColumnName("DTDERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereVente)
                    .HasColumnName("DTDERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ForcedPrice).HasColumnName("forced_price");

                entity.Property(e => e.IsDiscount).HasColumnName("is_discount");

                entity.Property(e => e.IsPayable).HasColumnName("is_payable");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.LineIndex).HasColumnName("line_index");

                entity.Property(e => e.OriginalPrice).HasColumnName("original_price");

                entity.Property(e => e.OriginalQuantity).HasColumnName("original_quantity");

                entity.Property(e => e.PreparationState)
                    .IsRequired()
                    .HasColumnName("preparation_state");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductExternalId).HasColumnName("ProductExternal_id");

                entity.Property(e => e.ProductWyndDefaultLabel)
                    .IsRequired()
                    .HasColumnName("ProductWyndDefault_label");

                entity.Property(e => e.ProductWyndUuid).IsRequired();

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StockDatePreparation).HasColumnName("STOCK_DATE_PREPARATION");

                entity.Property(e => e.StockDispo).HasColumnName("STOCK_DISPO");

                entity.Property(e => e.TotalVat).HasColumnName("total_vat");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded");

                entity.Property(e => e.TotalVatIncluded).HasColumnName("total_vat_included");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("unit");

                entity.Property(e => e.UnitPriceVatExcluded).HasColumnName("unit_price_vat_excluded");

                entity.Property(e => e.Vat).HasColumnName("vat");

                entity.Property(e => e.VatRate)
                    .IsRequired()
                    .HasColumnName("vat_rate");

                entity.Property(e => e.WyndOrderHeaderReference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.WyndOrderHeaderUu)
                    .WithMany(p => p.WyndOrderDetail)
                    .HasForeignKey(d => d.WyndOrderHeaderUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WyndOrderDetail_ToWyndOrderHeader");
            });

            modelBuilder.Entity<WyndOrderDetailArch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WyndOrderDetail_Arch", "capacity");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.DtderniereCommande)
                    .HasColumnName("DTDERNIERE_COMMANDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereReception)
                    .HasColumnName("DTDERNIERE_RECEPTION")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtderniereVente)
                    .HasColumnName("DTDERNIERE_VENTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ForcedPrice).HasColumnName("forced_price");

                entity.Property(e => e.IsDiscount).HasColumnName("is_discount");

                entity.Property(e => e.IsPayable).HasColumnName("is_payable");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label");

                entity.Property(e => e.LineIndex).HasColumnName("line_index");

                entity.Property(e => e.OriginalPrice).HasColumnName("original_price");

                entity.Property(e => e.OriginalQuantity).HasColumnName("original_quantity");

                entity.Property(e => e.PreparationState)
                    .IsRequired()
                    .HasColumnName("preparation_state");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductExternalId).HasColumnName("ProductExternal_id");

                entity.Property(e => e.ProductWyndDefaultLabel)
                    .IsRequired()
                    .HasColumnName("ProductWyndDefault_label");

                entity.Property(e => e.ProductWyndUuid).IsRequired();

                entity.Property(e => e.QteRecu).HasColumnName("QTE_RECU");

                entity.Property(e => e.QteVendu).HasColumnName("QTE_VENDU");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StockDatePreparation).HasColumnName("STOCK_DATE_PREPARATION");

                entity.Property(e => e.StockDispo).HasColumnName("STOCK_DISPO");

                entity.Property(e => e.TotalVat).HasColumnName("total_vat");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded");

                entity.Property(e => e.TotalVatIncluded).HasColumnName("total_vat_included");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("unit");

                entity.Property(e => e.UnitPriceVatExcluded).HasColumnName("unit_price_vat_excluded");

                entity.Property(e => e.Vat).HasColumnName("vat");

                entity.Property(e => e.VatRate)
                    .IsRequired()
                    .HasColumnName("vat_rate");

                entity.Property(e => e.WyndOrderDetailUuid)
                    .IsRequired()
                    .HasColumnName("WyndOrderDetailUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.WyndOrderHeaderReference)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.WyndOrderHeaderUuid)
                    .IsRequired()
                    .HasColumnName("WyndOrderHeaderUUID")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<WyndOrderHeader>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__tmp_ms_x__65A475E75AC07FF8");

                entity.ToTable("WyndOrderHeader", "capacity");

                entity.HasIndex(e => e.Reference)
                    .HasName("IX_WyndOrderHeader_Reference");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(300);

                entity.Property(e => e.AddressInline).HasColumnName("Address_Inline");

                entity.Property(e => e.ChannelUuid)
                    .HasColumnName("ChannelUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Complement).HasColumnName("complement");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerFullName).IsRequired();

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CustomerUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.DatePreparationFinish).HasColumnType("datetime");

                entity.Property(e => e.DatePreparationStart).HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJob).HasColumnType("datetime");

                entity.Property(e => e.DeliveryLat).HasMaxLength(50);

                entity.Property(e => e.DeliveryLon).HasMaxLength(50);

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Door).HasColumnName("door");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart).HasColumnType("datetime");

                entity.Property(e => e.EntityLabel)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.EntityUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Env)
                    .HasColumnName("env")
                    .HasMaxLength(10);

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.ErpStoreId).HasColumnName("_erp_store_id");

                entity.Property(e => e.PaymentMethod).HasColumnName("Payment_Method");

                entity.Property(e => e.PickerUuid).HasMaxLength(300);

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.ShipDateTimeLastUpdate)
                    .HasColumnName("Ship_dateTimeLastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenDelivrered)
                    .HasColumnName("Ship_dateTimeWhenDelivrered")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenInTransport)
                    .HasColumnName("Ship_dateTimeWhenInTransport")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipJobUpdateDate)
                    .HasColumnName("Ship_JobUpdateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartedAt)
                    .HasColumnName("started_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StreetName).HasColumnName("street_name");

                entity.Property(e => e.StreetNumber).HasColumnName("street_number");

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded ");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<WyndOrderHeaderArch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WyndOrderHeader_Arch", "capacity");

                entity.Property(e => e.ChannelUuid)
                    .HasColumnName("ChannelUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerFullName).IsRequired();

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CustomerUUID")
                    .HasMaxLength(300);

                entity.Property(e => e.DatePreparationFinish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdateJob).HasColumnType("datetime");

                entity.Property(e => e.DeliveryLat).HasMaxLength(50);

                entity.Property(e => e.DeliveryLon).HasMaxLength(50);

                entity.Property(e => e.DestinationCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDateStart).HasColumnType("datetime");

                entity.Property(e => e.EntityLabel)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.EntityUuid)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ErpStoreId).HasColumnName("_erp_store_id");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasMaxLength(300);

                entity.Property(e => e.ShipDateTimeLastUpdate)
                    .HasColumnName("Ship_dateTimeLastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenDelivrered)
                    .HasColumnName("Ship_dateTimeWhenDelivrered")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDateTimeWhenInTransport)
                    .HasColumnName("Ship_dateTimeWhenInTransport")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipJobUpdateDate)
                    .HasColumnName("Ship_JobUpdateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartedAt)
                    .HasColumnName("started_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubTotal).HasColumnName("sub_total");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalVatExcluded).HasColumnName("total_vat_excluded ");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("UUID")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<WyndRatingClient>(entity =>
            {
                entity.ToTable("WyndRatingClient", "capacity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.CustomerEmail).HasColumnName("CUSTOMER_EMAIL");

                entity.Property(e => e.CustomerFullname)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_FULLNAME");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_PHONE");

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_UUID");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("RATING_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resolved).HasColumnName("RESOLVED");

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });

            modelBuilder.Entity<WyndRatingCommande>(entity =>
            {
                entity.ToTable("WyndRatingCommande", "capacity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.CustomerEmail).HasColumnName("CUSTOMER_EMAIL");

                entity.Property(e => e.CustomerFullname)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_FULLNAME");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_PHONE");

                entity.Property(e => e.CustomerUuid)
                    .IsRequired()
                    .HasColumnName("CUSTOMER_UUID");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderReference)
                    .IsRequired()
                    .HasColumnName("ORDER_REFERENCE");

                entity.Property(e => e.OrderUuid)
                    .IsRequired()
                    .HasColumnName("ORDER_UUID");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.Property(e => e.RatingDate)
                    .HasColumnName("RATING_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resolved).HasColumnName("RESOLVED");

                entity.Property(e => e.Type).HasColumnName("TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
