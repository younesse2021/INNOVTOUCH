using Shared.Models.OUT.ArticleByEAN;
using Shared.Models.OUT_.Stock;
using Shared.Models.OUT_.Vente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
    public class InfosArticleByEANResponse
    {
        public ArticleByEAN InfoArticle { get; set; }
        public InfoStock InfoStock { get; set; }
        public InfoVente InfoVente { get; set; }
    }
}
