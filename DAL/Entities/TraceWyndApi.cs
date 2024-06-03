using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class TraceWyndApi
    {
        public long Id { get; set; }
        public DateTime DateOperation { get; set; }
        public string Url { get; set; }
        public string Env { get; set; }
        public string Username { get; set; }
        public string PhoneId { get; set; }
        public string AppVersion { get; set; }
        public string InputPayload { get; set; }
        public string OutputPayload { get; set; }
        public string Method { get; set; }
        public double? CallDuration { get; set; }
    }
}
