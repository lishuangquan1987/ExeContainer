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
using System.Windows.Interop;
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
        private HwndSource _hostPanelSource;
        public ExeContainerWpf()
        {
            InitializeComponent();
            Loaded+=OnLoaded;
            SizeChanged += ExeContainerWpf_SizeChanged;
        }
        
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _hostPanelSource = PresentationSource.FromVisual(FormsHost) as HwndSource;
        }

        private void ExeContainerWpf_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            (int actualWidth, int actualHeight) = GetActualSize();
            _containerHelper.SetSize(0, 0, actualWidth, actualHeight);
        }

        public async Task<bool> EmbedProcess(string fileName)
        {
            (int actualWidth, int actualHeight) = GetActualSize();
            return await _containerHelper.StartEmbedProcess(fileName, this.Host.Handle, actualWidth, actualHeight);
        }

        private (int width,int height) GetActualSize()
        {
            // 获取HostPanel的实际尺寸
            double actualWidth = Host.Size.Width;
            double actualHeight = Host.Size.Height;
                
            // 处理DPI缩放
            double dpiScale = GetDpiScaleFactor();
            // int x = (int)(clientLocation.X * dpiScale);
            // int y = (int)(clientLocation.Y * dpiScale);
            int width = (int)(actualWidth * dpiScale);
            int height = (int)(actualHeight * dpiScale);
            return (width, height);
        }
        
        private double GetDpiScaleFactor()
        {
            if (_hostPanelSource?.CompositionTarget != null)
            {
                // 获取DPI缩放因子
                Matrix transform = _hostPanelSource.CompositionTarget.TransformToDevice;
                // return transform.M11; // M11 和 M22 应该相同
            }
            return 1.0;
        }
        
    }
}
