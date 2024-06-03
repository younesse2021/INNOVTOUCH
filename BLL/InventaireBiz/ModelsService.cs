using AutoMapper;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Shared.Models.IN;
using Shared.Models.OUT.ModelsUser;
using Shared.Models.REST;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ModelsService : BaseService
    {


        private readonly IUnitOfWork _IUnitOfWork;
         private readonly IMapper _mapper;

        public ModelsService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = iUnitOfWork;
             _mapper = mapper;
        }

        public async Task<Response<List<ITEM>>> Models(ModelsUserModel model)
        {
            try
            {
                var Response = new Response<List<ITEM>>();

                var Items =  new List<ITEM>()
                {
                   new ITEM()
                   {
                       IDENT = "1008",
                       LABEL = new LABEL()
                       {
                           CdataSection = "InnovTouch"
                       },
                       FUNCTION = "",
                       PARENT = ""
                   } 
                };

                Response.Succeeded = true;
                Response.Message = "";
                Response.Data = Items;
                return Response;

            }
            catch (Exception ex)
            {
                return new Response<List<ITEM>>("Résultats non trouvées.");
            }
        }
    }
}
