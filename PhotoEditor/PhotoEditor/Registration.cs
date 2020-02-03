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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        Form parent;
        public Registration(Form form)
        {
            InitializeComponent();

            this.parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Are These Correct Detail?\n" +"Name : "+ textBox1.Text + "\n" +"Email : "+ textBox2.Text + "\n"
                +"Password : "+ textBox3.Text + "\n" +"Phone No : "+ textBox4.Text;
            string details = "Details Checking";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, details, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                label5.Text="Record was successfully added!";
            }
        }
        
        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.parent.Visible = true;
        }
    }
}
