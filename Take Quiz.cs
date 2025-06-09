using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MathMind
{
   public partial class TakeQuiz : Form
   {
      private string username;
      private string name;
      private bool QuizInProgress = false;
      private int remainingtime = 120;
      private System.Windows.Forms.Timer quizTimer;
      private List<Question> questions;
      private Dictionary<int, int> studentAnswers;
      private bool f = true;
      string connectionString = ConfigHelper.GetConnectionString();

      public TakeQuiz(string name, string username)
      {
         InitializeComponent();
         this.username = username;
         this.name = name;
         quizTimer = new System.Windows.Forms.Timer();
         quizTimer.Interval = 1000;
         quizTimer.Tick += QuizTimer_Tick;
         studentAnswers = new Dictionary<int, int>();
         this.FormBorderStyle = FormBorderStyle.FixedDialog;

      }

      private void Back_Click(object sender, EventArgs e)
      {
         if (QuizInProgress)
         {
            var result = MessageBox.Show("Are you sure you want to end your quiz? Your progress will be submitted.", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
               SubmitQuizResults();
               var x = new StudentHome(name,username);
               x.StartPosition = FormStartPosition.Manual;
               x.Location = this.Location;
               x.Show();
               Visible = false;
            }
         }
         else
         {
            var x = new StudentHome(name, username);
            x.StartPosition = FormStartPosition.Manual;
            x.Location = this.Location;
            x.Show();
            Visible = false;
         }
      }
      private void pictureBox2_Click(object sender, EventArgs e)
      {
         if (QuizInProgress)
         {
            var result = MessageBox.Show("Are you sure you want to end your quiz? Your progress will be submitted.", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
               SubmitQuizResults();
               Application.Exit();
            }
         }
         else
         {
            var x = new StudentLogin();
            Application.Exit();
         }
      }
      private void ShowNonBlockingMessage(string message, string title)
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


      private bool HasActiveRequest(string username)
      {
         SqlConnection conn = new SqlConnection(connectionString);
         conn.Open();
         string checkRequestQuery = "SELECT HasActiveRequest FROM StudentsAccounts WHERE Username = @Username";
         SqlCommand checkCmd = new SqlCommand(checkRequestQuery, conn);
         checkCmd.Parameters.AddWithValue("@Username", username);
         bool hasActiveRequest = Convert.ToBoolean(checkCmd.ExecuteScalar());
         conn.Close();
         return hasActiveRequest;
      }
      private int MakeNewRequest(string username)
      {
         int studentID = getstudentid(username);
         SqlConnection conn = new SqlConnection(connectionString);
         conn.Open();

         string insertRequestQuery = "INSERT INTO QuizRequests (StudentID) OUTPUT INSERTED.RequestID VALUES (@StudentID)";
         SqlCommand insertCmd = new SqlCommand(insertRequestQuery, conn);
         insertCmd.Parameters.AddWithValue("@StudentID", studentID);
         int requestID = (int)insertCmd.ExecuteScalar();

         string updateStudentQuery = "UPDATE StudentsAccounts SET HasActiveRequest = 1 WHERE StudentID = @StudentID";
         SqlCommand updateCmd = new SqlCommand(updateStudentQuery, conn);
         updateCmd.Parameters.AddWithValue("@StudentID", studentID);

         updateCmd.ExecuteNonQuery();
         conn.Close();
         return requestID;
      }
      private bool isQuizAccepted(int requestID)
      {
         SqlConnection conn = new SqlConnection(connectionString);
         conn.Open();

         string checkStatusQuery = "SELECT Status FROM QuizRequests WHERE RequestID = @RequestID AND Status = 'Accepted'";
         SqlCommand statusCmd = new SqlCommand(checkStatusQuery, conn);
         statusCmd.Parameters.AddWithValue("@RequestID", requestID);

         object result = statusCmd.ExecuteScalar();
         conn.Close();
         if (result == null)
            return false;
         return true;
      }
      private void RejectRequest(int requestID)
      {
         SqlConnection conn = new SqlConnection(connectionString);
         conn.Open();

         string rejectRequestQuery = "UPDATE QuizRequests SET Status = 'Rejected' WHERE RequestID = @RequestID";
         SqlCommand rejectCmd = new SqlCommand(rejectRequestQuery, conn);
         rejectCmd.Parameters.AddWithValue("@RequestID", requestID);

         string resetStudentQuery = "UPDATE StudentsAccounts SET HasActiveRequest = 0 WHERE Username = @Username";
         SqlCommand resetCmd = new SqlCommand(resetStudentQuery, conn);
         resetCmd.Parameters.AddWithValue("@Username", username);

         rejectCmd.ExecuteNonQuery();
         resetCmd.ExecuteNonQuery();
         conn.Close();
      }
      private void EndRequest(string username)
      {
         SqlConnection conn = new SqlConnection(connectionString);
         conn.Open();

         string resetStudentQuery = "UPDATE StudentsAccounts SET HasActiveRequest = 0 WHERE Username = @Username";
         SqlCommand resetCmd = new SqlCommand(resetStudentQuery, conn);
         resetCmd.Parameters.AddWithValue("@Username", username);

         resetCmd.ExecuteNonQuery();
         conn.Close();
      }

      private void TakeQuizClick(object sender, EventArgs e)
      {
         if (!QuizInProgress)
         {
            if (!HasActiveRequest(username))
            {
               SetControlsEnabled(false);

               int requestID = MakeNewRequest(username);
               ShowNonBlockingMessage("Quiz Requested! Waiting for acceptance...", "Request Sent");

               Task.Run(() =>
               {
                  int elapsedSeconds = 0;
                  const int maxWaitTime = 10; 

                  while (elapsedSeconds < maxWaitTime)
                  {
                     if (isQuizAccepted(requestID))
                     {
                        this.Invoke(new Action(async () =>
                        {
                           ShowNonBlockingMessage("Quiz Accepted! Starting in 5 seconds.", "Accepted");

                           await Task.Delay(5000); 
                           SetControlsEnabled(true);
                           StartQuiz();
                        }));
                        return; 
                     }

                     Thread.Sleep(1000); 
                     elapsedSeconds++;
                  }

                  this.Invoke(new Action(() =>
                  {
                     RejectRequest(requestID);
                     ShowNonBlockingMessage("Quiz not Accepted! Try Again Later.", "Declined");

                     var autoCloseTimer = new System.Windows.Forms.Timer
                     {
                        Interval = 2000
                     };
                     autoCloseTimer.Tick += (s, args) =>
                     {
                        autoCloseTimer.Stop();
                        autoCloseTimer.Dispose();

                        var studentHome = new StudentHome(name, username)
                        {
                           StartPosition = FormStartPosition.Manual,
                           Location = this.Location
                        };
                        studentHome.Show();

                        this.Close();
                     };
                     autoCloseTimer.Start();
                  }));
               });
            }
            else
            {
               ShowNonBlockingMessage("Quiz has already been requested or started", "Try Again Later");
            }
         }
         else
         {
            Request.Enabled = false;
            SubmitQuizResults();
         }
      }

      private void SetControlsEnabled(bool enabled)
      {
         this.Invoke(new Action(() =>
         {
            Request.Enabled = enabled;
            Back.Enabled = enabled;
            pictureBox2.Enabled = enabled;
         }));
      }



      private void StartQuiz()
      {
         pictureBox1.Visible = false;
         QuizInProgress = true;
         Request.Text = "Submit Quiz";
         remainingtime = 120;
         timer.Text = "2:00";
         timer.Visible = true;
         timerpic.Visible = true;
         flowLayoutPanel1.Visible = true;
         flowLayoutPanel1.BringToFront();
         quizTimer.Start();

         questions = GetRandomQuestions(5);
         if (questions.Count == 0)
         {
            MessageBox.Show("No questions availlable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         flowLayoutPanel1.Controls.Clear();
         int i = 1;
         foreach (var question in questions)
         {
            AddQuestionToUI(question, i);
            i++;
         }
      }
      private void QuizTimer_Tick(object sender, EventArgs e)
      {
         if (!QuizInProgress) return;

         remainingtime--;
         int minutes = remainingtime / 60;
         int seconds = remainingtime % 60;
         timer.Text = $"{minutes:D2}:{seconds:D2}";

         if (remainingtime <= 0)
         {
            Request.Enabled = false;
            quizTimer.Stop();
            quizTimer.Dispose();
            ShowNonBlockingMessage("Time's up! Quiz submitted automatically.", "Time's Up");
            f = false;
            SubmitQuizResults();
         }
      }


      private void AddQuestionToUI(Question question, int index)
      {
         var questionLabel = new Label
         {
            Text = $"Q{index}. {question.Text}",
            AutoSize = true,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Arial", 12, FontStyle.Bold),
            Margin = new Padding(0, 10, 0, 5)
         };

         flowLayoutPanel1.Controls.Add(questionLabel);

         var optionsPanel = new FlowLayoutPanel
         {
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Font = new Font("Arial", 12, FontStyle.Bold),
            Margin = new Padding(0, 5, 0, 10)
         };

         for (int i = 0; i < question.Options.Length; i++)
         {
            var radioButton = new RadioButton
            {
               Text = $" {question.Options[i]}",
               Tag = new { QuestionID = question.ID, OptionIndex = i },
               AutoSize = true,
               Font = new Font("Arial", 10, FontStyle.Bold),
               Padding = new Padding(5)
            };
            radioButton.CheckedChanged += RadioButton_CheckedChanged;
            optionsPanel.Controls.Add(radioButton);
         }
         flowLayoutPanel1.Controls.Add(optionsPanel);
      }


      private void RadioButton_CheckedChanged(object sender, EventArgs e)
      {
         var radioButton = sender as RadioButton;
         if (radioButton != null && radioButton.Checked)
         {
            var tag = (dynamic)radioButton.Tag;
            int questionID = tag.QuestionID;
            int selectedOption = tag.OptionIndex;
            studentAnswers[questionID] = selectedOption;
         }
      }
      private List<Question> GetRandomQuestions(int numberOfQuestions)
      {
         var questions = new List<Question>();

         string query = $"SELECT TOP {numberOfQuestions} * FROM Questions ORDER BY NEWID()";

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
               using (SqlDataReader reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     questions.Add(new Question
                     {
                        ID = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        Options = new[]
                         {
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6)
                        },
                        CorrectAnswerIndex = reader.GetInt32(2)
                     });
                  }
               }
            }
         }
         return questions;
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
      private void SubmitQuizResults()
      {
         if (!QuizInProgress) return;
         QuizInProgress = false;
         quizTimer.Stop();       
         quizTimer.Dispose();  

         int studentID = getstudentid(username);
         int quizID;

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            connection.Open();

            string insertQuizQuery = "INSERT INTO Quizzes (StudentID) OUTPUT INSERTED.QuizID VALUES (@StudentID)";
            using (SqlCommand cmd = new SqlCommand(insertQuizQuery, connection))
            {
               cmd.Parameters.AddWithValue("@StudentID", studentID);
               quizID = (int)cmd.ExecuteScalar();
            }
            string insertAnswerQuery = "INSERT INTO QuizQuestions (QuizID, QuestionID, StudentAnswer) VALUES (@QuizID, @QuestionID, @StudentAnswer)";
            foreach (var question in questions) 
            {
               int selectedAnswer = studentAnswers.ContainsKey(question.ID) ? studentAnswers[question.ID] : -1;

               using (SqlCommand cmd = new SqlCommand(insertAnswerQuery, connection))
               {
                  cmd.Parameters.AddWithValue("@QuizID", quizID);
                  cmd.Parameters.AddWithValue("@QuestionID", question.ID);

                  if (selectedAnswer == -1)
                  {
                     cmd.Parameters.AddWithValue("@StudentAnswer", DBNull.Value);
                  }
                  else
                  {
                     cmd.Parameters.AddWithValue("@StudentAnswer", selectedAnswer);
                  }

                  cmd.ExecuteNonQuery();
               }
            }

         }
         this.Invoke(new Action(() =>
         { 
            if (f)
               ShowNonBlockingMessage("Your quiz has been submitted successfully.", "Quiz Submitted");
            EndRequest(username);
            var autoCloseTimer = new System.Windows.Forms.Timer
            {
               Interval = 2000
            };
            autoCloseTimer.Tick += (s, args) =>
            {
               autoCloseTimer.Stop();
               autoCloseTimer.Dispose();

               var studentHome = new StudentHome(name, username)
               {
                  StartPosition = FormStartPosition.Manual,
                  Location = this.Location
               };
               studentHome.Show();

               this.Close();
            };
            autoCloseTimer.Start();
         }));
      }

      private void TakeQuiz_Load(object sender, EventArgs e)
      {
         pictureBox1.Visible = true;
         flowLayoutPanel1.Visible = false;
         pictureBox1.BringToFront();
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