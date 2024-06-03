using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.CheckPaletteResponse
{
    public class AuthentificationCheckPaletteResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextCheckPaletteResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersCheckPaletteResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationCheckPaletteResponse Authentification { get; set; }
        public ContextCheckPaletteResponse Context { get; set; }
    }
    public class SOAPENVHeaderCheckPaletteResponse
    {
        public ParametersCheckPaletteResponse Parameters { get; set; }
    }
    public class CheckPaletteResponseCheckPaletteResponse
    {
        public string NumPalette { get; set; }
        public string CintPalette { get; set; }
        public string Zone { get; set; }
        public string Emplacement { get; set; }
        public string EtatPalette { get; set; }
        public string NbArticles { get; set; }
    }
    public class InfoPaletteResponse
    {
        public CheckPaletteResponseCheckPaletteResponse InfoPalette { get; set; }
    }


    public class SOAPENVBodyCheckPaletteResponse
    {
        public InfoPaletteResponse Response_PDARsvCheckNumPalettExistantMarj { get; set; }


    }
    public class SOAPENVEnvelopeCheckPaletteResponse
    {
        [JsonProperty("@xmlns:soapenv")]
        public string XmlnsSoapenv { get; set; }

        [JsonProperty("@xmlns:xsd")]
        public string XmlnsXsd { get; set; }

        [JsonProperty("@xmlns:xsi")]
        public string XmlnsXsi { get; set; }

        [JsonProperty("@xmlns:SOAP-ENV")]
        public string XmlnsSOAPENV { get; set; }

        [JsonProperty("SOAP-ENV:Header")]
        public SOAPENVHeaderCheckPaletteResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyCheckPaletteResponse SOAPENVBody { get; set; }
    }
    public class CheckExistPaletteResponseCheckPaletteResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeCheckPaletteResponse SOAPENVEnvelope { get; set; }
    }
}