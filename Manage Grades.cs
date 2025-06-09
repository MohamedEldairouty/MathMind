using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;
using System;
using System.IO;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MathMind
{
   public partial class ManageGrades : Form
   {
      private string username;
      private string name;
      string connectionString = ConfigHelper.GetConnectionString();
      private Timer autoRefreshTimer;
      private HashSet<int> previousQuizIDs = new HashSet<int>();

      public ManageGrades(string name, string username)
      {
         InitializeComponent();
         this.username = username;
         this.name = name;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         LoadGrades();
         SetupAutoRefresh();
      }


      private void AutoRefresh()
      {
         LoadGrades();
      }
      private void ShowNonBlockingMessage(string message, string title)
      {
         Thread messageThread = new Thread(() =>
         {
            try
            {
               if (InvokeRequired)
               {
                  Invoke(new Action(() => CreateMessageForm(message, title)));
               }
               else
               {
                  CreateMessageForm(message, title);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error displaying message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         });
         messageThread.Start();
      }

      private void CreateMessageForm(string message, string title)
      {
         Form messageForm = new Form
         {
            Text = title,
            Width = 650,
            Height = 150,
            StartPosition = FormStartPosition.CenterScreen,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MinimizeBox = false,
            MaximizeBox = false,
            ShowInTaskbar = false,
            TopMost = true
         };

         Label label = new Label
         {
            Text = message,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Arial", 16, FontStyle.Bold)
         };
         messageForm.Controls.Add(label);

         var autoCloseTimer = new System.Windows.Forms.Timer
         {
            Interval = 2000
         };
         autoCloseTimer.Tick += (s, args) =>
         {
            autoCloseTimer.Stop();
            autoCloseTimer.Dispose();
            if (!messageForm.IsDisposed)
            {
               messageForm.Close();
            }
         };
         autoCloseTimer.Start();

         messageForm.Show();
      }
      private void SetupAutoRefresh()
      {
         autoRefreshTimer = new Timer
         {
            Interval = 5000
         };
         autoRefreshTimer.Tick += (s, e) => AutoRefresh();
         autoRefreshTimer.Start();
      }
      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         autoRefreshTimer?.Stop();
         autoRefreshTimer?.Dispose();
         base.OnFormClosing(e);
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

      private void LoadGrades()
      {
         string query = @"
        SELECT 
            Quizzes.QuizID, 
            StudentsAccounts.Username,
            Quizzes.QuizDate, 
            Quizzes.Status, 
            Quizzes.Score, 
            CAST(Score / 0.05 AS DECIMAL(10, 2)) AS Percentage 
        FROM Quizzes, StudentsAccounts
        WHERE Quizzes.StudentID = StudentsAccounts.StudentID 
        ORDER BY QuizDate DESC";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            DataTable quizTable = new DataTable();
            try
            {
               connection.Open();
               adapter.Fill(quizTable);

               HashSet<int> currentQuizIDs = new HashSet<int>();
               foreach (DataRow row in quizTable.Rows)
               {
                  int quizID = Convert.ToInt32(row["QuizID"]);
                  currentQuizIDs.Add(quizID);
               }

               if (previousQuizIDs.Count > 0) 
               {
                  var newQuizzes = currentQuizIDs.Except(previousQuizIDs).ToList();
                  if (newQuizzes.Any())
                  {
                     if (newQuizzes.Count == 1)
                        ShowNonBlockingMessage("New Quiz Detected!", "New Quiz");
                     else
                     ShowNonBlockingMessage($"{newQuizzes.Count} New Quizzes Detected!", "New Quizzes");
                  }
               }

               previousQuizIDs = currentQuizIDs;

               dataGridView1.DataSource = null;
               dataGridView1.Columns.Clear();
               dataGridView1.DataSource = quizTable;
               dataGridView1.Columns["QuizID"].HeaderText = "Quiz";
               dataGridView1.Columns["Username"].HeaderText = "Student";
               dataGridView1.Columns["QuizDate"].HeaderText = "Date";
               dataGridView1.Columns["Percentage"].HeaderText = "Percent (%)";
               dataGridView1.Columns["Percentage"].DefaultCellStyle.Format = "N2";

               foreach (DataGridViewRow row in dataGridView1.Rows)
               {
                  if (row.Cells["Status"].Value != null && row.Cells["Status"].Value.ToString() == "Pending")
                  {
                     row.Cells["Score"].Value = DBNull.Value;
                     row.Cells["Percentage"].Value = DBNull.Value;
                  }
               }

               Results.Enabled = dataGridView1.Rows.Count > 0 &&
                                 dataGridView1.Rows[0].Cells["Status"].Value?.ToString() == "Graded";
               Grade.Enabled = dataGridView1.Rows.Count > 0 &&
                               dataGridView1.Rows[0].Cells["Status"].Value?.ToString() == "Pending";
               Remove.Enabled = dataGridView1.Rows.Count > 0;

               dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
               dataGridView1.DefaultCellStyle.BackColor = Color.White;
               dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
               dataGridView1.ReadOnly = true;
               dataGridView1.AllowUserToDeleteRows = false;
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               dataGridView1.BackgroundColor = Color.White;
               dataGridView1.AllowUserToResizeColumns = false;
               dataGridView1.AllowUserToResizeRows = false;
               dataGridView1.Refresh();
               dataGridView1.MultiSelect = true;

               DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
               {
                  Alignment = DataGridViewContentAlignment.MiddleCenter,
                  BackColor = Color.White,
                  Font = new Font("Forte", 16F, FontStyle.Bold),
                  ForeColor = Color.Black,
                  WrapMode = DataGridViewTriState.False
               };
               dataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;

               dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

               DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
               {
                  Alignment = DataGridViewContentAlignment.MiddleLeft,
                  BackColor = Color.White,
                  Font = new Font("Arial", 12F),
                  ForeColor = Color.Black,
                  SelectionBackColor = Color.Red,
                  SelectionForeColor = Color.Black,
                  WrapMode = DataGridViewTriState.False
               };
               dataGridView1.DefaultCellStyle = cellStyle;

               dataGridView1.Location = new Point(2, 150);
               dataGridView1.Name = "dataGridView1";
               dataGridView1.ReadOnly = true;
               dataGridView1.RowHeadersWidth = 51;
               dataGridView1.Size = new Size(892, 435);
               dataGridView1.TabIndex = 27;
               dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
               dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
               dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
               dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
      private void ResultsView(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];
            int quizID = (int)selectedRow.Cells["QuizID"].Value;

            var x = new ExaminerQuizReview(quizID, name, username);
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
         }
      }

      private void DataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         var selectedRows = dataGridView1.SelectedRows;
         if (selectedRows.Count == 0)
         {
            Grade.Enabled = false;
            Results.Enabled = false;
            Remove.Enabled = false;
            return;
         }

         if (!dataGridView1.Columns.Contains("Status"))
         {
            Grade.Enabled = false;
            Results.Enabled = false;
            Remove.Enabled = false;
            return;
         }

         bool allPending = true;
         bool allGraded = true;
         bool containsNewRow = false;


         foreach (DataGridViewRow row in selectedRows)
         {
            if (row.IsNewRow)
            {
               containsNewRow = true;
               break;
            }
            var cellValue = row.Cells["Status"].Value;

            if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
            {
               allPending = false;
               allGraded = false;
               break;
            }

            string status = cellValue.ToString();
            if (status != "Pending") allPending = false;
            if (status != "Graded") allGraded = false;

         }

         Grade.Enabled = allPending && !containsNewRow;
         Results.Enabled = allGraded && !containsNewRow && selectedRows.Count <= 1;
         Remove.Enabled = !containsNewRow;

      }


      private void Export_Click(object sender, EventArgs e)
      {
         DateTime date = DateTime.Now;
         string date1 = date.ToString("dd-MM-yyyy HH-mm-ss");
         try
         {
            using (var package = new ExcelPackage())
            {

               var worksheet = package.Workbook.Worksheets.Add($"Students Grades");
               int excelColumnIndex = 1;
               for (int i = 0; i < dataGridView1.Columns.Count; i++)
               {
                  if (dataGridView1.Columns[i].HeaderText != "QuizID")
                  {
                     worksheet.Cells[1, excelColumnIndex].Value = dataGridView1.Columns[i].HeaderText;
                     worksheet.Cells[1, excelColumnIndex].Style.Font.Bold = true;
                     excelColumnIndex++;
                  }
               }

               int row = 2;
               foreach (DataGridViewRow rowData in dataGridView1.Rows)
               {
                  if (!rowData.IsNewRow)
                  {
                     excelColumnIndex = 1;
                     for (int i = 0; i < dataGridView1.Columns.Count; i++)
                     {
                        if (dataGridView1.Columns[i].HeaderText != "QuizID")
                        {
                           object cellValue = rowData.Cells[i].Value;

                           if (dataGridView1.Columns[i].HeaderText == "Date" && DateTime.TryParse(cellValue?.ToString(), out DateTime dateValue))
                           {
                              worksheet.Cells[row, excelColumnIndex].Value = dateValue;
                              worksheet.Cells[row, excelColumnIndex].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                           }
                           else if (dataGridView1.Columns[i].HeaderText == "Percentage" && decimal.TryParse(cellValue?.ToString(), out decimal percentageValue))
                           {
                              worksheet.Cells[row, excelColumnIndex].Value = (int)Math.Round(percentageValue);
                           }
                           else if (dataGridView1.Columns[i].HeaderText == "Score" && int.TryParse(cellValue?.ToString(), out int intValue))
                           {
                              worksheet.Cells[row, excelColumnIndex].Value = intValue;
                           }
                           else
                           {
                              worksheet.Cells[row, excelColumnIndex].Value = cellValue?.ToString();
                           }
                           excelColumnIndex++;
                        }
                     }
                     row++;
                  }
               }
               worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

               using (SaveFileDialog saveFileDialog = new SaveFileDialog())
               {
                  string defaultFileName = $"Student Grades {date1}";
                  saveFileDialog.FileName = defaultFileName;
                  saveFileDialog.Filter = "Excel Files (.xlsx)|.xlsx";
                  saveFileDialog.DefaultExt = "xlsx";

                  if (saveFileDialog.ShowDialog() == DialogResult.OK)
                  {
                     File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                     ShowNonBlockingMessage("Excel file exported successfully!", "Export");
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Grade_Click(object sender, EventArgs e)
      {


         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            try
            {
               connection.Open();
               using (SqlTransaction transaction = connection.BeginTransaction())
               {
                  foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                  {
                     var quizIDCell = row.Cells["QuizID"].Value;
                     var statusCell = row.Cells["Status"].Value;

                     if (quizIDCell == null || statusCell == null || statusCell.ToString() != "Pending")
                     {
                        continue;
                     }

                     int quizID = (int)quizIDCell;

                     string query = "UPDATE Quizzes SET Status = 'Graded' WHERE QuizID = @QuizID";

                     using (SqlCommand command = new SqlCommand(query, connection, transaction))
                     {
                        command.Parameters.AddWithValue("@QuizID", quizID);
                        command.ExecuteNonQuery();
                     }
                  }

                  transaction.Commit();
                  int n = dataGridView1.SelectedRows.Count;
                  if (n == 1)
                     ShowNonBlockingMessage("Quiz has been successfully graded!", "Graded");
                  else
                     ShowNonBlockingMessage($"{n} Quizzes have been successfully graded!", "Graded");
                  LoadGrades();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error updating grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void Remove_Click(object sender, EventArgs e)
      {

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            try
            {
               connection.Open();
               using (SqlTransaction transaction = connection.BeginTransaction())
               {
                  foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                  {
                     var quizIDCell = row.Cells["QuizID"].Value;
                     int quizID = (int)quizIDCell;

                     string query = "DELETE FROM Quizzes WHERE QuizID = @QuizID";

                     using (SqlCommand command = new SqlCommand(query, connection, transaction))
                     {
                        command.Parameters.AddWithValue("@QuizID", quizID);
                        command.ExecuteNonQuery();
                     }
                  }

                  transaction.Commit();
                  int n = dataGridView1.SelectedRows.Count;
                  if (n == 1)
                     ShowNonBlockingMessage("Quiz has been successfully deleted!", "Deleted");
                  else
                     ShowNonBlockingMessage($"{n} Quizzes have been successfully deleted!", "Deleted");
                  LoadGrades();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error updating grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      protected override CreateParams CreateParams
      {
         get
         {
            const int CS_NOCLOSE = 0x200;
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= CS_NOCLOSE;
            return cp;
         }
      }

   }
}