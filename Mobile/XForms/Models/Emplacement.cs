using System;
using System.Collections.Generic;
using System.Text;

namespace XForms.Models
{
    public class Emplacement
    {
        public int Id { get; set; }
        public Inventory Inventory { get; set; }
        public Rayone Rayone { get; set; }
        public int TypeInventaire { get; set; }
        public int NumberEmplacement { get; set; }
        public string TypeInv
        {
            get
            {
                if (Inventory.stockPosition == "102")
                    return "Tournant";
                else return "Generale";
            }
        }
    }

    public class Inventory
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string stockPosition { get; set; }
        public string valorisationDate { get; set; } = "";
        public string typeInventaire { get; set; }
    }
}
