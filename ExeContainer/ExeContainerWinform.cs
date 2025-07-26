using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeContainer
{
    public partial class ExeContainerWinform : UserControl
    {
        private ContainerHelper _containerHelper = new ContainerHelper();
        public ExeContainerWinform()
        {
            InitializeComponent();
            this.SizeChanged += ExeContainerWinform_SizeChanged;
        }

        private void ExeContainerWinform_SizeChanged(object sender, EventArgs e)
        {
            _containerHelper.SetSize(0, 0, this.Width, this.Height);
        }

        public async Task<bool> EmbedProcess(string fileName)
        {
            return await _containerHelper.StartEmbedProcess(fileName, this.Handle, this.Width, this.Height);
        }
    }
}
