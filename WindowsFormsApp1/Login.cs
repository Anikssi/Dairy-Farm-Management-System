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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private object txtPass;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = Username1.Text;
            string Password = Password1.Text;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both Name and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string query = "SELECT COUNT(*) FROM Registation WHERE Password = @Password AND Username = @Username";
           // string query = "SELECT COUNT(*) FROM LogIn WHERE Password = @Password AND Username  COLLATE SQL_Latin1_General_CP1_CS_AS = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                       Cows ob = new Cows ();
                       ob.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }


            private void button2_Click(object sender, EventArgs e)
            {
            Registation ob = new Registation();
            ob.Show();
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          //  txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }


    }
}
