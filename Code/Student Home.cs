using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MathMind
{
   public partial class StudentHome : Form
   {
      private string studentName;
      private string username;
      string connectionString = ConfigHelper.GetConnectionString();

      public StudentHome(string studentName, string username)
      {
         InitializeComponent();
         this.studentName = studentName;
         this.username = username;
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
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
      private void Back_Click(object sender, EventArgs e)
      {
         var x = new StudentLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }


      private void ViewGradesClick(object sender, EventArgs e)
      {
         var x = new ViewGrades(studentName,username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void TakeQuizClick(object sender, EventArgs e)
      {
         var x = new TakeQuiz(studentName,username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void EditProfile_Click(object sender, EventArgs e)
      {
         var x = new StudentEditProfile(username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void StudentHome_Load(object sender, EventArgs e)
      {
         Welcome.Text = $"Welcome,{studentName}";
         LoadProfilePicture(username);
      }

      private void LoadProfilePicture(string username)
      {
         string query = "SELECT ProfilePicture FROM StudentsAccounts WHERE Username = @Username";
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);

            conn.Open();
            byte[] imageBytes = cmd.ExecuteScalar() as byte[];

            if (imageBytes != null)
            {
               using (MemoryStream ms = new MemoryStream(imageBytes))
               {
                  PFP.Image = Image.FromStream(ms);
               }
            }
            else
            {
               PFP.Image = Properties.Resources.DefaultPP;
            }
         }
      }
   }
}
