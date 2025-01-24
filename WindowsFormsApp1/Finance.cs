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

namespace WindowsFormsApp1
{
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            this.Load += new EventHandler(Income_Load);


        }


        private void LoadData()//NEWWWW
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT Date, Purpose, Amount, Filter FROM [Expenditure]";



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void label14_Click(object sender, EventArgs e)
        {
           
        }

        private void label16_Click(object sender, EventArgs e)
        {
           
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Finance_Load(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT Date, Purpose, Amount, Filter FROM [Expenditure]";

            try
            {
                // Create a new SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a SqlDataAdapter to fetch data from the database
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Fill the data into a DataTable
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Optional: Adjust the DataGridView columns to fit content
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }

            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string Date = dateTimePicker1.Text.Trim();
            string Purpose = textBox3.Text.Trim();
            string Amount = textBox1.Text.Trim();
            string Filter = dateTimePicker2.Text.Trim();
            



            if (string.IsNullOrWhiteSpace(Date) || string.IsNullOrWhiteSpace(Purpose) ||
           
                  string.IsNullOrWhiteSpace(Amount) || string.IsNullOrWhiteSpace(Filter))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Expenditure (Date, Purpose, Amount, Filter) VALUES (@Date, @Purpose, @Amount, @Filter)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@Purpose", Purpose);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Filter", Filter);
                    



                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Entry successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Entry. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //uncome
        }
        private void Income_Load(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT Date, Type, Amount, Filter FROM [Income]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind to dataGridView2 explicitly
                    dataGridView2.DataSource = dataTable;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading income data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string Date = dateTimePicker4.Text.Trim();
            string Type = textBox4.Text.Trim();
            string Amount = textBox2.Text.Trim();
            string Filter = dateTimePicker3.Text.Trim();




            if (string.IsNullOrWhiteSpace(Date) || string.IsNullOrWhiteSpace(Type) ||

                  string.IsNullOrWhiteSpace(Amount) || string.IsNullOrWhiteSpace(Filter))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Income (Date, Type, Amount, Filter) VALUES (@Date, @Type, @Amount, @Filter)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@Type", Type);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Filter", Filter);




                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Entry successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Income_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Entry. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Milk_Production Ob = new Milk_Production();
            Ob.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Health Ob = new Health();
            Ob.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Milk_Sales Ob = new Milk_Sales();
            Ob.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
    }
}
