using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MathMind
{
   public partial class StudentLogin : Form
   {
      string connectionString = ConfigHelper.GetConnectionString();

      public StudentLogin()
      {
         InitializeComponent();
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
         var x = new HomePage();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void ShowPass_CheckedChanged(object sender, EventArgs e)
      {
         tPass.UseSystemPasswordChar = !ShowPass.Checked;
      }

      private void RegisterB_Click(object sender, EventArgs e)
      {
         var x = new StudentRegister();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }
      Client Client = new Client();
      private void LoginB_Click(object sender, EventArgs e)
      {
         string username = tUser.Text;
         string password = tPass.Text;
         if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
         {
            MessageBox.Show("Please Fill in All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else
         {
            //Client.ConnectToServer();
            //string response = Client.SendMessage($"LOGIN|{username}|{password}");
            //MessageBox.Show(response);
            //Client.Disconnect();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               string query = "SELECT FullName FROM StudentsAccounts WHERE Username = @Username AND Password = @Password";
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.AddWithValue("@Username", username);
               command.Parameters.AddWithValue("@Password", password);

               try
               {
                  connection.Open();
                  object result = command.ExecuteScalar();
                  if (result != null)
                  {
                     MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     string Name = result.ToString();
                     var x = new StudentHome(Name, username);
                     x.StartPosition = FormStartPosition.Manual;
                     x.Location = this.Location;
                     x.Show();
                     Visible = false;
                  }
                  else
                  {
                     MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show($"Error: {ex.Message}");
               }
            }
         }
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
          Application.Exit();
      }
   }
}
