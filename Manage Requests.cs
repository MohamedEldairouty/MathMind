using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MathMind
{
   public partial class ManageRequests : Form
   {
      private string name;
      private string username;
      private Timer autoRefreshTimer;
      private List<int> previousRequestIDs = new List<int>();
      private List<int> previousRejectedRequestIDs = new List<int>();
      string connectionString = ConfigHelper.GetConnectionString();

      public ManageRequests(string name, string username)
      {
         InitializeComponent();
         this.name = name;
         this.username = username;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         LoadRequests();
         InitializePreviousRequestIDs();
         SetupAutoRefresh();
      }



      private void InitializePreviousRequestIDs()
      {
         string query = "SELECT RequestID, Status FROM QuizRequests";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  int requestId = reader.GetInt32(0);
                  string status = reader.GetString(1);

                  previousRequestIDs.Add(requestId);
                  if (status == "Rejected")
                  {
                     previousRejectedRequestIDs.Add(requestId);
                  }
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error initializing requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void AutoRefreshRequests()
      {
         string query = @"
SELECT 
    QuizRequests.RequestID, 
    QuizRequests.StudentID, 
    StudentsAccounts.Username, 
    QuizRequests.RequestTime, 
    QuizRequests.Status
FROM QuizRequests
INNER JOIN StudentsAccounts ON QuizRequests.StudentID = StudentsAccounts.StudentID";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable currentRequests = new DataTable();

            try
            {
               connection.Open();
               adapter.Fill(currentRequests);

               List<int> currentRequestIDs = currentRequests.AsEnumerable()
                                                            .Select(row => row.Field<int>("RequestID"))
                                                            .ToList();

               List<int> newRequestIDs = currentRequestIDs.Except(previousRequestIDs).ToList();

               if (newRequestIDs.Any())
               {
                  if (newRequestIDs.Count == 1)
                  {
                     ShowNonBlockingMessage("1 new request received.", "New Request");
                  }
                  else
                  {
                     ShowNonBlockingMessage($"{newRequestIDs.Count} new requests received.", "New Requests");
                  }

                  previousRequestIDs.AddRange(newRequestIDs);
               }

               List<int> newRejectedRequestIDs = currentRequests.AsEnumerable()
                   .Where(row => row.Field<string>("Status") == "Rejected")
                   .Select(row => row.Field<int>("RequestID"))
                   .Except(previousRejectedRequestIDs)
                   .ToList();

               if (newRejectedRequestIDs.Any())
               {
                  if (newRejectedRequestIDs.Count == 1)
                  {
                     ShowNonBlockingMessage("1 request was rejected.", "Request Rejected");
                  }
                  else
                  {
                     ShowNonBlockingMessage($"{newRejectedRequestIDs.Count} requests were rejected.", "Requests Rejected");
                  }

                  previousRejectedRequestIDs.AddRange(newRejectedRequestIDs);
               }

               dataGridView1.DataSource = null;
               dataGridView1.DataSource = currentRequests;

               dataGridView1.Columns["RequestID"].Visible = false;
               dataGridView1.Columns["StudentID"].Visible = false;

               dataGridView1.Columns["Username"].HeaderText = "Student Username";
               dataGridView1.Columns["RequestTime"].HeaderText = "Request Time";
               dataGridView1.Columns["Status"].HeaderText = "Status";

               dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
               dataGridView1.DefaultCellStyle.BackColor = Color.White;
               dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
               dataGridView1.Refresh();

               previousRequestIDs.AddRange(currentRequestIDs.Except(previousRequestIDs));
               dataGridView1.Sort(dataGridView1.Columns["RequestTime"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error refreshing requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }




      private void SetupAutoRefresh()
      {
         autoRefreshTimer = new Timer
         {
            Interval = 5000
         };
         autoRefreshTimer.Tick += (s, e) => AutoRefreshRequests();
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

      private void LoadRequests()
      {
         string query = @"
        SELECT 
            QuizRequests.RequestID, 
            QuizRequests.StudentID, 
            StudentsAccounts.Username, 
            QuizRequests.RequestTime, 
            QuizRequests.Status
        FROM QuizRequests
        INNER JOIN StudentsAccounts ON QuizRequests.StudentID = StudentsAccounts.StudentID";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable requests = new DataTable();
            try
            {
               connection.Open();
               adapter.Fill(requests);

               dataGridView1.DataSource = null;
               dataGridView1.DataSource = requests;

               dataGridView1.Columns["RequestID"].Visible = false;
               dataGridView1.Columns["StudentID"].Visible = false;

               dataGridView1.Columns["Username"].HeaderText = "Student Username";
               dataGridView1.Columns["RequestTime"].HeaderText = "Request Time";
               dataGridView1.Columns["Status"].HeaderText = "Status";

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
               dataGridView1.TabIndex = 27;
               dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
               dataGridView1.Refresh();

               dataGridView1.Sort(dataGridView1.Columns["RequestTime"], ListSortDirection.Descending);

            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error loading requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void Refresh_Click(object sender, EventArgs e)
      {
         LoadRequests();
      }
      private void dataGridView1_SelectionChanged(object sender, EventArgs e)
      {
         var selectedRows = dataGridView1.SelectedRows;
         if (selectedRows.Count == 0)
         {
            Accept.Enabled = false;
            Reject.Enabled = false;
            return;
         }


         if (!dataGridView1.Columns.Contains("Status"))
         {
            Accept.Enabled = false;
            Reject.Enabled = false;
            return;
         }

         bool allPending = true;

         foreach (DataGridViewRow row in selectedRows)
         {
            var cellValue = row.Cells["Status"].Value;

            if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
            {
               allPending = false;
               break;
            }

            string status = cellValue.ToString();
            if (status != "Pending") allPending = false;

            if (!allPending) break;
         }
         Accept.Enabled = allPending;
         Reject.Enabled = allPending;
      }
      private void Reject_Click(object sender, EventArgs e)
      {
         var selectedRequestIds = dataGridView1.SelectedRows
             .Cast<DataGridViewRow>()
             .Select(row => (int)row.Cells["RequestID"].Value)
             .ToList();

         string query = $"UPDATE QuizRequests SET Status = 'Rejected' WHERE RequestID IN ({string.Join(",", selectedRequestIds)})";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
               connection.Open();
               command.ExecuteNonQuery();

               foreach (DataGridViewRow row in dataGridView1.SelectedRows)
               {
                  row.Cells["Status"].Value = "Rejected";
               }

               if (dataGridView1.SelectedRows.Count == 1)
               {
                  ShowNonBlockingMessage("Selected request has been rejected.", "Rejected");
               }
               else
               {
                  ShowNonBlockingMessage("Selected requests have been rejected.", "Rejected");
               }

               previousRejectedRequestIDs.AddRange(selectedRequestIds);
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error rejecting requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }



      private void Accept_Click(object sender, EventArgs e)
      {
         var selectedRequestIds = dataGridView1.SelectedRows
             .Cast<DataGridViewRow>()
             .Select(row => row.Cells["RequestID"].Value.ToString())
             .ToList();

         string query = $"UPDATE QuizRequests SET Status = 'Accepted' WHERE RequestID IN ({string.Join(",", selectedRequestIds)})";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
               connection.Open();
               command.ExecuteNonQuery();

               foreach (DataGridViewRow row in dataGridView1.SelectedRows)
               {
                  row.Cells["Status"].Value = "Accepted";
               }

               if (dataGridView1.SelectedRows.Count == 1)
               {
                  ShowNonBlockingMessage("Selected request has been accepted.", "Accepted");
               }
               else
               {
                  ShowNonBlockingMessage("Selected requests have been accepted.", "Accepted");
               }

            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error accepting requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

      }

      private Queue<(string message, string title)> messageQueue = new Queue<(string, string)>();
      private Form activeMessageForm = null;

      private void ShowNonBlockingMessage(string message, string title)
      {
         if (activeMessageForm != null)
         {
            messageQueue.Enqueue((message, title));
            return;
         }

         activeMessageForm = new Form
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
         activeMessageForm.Controls.Add(label);

         var autoCloseTimer = new Timer { Interval = 2000 };
         autoCloseTimer.Tick += (s, args) =>
         {
            autoCloseTimer.Stop();
            autoCloseTimer.Dispose();
            activeMessageForm.Close();
            activeMessageForm = null;

            if (messageQueue.Count > 0)
            {
               var nextMessage = messageQueue.Dequeue();
               ShowNonBlockingMessage(nextMessage.message, nextMessage.title);
            }
         };

         autoCloseTimer.Start();
         activeMessageForm.Show();
      }
   }
}
