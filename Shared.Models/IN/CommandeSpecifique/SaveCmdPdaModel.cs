using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models.IN.CommandeSpecifique
{
   public class SaveCmdPdaModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string site { get; set; }

        public ArticleCmdSpe article { get; set; }

    }
    public class ArticleCmdSpe
    {
        public string nolot { get; set; }
        public string cinr { get; set; }
        public string cinl { get; set; }
        public string orderable { get; set; }
        public string label { get; set; }
        public string nCmd { get; set; }
        public string existCmd { get; set; }
        public string existInLot { get; set; }
        public string stockNormal { get; set; }
        public string stonbrjour { get; set; }
        public string encoursCmd { get; set; }
        public string encoursjour { get; set; }
        public string stockEntrepot { get; set; }
        public string moyhebvte { get; set; }
        public string vtedersem { get; set; }
        public string qteProposee { get; set; }
        public string cinv { get; set; }
        public string etat { get; set; }
        public string etatlibl { get; set; }
        public string orderableUnit { get; set; }
        public string orderableUnitLabel { get; set; }
        public string UAUVC { get; set; }
        public string SEQVL { get; set; }
        public string EAN { get; set; }

        public string refreshFunction { get; set; }

    }
}