using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Bo
{
    public class UtilisateurBoDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string[]? Enseigne { get; set; }
        public string[]? Magasins { get; set; }
        public string[]? Departements { get; set; }
        public string[]? Rayons { get; set; }
        public string? EnseigneId { get; set; }
        public JwtToken? Token { get; set; }
        public bool? isConnected { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(UserName)}={UserName}, {nameof(Enseigne)}={Enseigne}, {nameof(Magasins)}={Magasins}, {nameof(Departements)}={Departements}, {nameof(Rayons)}={Rayons}, {nameof(EnseigneId)}={EnseigneId}, {nameof(Token)}={Token}, {nameof(isConnected)}={isConnected.ToString()}}}";
        }
    }
}
