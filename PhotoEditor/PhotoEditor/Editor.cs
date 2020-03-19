using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Editor : Form
    {
        Stack<Bitmap> UChanges = new Stack<Bitmap>(5);
        Stack<Bitmap> RChanges = new Stack<Bitmap>(5);
        Registration r;
        Login l;
        Bitmap tempbm;

        public void UCAdd(Bitmap img)
        {
            UChanges.Push(img);
            Undo.Enabled = true;
        }

        public void RCAdd(Bitmap img)
        {
            RChanges.Push(img);
            Redo.Enabled = true;
        }

        public Editor()
        {
            InitializeComponent();
            if (pictureBox2.Image == null)
                Download.Enabled=false;

            if (!string.IsNullOrEmpty(Login.email) && !string.IsNullOrEmpty(Login.pass)){
                

                if (Login.status)
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

                if (pictureBox2.Image == null)
                    Download.Enabled = false;

                if (Login.status)
                {
                    
                    contextMenuStrip1.Items.Add("Username : " + Login.pass);
                    contextMenuStrip1.Items.Add("Password : " + Login.email);
                    Options.Hide();
                    Profile.Show();
                    NoImage();
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

        private void Profile_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Options, new Point(0, Options.Height));
        }


        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                tempbm = new Bitmap(opnfd.FileName);
                Clear.Enabled = true;
                Invert.Enabled = true;
                Flip.Enabled = true;
                Greyscale.Enabled = true;
                Contrast.Enabled = true;
                Fog.Enabled = true;
                Brightness.Enabled = true;
                pictureBox2.Image = null;
                RChanges.Clear();
                UChanges.Clear();
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {   if (pictureBox2.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "png";
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox2.Image.Save(sfd.FileName, format);
                    MessageBox.Show("Image Saved Succesfully at location : \n" + sfd.FileName);
                }

            }
        }


        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r = new Registration(this);
            r.Show();
            this.Hide();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = new Login(this);
            l.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l.Dispose();
            contextMenuStrip1.Items.RemoveAt(1);
            contextMenuStrip1.Items.RemoveAt(1);
            NoImage();
            Profile.Hide();
            Options.Show();
        }

        private void Greyscale_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                Download.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm);
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
                pictureBox2.Image = bmap;
                tempbm = bmap;
                RChanges.Clear();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Brightness.Value = 0;
            Contrast.Value = 0;
            NoImage();
            RChanges.Clear();
            UChanges.Clear();
            Undo.Enabled = false;
            Redo.Enabled = false;
        }

        private void Invert_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                Download.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm);
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
                pictureBox2.Image = bmap;
                tempbm = bmap;
                RChanges.Clear();
            }
        }

        private void Fog_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Download.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm);
                Bitmap bmpInverted = new Bitmap(bmap.Width, bmap.Height);
                ImageAttributes ia = new ImageAttributes();                 
                ColorMatrix cmPicture = new ColorMatrix(new float[][]       
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0.7f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(bmap, new Rectangle(0, 0, bmap.Width, bmap.Height), 0, 0, bmap.Width, bmap.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox2.Image = bmpInverted;
                tempbm = bmpInverted;
                RChanges.Clear();
            }
        }

        private void Flip_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Download.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm);
                bmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox2.Image = bmap;

                tempbm = bmap;
                RChanges.Clear();
            }
        }

        public void SetBrightness(int brightness)
        {
            Download.Enabled = true;
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
            pictureBox2.Image = bmap;      

        }

        private void Brightness_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Download.Enabled = true;
                label4.Text = Brightness.Value.ToString();
                SetBrightness(Brightness.Value);
            }
        }

        public void SetContrast(double contrast)
        {

            Download.Enabled = true;
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
            pictureBox2.Image = bmap;
            
        }

        private void Contrast_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Download.Enabled = true;    
                label3.Text = Contrast.Value.ToString();
                SetContrast(Contrast.Value);
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            Adjustment.Enabled = true;
            Filter.Enabled = false;
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void Adjustment_Click(object sender, EventArgs e)
        {
            Adjustment.Enabled = false;
            Filter.Enabled = true;
            panel2.Visible = false;
            panel1.Visible = true;
        }


        private void NoImage()
        {
            Clear.Enabled = false;
            Download.Enabled = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            Invert.Enabled = false;
            Greyscale.Enabled = false;
            Flip.Enabled = false;
            Fog.Enabled = false;
            Brightness.Enabled = false;
            Contrast.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (UChanges.Count != 0)
            {
                RCAdd((Bitmap)pictureBox2.Image);
                pictureBox2.Image = UChanges.Pop();
                tempbm = (Bitmap)pictureBox2.Image.Clone();
                if (UChanges.Count == 0)
                {
                    Undo.Enabled = false;
                }
                else
                {
                    Undo.Enabled = true;
                }
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (RChanges.Count != 0)
            {
                UCAdd((Bitmap)pictureBox2.Image);
                pictureBox2.Image = RChanges.Pop();
                tempbm = (Bitmap)pictureBox2.Image.Clone();
                if (RChanges.Count == 0)
                {
                    Redo.Enabled = false;
                }
                else
                {
                    Redo.Enabled = true;
                }
            }
        }
    }
}
