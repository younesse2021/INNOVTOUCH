using Shared.DTO.InnovTouch.DTO.Produit;
using Shared.DTO.InnovTouch.DTO.Role;
using System.Collections.Generic;
namespace Shared.DTO.InnovTouch.DTO.Entite
{
    public class MagasinDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Libelle { get; set; }
        public string? Adresse { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? RC { get; set; }
        public string? Patente { get; set; }
        public string? IF { get; set; }
        public string? CNSS { get; set; }
    }
}
