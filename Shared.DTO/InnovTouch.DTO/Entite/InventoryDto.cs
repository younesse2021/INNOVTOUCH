using Shared.DTO.InnovTouch.DTO.Inventaire;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Entite
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string stockPosition { get; set; }
        public string valorisationDate { get; set; } = "";
        public MagasinDto Magasin { get; set; }
        public RayoneDto? Rayone { get; set; }
        public ReserveMagasin Type { get; set; }
        [NotMapped]
        public int typeInventaire { get; set; }
        public int NumberEmplacement { get; set; } = 0;
        [NotMapped]
        public string TypeInv
        {
            get
            {
                if (Type == 0)
                    return "Reserve";
                else 
                    return "Magasin";
            }
        }

    }
    public enum ReserveMagasin
    {
        Reserve = 0,
        Magasin = 1
    }
    public class ZoneDto
    {
        public int Id { get; set; }
        public string codeExt { get; set; }
        public string desc { get; set; }
        public string code { get; set; }
        public string locationsAvailable { get; set; }
    }
    public class NumberDto
    {
        public string CdataSection { get; set; }
    }
    public class DescriptionDto
    {
        public string CdataSection { get; set; }
    }
    public class StockPositionDto
    {
        public string CdataSection { get; set; }
    }
    public class ValorisationDateDto
    {
        public string CdataSection { get; set; }
    }

}
