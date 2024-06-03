using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class CreateEtiquetteModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        public List<ArticlesEtiquetteModel> listeArticles { get; set; }

    }
    public class ArticlesEtiquetteModel
    {
        [Required]
        public string barCode { get; set; }
        [Required]
        public string articleCinr { get; set; }
        [Required]
        public string articleCinv { get; set; }
        [Required]
        public string formatOfEtiquettes { get; set; }
        [Required]
        public string numberOfEtiquettes { get; set; }
        [Required]
        public string codeEtiquette { get; set; }
    }
}
