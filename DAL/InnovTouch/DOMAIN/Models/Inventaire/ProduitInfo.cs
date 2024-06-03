using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DOMAIN.Models.Inventaire
{
    [Table("Pr_produit")]
    [Keyless]
    public class ProduitInfo
    {
        public string CODE_INT { get; set; }
        public DateTime DATE_CREATION { get; set; }
        public string ETAT { get; set; }
        public string LIB_ETAT_ARTICLE { get; set; }
        public string LIBELLE { get; set; }
        public string CODE_GRP { get; set; }
        public string GRP { get; set; }
        public string CODE_DEP { get; set; }
        public string DEP { get; set; }
        public string CODE_RAY { get; set; }
        public string RAY { get; set; }
        public string CODE_FAM { get; set; }
        public string FAM { get; set; }
        public string CODE_SFAM { get; set; }
        public string SFAM { get; set; }
        public string CODE_SSFAM { get; set; }
        public string SSFAM { get; set; }
        public string CODE_CAISSE { get; set; }
    }

    public class ProduitInfoDto
    {
        public string barcode { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string externalVariantCode { get; set; }
        public string internalLogisticCode { get; set; }
        public string stockUnit { get; set; }
        public string libStockUnit { get; set; }
        public string invoicingUnit { get; set; }
        public string libInvoicingUnit { get; set; }
        public string averageWeight { get; set; }
        public string intMerchStrucNode { get; set; }
        public string extMerchStrucNode { get; set; }
        public string merchStructureID { get; set; }
        public string salePrice { get; set; }
        public string behaviour { get; set; }
        public string stockMovementAllowed { get; set; }
        public string seqvl { get; set; }
        public Inventory Inventories { get; set; }
    }
}
