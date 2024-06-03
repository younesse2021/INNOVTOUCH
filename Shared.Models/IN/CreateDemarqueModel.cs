using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{
    public enum ActionDemarque
    {
        Add = 0,
        Update = 1,
        Delete = 2,
        Nothing = 4,
        Valider = 5,
        Integrer = 6
    }
    public class CreateDemarqueModel
    {
        public string? NomTelephone { get; set; }
        public string? Username { get; set; }
        public string? Site { get; set; }
        public string? TypeDemarque { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ArtcileDemarqueModel> ListArticles { get; set; }
        public ActionDemarque? Actions { get; set; }

        public override string ToString()
        {
            return $"Username:{Username}, Site:{Site}, NomTelephone:{NomTelephone}";
        }
    }
    public class ArticleDemarqueTelephoneModel
    {
        public string? Nomportable { get; set; }
        public List<ArtcileDemarqueModel>? ArticleDemarques { get; set; }
        public string? Count { get; set; }
        public bool? isValide { get; set; }

        public string? Status { get { if (isValide == true) return "IsValid.png"; else return "NoValid.png"; } }
        public string? DisplayCount { get { return $"{Count} : Articles"; } }
        public bool IsChecked { get; set; }
    }
    public class ArtcileDemarqueModel
    {
        public string Ean { get; set; }
        public string Conde_int { get; set; }
        public string Famille { get; set; }
        public string Sfamille { get; set; }
        public string Rayon { get; set; }
        public string Departement { get; set; }
        public string Qte { get; set; }
        public string Libelle { get; set; }

        public string? NomTelephone { get; set; }
        public bool? isValide { get; set; } = false;
        public DateTime? Date { get; set; }
        public ActionDemarque? Actions { get; set; }

        #region - Xamarin 
        public string? DisplayCode { get { return $"Code : {Ean}"; } }
        public string? DisplayLibelle { get { return $"Libelle : {Libelle}"; } }
        public string? DisplayQantity { get { return $"Quantite : {Qte}"; } }
        public string? Status { get { if (isValide == true) return "IsValid.png"; else return "NoValid.png"; } }
        public bool IsVisibleEdit { get { if (isValide == true) return false; else return true; } }
        public bool IsVisibleDelete { get { if (isValide == true) return false; else return true; } }
        #endregion

    }
}
