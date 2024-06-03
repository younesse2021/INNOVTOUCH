using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{
    public class ArticleTicketCasseFraisModel
    {
        public string ean { get; set; }
        public string libelle { get; set; }
        public string new_prix { get; set; }
        public string old_prix { get; set; }
        public string date_edition { get; set; }
        public string url_barcode { get; set; }
    }
}
