using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN
{
    public class FacingUpdateInfosArticleModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }
        [Required]
        public string cinv { get; set; }
        [Required]
        public string facing { get; set; }
        [Required]
        public string contenance { get; set; }
        [Required]
        public string nivdef { get; set; }
        [Required]
        public string stock { get; set; }
    }
}
