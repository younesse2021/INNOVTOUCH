
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DAL.Repositories.Entite;
using DAL.InnovTouch.DAL.Repositories.Inventaire;
using DAL.InnovTouch.DAL.Repositories.InventaireRepo;
using DAL.InnovTouch.DAL.Repositories.Produits;
using DAL.InnovTouch.DAL.Repositories.Role;
using DAL.InnovTouch.DOMAIN.IRepositories.Entite;
using DAL.InnovTouch.DOMAIN.IRepositories.Produits;
using DAL.InnovTouch.DOMAIN.IRepositories.Role;
using System;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.DOMAIN.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {

        #region - Attr 

        private readonly InnovTouchDbContext _InnovTouchDbContext;
        #endregion

        #region Entite
        private readonly Lazy<IEnseigneRepository> _IEnseigneRepository;
        private readonly Lazy<IMagasinRepository> _IMagasinRepository;
        #endregion

        #region Produits
        private readonly Lazy<IInnovTouchProduitRepository> _IInnovTouchProduitRepository;
        private readonly Lazy<IFamilleProduitRepository> _IFamilleProduitRepository;
        private readonly Lazy<IAlerteProduitRepository> _IAlerteProduitRepository;
        private readonly Lazy<IProduitRepository> _IProduitRepository;
        #endregion
       
        private readonly Lazy<IDroitRepository> _IDroitRepository;
        private readonly Lazy<IDroitProfileRepository> _IDroitProfileRepository;
        private readonly Lazy<IProfileRepository> _IProfileRepository;
        private readonly Lazy<IUtilisateurRepository> _IUtilisateurRepository;
        private readonly Lazy<IInventoryRepository> _IInventoryRepository;
        private readonly Lazy<IZoneRepository> _IZoneRepository;
        private readonly Lazy<IAddInventaireRepository> _IAddInventaireRepository;
        private readonly Lazy<IRayoneRepository> _IRayoneRepository;
        private readonly Lazy<IEmplacementRepository> _IEmplacementRepository;
        private readonly Lazy<IDetailsLot> _IDetailsLot;

        #region - Constructor

        public UnitOfWork(InnovTouchDbContext InnovTouchDbContext)
        {
            _InnovTouchDbContext = InnovTouchDbContext;

            //Entite
            _IEnseigneRepository = new Lazy<IEnseigneRepository>(() => new EnseigneRepository(_InnovTouchDbContext));
            _IMagasinRepository = new Lazy<IMagasinRepository>(() => new MagasinRepository(_InnovTouchDbContext));

            //Produits
            _IInnovTouchProduitRepository = new Lazy<IInnovTouchProduitRepository>(() => new InnovTouchProduitRepository(_InnovTouchDbContext));
            _IFamilleProduitRepository = new Lazy<IFamilleProduitRepository>(() => new FamilleProduitRepository(_InnovTouchDbContext));
            _IAlerteProduitRepository = new Lazy<IAlerteProduitRepository>(() => new AlerteProduitRepository(_InnovTouchDbContext));
            _IProduitRepository = new Lazy<InnovTouch.DOMAIN.IRepositories.Produits.IProduitRepository>(() => new DAL.Repositories.Produits.ProduitRepository(_InnovTouchDbContext));

            //Role
            _IDroitRepository = new Lazy<IDroitRepository>(() => new DroitRepository(_InnovTouchDbContext));
            _IDroitProfileRepository = new Lazy<IDroitProfileRepository>(() => new DroitProfileRepository(_InnovTouchDbContext));
            _IProfileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(_InnovTouchDbContext));
            _IUtilisateurRepository = new Lazy<IUtilisateurRepository>(() => new UtilisateurRepository(_InnovTouchDbContext));
            _IInventoryRepository = new Lazy<IInventoryRepository>(() => new InventoryRepository(_InnovTouchDbContext));
            _IZoneRepository = new Lazy<IZoneRepository>(() => new ZoneRepository(_InnovTouchDbContext));
            _IAddInventaireRepository = new Lazy<IAddInventaireRepository>(() => new AddinventaireRepository(_InnovTouchDbContext));
            _IRayoneRepository = new Lazy<IRayoneRepository>(() => new RayoneRepository(_InnovTouchDbContext));
            _IEmplacementRepository = new Lazy<IEmplacementRepository>(() => new EmplacementRepository(_InnovTouchDbContext));
            _IDetailsLot = new Lazy<IDetailsLot>(() => new DetailLot(_InnovTouchDbContext));
        }
        #endregion

        public IEnseigneRepository Enseignes => _IEnseigneRepository.Value;
        public IMagasinRepository Magasins => _IMagasinRepository.Value;
        public IInnovTouchProduitRepository InnovTouchProduits => _IInnovTouchProduitRepository.Value;
        public IFamilleProduitRepository FamilleProduits => _IFamilleProduitRepository.Value;
        public IAlerteProduitRepository AlerteProduits => _IAlerteProduitRepository.Value;
        public IProduitRepository Produits => _IProduitRepository.Value;
        public IDroitRepository Droits => _IDroitRepository.Value;
        public IDroitProfileRepository DroitProfiles => _IDroitProfileRepository.Value;
        public IProfileRepository Profiles => _IProfileRepository.Value;
        public IUtilisateurRepository Utilisateurs => _IUtilisateurRepository.Value;
        public IInventoryRepository Inventory => _IInventoryRepository.Value;
        public IZoneRepository Zone => _IZoneRepository.Value;
        public IAddInventaireRepository Inventaire => _IAddInventaireRepository.Value;
        public IRayoneRepository Rayone => _IRayoneRepository.Value;
        public IEmplacementRepository Emplacement => _IEmplacementRepository.Value;
        public IDetailsLot DetailsLot => _IDetailsLot.Value;
      

        public void Save()
        {
            _InnovTouchDbContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
           return await _InnovTouchDbContext.SaveChangesAsync();
        }
    }
}
