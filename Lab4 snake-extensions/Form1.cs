using System;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;

namespace Snakegame_Lab
{
    public class MainForm : Form
    {
        public MainForm() : base()
        {
            Text = "Snake";
            Width = 1400;
            Height = 1000;
            DoubleBuffered = true;

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1400, 1000);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}