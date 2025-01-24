﻿using System;
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
    public partial class Health : Form
    {
        public Health()
        {
            InitializeComponent();
        }
        private void LoadData()//NEWWWW
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT EarTag, CowName, Event, Diagnosis, Treatment, TreatmentCost, VetName FROM [Health]";

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
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void label17_Click(object sender, EventArgs e)
        {
            
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

        private void button10_Click(object sender, EventArgs e)
        {
            Finance Ob = new Finance();
            Ob.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string CowName = textBox1.Text.Trim();
            string EarTag = comboBox1.Text.Trim();
            string Event = textBox4.Text.Trim();
            string Diagnosis = textBox3.Text.Trim();
            string Treatment = textBox5.Text.Trim();
            string TreatmentCost = textBox7.Text.Trim();
            string VetName = textBox2.Text.Trim();


            if (string.IsNullOrWhiteSpace(CowName) || string.IsNullOrWhiteSpace(EarTag) ||
                string.IsNullOrWhiteSpace(Event) || string.IsNullOrWhiteSpace(Diagnosis) ||
                 string.IsNullOrWhiteSpace(Treatment) || string.IsNullOrWhiteSpace(TreatmentCost) ||
                 string.IsNullOrWhiteSpace(VetName))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Health (CowName, EarTag, Event, Diagnosis, Treatment, TreatmentCost, VetName) VALUES (@CowName, @EarTag, @Event, @Diagnosis, @Treatment, @TreatmentCost, @VetName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CowName", CowName);
                    command.Parameters.AddWithValue("@EarTag", EarTag);
                    command.Parameters.AddWithValue("@Event", Event);
                    command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
                    command.Parameters.AddWithValue("@Treatment", Treatment);
                    command.Parameters.AddWithValue("@TreatmentCost", TreatmentCost);
                    command.Parameters.AddWithValue("@VetName", VetName);


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

        private void Health_Load(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT EarTag, CowName, Event, Diagnosis, Treatment, TreatmentCost, VetName FROM [Health]";

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
            string EarTag = selectedRow.Cells["EarTag"].Value.ToString(); // Assuming EarTag is the unique identifier

            string CowName = textBox1.Text.Trim();
      
            string Event = textBox4.Text.Trim();
            string Diagnosis = textBox3.Text.Trim();
            string Treatment = textBox5.Text.Trim();
            string TreatmentCost = textBox7.Text.Trim();
            string VetName = textBox2.Text.Trim();


            if (string.IsNullOrWhiteSpace(CowName) || string.IsNullOrWhiteSpace(EarTag) ||
                string.IsNullOrWhiteSpace(Event) || string.IsNullOrWhiteSpace(Diagnosis) ||
                 string.IsNullOrWhiteSpace(Treatment) || string.IsNullOrWhiteSpace(TreatmentCost) ||
                 string.IsNullOrWhiteSpace(VetName))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Health SET CowName = @CowName, Event = @Event, Diagnosis = @Diagnosis, Treatment = @Treatment, TreatmentCost = @TreatmentCost, VetName = @VetName WHERE EarTag = @EarTag";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CowName", CowName);
                    command.Parameters.AddWithValue("@EarTag", EarTag);
                    command.Parameters.AddWithValue("@Event", Event);
                    command.Parameters.AddWithValue("@Diagnosis", Diagnosis);
                    command.Parameters.AddWithValue("@Treatment", Treatment);
                    command.Parameters.AddWithValue("@TreatmentCost", TreatmentCost);
                    command.Parameters.AddWithValue("@VetName", VetName);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string EarTag = selectedRow.Cells["EarTag"].Value.ToString(); // Assuming EarTag is the unique identifier

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Health WHERE EarTag = @EarTag";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EarTag", EarTag);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
