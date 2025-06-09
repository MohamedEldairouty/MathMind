using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MathMind
{
   public partial class ExaminerHome : Form
   {
      private string name;
      private string username;
      string connectionString = ConfigHelper.GetConnectionString();

      public ExaminerHome(string name, string username)
      {
         InitializeComponent();
         this.name = name;
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
         var x = new ExaminerLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }


      private void RequestsManage(object sender, EventArgs e)
      {
         var x = new ManageRequests(name, username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void QuestionsManage(object sender, EventArgs e)
      {
         var x = new Managequestions(name, username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void GradingManage(object sender, EventArgs e)
      {
         var x = new ManageGrades(name, username);
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
         var x = new ExaminerEditProfile(username);
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void StudentHome_Load(object sender, EventArgs e)
      {
         Welcome.Text = $"Welcome,{name}";
         LoadProfilePicture(username);
      }

      private void LoadProfilePicture(string username)
      {
         string query = "SELECT ProfilePicture FROM ExaminerAccounts WHERE Username = @Username";
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
      //Server Server = new Server();
      //private void server_Click(object sender, EventArgs e)
      //{
      //   Server.StartServer();
      //   MessageBox.Show("Server started");
      //}
   }
}
