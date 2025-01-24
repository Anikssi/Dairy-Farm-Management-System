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

namespace WindowsFormsApp1
{
    public partial class Registation : Form
    {
        public Registation()
        {
            InitializeComponent();
        }

        private void Registation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login ob = new Login();
            ob.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string Gender = textBox1.Text.Trim();
            string Number = textBox2.Text.Trim();
            DateTime DOB = dateTimePicker1.Value;
            string Username = textBox3.Text.Trim();
            string Password = textBox4.Text.Trim();
            string ConfirmPassword = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(Gender) || string.IsNullOrWhiteSpace(Number) ||
                /*string.IsNullOrWhiteSpace(DOB) ||*/ string.IsNullOrWhiteSpace(Username) ||
                 string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           /* if (!int.TryParse(age, out int parsedAge))
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } */

            string query = "INSERT INTO Registation (Gender, Number, DOB, Username, Password, ConfirmPassword) VALUES (@Gender, @Number, @DOB, @Username, @Password, @ConfirmPassword)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Number", Number);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@ConfirmPassword", ConfirmPassword);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login ob = new Login();
                        ob.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
