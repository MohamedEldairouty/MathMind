using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MathMind
{
   public partial class StudentRegister : Form
   {
      string connectionString = ConfigHelper.GetConnectionString();

      public StudentRegister()
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
         var x = new StudentLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;

      }

      private void ShowPass_CheckedChanged(object sender, EventArgs e)
      {
         Pass.UseSystemPasswordChar = !ShowPass.Checked;
      }
      private bool isexists(string username)
      {

         using (SqlConnection connection = new SqlConnection(connectionString))
         {
            string query = "SELECT COUNT(*) FROM StudentsAccounts WHERE Username = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);

            try
            {
               connection.Open();
               int count = (int)command.ExecuteScalar();
               return count > 0; 
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error checking account existence: {ex.Message}");
               return false;
            }
         }
      }
      private void Create_Click(object sender, EventArgs e)
      {
         string username = Username.Text;
         string password = Pass.Text;
         string email = Email.Text;
         string Name = FullName.Text;
         if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(Name))
         {
            MessageBox.Show("Please Fill in All Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else if (isexists(username)) 
         {
            MessageBox.Show("Acoount with this Username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else
         {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               string query = "INSERT INTO StudentsAccounts (Username, Password, FullName, Email) VALUES (@Username, @Password, @FullName, @Email)";
               SqlCommand command = new SqlCommand(query, connection);
               command.Parameters.AddWithValue("@Username", username);
               command.Parameters.AddWithValue("@Password", password);
               command.Parameters.AddWithValue("@FullName", Name);
               command.Parameters.AddWithValue("@Email", email);

               try
               {
                  connection.Open();
                  command.ExecuteNonQuery();
                  MessageBox.Show("Account Created Successfully!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  var x = new StudentHome(Name,username);
                  x.StartPosition = FormStartPosition.Manual;
                  x.Location = this.Location;
                  x.Show();
                  Visible = false;
               }
               catch (Exception ex)
               {
                  MessageBox.Show($"Error: {ex.Message}");
               }
            }
         }
      }

      private void pictureBox1_Click(object sender, EventArgs e)
      {
          Application.Exit();
      }
   }
}
