using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Cows : Form
    {
       
      
        public Cows( )
        {
           
            InitializeComponent();
          

        }

        private void label6_Click(object sender, EventArgs e)
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

        private void panel9_Paint(object sender, PaintEventArgs e)
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

        private void label15_Click(object sender, EventArgs e)
        {
            
           
        }

        private void label17_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Cows_Load(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";
            string query = "SELECT EarTag, CowName, Color, Breed, DateOfBirth, Age, WeightAtBirth, Pasture FROM [Cow]";

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

        private void button5_Click(object sender, EventArgs e)
        {
          
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

        private void button7_Click(object sender, EventArgs e)
        {
            Health Ob = new Health();
            Ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=DESKTOP-IABP1G3\\SQLEXPRESS; database=Dairy Farm Management System; integrated security=SSPI";

            string CowName = CowName1.Text.Trim();
            string EarTag = EarTag1.Text.Trim();
            string Color = Color1.Text.Trim();
            string Breed = Breed1.Text.Trim();
            string DateOfBirth = DOB1.Text.Trim();
            string Age = Age1.Text.Trim();
            string WeightAtBirth = WeightAtBirth1.Text.Trim();
            string Pasture = Pasture1.Text.Trim();

            if (string.IsNullOrWhiteSpace(CowName) || string.IsNullOrWhiteSpace(EarTag) ||
                string.IsNullOrWhiteSpace(DateOfBirth) || string.IsNullOrWhiteSpace(Color) ||
                 string.IsNullOrWhiteSpace(Breed) || string.IsNullOrWhiteSpace(Age) ||
                 string.IsNullOrWhiteSpace(WeightAtBirth) || string.IsNullOrWhiteSpace(Pasture))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "INSERT INTO Cow (CowName, EarTag, Color, Breed, DateOfBirth, Age, WeightAtBirth, Pasture) VALUES (@CowName, @EarTag, @Color, @Breed, @DateOfBirth, @Age, @WeightAtBirth, @Pasture)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CowName", CowName);
                    command.Parameters.AddWithValue("@EarTag", EarTag);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@Breed", Breed);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Age", Age);
                    command.Parameters.AddWithValue("@WeightAtBirth", WeightAtBirth);
                    command.Parameters.AddWithValue("@Pasture", Pasture);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Entry successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cows_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Entry. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            }

        private void button2_Click(object sender, EventArgs e) // Edit
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

            string CowName = CowName1.Text.Trim();
            string Color = Color1.Text.Trim();
            string Breed = Breed1.Text.Trim();
            string DateOfBirth = DOB1.Text.Trim();
            string Age = Age1.Text.Trim();
            string WeightAtBirth = WeightAtBirth1.Text.Trim();
            string Pasture = Pasture1.Text.Trim();

            if (string.IsNullOrWhiteSpace(CowName) || string.IsNullOrWhiteSpace(EarTag) ||
                string.IsNullOrWhiteSpace(DateOfBirth) || string.IsNullOrWhiteSpace(Color) ||
                string.IsNullOrWhiteSpace(Breed) || string.IsNullOrWhiteSpace(Age) ||
                string.IsNullOrWhiteSpace(WeightAtBirth) || string.IsNullOrWhiteSpace(Pasture))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Cow SET CowName = @CowName, Color = @Color, Breed = @Breed, DateOfBirth = @DateOfBirth, Age = @Age, WeightAtBirth = @WeightAtBirth, Pasture = @Pasture WHERE EarTag = @EarTag";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CowName", CowName);
                    command.Parameters.AddWithValue("@EarTag", EarTag);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@Breed", Breed);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Age", Age);
                    command.Parameters.AddWithValue("@WeightAtBirth", WeightAtBirth);
                    command.Parameters.AddWithValue("@Pasture", Pasture);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cows_Load(sender, e); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
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
                string query = "DELETE FROM Cow WHERE EarTag = @EarTag";

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
                            Cows_Load(sender, e); // Refresh data
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
