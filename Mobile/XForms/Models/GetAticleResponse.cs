using System;
using System.Collections.Generic;
using System.Text;

namespace XForms.Models
{
    public class GetAticleResult
    {
        public object Palette { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string USTK { get; set; }
        public string TypeUA { get; set; }
        public string UVCUA { get; set; }
        public string CINR { get; set; }
        public string SEQVL { get; set; }
        public string CEXR { get; set; }
        public string CINV { get; set; }
        public string CEXV { get; set; }
        public string QTEEXP { get; set; }
        public object Message { get; set; }
        public object Exception { get; set; }
    }
}
