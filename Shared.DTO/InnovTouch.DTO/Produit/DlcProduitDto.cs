
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Models.Helper;
using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.DTO.InnovTouch.DTO.Role;
using System;
using System.Collections.Generic;

namespace Shared.DTO.DLC.DTO.Produit
{
    public class DlcProduitDto
    {
        public int Id { get; set; }

        #region Produit
        public ProduitDto? Produit { get; set; }
        public int? ProduitId { get; set; }
        public string? CodeFamilleProduit { get; set; }
        public string? LibelleFamilleProduit { get; set; }
        public string? CodeProduit { get; set; }
        public string? LibelleProduit { get; set; }
        public double PrixInitial { get; set; }
        public int QteInitiale { get; set; }
        public DateTime Dlc { get; set; }
        public UtilisateurDto? Agent { get; set; }
        public int? AgentId { get; set; }
        public DateTime DateControl { get; set; }

        public string? AgentUserName { get; set; }
        #endregion

        #region Commun
        public int? QteActualise { get; set; }
        public MagasinDto? Magasin { get; set; }
        public int? MagasinId { get; set; }
        public string? CodeMagasin { get; set; }

        public int? EnseigneId { get; set; }
        public EnseigneDto? Enseigne { get; set; }
        public string? CodeEnseigne { get; set; }
        #endregion

        #region Remise
        public bool? IsRemiseApplique { get; set; }
        public double? PrixRemise { get; set; }
        public double? PourcentageRemise { get; set; }
        public UtilisateurDto? RespRemise { get; set; }
        public int? RespRemiseId { get; set; }
        public bool? IsRemiseValide { get; set; }
        public DateTime? DateValidationRemise { get; set; }
        public UtilisateurDto? RespRemiseValidation { get; set; }
        public int? RespRemiseValidationId { get; set; }
        public int? QteEtqImprime { get; set; }

        public string? RespRemiseUserName { get; set; }
        #endregion

        #region Retrait

        public bool? IsRetraitValide { get; set; }
        public DateTime? DateValidationRetrait { get; set; }
        public UtilisateurDto? RespRetraitValidation { get; set; }
        public int? RespRetraitValidationId { get; set; }
        public UtilisateurDto? RespRetrait { get; set; }
        public int? RespRetraitId { get; set; }
        public bool? IsRetire { get; set; }

        public string? RespRetraitUserName { get; set; }

        public string? RespRetraiUserName { get; set; }

        #endregion

        public ActionProduit? Action { get; set; }
        public string? ActionAFaire { get; set; }
        public string? CodeCouleur { get; set; }
        public int? NbrJourRestant { get; set; }
        public string? ActionRealise
        {
            get
            {
                if (IsRemiseApplique == true)
                {
                    return "Remisé";
                }
                else if (IsRetraitValide == true)
                {
                    return "Retiré";
                }
                else
                {
                    return "Rien";
                }

            }
        }

        #region Attribute binding xamarin
        public string CodeColrFram { get { if (Action == ActionProduit.Remise) return "#00c851"; else return "#C65717"; } }
        public string DisplayRespRemise { get { return $"Responsable Remise : {RespRemiseUserName}"; } }
        public string DisplayCodeProduit { get { return $"Code  :   {CodeProduit}"; } }
        public string DisplayNomProduit { get { return $"Nom Produit :  {LibelleProduit}"; } }
        public string DispayRemise { get { if (PrixRemise != null && PrixRemise != 0) { return "Remise appliqué : Oui "; } else return "Remise appliqué : Non"; } }
        public string DisplayPrixUntaire
        {
            get
            {
                if (PrixRemise != null && PrixRemise != 0)
                    return $"Prix Unitaire   :  {PrixRemise.Value}";
                else return $"Prix Unitaire   :  {PrixInitial.ToString()}";
            }
        }
        public string DisplayQNt { get { return $"Quantité  :  {QteActualise}"; } }
        public string DisplayNbDay { get { if (Action == ActionProduit.Remise) return $"Le nombre de jours restant :   {NbrJourRestant}"; else return $"Ce produit a expiré avant:   {NbrJourRestant} Jours"; } }
        public string DisplayDLC { get { return $"DLC  :   {Dlc.ToString("dd-MM-yyyy")}"; } }
        public string DisplayFamilleProduit { get { return $"Libelle du produit  :   {Produit?.Libelle}"; } }
        public string DisplayValideRemise { get { return IsRemiseValide == true ? "Valide" : "Non Valide"; } }
        public bool IsHaveAccessToPrint { get { if (DisplayValideRemise == "Non Valide") { return false; } else return true; } }
        public string DisplayColorValidRemise { get { return IsRemiseValide == true ? "#008000" : "#FF0000"; } }
        public bool IsEnabledActionRetrais { get { if (Action == ActionProduit.Retrait) return true; else return false; } }
        public bool IsEnabledActionRemise { get { if (IsEnabledActionRetrais) return false; else return true; } }

