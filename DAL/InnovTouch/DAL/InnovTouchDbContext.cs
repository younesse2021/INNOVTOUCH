
using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace DAL.InnovTouch.DAL
{
    public class InnovTouchDbContext : DbContext
    {
        public InnovTouchDbContext(DbContextOptions<InnovTouchDbContext> options) : base(options)
        {
        }

        #region Entite
        public DbSet<Magasin> Magasins { get; set; }
        #endregion

        #region Produits
        public DbSet<InnovTouchProduit> InnovTouchProduits { get; set; }
        public DbSet<FamilleProduit> FamilleProduits { get; set; }
        public DbSet<AlerteProduit> AlerteProduits { get; set; }
         #endregion

        #region Role
        public DbSet<Droit> Droits { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<DroitProfile> DroitProfiles { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        #endregion

        #region Inventaire
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<ProduitInfo> Produit { get; set; }
        public DbSet<AddInventaire> Inventaire { get; set; }
        public DbSet<ProduitList> ProduitList { get; set; }
        public DbSet<Rayone> Rayone { get; set; }
        public DbSet<Emplacement> Emplacement { get; set; }
        public DbSet<DetailsLot> DetailsLot { get; set; }

        #endregion

        #region "Configuring soft"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InnovTouchProduit>()
            .HasOne(p => p.Agent)
            .WithMany(u => u.InnovTouchProduits)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasForeignKey(p => p.AgentId);

            modelBuilder.Entity<InnovTouchProduit>()
            .HasOne(p => p.RespRemise)
            .WithMany(u => u.InnovTouchProduitsRemise)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasForeignKey(p => p.RespRemiseId);

            modelBuilder.Entity<InnovTouchProduit>()
             .HasOne(p => p.RespRetrait)
             .WithMany(u => u.InnovTouchProduitsRetrait)
             .OnDelete(DeleteBehavior.ClientNoAction)
             .HasForeignKey(p => p.RespRetraitId);

            modelBuilder.Entity<InnovTouchProduit>()
            .HasOne(p => p.RespRemiseValidation)
            .WithMany(u => u.InnovTouchProduitsValideRemise)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasForeignKey(p => p.RespRemiseValidationId);

            modelBuilder.Entity<InnovTouchProduit>()
            .HasOne(p => p.RespRetraitValidation)
            .WithMany(u => u.InnovTouchProduitsValideRetrait)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasForeignKey(p => p.RespRetraitValidationId);

            modelBuilder.Entity<DroitProfile>()
                .ToTable("Ro_DroitProfile")
                .HasKey(dp => new { dp.ProfileId, dp.DroitId });
            modelBuilder.Entity<DroitProfile>()
                .HasOne(bc => bc.Droit)
                .WithMany(b => b.DroitsProfiles)
                .HasForeignKey(bc => bc.DroitId);
            modelBuilder.Entity<DroitProfile>()
                .HasOne(bc => bc.Profile)
                .WithMany(b => b.DroitsProfiles)
                .HasForeignKey(bc => bc.ProfileId);

            modelBuilder.Entity<ProduitList>()
           .HasOne(p => p.AddInfentaire)
           .WithMany(o => o.Produits)
           .HasForeignKey(p => p.InventaireId);

        }
        #endregion
    }
}
