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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadFinanceData();
        }
        private void LoadData()//NEWWWW
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT EmployeeID, EmployeeName, Number, Gender FROM [Employee]";

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
        private void LoadFinanceData()
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            // Queries to get the total amounts, total cows, and total employees
            string expenditureQuery = "SELECT SUM(CAST(Amount AS FLOAT)) AS TotalExpenditure FROM [Expenditure]";
            string incomeQuery = "SELECT SUM(CAST(Amount AS FLOAT)) AS TotalIncome FROM [Income]";
            string cowCountQuery = "SELECT COUNT(*) AS TotalCows FROM [Cow]";
            string employeeCountQuery = "SELECT COUNT(*) AS TotalEmployees FROM [Employee]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get total expenditure
                    using (SqlCommand expenditureCommand = new SqlCommand(expenditureQuery, connection))
                    {
                        object result = expenditureCommand.ExecuteScalar();
                        label3.Text = result != DBNull.Value ? $" {result:C}" : "Tk0.00";
                    }

                    // Get total income
                    using (SqlCommand incomeCommand = new SqlCommand(incomeQuery, connection))
                    {
                        object result = incomeCommand.ExecuteScalar();
                        label8.Text = result != DBNull.Value ? $" {result:C}" : "Tk0.00";
                    }

                    // Get total cows
                    using (SqlCommand cowCommand = new SqlCommand(cowCountQuery, connection))
                    {
                        object result = cowCommand.ExecuteScalar();
                        label11.Text = result != DBNull.Value ? $" {result}" : "0";
                    }

                    // Get total employees
                    using (SqlCommand employeeCommand = new SqlCommand(employeeCountQuery, connection))
                    {
                        object result = employeeCommand.ExecuteScalar();
                        label9.Text = result != DBNull.Value ? $" {result}" : "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Milk_Production Ob = new Milk_Production();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Health Ob = new Health();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Milk_Sales Ob = new Milk_Sales();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string EmployeeID = textBox1.Text.Trim();
            string EmployeeName = textBox2.Text.Trim();
            string Number = textBox3.Text.Trim();
            string Gender = textBox4.Text.Trim();
           


            if (string.IsNullOrWhiteSpace(EmployeeID) || string.IsNullOrWhiteSpace(EmployeeName) ||
                 string.IsNullOrWhiteSpace(Number) || string.IsNullOrWhiteSpace(Gender))

            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Employee (EmployeeID, EmployeeName, Number, Gender) VALUES (@EmployeeID, @EmployeeName, @Number, @Gender)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    command.Parameters.AddWithValue("@Number", Number);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    


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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            // Get the selected row data
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string EmployeeID = textBox1.Text.Trim();
            string EmployeeName = textBox2.Text.Trim();
            string Number = textBox3.Text.Trim();
            string Gender = textBox4.Text.Trim();


            if (string.IsNullOrWhiteSpace(EmployeeID) || string.IsNullOrWhiteSpace(EmployeeName) ||
                 string.IsNullOrWhiteSpace(Number) || string.IsNullOrWhiteSpace(Gender))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Employee SET EmployeeName = @EmployeeName, Number = @Number, Gender = @Gender WHERE EmployeeID = @EmployeeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    command.Parameters.AddWithValue("@Number", Number);
                    command.Parameters.AddWithValue("@Gender", Gender);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Milk_Production_Load(sender, e); 
                        LoadData();

                    }
                    else
                    {
                        MessageBox.Show("Failed to update the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            // Get the selected row's EarTag
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string EmployeeID = selectedRow.Cells["EmployeeID"].Value.ToString(); // Assuming EarTag is the unique identifier

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Milk_Production_Load(sender, e); // Refresh data
                            LoadData();

                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT EmployeeID, EmployeeName, Number, Gender FROM [Employee]";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    }
}
