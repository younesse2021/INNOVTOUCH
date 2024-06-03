using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XForms.Models
{
    public partial class CommandeSpecifiqueModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }

        [JsonProperty("nolot")]
        public string nolot { get; set; }
        [JsonProperty("CINV")]
        public string CINV { get; set; }

        [JsonProperty("MODE")]
        public string MODE { get; set; }
        [JsonProperty("NLOT")]
        public string NLOT { get; set; }

    }

    public partial class GeetListLotResponseData
    {
        public List<CommandeSpecifiqueResponses> lot { get; set; }
    }
    public partial class GeetLotData
    {
        public GeetListLotResponseData DATA { get; set; }
    }
    public partial class SaveLotPdaResponseData
    {
        public object DATA { get; set; }
    }
    public partial class CommandeSpecifiqueResponses
    {
        public string MSG1 { get; set; }
        public string MSG2 { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }

        [JsonProperty("nolot")]
        public string nolot { get; set; }

        [JsonProperty("liblot")]
        public string liblot { get; set; }
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
    public class ArticleCommandeSpecifiqueResponse
    {
        public CommandeSpecifiqueResponses article { get; set; }


        [JsonProperty("nolot")]
        public string nolot { get; set; }

        [JsonProperty("liblot")]
        public string liblot { get; set; }
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

        

        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
    }

    public partial class CommandeSpecifiqueResponsesData
    {
        [JsonProperty("lot")]
        public CommandeSpecifiqueResponses lot { get; set; }
    }
    public partial class CommandeSpecifiqueDataModel
    {
        [JsonProperty("data")]
        public CommandeSpecifiqueResponses DATA { get; set; }
    }
    public partial class ArticleCommandeSpcecifiqueModel
    {
        public CommandeSpecifiqueResponses article { get; set; }
    }
    public partial class CartCmdSpecifiqueArticle : BindableObject
    {
        [JsonProperty("orderableUnitLabel")]
        public string orderableUnitLabel { get; set; }
        [JsonProperty("UAUVC")]
        public string UAUVC { get; set; }
        public string Quantiteacommande { get; set; }
        public string label { get; set; }
        public string EAN { get; set; }
        
    }

}

