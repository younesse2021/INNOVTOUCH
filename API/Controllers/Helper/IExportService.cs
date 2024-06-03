using System.Linq;

namespace API.Controllers.Helper
{
    public interface IExportService
    {
        public byte[] ExportListToExcel(IQueryable query, string[] columns);

    }
}
