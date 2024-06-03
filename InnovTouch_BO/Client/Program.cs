using Blazored.SessionStorage;
using BlazorFileSaver;
using BlazorSpinner;
using DLC_BO.Client.Service.Entite;
using DLC_BO.Client.Service.Produits;
using DLC_BO.Client.Service.Role;
using InnovTouch_BO.Client;
using InnovTouch_BO.Client.Models;
using InnovTouch_BO.Client.Service;
using InnovTouch_BO.Client.Service.Bo;
using InnovTouch_BO.Client.Service.DetailsLotService;
using InnovTouch_BO.Client.Service.Emplacement;
using InnovTouch_BO.Client.Service.Inventaires;
using InnovTouch_BO.Client.Service.Magasin;
using InnovTouch_BO.Client.Service.Produits;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
    var baseUri1 = builder.HostEnvironment.BaseAddress;
    var httpClient = new HttpClient();
    var baseUri = await httpClient.GetStringAsync($"{baseUri1}apiUrl.txt");

    builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(baseUri)
    });

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<SpinnerService>();

    builder.Services.AddSingleton<AppStateContainer>();
    builder.Services.AddBlazoredSessionStorageAsSingleton();

    builder.Services.AddScoped<UtilisateurBoService>();
    builder.Services.AddScoped<UtilisateurService>();
    builder.Services.AddScoped<ProfileService>();

    builder.Services.AddScoped<EnseigneService>();
    builder.Services.AddScoped<MagasinService>();
    builder.Services.AddScoped<AddInventaireService>();
    builder.Services.AddScoped<MultyDataForm>();

    builder.Services.AddScoped<AlerteProduitService>();
    builder.Services.AddScoped<DlcProduitService>();
    builder.Services.AddScoped<FamilleProduitService>();
    builder.Services.AddScoped<ProduitService>();
    builder.Services.AddScoped<InventaireService>();
    builder.Services.AddScoped<RayoneService>();
    builder.Services.AddScoped<EmplacementService>();
    builder.Services.AddScoped<DetailLotService>();

    builder.Services.AddBlazorFileSaver();

    await builder.Build().RunAsync();
}
catch (Exception ex)
{
	throw;
}

