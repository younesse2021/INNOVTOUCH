using Shared.DTO.InnovTouch.DTO.Inventaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Inventaire
{
    public class ProduitListDTO
    {
        public int Id { get; set; }
        public string barcode { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string stockUnit { get; set; }
        public string? libStockUnit { get; set; }
        public string averageWeight { get; set; }
        public string salePrice { get; set; }
        public string seqvl { get; set; }
        public int? AddInventaireId { get; set; }
        public AddInfentaireDto AddInfentaire { get; set; }
    }

}
