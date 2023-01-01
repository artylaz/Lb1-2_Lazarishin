using Lb1_2_Lazarishin.TaxonLibrary;
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

        [HttpGet]
        public IActionResult Normalization(IndexVM indexVM)
        {
            //Преобразуем лист<string> в лист<double>
            indexVM = GetValuesDoouble(indexVM);
            if (indexVM == null)
                return View();

            //Находим минимальные и максимальные значения для каждой строки
            //var (minValues, maxValues) = GetMinMaxValues(indexVM);

            //Нормализация
            for (int i = 0; i < indexVM.Rows.Count; i++)
            {
                for (int j = 0; j < indexVM.Questionnaires.Count; j++)
                {
                    var result = (indexVM.Questionnaires[j].Values[i] - indexVM.Rows[i].MinValueRow) / (indexVM.Rows[i].MaxValueRow - indexVM.Rows[i].MinValueRow);

                    if (double.IsNaN(result))
                        indexVM.Questionnaires[j].Values[i] = 0;
                    else
                    {
                        if (result % 1 == 0)
                            indexVM.Questionnaires[j].Values[i] = result;
                        else
                            indexVM.Questionnaires[j].Values[i] = Math.Round(result, 2);
                    }
                }
            }

            // Говрим о том, что мы нормализировали данные
            indexVM.Status = Status.Normalization;

            return View(indexVM);
        }

        [HttpGet]
        public IActionResult TaxonView(IndexVM indexVM)
        {
            var vectors = new List<Vector>();

            foreach (var item in indexVM.Questionnaires)
            {
                vectors.Add(new Vector { Name = item.PersonName, Values = item.Values });
            }

            var taxa = Calculation.FindTaxa(vectors, indexVM.R);

            var taxonVM = new TaxonVM(taxa);
            return View(taxonVM);
        }

        /// <summary>
        /// Преобразует значения Questionnaires из string в double и заполнятет IndexVM.Questionnaires новыми значениями
        /// </summary>
        /// <param name="indexVM"></param>
        /// <returns></returns>
        public IndexVM GetValuesDoouble(IndexVM indexVM)
        {
            for (int i = 0; i < indexVM.Rows.Count; i++)
            {
                for (int j = 0; j < indexVM.Questionnaires.Count; j++)
                {
                    if (indexVM.Questionnaires[j].ValuesToString[i].Replace(" ", "") == "да")
                        indexVM.Questionnaires[j].ValuesToString[i] = "1";
                    else if (indexVM.Questionnaires[j].ValuesToString[i].Replace(" ", "") == "нет")
                        indexVM.Questionnaires[j].ValuesToString[i] = "0";

                    var valueStr = indexVM.Questionnaires[j].ValuesToString[i];

                    if (double.TryParse(valueStr, out double value))
                        indexVM.Questionnaires[j].Values.Add(value);
                }
            }

            return indexVM;
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

        ///// <summary>
        ///// Находить для каждого ряда минимальное и максимальное значение
        ///// </summary>
        ///// <param name="questionnaires"></param>
        ///// <returns>Возвращает кортеж с листом максимальных и минимальных значений для каждого ряда значений</returns>
        //public (List<double> minValues, List<double> maxValues) GetMinMaxValues(IndexVM indexVM)
        //{
        //    var minValues = new List<double>();
        //    var maxValues = new List<double>();

        //    for (int i = 0; i < indexVM.Rows.Count; i++)
        //    {
        //        double min = -1; // Для присваивания самого первого числа
        //        double max = 0;
        //        for (int j = 0; j < indexVM.Questionnaires.Count; j++)
        //        {
        //            if (min == -1)
        //                min = indexVM.Questionnaires[j].Values[i];
        //            else if (indexVM.Questionnaires[j].Values[i] < min)
        //                min = indexVM.Questionnaires[j].Values[i];

        //            if (indexVM.Questionnaires[j].Values[i] > max)
        //                max = indexVM.Questionnaires[j].Values[i];
        //        }
        //        minValues.Add(min);
        //        maxValues.Add(max);
        //    }

        //    return (minValues, maxValues);
        //}

    }
}