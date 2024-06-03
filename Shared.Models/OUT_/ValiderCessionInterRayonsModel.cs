using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.OUT_
{
    public class ValiderCessionInterRayonsModel
    {

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
      
        public List<CessionInterRayonsArticlesModel> list_articles { get; set; }

    }

    public class CessionInterRayonsArticlesModel
    {
        public string prix_cession { get; set; }
        public OrigModel orig { get; set; }
        public DestModel dest { get; set; }
    }

    public class OrigModel
    {
        public string Code { get; set; }
        public string CodeRegrpt { get; set; }
        public string Libelle { get; set; }
        public string Cinl { get; set; }
        public string Seqvl { get; set; }
        public string PrixVente { get; set; }
        public string TVACode { get; set; }
        public string TVADesc { get; set; }
        public string TVARate { get; set; }
        public string StockDispoQte { get; set; }
        public string StockDispoPds { get; set; }
        public string StockUnite { get; set; }
        public string Artustk { get; set; }
        public string Arlpmoy { get; set; }
        public string Artcomp { get; set; }
        public string Qte { get; set; }
        public string Poids { get; set; }
    }

    public class DestModel
    {
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Cinl { get; set; }
        public string Seqvl { get; set; }
        public string PrixVente { get; set; }
        public string TVACode { get; set; }
        public string TVADesc { get; set; }
        public string TVARate { get; set; }
        public string Artustk { get; set; }
        public string Arlpmoy { get; set; }
        public string Artcomp { get; set; }
        public string Qte { get; set; }
        public string Poids { get; set; }
    }
}
