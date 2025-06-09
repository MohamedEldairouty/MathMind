using System.Windows.Forms;

namespace MathMind
{
   partial class ExaminerLogin
   {
      private System.ComponentModel.IContainer components = null;

      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExaminerLogin));
         Title = new Label();
         Slogan = new Label();
         ShowPass = new CheckBox();
         tPass = new TextBox();
         tUser = new TextBox();
         LoginB = new Button();
         Back = new PictureBox();
         pictureBox1 = new PictureBox();
         ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
         SuspendLayout();
         // 
         // Title
         // 
         Title.AutoSize = true;
         Title.BackColor = Color.Transparent;
         Title.Font = new Font("Jokerman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Title.ForeColor = Color.LightBlue;
         Title.Location = new Point(164, 38);
         Title.Name = "Title";
         Title.Size = new Size(365, 88);
         Title.TabIndex = 1;
         Title.Text = "Math Mind";
         Title.TextAlign = ContentAlignment.MiddleCenter;
         // 
         // Slogan
         // 
         Slogan.AutoSize = true;
         Slogan.BackColor = Color.Transparent;
         Slogan.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
         Slogan.ForeColor = Color.FromArgb(255, 128, 128);
         Slogan.Location = new Point(126, 113);
         Slogan.Name = "Slogan";
         Slogan.Size = new Size(444, 40);
         Slogan.TabIndex = 13;
         Slogan.Text = "Where Math Meets Mastery";
         // 
         // ShowPass
         // 
         ShowPass.AutoSize = true;
         ShowPass.Font = new Font("Cooper Black", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
         ShowPass.ForeColor = Color.Gold;
         ShowPass.Location = new Point(473, 299);
         ShowPass.Name = "ShowPass";
         ShowPass.Size = new Size(223, 30);
         ShowPass.TabIndex = 22;
         ShowPass.Text = "Show Password";
         ShowPass.UseVisualStyleBackColor = true;
         ShowPass.CheckedChanged += ShowPass_CheckedChanged;
         // 
         // tPass
         // 
         tPass.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         tPass.ForeColor = Color.Black;
         tPass.Location = new Point(200, 228);
         tPass.Name = "tPass";
         tPass.PlaceholderText = "Enter Password";
         tPass.Size = new Size(266, 46);
         tPass.TabIndex = 21;
         tPass.UseSystemPasswordChar = true;
         // 
         // tUser
         // 
         tUser.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         tUser.ForeColor = Color.Black;
         tUser.Location = new Point(200, 165);
         tUser.Name = "tUser";
         tUser.PlaceholderText = "Enter Username";
         tUser.Size = new Size(266, 46);
         tUser.TabIndex = 20;
         // 
         // LoginB
         // 
         LoginB.BackColor = Color.Green;
         LoginB.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         LoginB.ForeColor = Color.AliceBlue;
         LoginB.Location = new Point(249, 324);
         LoginB.Name = "LoginB";
         LoginB.Size = new Size(189, 54);
         LoginB.TabIndex = 19;
         LoginB.Text = "Login";
         LoginB.UseVisualStyleBackColor = false;
         LoginB.Click += LoginB_Click;
         // 
         // Back
         // 
         Back.BackColor = SystemColors.Window;
         Back.BackgroundImage = Properties.Resources.Back;
         Back.BackgroundImageLayout = ImageLayout.Stretch;
         Back.Image = Properties.Resources.Back;
         Back.Location = new Point(12, 12);
         Back.Name = "Back";
         Back.Size = new Size(39, 29);
         Back.TabIndex = 23;
         Back.TabStop = false;
         Back.Click += Back_Click;
         // 
         // pictureBox1
         // 
         pictureBox1.BackColor = Color.Transparent;
         pictureBox1.Image = Properties.Resources.pngegg__1_;
         pictureBox1.Location = new Point(658, 12);
         pictureBox1.Name = "pictureBox1";
         pictureBox1.Size = new Size(48, 37);
         pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox1.TabIndex = 24;
         pictureBox1.TabStop = false;
         pictureBox1.Click += pictureBox1_Click;
         // 
         // ExaminerLogin
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Black;
         BackgroundImage = Properties.Resources.Walp;
         ClientSize = new Size(728, 415);
         Controls.Add(pictureBox1);
         Controls.Add(Back);
         Controls.Add(ShowPass);
         Controls.Add(tPass);
         Controls.Add(tUser);
         Controls.Add(LoginB);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.Blue;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "ExaminerLogin";
         Text = "MathMind";
         ((System.ComponentModel.ISupportInitialize)Back).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private CheckBox ShowPass;
      private TextBox tPass;
      public TextBox tUser;
      private Button LoginB;
      private PictureBox Back;
      private PictureBox pictureBox1;
   }
}
