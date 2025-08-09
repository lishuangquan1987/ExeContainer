namespace ExeContainer.WinformDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbPath = new TextBox();
            btnBrowswer = new Button();
            btnEmbed = new Button();
            exeContainerWinform1 = new ExeContainerWinform();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbPath
            // 
            tbPath.Location = new Point(3, 5);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(639, 23);
            tbPath.TabIndex = 0;
            // 
            // btnBrowswer
            // 
            btnBrowswer.Location = new Point(648, 5);
            btnBrowswer.Name = "btnBrowswer";
            btnBrowswer.Size = new Size(75, 23);
            btnBrowswer.TabIndex = 1;
            btnBrowswer.Text = "浏览";
            btnBrowswer.UseVisualStyleBackColor = true;
            btnBrowswer.Click += btnBrowswer_Click;
            // 
            // btnEmbed
            // 
            btnEmbed.Location = new Point(729, 5);
            btnEmbed.Name = "btnEmbed";
            btnEmbed.Size = new Size(75, 23);
            btnEmbed.TabIndex = 2;
            btnEmbed.Text = "嵌入";
            btnEmbed.UseVisualStyleBackColor = true;
            btnEmbed.Click += btnEmbed_Click;
            // 
            // exeContainerWinform1
            // 
            exeContainerWinform1.Dock = DockStyle.Fill;
            exeContainerWinform1.Location = new Point(3, 43);
            exeContainerWinform1.Name = "exeContainerWinform1";
            exeContainerWinform1.Size = new Size(847, 404);
            exeContainerWinform1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(exeContainerWinform1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(853, 450);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbPath);
            panel1.Controls.Add(btnEmbed);
            panel1.Controls.Add(btnBrowswer);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(847, 34);
            panel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbPath;
        private Button btnBrowswer;
        private Button btnEmbed;
        private ExeContainerWinform exeContainerWinform1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}
