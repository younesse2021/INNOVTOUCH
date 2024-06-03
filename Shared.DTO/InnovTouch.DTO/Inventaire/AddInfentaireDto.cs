using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Inventaire
{
    public class AddInfentaireDto
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string inventaire { get; set; }
        public string type { get; set; }
        public string zone { get; set; }
        public string emplacement { get; set; }
        public List<ProduitListDTO> Produits { get; set; }
        public int CountOfProduts { get { return Produits.Count; } }
    }

    public class ExportExcelModelDto
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; } = "";
        public string site { get; set; }
        public string inventaire { get; set; }
        public string type { get; set; } = "";
        public string zone { get; set; }
        public string emplacement { get; set; }
        public string quantity { get; set; }
        public string codebar { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string stockUnit { get; set; }
        public string? libStockUnit { get; set; }
        public string averageWeight { get; set; }
        public string salePrice { get; set; }
        public string seqvl { get; set; }
        public int? AddInventaireId { get; set; }
        public int? NewQentity { get; set; }
    }

    public class ExportExcelModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string inventaire { get; set; }
        public string type { get; set; }
        public string zone { get; set; }
        public string quantity { get; set; }
        public string emplacement { get; set; }
        public string barcode { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string stockUnit { get; set; }
        public string? libStockUnit { get; set; }
        public string averageWeight { get; set; }
        public string salePrice { get; set; }
        public string seqvl { get; set; }
        public int? AddInventaireId { get; set; }
 
    }
    public class DetailsLotDto
    {
        public int Id { get; set; }
        public int IdInventaire { get; set; }
        public int IdRayone { get; set; }
        public int Type { get; set; }
        public int NumberLot { get; set; }
        public string Libbele { get; set; }
        public string CodeIn { get; set; }
        public string CodeOut { get; set; }
        public bool IsScanned { get; set; }
        public string NomInventaire { get; set; }
        public string Nomrayone { get; set; }
        public string StatusLOt { get; set; }
    }
    public class ExportLot
    {
        public string? Inventaire_number { get; set; }
        public string? Inventaire_Libbele { get; set; }
        public string? Inventaire_CodeIn { get; set; }
        public string? Inventaire_CodeOut { get; set; }
        public int Inventaire_Rayone_Id { get; set; }
        public string? Inventaire_Rayone_name { get; set; }
        public int Inventaire_numeber_emplaamcent { get; set; }
        public string Inventaire_Nom_lot { get; set; }
    }
}
