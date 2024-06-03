using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN.ReserveIn
{
    public class MajDetailPaletteModel
    {

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        public string CodeArticle { get; set; }
        public string LiblCaisseC { get; set; }
        public string LiblCaisseL { get; set; }
        public string Cinv { get; set; }
        public string Cinr { get; set; }
        public string Ustk { get; set; }
        public string PdsMoyen { get; set; }
        public string QteStock { get; set; }
        public string PdsStock { get; set; }
        public string QtePalette { get; set; }
        public string PdsPalette { get; set; }
        public string QteAjoute { get; set; }
        public string PdsAjoute { get; set; }
        public string QteRetire { get; set; }
        public string PdsRetire { get; set; }
        public string NewQtePalette { get; set; }
        public string NewPdsPalette { get; set; }

        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string Zone { get; set; }
        public string Emplacement { get; set; }
        public string EtatPalette { get; set; }
        public string NbArticles { get; set; }


    }




}
