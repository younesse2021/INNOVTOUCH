using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ArticleInfo
    {
        public ArticleInfo()
        {
            ArticleInfoEan = new HashSet<ArticleInfoEan>();
            SubstitutionGroup = new HashSet<SubstitutionGroup>();
            WyndDisabledArticle = new HashSet<WyndDisabledArticle>();
            WyndDisabledArticleHistorique = new HashSet<WyndDisabledArticleHistorique>();
        }

        public long Codeart { get; set; }
        public string Ean { get; set; }
        public string Lblart { get; set; }
        public double Artdegr { get; set; }
        public string Onlin { get; set; }
        public string TypeArticle { get; set; }
        public int Dept { get; set; }
        public int Ray { get; set; }
        public int Fam { get; set; }
        public int Sfam { get; set; }
        public int? Ssfam { get; set; }
        public string Departement { get; set; }
        public string Rayon { get; set; }
        public string Famille { get; set; }
        public string Sfamille { get; set; }
        public string Ssfamille { get; set; }
        public string Ub { get; set; }
        public string BalancePiece { get; set; }
        public string BalancePoids { get; set; }
        public long? CodeArticlePere { get; set; }
        public string EanArticlePere { get; set; }
        public string LibelleArticlePere { get; set; }
        public int? CodePack { get; set; }
        public string LibellePack { get; set; }
        public double? CoeffPack { get; set; }
        public int? CodeUnite { get; set; }
        public string LibelleUnite { get; set; }
        public double? CoeffUnite { get; set; }
        public bool FlagIsActifEcom { get; set; }
        public decimal PvPerm { get; set; }
        public double Ttva { get; set; }
        public int Codeetat { get; set; }
        public string PluArticlePere { get; set; }
        public string Picture { get; set; }
        public long? CategoryNiv1Id { get; set; }
        public string CategoryNiv1Lib { get; set; }
        public long? CategoryNiv2Id { get; set; }
        public string CategoryNiv2Lib { get; set; }
        public long? CategoryNiv3Id { get; set; }
        public string CategoryNiv3Lib { get; set; }
        public long? WyndArticleId { get; set; }
        public string WyndArticleUuid { get; set; }
        public DateTime Dateupdate { get; set; }
        public string PluArticle { get; set; }
        public decimal? NewPrice { get; set; }
        public string PotAmount { get; set; }

        public virtual ICollection<ArticleInfoEan> ArticleInfoEan { get; set; }
        public virtual ICollection<SubstitutionGroup> SubstitutionGroup { get; set; }
        public virtual ICollection<WyndDisabledArticle> WyndDisabledArticle { get; set; }
        public virtual ICollection<WyndDisabledArticleHistorique> WyndDisabledArticleHistorique { get; set; }
    }
}
