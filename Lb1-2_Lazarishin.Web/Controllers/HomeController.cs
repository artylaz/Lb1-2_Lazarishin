using Lb1_2_Lazarishin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Lb1_2_Lazarishin.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFileCollection excelFiles)
        {
            if (excelFiles == null || excelFiles.Count == 0)
                return View();

            var indexVM = GetIndexVmAsync(new IndexVM(), excelFiles);

            if (indexVM != null)
            {
                indexVM.Status = Status.Excel;
                return View(indexVM);
            }
            else
                return View();
        }
        /// <summary>
        /// </summary>
        /// <param name="indexVM"></param>
        /// <param name="excelFiles"></param>
        /// <returns>Возвращает заполненную ViewModel данными из внесенных excel файлов</returns>
        public IndexVM GetIndexVmAsync(IndexVM indexVM, IFormFileCollection excelFiles)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (excelFiles == null || excelFiles.Count == 0)
                return null;

            indexVM.Questionnaires = new List<Questionnaire>();

            foreach (var excelFile in excelFiles)
            {
                string fileExtension = Path.GetExtension(excelFile.FileName);

                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    return null;

                using ExcelPackage p = new(excelFile.OpenReadStream());
                ExcelWorksheet workSheet = p.Workbook.Worksheets[0];

                var questionnaire = new Questionnaire { PersonName = workSheet.Cells[1, 2].Value.ToString() };

                int totalRows = workSheet.Dimension.Rows;
                for (int i = 2; i <= totalRows; i++)
                {
                    var value = workSheet.Cells[i, 2].Value.ToString().Replace(".", ",");
                    questionnaire.ValuesToString.Add(value);
                }

                indexVM.Questionnaires.Add(questionnaire);
            }
            return indexVM;
        }

    }
}