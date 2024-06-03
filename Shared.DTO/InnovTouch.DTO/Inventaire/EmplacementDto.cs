using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Inventaire
{
    public class EmplacementDto
    {
        public int Id { get; set; }
        public InventoryDTO Inventory { get; set; }
        public RayoneDto  Rayone { get; set; }
        public int TypeInventaire { get; set; }
        public int NumberEmplacement { get; set; }
    }

    public class EmplacementDetails
    {
        public int Id { get; set; }
        public InventoryDTO Inventory { get; set; }
        public RayoneDto Rayone { get; set; }
        public int TypeInventaire { get; set; }
        public int NumberEmplacement { get; set; }
        public string DisplayInventaire { get { if (TypeInventaire == 0) return "Reserve"; else return "Magasin"; } }
    }
    public class Inventory
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

    public class Rayone
    {
        public int Id { get; set; }
        public int IdRayone { get; set; }
        public string Name { get; set; }
    }
}
