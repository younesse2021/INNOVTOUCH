using DAL.InnovTouch.DOMAIN.Models.Entite;
using DAL.InnovTouch.DOMAIN.Models.Role;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Produits
{
    [Table("Pr_InnovTouchProduit")]
    public class InnovTouchProduit : BaseModel
    {
        public int Id { get; set; }

        #region Produit
        public Produit? Produit { get; set; }
        public Nullable<int> ProduitId { get; set; }
        public string CodeFamilleProduit { get; set; }
        public string LibelleFamilleProduit { get; set; }
        public string CodeProduit { get; set; }
        public string LibelleProduit { get; set; }
        public double PrixInitial { get; set; }
        public int QteInitiale { get; set; }
        public DateTime InnovTouch { get; set; }
        public Utilisateur? Agent { get; set; }

        [ForeignKey("Agent")]
        public Nullable<int> AgentId { get; set; }
        public DateTime DateControl { get; set; }
        #endregion

        #region Commun
        public  int? QteActualise { get; set; }
        public Magasin? Magasin { get; set; }
        public Nullable<int> MagasinId { get; set; }
        public  string CodeMagasin { get; set; }
        #endregion

        #region Remise
        public Nullable<bool> IsRemiseApplique { get; set; }
        public Nullable<double>  PrixRemise { get; set; }
        public Nullable<double>  PourcentageRemise { get; set; }
        public Utilisateur? RespRemise { get; set; }

        [ForeignKey("RespRemise")]
        public Nullable<int>  RespRemiseId { get; set; }
        public Nullable<bool>  IsRemiseValide { get; set; }
        public Nullable<DateTime> DateValidationRemise { get; set; }
        public Utilisateur? RespRemiseValidation { get; set; }

        [ForeignKey("RespRemiseValidation")]
        public Nullable<int>  RespRemiseValidationId { get; set; }
        public Nullable<int>  QteEtqImprime { get; set; }
        #endregion

        #region Retrait

        public Nullable<bool>  IsRetraitValide { get; set; }
        public Nullable<DateTime> DateValidationRetrait { get; set; }
        public Utilisateur? RespRetraitValidation { get; set; }

        [ForeignKey("RespRetraitValidation")]
        public Nullable<int>  RespRetraitValidationId { get; set; }
        public Utilisateur? RespRetrait { get; set; } 

        [ForeignKey("RespRetrait")]
        public Nullable<int>  RespRetraitId { get; set; }
        public Nullable<bool>  IsRetire { get; set; }




        #endregion

        [NotMapped]
        public ActionProduit? Action { get; set; }
        [NotMapped]
        public string? ActionAFaire { get; set; }
        [NotMapped]
        public string? CodeCouleur { get; set; }
        [NotMapped]
        public int? NbrJourRestant { get; set; }

    }
}
