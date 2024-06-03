using AutoMapper;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Oracle.ManagedDataAccess.Client;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.ZonesEmplacements;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ZonesEmplacementsService : BaseService
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;
        public ZonesEmplacementsService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<Zone>>> ZonesEmplacements(ZonesEmplacementsModel model)
        {
            List<Zone> listOfZon = new List<Zone>();

            var Resulte = _IUnitOfWork.Zone.All().ToList();

            if (Resulte.Count() != 0)
            {
                var Responce = new Response<List<Zone>>();
                Responce.Succeeded = true;
                Responce.Errors = null;

                foreach (var item in Resulte)
                {
                    listOfZon.Add(new Zone()
                    {
                        code = item.code,
                        codeExt = item.codeExt,
                        desc = item.desc,
                        locationsAvailable = item.locationsAvailable
                    });
                }
                Responce.Data = listOfZon;
                return Responce;
            }
            else
            {
                return new Response<List<Zone>>();
            }
        }

        public async Task<Response<bool>> CheckEmplacement(string db_serveur, string db_username, string db_password, string numInventaire, string numEmplacement)
        {
            var response = new Response<bool>();
            response.Succeeded = true;
            response.Data = true;
            return await Task.FromResult(response);
        }
    }
}
