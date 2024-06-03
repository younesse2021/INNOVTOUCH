using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class TraceKaalixApi
    {
        public string Uuid { get; set; }
        public string Reference { get; set; }
        public string Response { get; set; }
        public bool IsSuccessCreatedUpdated { get; set; }
        public bool IsSuccessCanceled { get; set; }
        public string CodeResponse { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
