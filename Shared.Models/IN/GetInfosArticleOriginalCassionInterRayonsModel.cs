using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class GetInfosArticleOriginalCassionInterRayonsModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string code_orig { get; set; }
        [Required]
        public string site_gere_en_stock { get; set; }
    }
}
