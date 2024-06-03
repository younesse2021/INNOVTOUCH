using System.Collections.Generic;

public class CreerLotPreparationModel
{

    public string Username { get; set; }
    public string Password { get; set; }
    public string Site { get; set; }
    public string NumLot { get; set; }
    public ArticleListResseve Article { get; set; }
}
public class PalettesCreationModelList
{
    public List<PaletteListCreationLotModel> palettes { get; set; }
}
public class PaletteListCreationLotModel
{
    public string Palette { get; set; }
}
public class ArticleListResseve
{
    public PalettesCreationModelList DATA { get; set; }
    public string CodeArticle { get; set; }
    public string LiblCaisseC { get; set; }
    public string LiblCaisseL { get; set; }
    public string Cinv { get; set; }
    public string Cinr { get; set; }
    public string Ustk { get; set; }
    public string PdsMoyen { get; set; }
    public string QteStock { get; set; }
    public string PdsStock { get; set; }
    public string CinlPCB { get; set; }
    public string NbrUVCparPCB { get; set; }
    public string QteDemandeePCB { get; set; }
    public string QteDemandeeUVC { get; set; }
}