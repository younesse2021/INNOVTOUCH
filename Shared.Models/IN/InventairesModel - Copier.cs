using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{
   public class InventairesModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public int IdInventaire { get; set; }
        public int IdRayone  { get; set; }
        public string?  NomEmplacement  { get; set; }
        public int? TypeInventaire { get; set; }
    }
}
