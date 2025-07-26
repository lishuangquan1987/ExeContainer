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
            SuspendLayout();
            // 
            // tbPath
            // 
            tbPath.Location = new Point(19, 10);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(639, 23);
            tbPath.TabIndex = 0;
            // 
            // btnBrowswer
            // 
            btnBrowswer.Location = new Point(664, 10);
            btnBrowswer.Name = "btnBrowswer";
            btnBrowswer.Size = new Size(75, 23);
            btnBrowswer.TabIndex = 1;
            btnBrowswer.Text = "浏览";
            btnBrowswer.UseVisualStyleBackColor = true;
            btnBrowswer.Click += btnBrowswer_Click;
            // 
            // btnEmbed
            // 
            btnEmbed.Location = new Point(745, 10);
            btnEmbed.Name = "btnEmbed";
            btnEmbed.Size = new Size(75, 23);
            btnEmbed.TabIndex = 2;
            btnEmbed.Text = "嵌入";
            btnEmbed.UseVisualStyleBackColor = true;
            btnEmbed.Click += btnEmbed_Click;
            // 
            // exeContainerWinform1
            // 
            exeContainerWinform1.Location = new Point(19, 62);
            exeContainerWinform1.Name = "exeContainerWinform1";
            exeContainerWinform1.Size = new Size(814, 376);
            exeContainerWinform1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(exeContainerWinform1);
            Controls.Add(btnEmbed);
            Controls.Add(btnBrowswer);
            Controls.Add(tbPath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbPath;
        private Button btnBrowswer;
        private Button btnEmbed;
        private ExeContainerWinform exeContainerWinform1;
    }
}
