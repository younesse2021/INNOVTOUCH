using DAL.InnovTouch.DOMAIN.Models.Produits;
using DAL.InnovTouch.DOMAIN.Models.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.InnovTouch.DOMAIN.Models.Entite
{
    [Table("En_Magasin")]
    public class Magasin
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string RC { get; set; }
        public string Patente { get; set; }
        public string IF { get; set; }
        public string CNSS { get; set; }
    }
}
