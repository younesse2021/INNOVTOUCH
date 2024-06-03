using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{

    public class ArticleModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string ean { get; set; }
        //[Required]
        //public string codeArticle { get; set; }
        [Required]
        public string inventaire { get; set; }
        [Required]
        public string type { get; set; } = "string";

        [Required]
        public string type_demarque { get; set; }

        public string NumeroArrivage { get; set; }
        public string NumeroImmatr { get; set; }
        public string code_orig { get; set; }
        public string site_gere_en_stock { get; set; }
        public string code_dest { get; set; }
        public string Artcomp { get; set; }
        public string palette { get; set; }
        public string paletteCode { get; set; }
        public string barCode { get; set; }
        public string CintPalette { get; set; }
        public string NumPalette { get; set; }
        public string ArticleCode { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }
        [JsonProperty("emplacement")]
        public string Emplacement { get; set; }
        [JsonProperty("etatPalette")]
        public string EtatPalette { get; set; }
        [JsonProperty("nbArticles")]
        public string NbArticles { get; set; }
        public GetInfoPaletteContenuModel InfoPalette { get; set; }

        public List<ArticlesInsertArrivage> listeArticles { get; set; }

        //[Required]
        //public string controlNo { get; set; }
    }

    public class ImmatriculationModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }

        public string numeroImmatr { get; set; }
    }

    public class ArticlesInsertArrivage
    {
        public string codeEan { get; set; }
        public string articleLibelle { get; set; }
        public string quantite { get; set; }
        public string poids { get; set; }
        public string uvcua { get; set; }
        public string ua { get; set; }
        public string ustk { get; set; }
        public string seqvl { get; set; }
        public string cexr { get; set; }
        public string cinv { get; set; }
        public string cexv { get; set; }
        public string motif { get; set; }
    }
    public class GetInfoPaletteContenuModel
    {
        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string Zone { get; set; }
        public string Emplacement { get; set; }
        public string EtatPalette { get; set; }
        public string NbArticles { get; set; }
    }
}
