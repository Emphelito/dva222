using System;
using System.Windows.Forms;


namespace Bounce
{
	public class MainForm : Form
	{
		public MainForm() : base()
		{
			Text = "Bounce!";
			Width = 800;
			Height = 600;
			DoubleBuffered = true;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1359, 779);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}
