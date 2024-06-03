using Shared.DTO.InnovTouch.DTO.Produit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Entite
{
    public class FiltreDto
    {
        public EnseigneDto? Enseigne { get; set; }
        public string? Magasin { get; set; }
        public string? Departement { get; set; }
        public string? Rayon { get; set; }
        public FamilleProduitDto? FamilleProduit { get; set; }
        public ProduitDto? Produit { get; set; }
        public DateTime? DateDu { get; set; }
        public DateTime? DateAu { get; set; }

        //Cache des listes pour éviter l'aller au serveur chaque fois qu'on ouvre le popup du filtre
        public IEnumerable<EnseigneDto>? Enseignes { get; set; }
        public IEnumerable<FamilleProduitDto>? FamilleProduits { get; set; }
        public IEnumerable<ProduitDto>? Produits { get; set; }
        public IEnumerable<string>? Magasins { get; set; }
        public IEnumerable<string>? Departements { get; set; }
        public IEnumerable<string>? Rayons { get; set; }

        //Activer les champs filtre
        public bool? IsEnseigneVisible { get; set; } = false;
        public bool? IsMagasinVisible { get; set; } = false;
        public bool? IsDepartementVisible { get; set; } = false;
        public bool? IsRayonVisible { get; set; } = false;
        public bool? IsFamilleProduitVisible { get; set; } = false;
        public bool? IsProduitVisible { get; set; } = false;
        public bool? IsDateDuVisible { get; set; } = false;
        public bool? IsDateAuVisible { get; set; } = false;

        //Activer les champs filtre
        public bool? IsEnseigneDisabled { get; set; } = false;
        public bool? IsMagasinDisabled { get; set; } = false;
        public bool? IsDepartementDisabled { get; set; } = false;
        public bool? IsRayonDisabled { get; set; } = false;

        public override string ToString()
        {
            return $"{{{nameof(Enseigne)}={Enseigne}, {nameof(FamilleProduit)}={FamilleProduit}, {nameof(Produit)}={Produit}, {nameof(DateDu)}={DateDu.ToString()}, {nameof(DateAu)}={DateAu.ToString()}}}";
        }
    }
}
