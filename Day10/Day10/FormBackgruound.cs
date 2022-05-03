using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormBackgruound
{
    class MainApp : Form
    {
        Random rand;
        public MainApp()
        {
            rand = new Random();

            this.MouseWheel += new MouseEventHandler(MainApp_MouseWheel);
            this.MouseDown += new MouseEventHandler(MainApp_MouseDown);
        }

        void MainApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Color oldColor = this.BackColor;
                this.BackColor = Color.FromArgb(rand.Next(0, 255),
                                                rand.Next(0, 255),
                                                rand.Next(0, 255));
            }
            else if (e.Button == MouseButtons.Right)
            {
                if(this.BackgroundImage != null)
                {
                    this.BackgroundImage = null;
                    return;
                }

                string file = "sample.jpg";
                if (System.IO.File.Exists(file) == false)
                    MessageBox.Show("이미지 파일이 없습니다.");
                else
                    this.BackgroundImage = Image.FromFile(file);
            }
        }

        void MainApp_MouseWheel(object sender, MouseEventArgs e)
        {
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
            this.Opacity = this.Opacity < 0.1 ? 0.1: this.Opacity;

            Console.WriteLine($"Opacity : {this.Opacity}");
        }

        static void Main(string[] args)
        {
            MainApp form = new MainApp();
            form.Width = 800;
            form.Height = 500;
            Application.Run(form);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainApp
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Name = "MainApp";
            this.ResumeLayout(false);

        }
    }
}
