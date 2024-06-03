using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ConnexionUser
    {
        public long Id { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Utilisateur { get; set; }
        public string Pays { get; set; }
        public string Appareil { get; set; }
        public string Platforme { get; set; }
        public string Navigateur { get; set; }
        public string AdresseIp { get; set; }
        public string Action { get; set; }
    }
}
