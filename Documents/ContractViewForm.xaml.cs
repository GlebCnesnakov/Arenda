using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Documents
{
    /// <summary>
    /// Логика взаимодействия для ContractViewForm.xaml
    /// </summary>
    public partial class ContractViewForm : Window
    {
        List<ContractPremises> contractPremises;
        Contract contract;
        Rentor rentor;
        public ContractViewForm(Rentor rentor, Contract contract)
        {
            InitializeComponent();
            try
            {
                contractPremises = Data.GetContractPremises(contract); // Строки с помещениями и параметрами
                this.contract = contract;
                this.rentor = rentor;
            }
            catch(Exception ex){return;}
            //contractTextBlock.Text = $"Договор аренды {contract.ContractNumber}";
            contractTextBlock.Text = GenerateContractText(rentor, contract, contractPremises);
        }
        public static string GenerateContractText(Rentor rentor, Contract contract, List<ContractPremises> contractPremises)
        {
            StringBuilder sb = new StringBuilder();

            // Заголовок договора
            sb.AppendLine($"Предварительный договор аренды № {contract.ContractNumber}");
            sb.AppendLine($"г. Новосибирск");
            sb.AppendLine($"Дата: {contract.StartDate}\n");
            // Стороны договора
            sb.AppendLine("«Агентство Недвижимости», в лице _____________________________,");
            sb.AppendLine("действующего на основании ___________________, с одной стороны, и");
            if (rentor.Individual != null) sb.AppendLine($"«{rentor.Name} {rentor.Surname}»,");
            else sb.AppendLine($"«{rentor.Legal.NameLiquid}»,");
            sb.AppendLine("в лице _____________________________, действующего на основании ___________________, с другой стороны,");
            sb.AppendLine("именуемые в дальнейшем совместно «Стороны», заключили настоящий договор (далее – Договор) о нижеследующем:\n");
            // Предмет договора
            sb.AppendLine("1. ПРЕДМЕТ ДОГОВОРА");
            sb.AppendLine("1.1. Стороны обязуются заключить Основной договор аренды помещений(я) (далее – Основной договор), расположенных(ого) по следующим(ему) адресам(у):");
            for (int i = 0; i < contractPremises.Count; i++)
            {
                var premises = contractPremises[i].Premises;
                sb.AppendLine(
                    $"  {i + 1}. Телефон коменданта {premises.Building.Phone}, {premises.Building.DistrictName}, {premises.Building.StreetName}, д.{premises.Building.BuildingNumber}, этажей: {premises.Building.FloorCount}, " +
                    $"корпус №{(premises.Housing.HasValue ? premises.Housing.ToString():"N/A")}, квартира №{(premises.PremisesNumber.HasValue ? premises.PremisesNumber.ToString():"N/A")}, помещение №{(premises.ApartmentNumber.HasValue ? premises.ApartmentNumber.ToString():"N/A")}, этаж {premises.FloorNumber} \n");
            }
            sb.AppendLine("\n1.2. Помещения принадлежат «Стороне 1» на праве собственности, что подтверждается _____________________________.");
            sb.AppendLine("1.3. Согласие собственника помещения: ____________________________________________________.");
            sb.AppendLine($"1.4. В обеспечение исполнения Договора Сторона 2 вносит денежное обеспечение в размере {contractPremises.Sum(p => p.Rent)} руб., которое будет зачтено в счет первого платежа по аренде.\n");
            sb.AppendLine($"1.5. Сторона 1 обязуется передать помещение во временное пользование Стороне 2 в течение ____ дней с даты подписания Основного договора.");
            // Условия аренды
            sb.AppendLine("2. УСЛОВИЯ АРЕНДЫ");
            sb.AppendLine($"2.1. Помещения передаются в аренду в следующем состоянии:");
            foreach (var premises in contractPremises)
            {
                sb.AppendLine($"   - Адрес: {premises.FullAddress}");
                sb.AppendLine($"     Площадь: {premises.Premises.Area} кв. м.");
                sb.AppendLine($"     Отделка: {premises.Premises.DecorationName}, Назначение: {premises.RentPurpose.Name}.");
                sb.AppendLine($"     Помещение арендуется на {premises.RentalPeriod} д.");
            }
            sb.AppendLine($"2.2. Общая арендная плата составляет {contractPremises.Sum(p => p.Rent)} руб./мес. Она должна быть внесена до ____ числа каждого месяца.\n");

            // Ответственность сторон
            sb.AppendLine("3. ОТВЕТСТВЕННОСТЬ СТОРОН");
            sb.AppendLine($"3.1. В случае нарушения условий Договора виновная сторона обязуется уплатить штраф в размере {contract.Penalty} руб.");
            sb.AppendLine("3.2. Все спорные вопросы решаются путем переговоров, а при недостижении согласия – в суде по месту нахождения помещения.\n");

            // Прочие условия
            sb.AppendLine("4. ПРОЧИЕ УСЛОВИЯ");
            sb.AppendLine("4.1. Настоящий договор составлен в двух экземплярах, имеющих одинаковую юридическую силу.");
            sb.AppendLine("4.2. Подписанием настоящего договора стороны подтверждают, что ознакомлены с его условиями и согласны с ними.\n");

            // Подписи сторон
            sb.AppendLine("**Подписи сторон:**");
            sb.AppendLine("Сторона 1: ____________________ «Агентство Недвижимости»");
            if (rentor.Individual != null) sb.AppendLine($"Сторона 2: ____________________ {rentor.Name} {rentor.Surname}");
            else sb.AppendLine($"Сторона 2: ____________________ {rentor.Legal.NameLiquid}");
            return sb.ToString();
        }

        public static void CreateWordDocument(string filePath, string content)
        {
            // Создаем новый документ
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Добавляем основную часть документа
                var mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                var body = mainPart.Document.AppendChild(new Body());

                // Разделяем содержимое на строки и добавляем их в документ
                foreach (string line in content.Split('\n'))
                {
                    var paragraph = new Paragraph();
                    var paragraphProperties = new ParagraphProperties();
                    paragraphProperties.Justification = new Justification { Val = JustificationValues.Center };
                    paragraph.AppendChild(paragraphProperties);
                    var run = new Run();
                    var runProperties = new RunProperties();
                    runProperties.FontSize = new FontSize { Val = "26" }; // Шрифт 12 pt (24 половины пункта)
                    runProperties.RunFonts = new RunFonts
                    {
                        Ascii = "Times New Roman",       // Для латинских символов
                        EastAsia = "Times New Roman",    // Для восточноазиатских символов
                        HighAnsi = "Times New Roman",    // Для символов высокого ASCII (например, для символов с акцентами)
                        ComplexScript = "Times New Roman" // Для сложных скриптов (например, кириллица)
                    };
                    run.PrependChild(runProperties);
                    run.AppendChild(new Text(line));
                    paragraph.AppendChild(run);
                    body.AppendChild(paragraph);
                }
            }
        }
        private void ButtonClickExport(object sender, RoutedEventArgs e)
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Contract_{Guid.NewGuid()}.docx");
            CreateWordDocument(filePath, GenerateContractText(rentor, contract, contractPremises));
            MessageBox.Show("Файл добавлен на рабочий стол");
            Close();
        }
    }
}
