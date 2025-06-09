using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MathMind
{
   public partial class QuizReview : Form
   {
      private string username;
      private int QuizID;
      private string name;
      private List<Question> questions;
      string connectionString = ConfigHelper.GetConnectionString();


      public QuizReview(string name,string username, int QuizID)
      {
         InitializeComponent();
         this.username = username;
         this.QuizID = QuizID;
         this.name = name;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         questions = GetQuizQuestions(QuizID);
         flowLayoutPanel1.Controls.Clear();
         int i = 1;
         foreach (var question in questions)
         {
            AddQuestionToUI(question, i);
            i++;
         }

      }
      private List<Question> GetQuizQuestions(int quizID)
      {
         var questions = new List<Question>();
         string query = @"
        SELECT 
            QQ.QuestionID, 
            Q.QuestionText, 
            Q.OptionA, Q.OptionB, Q.OptionC, Q.OptionD, 
            Q.CorrectAnswer, 
            QQ.StudentAnswer
        FROM QuizQuestions QQ
        INNER JOIN Questions Q ON QQ.QuestionID = Q.QuestionID
        WHERE QQ.QuizID = @QuizID";

         using (var connection = new SqlConnection(connectionString))
         using (var command = new SqlCommand(query, connection))
         {
            command.Parameters.AddWithValue("@QuizID", quizID);
            connection.Open();

            using (var reader = command.ExecuteReader())
            {
               while (reader.Read())
               {
                  var correctAnswerIndex = reader.GetInt32(6);
                  var studentAnswerIndex = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7);

                  var question = new Question
                  {
                     ID = reader.GetInt32(0), 
                     Text = reader.GetString(1),
                     Options = new string[]
                      {
                        reader.GetString(2), 
                        reader.GetString(3),
                        reader.GetString(4), 
                        reader.GetString(5) 
                      },
                     CorrectAnswerIndex = correctAnswerIndex,
                     StudentAnswerIndex = studentAnswerIndex,
                     IsCorrect = studentAnswerIndex.HasValue
                                  ? studentAnswerIndex == correctAnswerIndex
                                  : (bool?)null
                  };

                  questions.Add(question);
               }
            }
         }

         return questions;
      }

      private void Logout(object sender, EventArgs e)
      {
         var x = new ViewGrades(name, username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }
      private void pictureBox2_Click(object sender, EventArgs e)
      {
         Application.Exit();

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
               Text = question.Options[i],
               Tag = i, 
               AutoSize = true,
               Font = new Font("Arial", 10, FontStyle.Regular),
               Padding = new Padding(5)
            };

            radioButton.Click += (s, e) => ((RadioButton)s).Checked = false;

            if (question.StudentAnswerIndex.HasValue && question.StudentAnswerIndex == i)
            {
               radioButton.Font = new Font("Arial", 10, FontStyle.Bold);
               radioButton.ForeColor = Color.Red;
            }

            if (i == question.CorrectAnswerIndex)
            {
               radioButton.Font = new Font("Arial", 10, FontStyle.Bold);
               radioButton.ForeColor = Color.Green;
            }
            if (!question.StudentAnswerIndex.HasValue && i == question.CorrectAnswerIndex)
            {
               radioButton.Font = new Font("Arial", 10, FontStyle.Bold);
               radioButton.ForeColor = Color.Red;
            }

            optionsPanel.Controls.Add(radioButton);
         }

         flowLayoutPanel1.Controls.Add(optionsPanel);
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