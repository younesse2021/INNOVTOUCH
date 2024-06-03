using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN.ReserveModel
{
    public class GetContenuPaletteModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Site { get; set; }
        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string Zone { get; set; }
        public string Emplacement { get; set; }
        public string EtatPalette { get; set; }
        public string NbArticles { get; set; }
    }
}