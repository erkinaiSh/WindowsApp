namespace PhotoEditor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Options = new System.Windows.Forms.Button();
            this.Profile = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Invert = new System.Windows.Forms.Button();
            this.Greyscale = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Flip = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Upload = new System.Windows.Forms.Button();
            this.Download = new System.Windows.Forms.Button();
            this.Fog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Brightness = new System.Windows.Forms.TrackBar();
            this.Contrast = new System.Windows.Forms.TrackBar();
            this.Filter = new System.Windows.Forms.Button();
            this.Adjustment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Undo = new System.Windows.Forms.Button();
            this.Redo = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Ruser = new System.Windows.Forms.Button();
            this.SaveCB = new System.Windows.Forms.Button();
            this.Sepia = new System.Windows.Forms.Button();
            this.Vertical = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Location = new System.Drawing.Point(805, 22);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(75, 23);
            this.Options.TabIndex = 0;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // Profile
            // 
            this.Profile.Location = new System.Drawing.Point(805, 22);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(75, 23);
            this.Profile.TabIndex = 1;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = true;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // Clear
            // 
            this.Clear.Enabled = false;
            this.Clear.Location = new System.Drawing.Point(93, 22);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Invert
            // 
            this.Invert.Enabled = false;
            this.Invert.Location = new System.Drawing.Point(12, 117);
            this.Invert.Name = "Invert";
            this.Invert.Size = new System.Drawing.Size(75, 23);
            this.Invert.TabIndex = 3;
            this.Invert.Text = "Invert";
            this.Invert.UseVisualStyleBackColor = true;
            this.Invert.Click += new System.EventHandler(this.Invert_Click);
            // 
            // Greyscale
            // 
            this.Greyscale.Enabled = false;
            this.Greyscale.Location = new System.Drawing.Point(117, 117);
            this.Greyscale.Name = "Greyscale";
            this.Greyscale.Size = new System.Drawing.Size(75, 23);
            this.Greyscale.TabIndex = 4;
            this.Greyscale.Text = "Greyscale";
            this.Greyscale.UseVisualStyleBackColor = true;
            this.Greyscale.Click += new System.EventHandler(this.Greyscale_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(117, 48);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // Flip
            // 
            this.Flip.Enabled = false;
            this.Flip.Location = new System.Drawing.Point(12, 16);
            this.Flip.Name = "Flip";
            this.Flip.Size = new System.Drawing.Size(86, 32);
            this.Flip.TabIndex = 7;
            this.Flip.Text = "Flip Horizontal";
            this.Flip.UseVisualStyleBackColor = true;
            this.Flip.Click += new System.EventHandler(this.Flip_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 299);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(356, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(326, 299);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(12, 22);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(75, 23);
            this.Upload.TabIndex = 14;
            this.Upload.Text = "Upload";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Download
            // 
            this.Download.Location = new System.Drawing.Point(174, 22);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(75, 23);
            this.Download.TabIndex = 17;
            this.Download.Text = "Download";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // Fog
            // 
            this.Fog.Enabled = false;
            this.Fog.Location = new System.Drawing.Point(117, 67);
            this.Fog.Name = "Fog";
            this.Fog.Size = new System.Drawing.Size(75, 23);
            this.Fog.TabIndex = 8;
            this.Fog.Text = "Fog";
            this.Fog.UseVisualStyleBackColor = true;
            this.Fog.Click += new System.EventHandler(this.Fog_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Brightness";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contrast";
            // 
            // Brightness
            // 
            this.Brightness.Enabled = false;
            this.Brightness.Location = new System.Drawing.Point(22, 79);
            this.Brightness.Maximum = 50;
            this.Brightness.Minimum = -50;
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(186, 45);
            this.Brightness.TabIndex = 10;
            this.Brightness.TickFrequency = 2;
            this.Brightness.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Brightness.Scroll += new System.EventHandler(this.Brightness_Scroll);
            // 
            // Contrast
            // 
            this.Contrast.Enabled = false;
            this.Contrast.Location = new System.Drawing.Point(22, 3);
            this.Contrast.Maximum = 50;
            this.Contrast.Minimum = -50;
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(186, 45);
            this.Contrast.TabIndex = 11;
            this.Contrast.TickFrequency = 2;
            this.Contrast.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Contrast.Scroll += new System.EventHandler(this.Contrast_Scroll);
            // 
            // Filter
            // 
            this.Filter.Enabled = false;
            this.Filter.Location = new System.Drawing.Point(821, 73);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(75, 23);
            this.Filter.TabIndex = 19;
            this.Filter.Text = "Filter";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // Adjustment
            // 
            this.Adjustment.Location = new System.Drawing.Point(740, 73);
            this.Adjustment.Name = "Adjustment";
            this.Adjustment.Size = new System.Drawing.Size(75, 23);
            this.Adjustment.TabIndex = 20;
            this.Adjustment.Text = "Adjustment";
            this.Adjustment.UseVisualStyleBackColor = true;
            this.Adjustment.Click += new System.EventHandler(this.Adjustment_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveCB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Contrast);
            this.panel1.Controls.Add(this.Brightness);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(688, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 154);
            this.panel1.TabIndex = 22;
            this.panel1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 15;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Vertical);
            this.panel2.Controls.Add(this.Sepia);
            this.panel2.Controls.Add(this.Greyscale);
            this.panel2.Controls.Add(this.Invert);
            this.panel2.Controls.Add(this.Flip);
            this.panel2.Controls.Add(this.Fog);
            this.panel2.Location = new System.Drawing.Point(688, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 158);
            this.panel2.TabIndex = 23;
            // 
            // Undo
            // 
            this.Undo.Enabled = false;
            this.Undo.Location = new System.Drawing.Point(630, 25);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(75, 23);
            this.Undo.TabIndex = 24;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Redo
            // 
            this.Redo.Enabled = false;
            this.Redo.Location = new System.Drawing.Point(535, 25);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(75, 23);
            this.Redo.TabIndex = 25;
            this.Redo.Text = "Redo";
            this.Redo.UseVisualStyleBackColor = true;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(255, 22);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 26;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(336, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 28;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(686, 280);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(129, 108);
            this.listBox1.TabIndex = 29;
            this.listBox1.Visible = false;
            // 
            // Ruser
            // 
            this.Ruser.Location = new System.Drawing.Point(821, 321);
            this.Ruser.Name = "Ruser";
            this.Ruser.Size = new System.Drawing.Size(75, 43);
            this.Ruser.TabIndex = 30;
            this.Ruser.Text = "Remove User";
            this.Ruser.UseVisualStyleBackColor = true;
            this.Ruser.Visible = false;
            this.Ruser.Click += new System.EventHandler(this.Ruser_Click);
            // 
            // SaveCB
            // 
            this.SaveCB.Location = new System.Drawing.Point(139, 127);
            this.SaveCB.Name = "SaveCB";
            this.SaveCB.Size = new System.Drawing.Size(75, 23);
            this.SaveCB.TabIndex = 16;
            this.SaveCB.Text = "Save Filter";
            this.SaveCB.UseVisualStyleBackColor = true;
            this.SaveCB.Click += new System.EventHandler(this.SaveCB_Click);
            // 
            // Sepia
            // 
            this.Sepia.Enabled = false;
            this.Sepia.Location = new System.Drawing.Point(12, 67);
            this.Sepia.Name = "Sepia";
            this.Sepia.Size = new System.Drawing.Size(75, 23);
            this.Sepia.TabIndex = 31;
            this.Sepia.Text = "Sepia";
            this.Sepia.UseVisualStyleBackColor = true;
            this.Sepia.Click += new System.EventHandler(this.Sepia_Click);
            // 
            // Vertical
            // 
            this.Vertical.Enabled = false;
            this.Vertical.Location = new System.Drawing.Point(117, 16);
            this.Vertical.Name = "Vertical";
            this.Vertical.Size = new System.Drawing.Size(80, 32);
            this.Vertical.TabIndex = 31;
            this.Vertical.Text = "Flip Vertical";
            this.Vertical.UseVisualStyleBackColor = true;
            this.Vertical.Click += new System.EventHandler(this.Vertical_Click);
            // 
            // Editor
            // 
            this.ClientSize = new System.Drawing.Size(908, 501);
            this.Controls.Add(this.Ruser);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Redo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Adjustment);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.Options);
            this.Name = "Editor";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Options;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Invert;
        private System.Windows.Forms.Button Greyscale;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button Flip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar Brightness;
        private System.Windows.Forms.TrackBar Contrast;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.Button Adjustment;
        private System.Windows.Forms.Button Fog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Ruser;
        private System.Windows.Forms.Button SaveCB;
        private System.Windows.Forms.Button Sepia;
        private System.Windows.Forms.Button Vertical;
    }
}