using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExeContainer.WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "应用程序|*.exe";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            this.tbPath.Text = openFileDialog.FileName;
        }

        private async void btnEmbed_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbPath.Text) || !File.Exists(this.tbPath.Text)) return;

            await this.wpfContainer.EmbedProcess(this.tbPath.Text);
        }
    }
}