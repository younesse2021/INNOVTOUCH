using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class InventoryDataModel
    {
        public List<InventoryModel> Inventory { get; set; }
    }

    public partial class InventoryModel
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string stockPosition { get; set; }
        public string valorisationDate { get; set; } = "";
        public Magasin Magasin { get; set; }
        public Rayone Rayone { get; set; }
        public ReserveMagasin Type { get; set; }

        [NotMapped]
        public int typeInventaire { get; set; }
        public int NumberEmplacement { get; set; } = 0;
    }


    public enum ReserveMagasin
    {
        Reserve = 0,
        Magasin = 1
    }



    public class Rayone
    {
        public int Id { get; set; }
        public int IdRayone { get; set; }
        public string Name { get; set; }
    }
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
