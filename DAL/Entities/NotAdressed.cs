using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class NotAdressed
    {
        public int Mag { get; set; }
        public string LibMag { get; set; }
        public long Code { get; set; }
        public string Gencode { get; set; }
        public string Libelle { get; set; }
        public string Dept { get; set; }
        public string Rayon { get; set; }
        public string Famille { get; set; }
        public string Sfamille { get; set; }
        public string Ssfamille { get; set; }
        public string Ub { get; set; }
    }
}
