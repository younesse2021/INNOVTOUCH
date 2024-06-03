using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Reflection;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace API.Controllers.Helper
{
    public class ExportService : IExportService
    {
        private readonly ILogger<ExportService> _logger;
        public ExportService(ILogger<ExportService> logger)
        {
            _logger = logger;
            _logger.LogInformation("ExportService(...)");
        }
        public byte[] ExportListToExcel(IQueryable query, string[] columns)
        {
            _logger.LogInformation($"ExportListToExcel(colomns:{columns})");
            // Create a new workbook and sheet
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            // Create headers
            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < columns.Count(); i++)
            {
                headerRow.CreateCell(i).SetCellValue(columns[i]);
            }

            //Get the properties from the query
            var columnsClass = GetProperties(query.ElementType);

            // Add data to rows
            var j = 0;
            foreach (var item in query)
            {
                j++;
                IRow dataRow = sheet.CreateRow(j);
                var colIndx = 0;
                foreach (var column in columnsClass)
                {
                    var value = GetValue(item, column.Key);
                    dataRow.CreateCell(colIndx).SetCellValue(Convert.ToString(value));
                    colIndx++;
                }
            }
            // Convert workbook to a byte array
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                return stream.ToArray();
            }
        }
        private static IEnumerable<KeyValuePair<string, Type>> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && IsSimpleType(p.PropertyType)).Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
        }
        private static bool IsSimpleType(Type type)
        {
            var underlyingType = type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                Nullable.GetUnderlyingType(type) : type;

            var typeCode = Type.GetTypeCode(underlyingType);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.String:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }
        private static object GetValue(object target, string name)
        {
            return target.GetType().GetProperty(name).GetValue(target);
        }
    }
}
