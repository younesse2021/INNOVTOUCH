using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ReferenceClient
    {
        public ReferenceClient()
        {
            ReferenceClientAddress = new HashSet<ReferenceClientAddress>();
            ReferenceClientChild = new HashSet<ReferenceClientChild>();
        }

        public long Id { get; set; }
        public string Uuid { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? EntityId { get; set; }
        public string EntityUuid { get; set; }
        public long? OriginalEntityId { get; set; }
        public string OriginalEntityUuid { get; set; }
        public string Login { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string HonorificPrefix { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthdate { get; set; }
        public string Comments { get; set; }
        public bool? IsActive { get; set; }
        public string AttributeApplicationMobile { get; set; }
        public string AttributeLangueDePreference { get; set; }
        public string AttributeOptinEmail { get; set; }
        public string AttributeOptinPush { get; set; }
        public string AttributeOptinSms { get; set; }
        public string AttributeQuartier { get; set; }
        public string AttributeQuartierLabel { get; set; }
        public string AttributeVille { get; set; }
        public string AttributeVilleLabel { get; set; }
        public string AttributeMaxxingSynchroAt { get; set; }
        public string AttributeTelechargementApplicationMobile { get; set; }
        public string AttributeTypeCarte { get; set; }
        public bool? IsGuest { get; set; }
        public string ExternalId { get; set; }
        public string CreationChannel { get; set; }
        public string CustomerDivision { get; set; }
        public string VatNumber { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public bool? Default { get; set; }
        public string MaxxingLogin { get; set; }
        public string MaxxingCard { get; set; }
        public string MaxxingCustomerKey { get; set; }
        public string MaxxingAccountKey { get; set; }
        public string WafasalafId { get; set; }
        public long? Gender { get; set; }
        public long? MaxxingCustomerType { get; set; }
        public string Cohorts { get; set; }
        public string Addresses { get; set; }

        public virtual ICollection<ReferenceClientAddress> ReferenceClientAddress { get; set; }
        public virtual ICollection<ReferenceClientChild> ReferenceClientChild { get; set; }
    }
}
