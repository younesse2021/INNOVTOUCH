using DAL.InnovTouch.DOMAIN.Models.Inventaire;
using Shared.DTO.InnovTouch.DTO.Entite;
using Shared.DTO.InnovTouch.DTO.Inventaire;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contrat
{
    public interface IEmplacementService
    {
        Response<int> CreateEmplacement(EmplacementDto model);
    }
}
