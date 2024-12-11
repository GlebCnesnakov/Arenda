using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

namespace Documents
{
    /// <summary>
    /// Логика взаимодействия для PremisesUserControl.xaml
    /// </summary>
    public partial class PremisesUserControl : UserControl
    {
        List<Premises> premises;
        public PremisesUserControl()
        {
            InitializeComponent();
            var districts = Data.GetDistricts();
            districtsComboBox.ItemsSource = districts;
            if (districts != null) viewButton.IsEnabled = true;
        }
        private void ButtonClickView(object sender, RoutedEventArgs e)
        {
            exportButton.Visibility = Visibility.Visible;
            dataGrid.IsEnabled = true;
            premises = Data.GetPremises(districtsComboBox.SelectedItem as District);
            dataGrid.ItemsSource = premises;
            if (premises != null) { dataGrid.IsEnabled = true; exportButton.IsEnabled = true; }
        }
        private void districtsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) => exportButton.IsEnabled = true;
        private void ButtonClickExport(object sender, RoutedEventArgs e)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @$"..\..\..\..\Выходные документы", $"Premises_{Guid.NewGuid()}.xlsx");
            ExportPremisesToExcel(filePath, premises);
            MessageBox.Show("Файл добавлен на рабочий стол");
        }
        public static void ExportPremisesToExcel(string filePath, List<Premises> premisesList)
        {
            // Создаем новый Excel-файл
            using (var spreadsheetDocument = SpreadsheetDocument.Create(filePath, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                // Создаем рабочую книгу
                var workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Создаем рабочий лист
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Добавляем лист в книгу
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Premises"
                };
                sheets.Append(sheet);

                // Получаем SheetData для добавления данных
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Добавляем заголовок
                var headerRow = new Row();
                headerRow.Append(
                    CreateTextCell("A1", "Адрес"),
                    CreateTextCell("B1", "Номер квартиры"),
                    CreateTextCell("C1", "Номер помещения"),
                    CreateTextCell("D1", "Корпус"),
                    CreateTextCell("E1", "Количество этажей"),
                    CreateTextCell("F1", "Телефон"),
                    CreateTextCell("G1", "Тип отделки")
                );
                sheetData.Append(headerRow);

                // Заполняем данные из списка Premises
                int rowIndex = 2; // Нумерация строк начинается с 1, первая строка занята заголовком
                foreach (var premises in premisesList)
                {
                    var dataRow = new Row();
                    dataRow.Append(
                        CreateTextCell($"A{rowIndex}", premises.Address),
                        CreateTextCell($"B{rowIndex}", premises.ApartmentNumber?.ToString() ?? "N/A"),
                        CreateTextCell($"C{rowIndex}", premises.PremisesNumber?.ToString() ?? "N/A"),
                        CreateTextCell($"D{rowIndex}", premises.Housing?.ToString() ?? "N/A"),
                        CreateTextCell($"E{rowIndex}", premises.FloorNumber.ToString()),
                        CreateTextCell($"F{rowIndex}", premises.Phone),
                        CreateTextCell($"G{rowIndex}", premises.DecorationName)
                    );
                    sheetData.Append(dataRow);
                    rowIndex++;
                }

                // Сохраняем изменения
                workbookPart.Workbook.Save();
            }
        }

        // Вспомогательный метод для создания текстовой ячейки
        private static Cell CreateTextCell(string cellReference, string cellValue)
        {
            return new Cell
            {
                CellReference = cellReference,
                DataType = CellValues.String,
                CellValue = new CellValue(cellValue)
            };
        }
    }
}
