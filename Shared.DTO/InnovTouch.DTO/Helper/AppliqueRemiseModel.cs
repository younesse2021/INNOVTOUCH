using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Helper
{
    public class AppliqueRemiseModel
    {
        public InnovTouchProduitDto Produit { get; set; }
        public RemisePourcentage Remise { get; set; }
        public int Qantity { get; set; }
        public double Montont { get; set; }
        public string? NumberOfTicket { get; set; }
    }
}
