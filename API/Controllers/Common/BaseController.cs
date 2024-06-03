using API.Filters;
using Aspose.Pdf;
using Microsoft.AspNetCore.Mvc;
using NetBarcode;
using Shared.Models.IN;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace API.Controllers
{
    [ApiKey]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string CurrentBaseUrl => $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";


        public static string GenerateTicketCasseFrais(ArticleTicketCasseFraisModel model)
        {
            var tmp_path_barcode = Path.Combine(Path.GetTempPath(), $"codebar-{model.ean}-{DateTime.Now.Ticks}.jpg");

            #region Generate BarCode EAN13
            var barcode = new Barcode(model.ean, NetBarcode.Type.EAN13, false, 250, 80);
            barcode.SaveImageFile(tmp_path_barcode, ImageFormat.Jpeg);
            #endregion

            var filename = $"ticket-cassefrais-{model.ean}-{DateTime.Now.Ticks}.pdf";
            var tmp_path_ticket = Path.Combine(Path.GetTempPath(), filename);

            #region Generate Ticket Casse & Frais
            Document document = new Document();
            Page page = document.Pages.Add();
            page.SetPageSize(250, 150);
            int lowerLeftX = 50;
            int lowerLeftY = 0;
            int upperRightX = 200;
            int upperRightY = 200;
            page.AddImage(tmp_path_barcode, new Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY));

            var textean = new Aspose.Pdf.TextStamp(model.ean)
            {
                Background = false,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TopMargin = 20,
                TextAlignment = Aspose.Pdf.HorizontalAlignment.Center
            };
            page.AddStamp(textean);
            var textlibelle = new Aspose.Pdf.TextStamp(model.libelle)
            {
                Background = false,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TopMargin = 50,
                TextAlignment = Aspose.Pdf.HorizontalAlignment.Center
            };
            page.AddStamp(textlibelle);
            var textPrices = new Aspose.Pdf.TextStamp(model.old_prix + " au lieu de " +  model.new_prix)
            {
                Background = false,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                TopMargin = 80
            };
            page.AddStamp(textPrices);
            page.AddStamp(textlibelle);
            var textDate_edition = new Aspose.Pdf.TextStamp("Edite le " + model.date_edition)
            {
                Background = false,
                HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = Aspose.Pdf.HorizontalAlignment.Center,
                TopMargin = 110
            };
            page.AddStamp(textDate_edition);
            #endregion

            document.Save(tmp_path_ticket);

            return filename;
        }
    }
}
