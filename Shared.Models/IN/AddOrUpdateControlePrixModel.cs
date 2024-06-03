using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class AddOrUpdateControlePrixModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string existintable { get; set; }
        [Required]
        public string controlNo { get; set; }
        public List<ArticleControlePrixModel> listeArticles { get; set; }
    }

    public class ArticleControlePrixModel
    {
        public string existintable { get; set; }
        public string changed { get; set; }
        public string TillCode { get; set; }
        public string CaisseCode { get; set; }
        public string TillDesc { get; set; }
        public string VentePrice { get; set; }
        public string CaissePrice { get; set; }
        public string intCodeArticleSale { get; set; }
        public string SeqNum { get; set; }
        public string cinr { get; set; }
        public string RayonPrice { get; set; }
        public string EtiqNumber { get; set; }
    }
}
