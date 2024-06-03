using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class CreateCasseFraisModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }

        public List<ArticlesCasseFrais> listeArticles { get; set; }
    }

    public class ArticlesCasseFrais
    {
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Source { get; set; }
        public string PrixVente { get; set; }
        public string sitgbal { get; set; }
        public string Grat { get; set; }
        public string WeightOpFrais { get; set; }
        public string EtiFormatCode { get; set; }
        public string EtiFormatDesc { get; set; }
        public string EtiFormatNbr { get; set; }
        public string Remise { get; set; }
        public string PrixCasseFrais { get; set; }
    }
}
