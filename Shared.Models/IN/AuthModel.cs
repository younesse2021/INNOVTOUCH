using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class AuthModel
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }
}
