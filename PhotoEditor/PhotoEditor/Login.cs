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
    public partial class Login : Form
    {
        public static string constring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PhotoEditor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string email;
        public static string pass ;
        public static bool status;
        public static int uid;

        public Login()
        {
            InitializeComponent();
        }

        Editor par;
        public Login(Form parent)
        {
            InitializeComponent();
            this.par = (Editor)parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {

                string query = "select * from [User] where Email=@email and Password=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@email", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@pass", textBox2.Text));
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.HasRows)
                {
                    label4.Text = "Invalid Email or Password";
                }
                else
                {
                    while (rd.Read())
                    {
                        email = rd["Email"].ToString();
                        pass = rd["Password"].ToString();
                        uid = Convert.ToInt32(rd["UId"]);
                    }
                    Login.status = true;
                    this.Hide();
                    this.par.ReloadEditor();
                    this.par.Visible = true;
                }
            }
            
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.par.Visible = true;
        }
    }
}
