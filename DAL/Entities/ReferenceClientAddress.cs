using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ReferenceClientAddress
    {
        public long ReferenceClientId { get; set; }
        public long Id { get; set; }
        public string Uuid { get; set; }
        public string AddressInline { get; set; }
        public string EntranceCode { get; set; }
        public string Floor { get; set; }
        public string Door { get; set; }
        public string Complement { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public long? CountryId { get; set; }
        public string CountryUuid { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string DefaultLabel { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string HonorificPrefix { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string District { get; set; }
        public string VatNumber { get; set; }
        public string CompanyName { get; set; }

        public virtual ReferenceClient ReferenceClient { get; set; }
    }
}
