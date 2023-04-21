using Microsoft.Win32;
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
            this.KeyPreview = true;
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\andre\OneDrive\Imágenes\Survival Java";
            if (dialog.ShowDialog() == DialogResult.OK ) 
            {
                pictureBox1.Image = new Bitmap(dialog.FileName);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Left:
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
                case Keys.Right:
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
                    case Keys.Escape:
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    btnBrowse.Visible = true;
                    break;
            }
                  
            
        }

        public void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            btnBrowse.Visible = false;
        }

        private void btnBrowse_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
