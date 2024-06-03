using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class ArticleByEANDemarqueModel
    {
        [Required]
        public string type_demarque { get; set; }
        [Required]
        public string ean { get; set; }
        [Required]
        public string username { get; set; }
    }
}
