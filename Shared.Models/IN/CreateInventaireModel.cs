using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{

     

    public class CreateInventaireModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string inventaire { get; set; }
        public string type { get; set; }
        public string zone { get; set; }
        public string emplacement { get; set; }
        public List<ListeArticlesInventaireModel> ListeArticles { get; set; }
    }

    public class ListeArticlesInventaireModel
    {
        public string id { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string weight { get; set; }
        public string salePrice { get; set; }
        public string externalVariantCode { get; set; }
        public string status { get; set; }
        public string internalLogisticCode { get; set; }
        public string intMerchStrucNode { get; set; }
        public string extMerchStrucNode { get; set; }
        public string merchStructureID { get; set; }
        public string invoicingUnit { get; set; }
        public string stockUnit { get; set; }
        public string averageWeight { get; set; }
        public string seqvl { get; set; }
        public string InventaireId { get; set; }
    }

    public class ListeArticlesInventaireModelSqlLight
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string inventaire { get; set; }
        public string type { get; set; }
        public string zone { get; set; }
        public string emplacement { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string weight { get; set; }
        public string salePrice { get; set; }
        public string externalVariantCode { get; set; }
        public string status { get; set; }
        public string internalLogisticCode { get; set; }
        public string intMerchStrucNode { get; set; }
        public string extMerchStrucNode { get; set; }
        public string merchStructureID { get; set; }
        public string invoicingUnit { get; set; }
        public string stockUnit { get; set; }
        public string averageWeight { get; set; }
        public string seqvl { get; set; }
    }
}
