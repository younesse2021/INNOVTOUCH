using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{
    public class ImprimerEtiquetteModel
    {
        public long lot { get; set; }
        public long site { get; set; }
        public long format_type { get; set; }
    }
}
