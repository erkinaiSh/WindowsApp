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
        public Editor()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Login.email) && !string.IsNullOrEmpty(Login.pass)){
                

                if (Login.email=="abc" && Login.pass == "abc")
                {
                    MessageBox.Show(Login.pass +" "+ Login.email);

                    contextMenuStrip1.Items.Add(Login.pass);
                    contextMenuStrip1.Items.Add(Login.email);
                    button1.Hide();
                    button2.Show();
                }
            }
            else {
                button1.Show();
                button2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button1, new Point(0, button1.Height));
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Equals("Register")) {
                Registration r = new Registration(this);
                r.Show();
                this.Hide();

            }
            if (e.ClickedItem.Text.Equals("Login"))
            {
                Login r = new Login(this);
                r.Show();
                this.Hide();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, new Point(0, button1.Height));

        }
    }
}
