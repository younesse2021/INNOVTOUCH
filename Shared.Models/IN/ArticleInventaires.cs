﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{

    public class ArticleInventaire
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string ean { get; set; }
        [Required]
        public string inventaire { get; set; }
        [Required]
        public string type { get; set; }
    }
}