using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ReferenceClientChild
    {
        public long ReferenceClientId { get; set; }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public long? Gender { get; set; }
        public long? MaxxingChildrenId { get; set; }

        public virtual ReferenceClient ReferenceClient { get; set; }
    }
}
