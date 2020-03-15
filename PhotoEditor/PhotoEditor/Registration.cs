using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                string constring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PhotoEditor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    
                    string query = "insert into [User](Name, Email, Password, PhoneNo, Designation) values(@name, @email, @pass, @phone, @desig)";
                    Boolean desig = false;
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@name", textBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("@email", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@phone", textBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("@desig", desig));
                    cmd.Parameters.Add(new SqlParameter("@pass", textBox3.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
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
