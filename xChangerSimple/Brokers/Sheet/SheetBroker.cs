using OfficeOpenXml;
using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Brokers.Sheet
{
    public class SheetBroker : ISheetBroker
    {
        public List<ExternalTalaba> ImportTalabalar(MemoryStream memoryStream)
        {
            List<ExternalTalaba> externalTalabalar = new List<ExternalTalaba>();

            using (ExcelPackage package = new ExcelPackage(memoryStream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= excelWorksheet.Dimension.End.Row; row++)
                {
                    ExternalTalaba externalTalaba = new ExternalTalaba();
                    externalTalaba.ID= Guid.NewGuid();
                    externalTalaba.FirstName = excelWorksheet.Cells[row, 1].Value?.ToString();
                    externalTalaba.LastName = excelWorksheet.Cells[row, 2].Value?.ToString();
                    externalTalaba.Age = excelWorksheet.Cells[row, 3].Value?.ToString();
                    externalTalaba.Secialty = excelWorksheet.Cells[row, 4].Value.ToString();
                    externalTalaba.Experience = excelWorksheet.Cells[row, 5].Value.ToString();

                    externalTalabalar.Add(externalTalaba);
                }
                return externalTalabalar;
            }
        }
    }
}
