using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Models.Helper
{
    public class FiltreInnovTouchDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? CodeFamilleProduit { get; set; }
        public string? CodeProduit { get; set; }
        public string? CodeMagasin { get; set; }
        public DateTime? DateInnovTouch { get; set; }
        public ActionProduit? ActionProduit { get; set; }

        public override string ToString()
        {
            return $"UserName:{UserName}, CodeFamilleProduit:{CodeFamilleProduit}, CodeProduit:{CodeProduit}, CodeMagasin:{CodeMagasin}, DateInnovTouch:{DateInnovTouch}";
        }
    }
}
