using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.InnovTouch.DTO.Role
{
    public class DroitDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; 
        public string Libelle { get; set; } = string.Empty;
        public List<ProfileDto>? Profiles { get; set; }
    }
}
