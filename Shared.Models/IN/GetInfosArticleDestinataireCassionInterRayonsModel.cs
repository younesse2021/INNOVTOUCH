using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class GetInfosArticleDestinataireCassionInterRayonsModel
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
        public string code_dest { get; set; }
        [Required]
        public string artcomp { get; set; }
    }
}
