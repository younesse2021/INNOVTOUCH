using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XForms.Models
{
    public class FacingRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string barCode { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FacingResponse
    {
        public string barCode { get; set; }
        public string articleLabel { get; set; }
        public string linearFacing { get; set; }
        public string linearCapacity { get; set; }
        public string logisticUnitType { get; set; }
        public string logisticUnitTypeDescription { get; set; }
        public string uvcUa { get; set; }
        public string merchandiseMaintCapac { get; set; }
        public string merchandiseMaintFacing { get; set; }
        public string stockPresentation { get; set; }
        public string replenishmentMaintenanceMode { get; set; }
        public string replenishmentMaintenanceType { get; set; }
        public string classe { get; set; }
        public string replenishmentMode { get; set; }
        public string cinv { get; set; }
        public string etat { get; set; }
        public string descetat { get; set; }
        public string niveauDefinition { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UpdateFacingRequest : BindableObject
    {
        public string username { get; set; }
        public string password { get; set; }
        public string site { get; set; }
        public string cinv { get; set; }
        public string facing { get; set; }
        public string contenance { get; set; }
        public string nivdef { get; set; }
        public string stock { get; set; }
    }


}
