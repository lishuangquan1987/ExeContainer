namespace ExeContainer.WinformDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowswer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "”¶”√≥Ã–Ú|*.exe";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            this.tbPath.Text = openFileDialog.FileName;
        }

        private async void btnEmbed_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbPath.Text) || !File.Exists(this.tbPath.Text)) return;

            await this.exeContainerWinform1.EmbedProcess(this.tbPath.Text);
        }
    }
}
