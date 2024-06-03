using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_.DescendrePaletteRacksResponse
{
    public class AuthentificationDescendrePaletteRacksResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string MethodName { get; set; }
    }
    public class ContextDescendrePaletteRacksResponse
    {
        public string Classe { get; set; }
        public string Site { get; set; }
        public string MerchStructID { get; set; }
        public string CommercialNetworkID { get; set; }
        public string Language { get; set; }
    }
    public class ParametersDescendrePaletteRacksResponse
    {
        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public AuthentificationDescendrePaletteRacksResponse Authentification { get; set; }
        public ContextDescendrePaletteRacksResponse Context { get; set; }
    }
    public class SOAPENVHeaderDescendrePaletteRacksResponse
    {
        public ParametersDescendrePaletteRacksResponse Parameters { get; set; }
    }
    public class DescendrePaletteRacksResultDescendrePaletteRacksResponse
    {
        public string CintPalette { get; set; }
    }
    public class SOAPENVBodyDescendrePaletteRacksResponse
    {
        public DescendrePaletteRacksResultDescendrePaletteRacksResponse Response_PDARsvDescendrePaletteRacksMarj { get; set; }
    }
    public class SOAPENVEnvelopeDescendrePaletteRacksResponse
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
        public SOAPENVHeaderDescendrePaletteRacksResponse SOAPENVHeader { get; set; }

        [JsonProperty("SOAP-ENV:Body")]
        public SOAPENVBodyDescendrePaletteRacksResponse SOAPENVBody { get; set; }
    }
    public class GetDescendrePaletteRacksResponseDescendrePaletteRacksResponse
    {
        [JsonProperty("SOAP-ENV:Envelope")]
        public SOAPENVEnvelopeDescendrePaletteRacksResponse SOAPENVEnvelope { get; set; }
    }
}