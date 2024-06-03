using Shared.DTO.InnovTouch.DTO.Bo;

namespace InnovTouch_BO.Client.Models
{
    public class AppStateContainer
    {
        public UtilisateurBoDto UtilisateurBo { get; set; } = new UtilisateurBoDto();

        public event Action OnStateChange;

        public void SetValue(UtilisateurBoDto value)
        {
            this.UtilisateurBo.UserName = value.UserName;
            this.UtilisateurBo.Enseigne = value.Enseigne;
            this.UtilisateurBo.EnseigneId = value.EnseigneId;
            this.UtilisateurBo.Token = value.Token;
            this.UtilisateurBo.isConnected = value.isConnected;
            this.UtilisateurBo.Magasins = value.Magasins;
            this.UtilisateurBo.Departements = value.Departements;
            this.UtilisateurBo.Rayons = value.Rayons;

            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
