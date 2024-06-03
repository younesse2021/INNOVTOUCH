using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN.CommandeSpecifique
{
    public class GWSInfoCmdPdaModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string CINV { get; set; }
        [Required]
        public string MODE { get; set; }
        [Required]
        public string NLOT { get; set; }
    }
}
