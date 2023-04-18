using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagenesWFCS
{
    public partial class Form1 : Form
    {
        OpenFileDialog dialog;
        Form fullScreenForm;
        string[] imagenes;
        int index;

        public Form1()
        {
            InitializeComponent();
            imagenes = Directory.GetFiles(@"C:\Users\andre\OneDrive\Imágenes\Survival Java");  
            index = 0;
           
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\andre\OneDrive\Imágenes\Survival Java";
            if (dialog.ShowDialog() == DialogResult.OK ) 
            {
                pictureBox1.Image = new Bitmap(dialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Focus();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if(e.KeyCode == Keys.A)
            {
                Label label;
                label = new Label();
                label.BackColor = Color.Red;
                label.Size = new Size(300, 300);
                label.Location = new Point(200, 200);
                this.Controls.Add(label);
                pictureBox1.SendToBack();
            }*/
            

            switch (e.KeyCode)
            {
                case Keys.A:
                    if (index == null)
                    {
                        index = 0;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                    else if (index == 0)
                    {
                        index = 10;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                    else 
                    {
                        index--;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                 break;
                case Keys.D:
                    if (index == null)
                    {
                        index = 0;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                    else if (index == 10)
                    {
                        index = 0;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                    else 
                    {
                        index++;
                        pictureBox1.Image = Image.FromFile(imagenes[index]);
                    }
                    break;
            }
                  
            
        }

        public void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            fullScreenForm = new Form();
            fullScreenForm.Name = "fullScreenForm";
            fullScreenForm.WindowState = FormWindowState.Maximized;
            fullScreenForm.FormBorderStyle = FormBorderStyle.None;
            fullScreenForm.BackColor = Color.Black;
            fullScreenForm.KeyPreview = true;
            fullScreenForm.KeyDown += FullScreenForm_KeyDown;

            PictureBox fullScreenPictureBox = new PictureBox();
            fullScreenPictureBox.Dock = DockStyle.Fill;
            fullScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            fullScreenPictureBox.Image = pictureBox1.Image;

            fullScreenForm.Controls.Add(fullScreenPictureBox);

            fullScreenForm.ShowDialog();
        }

        private void FullScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                fullScreenForm.Close();
            }
        }
    }
}
