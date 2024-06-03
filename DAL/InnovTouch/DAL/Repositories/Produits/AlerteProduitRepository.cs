﻿using DAL.InnovTouch.DOMAIN.IRepositories.Produits;
using DAL.InnovTouch.DOMAIN.Models.Produits;
using Ma.Marjane.RPC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InnovTouch.DAL.Repositories.Produits
{
    public class AlerteProduitRepository : RepositoryBase<AlerteProduit>, IAlerteProduitRepository
    {
        public AlerteProduitRepository(InnovTouchDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
