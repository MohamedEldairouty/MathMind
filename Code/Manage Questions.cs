using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MathMind
{
   public partial class Managequestions : Form
   {
      private string name;
      private string username;
      string connectionString = ConfigHelper.GetConnectionString();

      public Managequestions(string name, string username)
      {
         InitializeComponent();
         this.name = name;
         this.username = username;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         LoadQuestions();
      }

      private void Back_Click(object sender, EventArgs e)
      {
         var x = new ExaminerHome(name, username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void LoadQuestions()
      {
         string query = "SELECT QuestionID, QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectAnswer FROM Questions";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable questions = new DataTable();
            try
            {
               connection.Open();
               adapter.Fill(questions);
               dataGridView1.DataSource = null;
               dataGridView1.DataSource = questions;

               // Hide the QuestionID column (so it's not displayed in the DataGridView)
               dataGridView1.Columns["QuestionID"].Visible = false;

               dataGridView1.Columns["QuestionText"].HeaderText = "Question";
               dataGridView1.Columns["OptionA"].HeaderText = "A";
               dataGridView1.Columns["OptionB"].HeaderText = "B";
               dataGridView1.Columns["OptionC"].HeaderText = "C";
               dataGridView1.Columns["OptionD"].HeaderText = "D";
               dataGridView1.Columns["CorrectAnswer"].HeaderText = "Answer";

               dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
               dataGridView1.DefaultCellStyle.BackColor = Color.White;
               dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
               dataGridView1.ReadOnly = false;
               dataGridView1.AllowUserToDeleteRows = false;
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               dataGridView1.BackgroundColor = Color.White;
               dataGridView1.AllowUserToResizeColumns = false;
               dataGridView1.AllowUserToResizeRows = false;
               dataGridView1.AutoGenerateColumns = true;
               dataGridView1.Refresh();
               dataGridView1.MultiSelect = true;

               DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
               {
                  Alignment = DataGridViewContentAlignment.MiddleCenter,
                  BackColor = Color.White,
                  Font = new Font("Forte", 18F, FontStyle.Bold),
                  ForeColor = Color.Black,
                  WrapMode = DataGridViewTriState.False
               };
               dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;

               dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

               DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
               {
                  Alignment = DataGridViewContentAlignment.MiddleLeft,
                  BackColor = Color.White,
                  Font = new Font("Arial", 10F),
                  ForeColor = Color.Black,
                  SelectionBackColor = Color.Red,
                  SelectionForeColor = Color.Black,
                  WrapMode = DataGridViewTriState.False
               };
               dataGridView1.DefaultCellStyle = cellStyle;
               dataGridView1.Location = new Point(2, 150);
               dataGridView1.Name = "dataGridView1";
               dataGridView1.ReadOnly = false;
               dataGridView1.RowHeadersWidth = 51;
               dataGridView1.TabIndex = 27;
               dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
               dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error loading questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void Refresh_Click(object sender, EventArgs e)
      {
         LoadQuestions();
      }
      private void dataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];

            bool isDatabaseRow = IsRowInDatabase(selectedRow);
            Edit.Enabled = isDatabaseRow;
            Remove.Enabled = isDatabaseRow;
            Add.Enabled = !isDatabaseRow; 
         }
         else
         {
            Edit.Enabled = false;
            Remove.Enabled = false;
            Add.Enabled = false;
         }
      }
      private void RemoveQuestionFromDatabase(string questionId)
      {
         string query = "DELETE FROM Questions WHERE QuestionID = @QuestionID";

         using (SqlConnection con = new SqlConnection(connectionString))
         {
            try
            {
               con.Open();
               using (SqlCommand cmd = new SqlCommand(query, con))
               {
                  cmd.Parameters.AddWithValue("@QuestionID", questionId);
                  cmd.ExecuteNonQuery();
               }
               MessageBox.Show("Question removed successfully.");
               LoadQuestions();
            }
            catch (Exception ex)
            {
               MessageBox.Show($"An error occurred while removing the question: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
      private void Edit_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];
            var questionIdValue = selectedRow.Cells["QuestionID"].Value;

            if (questionIdValue == null || string.IsNullOrEmpty(questionIdValue.ToString()))
            {
               MessageBox.Show("This question is not in the database. Please insert it first.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            var correctAnswerValue = selectedRow.Cells["CorrectAnswer"].Value?.ToString();

            if (!int.TryParse(correctAnswerValue, out int correctAnswerIndex) || correctAnswerIndex < 0 || correctAnswerIndex > 3)
            {
               MessageBox.Show("The Correct Answer must be an integer between 0 and 3. Please correct it before editing.",
                               "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            var result = MessageBox.Show("Do you want to save the changes to this question?",
                                         "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               UpdateQuestionInDatabase(Convert.ToInt32(questionIdValue));
            }
         }
         else
         {
            MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      private void UpdateQuestionInDatabase(int questionId)
      {

         string newQuestionText = dataGridView1.SelectedRows[0].Cells["QuestionText"].Value?.ToString();
         string newOptionA = dataGridView1.SelectedRows[0].Cells["OptionA"].Value?.ToString();
         string newOptionB = dataGridView1.SelectedRows[0].Cells["OptionB"].Value?.ToString();
         string newOptionC = dataGridView1.SelectedRows[0].Cells["OptionC"].Value?.ToString();
         string newOptionD = dataGridView1.SelectedRows[0].Cells["OptionD"].Value?.ToString();
         string newCorrectAnswer = dataGridView1.SelectedRows[0].Cells["CorrectAnswer"].Value?.ToString();

         using (SqlConnection con = new SqlConnection(connectionString))
         {
            try
            {
               con.Open();
               string query = "UPDATE Questions SET " +
                              "QuestionText = @NewQuestionText, " +
                              "OptionA = @NewOptionA, " +
                              "OptionB = @NewOptionB, " +
                              "OptionC = @NewOptionC, " +
                              "OptionD = @NewOptionD, " +
                              "CorrectAnswer = @NewCorrectAnswer " +
                              "WHERE QuestionID = @QuestionID";

               using (SqlCommand command = new SqlCommand(query, con))
               {
                  command.Parameters.AddWithValue("@NewQuestionText", newQuestionText);
                  command.Parameters.AddWithValue("@NewOptionA", newOptionA);
                  command.Parameters.AddWithValue("@NewOptionB", newOptionB);
                  command.Parameters.AddWithValue("@NewOptionC", newOptionC);
                  command.Parameters.AddWithValue("@NewOptionD", newOptionD);
                  command.Parameters.AddWithValue("@NewCorrectAnswer", newCorrectAnswer);
                  command.Parameters.AddWithValue("@QuestionID", questionId);

                  command.ExecuteNonQuery();
               }

               MessageBox.Show("Question updated successfully.");
               LoadQuestions();
            }
            catch (Exception ex)
            {
               MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
      private int GetQuestionIdByText(string questionText)
      {
         int questionId = -1;

         string query = "SELECT QuestionID FROM Questions WHERE QuestionText = @QuestionText";
         using (SqlConnection con = new SqlConnection(connectionString))
         {
            try
            {
               con.Open();
               using (SqlCommand cmd = new SqlCommand(query, con))
               {
                  cmd.Parameters.AddWithValue("@QuestionText", questionText);
                  questionId = (int)cmd.ExecuteScalar();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"An error occurred while fetching Question ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         return questionId;
      }

      private void Remove_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];
            var questionIdValue = selectedRow.Cells["QuestionID"].Value;

            // Check if the question exists in the database
            if (questionIdValue == null || string.IsNullOrEmpty(questionIdValue.ToString()))
            {
               MessageBox.Show("This question is not in the database and cannot be removed.",
                               "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            var result = MessageBox.Show("Are you sure you want to remove this question?",
                                         "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
               RemoveQuestionFromDatabase(questionIdValue.ToString());
            }
         }
         else
         {
            MessageBox.Show("Please select a row to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }
      private bool IsRowInDatabase(DataGridViewRow row)
      {
         string questionText = row.Cells["QuestionText"].Value?.ToString()?.Trim();

         if (string.IsNullOrEmpty(questionText))
            return false;

         string query = "SELECT COUNT(*) FROM Questions WHERE QuestionText = @QuestionText";

         using (SqlConnection con = new SqlConnection(connectionString))
         {
            try
            {
               con.Open();

               using (SqlCommand cmd = new SqlCommand(query, con))
               {
                  cmd.Parameters.AddWithValue("@QuestionText", questionText);
                  int count = (int)cmd.ExecuteScalar();
                  return count > 0;
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error checking if row exists: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
            }
         }
      }
      private void Add_Click(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];

            if (IsRowInDatabase(selectedRow))
            {
               MessageBox.Show("This question is already in the database.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
            }

            string questionText = selectedRow.Cells["QuestionText"].Value?.ToString()?.Trim();
            string optionA = selectedRow.Cells["OptionA"].Value?.ToString()?.Trim();
            string optionB = selectedRow.Cells["OptionB"].Value?.ToString()?.Trim();
            string optionC = selectedRow.Cells["OptionC"].Value?.ToString()?.Trim();
            string optionD = selectedRow.Cells["OptionD"].Value?.ToString()?.Trim();
            string correctAnswerText = selectedRow.Cells["CorrectAnswer"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(optionA) ||
                string.IsNullOrEmpty(optionB) || string.IsNullOrEmpty(optionC) ||
                string.IsNullOrEmpty(optionD) || string.IsNullOrEmpty(correctAnswerText))
            {
               MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            if (!int.TryParse(correctAnswerText, out int correctAnswer) || correctAnswer < 0 || correctAnswer > 3)
            {
               MessageBox.Show("The Correct Answer must be an integer between 0 and 3.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            try
            {

               using (SqlConnection con = new SqlConnection(connectionString))
               {
                  con.Open();

                  string query = "INSERT INTO Questions (QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) " +
                                 "VALUES (@QuestionText, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer)";

                  using (SqlCommand cmd = new SqlCommand(query, con))
                  {
                     cmd.Parameters.AddWithValue("@QuestionText", questionText);
                     cmd.Parameters.AddWithValue("@OptionA", optionA);
                     cmd.Parameters.AddWithValue("@OptionB", optionB);
                     cmd.Parameters.AddWithValue("@OptionC", optionC);
                     cmd.Parameters.AddWithValue("@OptionD", optionD);
                     cmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);

                     cmd.ExecuteNonQuery();
                  }

                  MessageBox.Show("Question added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  LoadQuestions(); 
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"An error occurred while adding the question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         else
         {
            MessageBox.Show("Please select a row to add.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

      }
   }
}
