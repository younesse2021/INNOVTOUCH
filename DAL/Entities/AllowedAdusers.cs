using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class AllowedAdusers
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreation { get; set; }
        public bool IsPowerBiAllowed { get; set; }
        public bool? IsHistoriqueUsersAllowed { get; set; }
        public bool? IsLivraisonAllowed { get; set; }
        public bool? IsMissionAllowed { get; set; }
    }
}
