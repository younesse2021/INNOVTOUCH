using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN.ReserveModel
{
   public class GetArticlePaletteModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string ArticleCode { get; set; }
    }
}