        public int? JourRemise { get; set; }
        public int? JourRetrait { get; set; }

        public string BackgroundColor { get; set; } = "#FFFFFF";
        public string DateDlc { get { return Dlc.ToShortDateString(); } }
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Produit)}={Produit}, {nameof(ProduitId)}={ProduitId}, {nameof(CodeFamilleProduit)}={CodeFamilleProduit}, {nameof(LibelleFamilleProduit)}={LibelleFamilleProduit}, {nameof(CodeProduit)}={CodeProduit}, {nameof(LibelleProduit)}={LibelleProduit}, {nameof(PrixInitial)}={PrixInitial}, {nameof(QteInitiale)}={QteInitiale}, {nameof(Dlc)}={Dlc}, {nameof(Agent)}={Agent}, {nameof(AgentId)}={AgentId}, {nameof(DateControl)}={DateControl}, {nameof(QteActualise)}={QteActualise}, {nameof(Magasin)}={Magasin}, {nameof(MagasinId)}={MagasinId}, {nameof(CodeMagasin)}={CodeMagasin}, {nameof(PrixRemise)}={PrixRemise}, {nameof(PourcentageRemise)}={PourcentageRemise}, {nameof(RespRemise)}={RespRemise}, {nameof(RespRemiseId)}={RespRemiseId}, {nameof(IsRemiseValide)}={IsRemiseValide}, {nameof(DateValidationRemise)}={DateValidationRemise}, {nameof(RespRemiseValidation)}={RespRemiseValidation}, {nameof(RespRemiseValidationId)}={RespRemiseValidationId}, {nameof(QteEtqImprime)}={QteEtqImprime}, {nameof(IsRetraitValide)}={IsRetraitValide}, {nameof(DateValidationRetrait)}={DateValidationRetrait}, {nameof(RespRetraitValidation)}={RespRetraitValidation}, {nameof(RespRetraitValidationId)}={RespRetraitValidationId}, {nameof(RespRetrait)}={RespRetrait}, {nameof(RespRetraitId)}={RespRetraitId}, {nameof(IsRetire)}={IsRetire}, {nameof(Action)}={Action}, {nameof(ActionAFaire)}={ActionAFaire}, {nameof(CodeCouleur)}={CodeCouleur}, {nameof(NbrJourRestant)}={NbrJourRestant}, {nameof(DisplayCodeProduit)}={DisplayCodeProduit}, {nameof(DisplayNomProduit)}={DisplayNomProduit}, {nameof(DispayRemise)}={DispayRemise}, {nameof(DisplayPrixUntaire)}={DisplayPrixUntaire}, {nameof(DisplayQNt)}={DisplayQNt}, {nameof(DisplayNbDay)}={DisplayNbDay}, {nameof(DisplayDLC)}={DisplayDLC}, {nameof(DisplayFamilleProduit)}={DisplayFamilleProduit}, {nameof(DisplayValideRemise)}={DisplayValideRemise}, {nameof(IsHaveAccessToPrint)}={IsHaveAccessToPrint}, {nameof(DisplayColorValidRemise)}={DisplayColorValidRemise}, {nameof(IsEnabledActionRetrais)}={IsEnabledActionRetrais}, {nameof(IsEnabledActionRemise)}={IsEnabledActionRemise}}}";
        }
        #endregion
    }

    public class HestoriqueDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
