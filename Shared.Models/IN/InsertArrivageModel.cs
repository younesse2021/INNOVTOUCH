﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class InsertArrivageModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string NumeroArrivage { get; set; }
        [Required]
        public string NumeroImmatr { get; set; }
        [Required]
        public string paletteCode { get; set; }
        public List<ArticlesInsertArrivage> listeArticles { get; set; }
    }
}
