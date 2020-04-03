using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public static string constring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PhotoEditor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        Stack<Bitmap> UChanges = new Stack<Bitmap>(5);
        Stack<Bitmap> RChanges = new Stack<Bitmap>(5);
        List<int> imglist = new List<int>();
        Registration r;
        Login l;
        Bitmap tempbm;
        public static int currimgid = -99 ;

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
            {
                Download.Enabled = false;
                Save.Enabled = false;
            }

            if (!string.IsNullOrEmpty(Login.email) && !string.IsNullOrEmpty(Login.pass)){
                

                if (Login.status)
                {
                    MessageBox.Show(Login.pass +" "+ Login.email);
                    
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
                {
                    Download.Enabled = false;
                    Save.Enabled = false;
                }
                if (Login.status)
                {
                    
                    contextMenuStrip1.Items.Add("Username : " + Login.email);
                    using (SqlConnection con = new SqlConnection(constring))
                    {

                        string query = "select * from [Image] where UId=@uid";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@uid", Login.uid));
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            if (!Convert.ToBoolean(rd["ImageType"]))
                            {
                                imglist.Add(Convert.ToInt32(rd["IId"]));
                                contextMenuStrip1.Items.Add(rd["ImageName"].ToString());
                            }
                        }
                         
                    }
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
                Download.Enabled = false;
                Save.Enabled = false;
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

        private void Save_Click(object sender, EventArgs e)
        {
            string basepath = Directory.GetCurrentDirectory();
            string Ignm = "Image";
            DateTime currdate = DateTime.Now;
            if (textBox1.Text != "")
                Ignm = textBox1.Text;
            if (currimgid < 0)
            {
                int imgorg = 00;
                using (SqlConnection con = new SqlConnection(constring))
                {

                    string query = "insert into [Image](UId, ImageName, ImageType, Date) OUTPUT INSERTED.IId values(@uid, @name, @type, @date)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@name", Ignm));
                    cmd.Parameters.Add(new SqlParameter("@uid", Login.uid));
                    cmd.Parameters.Add(new SqlParameter("@type", true));
                    cmd.Parameters.Add(new SqlParameter("@Date", currdate));
                    con.Open();
                    imgorg = (int)cmd.ExecuteScalar();
                }
                string basepath1 = basepath + "\\"+imgorg.ToString()+".png";
                pictureBox1.Image.Save(basepath1, ImageFormat.Png);
                using (SqlConnection con = new SqlConnection(constring))
                {

                    string query = "insert into [Image](UId, ImageName, ImageType, Date) OUTPUT INSERTED.IId values(@uid, @name, @type, @date)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@name", Ignm));
                    cmd.Parameters.Add(new SqlParameter("@uid", Login.uid));
                    cmd.Parameters.Add(new SqlParameter("@type", false));
                    cmd.Parameters.Add(new SqlParameter("@date", currdate));
                    con.Open();
                    currimgid = (int)cmd.ExecuteScalar();
                }
                string basepath2 = basepath + "\\" + currimgid.ToString() + ".png";
                imglist.Add(currimgid);
                contextMenuStrip1.Items.Add(Ignm);
                pictureBox2.Image.Save(basepath2, ImageFormat.Png);
                label5.Text = "Image Stored successfully for the first time.";
            }
            else
            {
                if (MessageBox.Show("You have already saved this image do you wish to overwrite it ?", "Override", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        currdate = DateTime.Now;
                        string query = "UPDATE Image SET Date = @dnew ImageName = @ignm WHERE IId = @imgid";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@name", Ignm));
                        cmd.Parameters.Add(new SqlParameter("@dnew", currdate));
                        cmd.Parameters.Add(new SqlParameter("@imgid", currimgid));
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    string basepath3 = basepath + "\\" + currimgid.ToString() + ".png";
                    File.Delete(@basepath3);
                    pictureBox2.Image.Save(basepath3, ImageFormat.Png);
                    label5.Text = "Image Overriden successfully.";
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
            int rmv = imglist.Count;
            for (int i = 0; i < rmv; i++)
                contextMenuStrip1.Items.RemoveAt(1);
            imglist.Clear();
            NoImage();
            Profile.Hide();
            Options.Show();
        }

        private void Greyscale_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                Download.Enabled = true;
                if (Login.status)
                    Save.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm.Clone());
                Bitmap bmpInverted = new Bitmap(bmap.Width, bmap.Height);
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(
          new float[][]
          {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
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
                if (Login.status)
                    Save.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm.Clone());
                Bitmap bmpInverted = new Bitmap(bmap.Width, bmap.Height);
                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
{
    new float[] {-1, 0, 0, 0, 0},
    new float[] {0, -1, 0, 0, 0},
    new float[] {0, 0, -1, 0, 0},
    new float[] {0, 0, 0, 1, 0},
    new float[] {1, 1, 1, 0, 1}
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

        private void Fog_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Download.Enabled = true;
                if (Login.status)
                    Save.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm.Clone());
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
                if (Login.status)
                    Save.Enabled = true;
                Bitmap bmap = tempbm;

                UCAdd((Bitmap)tempbm.Clone());
                bmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox2.Image = bmap;

                tempbm = bmap;
                RChanges.Clear();
            }
        }

        public void SetBrightness(int brightness)
        {
            Download.Enabled = true;
            if (Login.status)
                Save.Enabled = true;
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
                if (Login.status)
                    Save.Enabled = true;
                label4.Text = Brightness.Value.ToString();
                SetBrightness(Brightness.Value);
            }
        }

        public void SetContrast(double contrast)
        {

            Download.Enabled = true;
            if (Login.status)
                Save.Enabled = true;
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
                if (Login.status)
                    Save.Enabled = true;
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
            Save.Enabled = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            Invert.Enabled = false;
            textBox1.Text = "";
            Greyscale.Enabled = false;
            UChanges.Clear();
            RChanges.Clear();
            Flip.Enabled = false;
            Fog.Enabled = false;
            Brightness.Enabled = false;
            Contrast.Enabled = false;
            currimgid = -99;
            Contrast.Value = 0;
            Brightness.Value = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (UChanges.Count != 0)
            {
                RCAdd((Bitmap)pictureBox2.Image.Clone());
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
                UCAdd((Bitmap)pictureBox2.Image.Clone());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            bool displaysvimg = true;
            if (currimgid < 0 && pictureBox2.Image!=null)
            {
                if (MessageBox.Show("You have not saved the editor image, do you want to load the other saved image?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    displaysvimg = false;
            }
            if (displaysvimg)
            {
                var parent = (ContextMenuStrip)sender;
                int i = parent.Items.IndexOf(e.ClickedItem);
                int indedit = imglist.ElementAt(i - 2);
                string basepath = Directory.GetCurrentDirectory();
                pictureBox1.Image = new Bitmap(basepath+"\\"+(indedit-1)+".png");
                pictureBox2.Image = new Bitmap(basepath + "\\" + (indedit)+".png");
                tempbm = new Bitmap(basepath + "\\" + (indedit) + ".png");
                currimgid = indedit;
                textBox1.Text = e.ClickedItem.Text;

                Clear.Enabled = true;
                Download.Enabled = true;
                Save.Enabled = true;
                Invert.Enabled = true;
                Greyscale.Enabled = true;
                Flip.Enabled = true;
                Fog.Enabled = true;
                Brightness.Enabled = true;
                Contrast.Enabled = true;
                UChanges.Clear();
                RChanges.Clear();
                Brightness.Value = 0;
                Contrast.Value = 0;
            }
        }
    }
}
