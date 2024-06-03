using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
    public class ArticleByEANDemarqueResponse
    {
        public string EAN { get; set; }
        public int? CODEINT { get; set; }
        public string DEPARTEMENT { get; set; }
        public string RAYON { get; set; }
        public string FAMILLE { get; set; }
        public string SOUSFAMILLE { get; set; }
        public string LIBELLE { get; set; }
    }
}
