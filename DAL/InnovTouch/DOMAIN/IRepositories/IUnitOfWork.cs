
using DAL.InnovTouch.DAL.Repositories.Inventaire;
using DAL.InnovTouch.DOMAIN.IRepositories.Entite;
using DAL.InnovTouch.DOMAIN.IRepositories.Produits;
using DAL.InnovTouch.DOMAIN.IRepositories.Role;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.DOMAIN.IRepositories
{
    public interface IUnitOfWork
    {
        #region Entite
        public IEnseigneRepository Enseignes { get; }
        public IMagasinRepository Magasins { get; }
        #endregion

        #region Produits
        public IInnovTouchProduitRepository InnovTouchProduits { get; }
        public IFamilleProduitRepository FamilleProduits { get; }
        public IAlerteProduitRepository AlerteProduits { get; }
        public InnovTouch.DOMAIN.IRepositories.Produits.IProduitRepository Produits { get; }
        #endregion

        #region Role
        public IDroitRepository Droits { get; }
        public IDroitProfileRepository DroitProfiles { get; }
        public IProfileRepository Profiles { get; }
        public IUtilisateurRepository Utilisateurs { get; }
        public IInventoryRepository Inventory { get; }
        public IZoneRepository Zone { get; }
        #endregion

        #region Inventaire
        public IAddInventaireRepository Inventaire { get; }
        public IRayoneRepository Rayone { get; }
        public IEmplacementRepository Emplacement { get; }
        public IDetailsLot DetailsLot { get; }
        #endregion

        void Save();
        Task<int> SaveAsync();
    }
}
