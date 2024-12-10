using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Documents
{
    /// <summary>
    /// Логика взаимодействия для ContractUserControl.xaml
    /// </summary>
    public partial class ContractUserControl : UserControl
    {
        Rentor rentor;
        Contract contract;
        public ContractUserControl()
        {
            InitializeComponent();
            rentorsComboBox.ItemsSource = Data.GetRentors();
            //string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Example.docx");
            //using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            //{
            //    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            //    mainPart.Document = new Document();
            //    Body body = mainPart.Document.AppendChild(new Body());

            //    Paragraph para = body.AppendChild(new Paragraph());
            //    Run run = para.AppendChild(new Run());
            //    run.AppendChild(new Text("Привет, мир!"));

            //    mainPart.Document.Save();
            //}
        }

        private void ButtonClickView(object sender, RoutedEventArgs e)
        {
            rentor = rentorsComboBox.SelectedItem as Rentor;
            contract = contractsComboBox.SelectedItem as Contract;
            if (rentor != null && contract != null)
            {
                ContractViewForm contractViewForm = new ContractViewForm(rentor, contract);
                contractViewForm.Show();
            }
        }
        private void rentorsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rentorsComboBoxSelectionChanged != null)
            {
                try
                {
                    List<Contract> contracts = Data.GetContracts(rentorsComboBox.SelectedItem as Rentor);
                    if (contracts != null) { contractsComboBox.ItemsSource = contracts; viewButton.IsEnabled = true; }
                    else viewButton.IsEnabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка");
                    return;
                }
                
            }
        }
    }
}
