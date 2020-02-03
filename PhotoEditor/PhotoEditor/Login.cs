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
    public partial class Login : Form
    {
        public static string email ;

        public static string pass ;
        public Login()
        {
            InitializeComponent();
        }

        Form par;
        public Login(Form parent)
        {
            InitializeComponent();
            this.par = parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            pass = textBox2.Text;
            this.Hide();
            this.par.Visible = true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.par.Visible = true;
        }
    }
}
