using Shared.DTO.InnovTouch.DTO.Entite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Inventaire
{
    internal class InventoryDto
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string description { get; set; }
        public string stockPosition { get; set; }
        public string valorisationDate { get; set; }
        public MagasinDto Magasin { get; set; }
    }

}
