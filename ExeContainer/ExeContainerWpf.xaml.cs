using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExeContainer
{
    /// <summary>
    /// ExeContainerWpf.xaml 的交互逻辑
    /// </summary>
    public partial class ExeContainerWpf : UserControl
    {
        private ContainerHelper _containerHelper = new ContainerHelper();
        public ExeContainerWpf()
        {
            InitializeComponent();
            this.SizeChanged += ExeContainerWpf_SizeChanged;
        }

        private void ExeContainerWpf_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _containerHelper.SetSize(0, 0, (int)this.ActualWidth, (int)this.ActualHeight);
        }

        public async Task<bool> EmbedProcess(string fileName)
        {
            return await _containerHelper.StartEmbedProcess(fileName, this.Host.Handle, (int)this.ActualWidth, (int)this.ActualHeight);
        }
    }
}
