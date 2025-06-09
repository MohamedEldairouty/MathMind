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


namespace MathMind
{
   public partial class ViewGrades : Form
   {
      private string username;
      private string name;
      private Timer autoRefreshTimer;
      private Dictionary<int, string> initialQuizStatuses = new Dictionary<int, string>();
      string connectionString = ConfigHelper.GetConnectionString();

      public ViewGrades(string name, string username)
      {
         InitializeComponent();
         this.username = username;
         this.name = name;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         NameLabel.Text = $"{name} Quizzes Records";
         LoadGrades();
         StoreInitialQuizStatuses();
         SetupAutoRefresh();
      }
      private void StoreInitialQuizStatuses()
      {
         foreach (DataGridViewRow row in dataGridView1.Rows)
         {
            if (row.Cells["QuizID"].Value != null && row.Cells["Status"].Value != null)
            {
               int quizID = Convert.ToInt32(row.Cells["QuizID"].Value);
               string status = row.Cells["Status"].Value.ToString();
               initialQuizStatuses[quizID] = status;
            }
         }
      }
      private void AutoRefresh()
      {
         LoadGrades();
         foreach (DataGridViewRow row in dataGridView1.Rows)
         {
            if (row.Cells["QuizID"].Value != null && row.Cells["Status"].Value != null)
            {
               int quizID = Convert.ToInt32(row.Cells["QuizID"].Value);
               string currentStatus = row.Cells["Status"].Value.ToString();

               if (initialQuizStatuses.ContainsKey(quizID) &&
                   initialQuizStatuses[quizID] == "Pending" &&
                   currentStatus == "Graded")
               {
                  string score = row.Cells["Score"].Value?.ToString() ?? "N/A";
                  ShowNonBlockingMessage($"Quiz has been graded with a score of {score}/5.", "Quiz Graded");
                  initialQuizStatuses[quizID] = currentStatus;
               }
            }
         }
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
         var x = new StudentHome(name, username);
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
         int studentID = getstudentid(username);
         string query = @"
        SELECT 
            QuizID, 
            QuizDate, 
            Status, 
            Score, 
            CAST(Score / 0.05 AS DECIMAL(10, 2)) AS Percentage 
        FROM Quizzes 
        WHERE StudentID = @StudentID 
        ORDER BY QuizDate DESC";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = studentID });

            DataTable quizTable = new DataTable();
            try
            {
               connection.Open();
               adapter.Fill(quizTable);
               dataGridView1.DataSource = null;
               dataGridView1.DataSource = quizTable;

               dataGridView1.Columns["QuizID"].HeaderText = "Quiz";
               dataGridView1.Columns["QuizDate"].HeaderText = "Date";
               dataGridView1.Columns["Status"].HeaderText = "Status";
               dataGridView1.Columns["Score"].HeaderText = "Score";

               if (quizTable.Columns.Contains("Percentage"))
               {
                  dataGridView1.Columns["Percentage"].HeaderText = "Percentage (%)";
                  dataGridView1.Columns["Percentage"].DefaultCellStyle.Format = "N2";
               }

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

               dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
               dataGridView1.DefaultCellStyle.BackColor = Color.White;
               dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
               dataGridView1.ReadOnly = true;
               dataGridView1.AllowUserToDeleteRows = false;
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               dataGridView1.BackgroundColor = Color.White;
               dataGridView1.AllowUserToResizeColumns = false;
               dataGridView1.AllowUserToResizeRows = false;
               dataGridView1.AutoGenerateColumns = true;
               dataGridView1.Refresh();
               dataGridView1.MultiSelect = false;


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

            var x = new QuizReview(name, username, quizID);
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
         }
      }
      private int getstudentid(string username)
      {
         int result = -1;
         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            string query = "SELECT StudentID FROM StudentsAccounts WHERE Username = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            try
            {
               connection.Open();
               var obj = command.ExecuteScalar();
               if (obj != null)
               {
                  result = Convert.ToInt32(obj);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error: {ex.Message}");
            }
         }
         return result;
      }

      private void DataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         if (dataGridView1.SelectedRows.Count > 0)
         {
            var selectedRow = dataGridView1.SelectedRows[0];
            var status = selectedRow.Cells["Status"].Value?.ToString();
            if (status == "Graded")
               Results.Enabled = true;
            else
               Results.Enabled = false;
         }
         else
            Results.Enabled = false;
      }


      private void Export_Click(object sender, EventArgs e)
      {
         DateTime date = DateTime.Now;
         string date1 = date.ToString("dd-MM-yyyy HH-mm-ss");
         try
         {
            using (var package = new ExcelPackage())
            {
               var worksheet = package.Workbook.Worksheets.Add(string.IsNullOrWhiteSpace(name) ? "Grades" : $"{name} Grades");
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
                  string defaultFileName = string.IsNullOrWhiteSpace(name) ? $"Student Grades {date1}" : $"{name} Grades {date1}";
                  saveFileDialog.FileName = defaultFileName;

                  saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
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