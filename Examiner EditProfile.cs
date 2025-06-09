using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace MathMind
{
   public partial class ExaminerEditProfile : Form
   {
      private string username;
      private Image selectedImage;
      private bool isDefaultImage = false;
      string connectionString = ConfigHelper.GetConnectionString();

      public ExaminerEditProfile(string username)
      {
         InitializeComponent();
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
      private void StudentEditProfile_Load(object sender, EventArgs e)
      {
         LoadProfilePicture(username);
         Username.Text = username;
         LoadProfileData();
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
                  pictureBox1.Image = Image.FromStream(ms);
                  selectedImage = pictureBox1.Image; 
                  isDefaultImage = false;
               }
            }
            else
            {
               pictureBox1.Image = Properties.Resources.DefaultPP;
               selectedImage = pictureBox1.Image; 
               isDefaultImage = true;
            }
         }
      }

      private void LoadProfileData()
      {
         string query = "SELECT FullName, Email, Password FROM ExaminerAccounts WHERE Username = @Username";
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               if (reader.Read())
               {
                  FullName.Text = reader["FullName"].ToString();
                  Email.Text = reader["Email"].ToString();
                  Pass.Text = reader["Password"].ToString();
               }
            }
         }
      }

      private void EditProfile_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "Image Files|.jpg;.jpeg;.png;.bmp;.gif|All Files|.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               try
               {
                  pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                  selectedImage = pictureBox1.Image; 
                  isDefaultImage = false; 
               }
               catch (Exception ex)
               {
                  MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
      }

      private void RemovePic_Click(object sender, EventArgs e)
      {
         if (isDefaultImage)
         {
            MessageBox.Show("No Profile Picture to Remove", "No Profile Picture", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         pictureBox1.Image = Properties.Resources.DefaultPP;
         selectedImage = pictureBox1.Image;
         isDefaultImage = true;
      }

      private void FinishClick(object sender, EventArgs e)
      {
         string name = FullName.Text;
         string email = Email.Text;
         string password = Pass.Text;

         string query = "UPDATE ExaminerAccounts SET FullName = @FullName, Email = @Email, Password = @Password, ProfilePicture = @ProfilePicture WHERE Username = @Username";

         try
         {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand(query, conn);

               cmd.Parameters.AddWithValue("@FullName", name);
               cmd.Parameters.AddWithValue("@Email", email);
               cmd.Parameters.AddWithValue("@Password", password);
               cmd.Parameters.AddWithValue("@Username", username);

               if (isDefaultImage || pictureBox1.Image == null)
               {
                  cmd.Parameters.Add("@ProfilePicture", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
               }
               else
               {
                  using (MemoryStream ms = new MemoryStream())
                  {
                     selectedImage.Save(ms, selectedImage.RawFormat);
                     cmd.Parameters.Add("@ProfilePicture", System.Data.SqlDbType.VarBinary).Value = ms.ToArray();
                  }
               }

               conn.Open();
               cmd.ExecuteNonQuery();
               MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               var home = new ExaminerHome(name, username);
               home.StartPosition = FormStartPosition.Manual;
               home.Location = this.Location;
               home.Show();
               this.Close();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("An error occurred while updating the profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Back_Click(object sender, EventArgs e)
      {
         string name = GetName(username);
         var home = new ExaminerHome(name, username);
         home.StartPosition = FormStartPosition.Manual;
         home.Location = this.Location;
         home.Show();
         this.Close();
      }

      private string GetName(string username)
      {
         string name = string.Empty;
         string query = "SELECT FullName FROM ExaminerAccounts WHERE Username = @Username";

         try
         {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand(query, conn);
               cmd.Parameters.AddWithValue("@Username", username);

               conn.Open();
               object result = cmd.ExecuteScalar();
               if (result != null)
               {
                  name = result.ToString();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("An error occurred while retrieving the name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         return name;
      }

      private void ShowPass_CheckedChanged(object sender, EventArgs e)
      {
         Pass.UseSystemPasswordChar = !ShowPass.Checked;
      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }
   }
}