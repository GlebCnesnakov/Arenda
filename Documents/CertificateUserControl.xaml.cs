using System.Windows.Controls;
using System.Diagnostics;
using System.Windows;
namespace Documents
{
    public partial class CertificateUserControl : UserControl
    {
        public CertificateUserControl()
        {
            InitializeComponent();
            string helpFilePath =
                System.IO.Path.GetFullPath(
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @$"..\..\..\..\spravka.chm"));
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = helpFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл справки");
                return;
            }
        }
    }
}