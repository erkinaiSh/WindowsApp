using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Editor : Form
    {
        Registration r;
        Login l;
        Bitmap tempbm;
        public Editor()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Login.email) && !string.IsNullOrEmpty(Login.pass)){
                

                if (Login.email=="abc" && Login.pass == "abc")
                {
                    MessageBox.Show(Login.pass +" "+ Login.email);

                    contextMenuStrip1.Items.Add(Login.pass);
                    contextMenuStrip1.Items.Add(Login.email);
                    Options.Hide();
                    Profile.Show();
                }
            }
            else {
                Options.Show();
                Profile.Hide();
            }
        }
        public void ReloadEditor() {
            if (!string.IsNullOrEmpty(Login.email) && !string.IsNullOrEmpty(Login.pass))
            {


                if (Login.email == "abc" && Login.pass == "abc")
                {
                    
                    contextMenuStrip1.Items.Add("Username : " + Login.pass);
                    contextMenuStrip1.Items.Add("Password : " + Login.email);
                    Options.Hide();
                    Profile.Show();
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                }
            }
            else
            {
                Options.Show();
                Profile.Hide();
            }
        }
        private void Options_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(Options, new Point(0, Options.Height));
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Equals("Register"))
            {
                r = new Registration(this);
                r.Show();
                this.Hide();

            }
            if (e.ClickedItem.Text.Equals("Login"))
            {
                l = new Login(this);
                l.Show();
                this.Hide();

            }
        }


        private void Profile_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Options, new Point(0, Options.Height));

        }


        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                tempbm = new Bitmap(opnfd.FileName);
                pictureBox2.Image = null;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l.Dispose();
            contextMenuStrip1.Items.RemoveAt(1);
            contextMenuStrip1.Items.RemoveAt(1);
            pictureBox1.Image = null;

            pictureBox2.Image = null;
            Profile.Hide();
            Options.Show();
        }

        private void Greyscale_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmap = tempbm;

                Color c;
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        c = bmap.GetPixel(i, j);
                        byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                        bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                }
                pictureBox2.Image = (Bitmap)bmap;
                tempbm = bmap;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void Invert_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmap = tempbm;
                Color c;
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        c = bmap.GetPixel(i, j);
                        bmap.SetPixel(i, j,
          Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    }
                }
                pictureBox2.Image = (Bitmap)bmap;
                tempbm = bmap;
            }
        }

        private void Flip_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap bmap = tempbm;

                bmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox2.Image = (Bitmap)bmap;
                tempbm = bmap;
            }
        }

        public void SetBrightness(int brightness)
        {
            //Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)tempbm.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            pictureBox2.Image = (Bitmap)bmap;
            //tempbm = bmap;

        }

        private void Brightness_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                label4.Text = Brightness.Value.ToString();
                SetBrightness(Brightness.Value);
            }
        }

        public void SetContrast(double contrast)
        {
            Bitmap bmap = (Bitmap)tempbm.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            pictureBox2.Image = (Bitmap)bmap;
            //tempbm = bmap;
        }

        private void Contrast_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                label3.Text = Contrast.Value.ToString();
                SetContrast(Contrast.Value);
            }
        }
    }
}
