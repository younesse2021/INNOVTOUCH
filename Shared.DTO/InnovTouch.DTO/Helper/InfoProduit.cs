using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Helper
{
    public class InfoProduit
    {
        public int Id { get; set; }
        public string  CodeBarre { get; set; }
        public int Qantite { get; set; }
        public DateTime Date { get; set; }
    }
}
