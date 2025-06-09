namespace MathMind
{
   partial class StudentEditProfile
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEditProfile));
         Title = new Label();
         Slogan = new Label();
         Back = new PictureBox();
         pictureBox2 = new PictureBox();
         pictureBox1 = new PictureBox();
         EditProfile = new Label();
         Finish = new Button();
         FullName = new TextBox();
         Username = new TextBox();
         ShowPass = new CheckBox();
         Pass = new TextBox();
         Email = new TextBox();
         RemovePic = new Label();
         ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
         SuspendLayout();
         // 
         // Title
         // 
         Title.AutoSize = true;
         Title.BackColor = Color.Transparent;
         Title.Font = new Font("Jokerman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Title.ForeColor = Color.LightBlue;
         Title.Location = new Point(193, 9);
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
         Slogan.Location = new Point(158, 91);
         Slogan.Name = "Slogan";
         Slogan.Size = new Size(444, 40);
         Slogan.TabIndex = 13;
         Slogan.Text = "Where Math Meets Mastery";
         // 
         // Back
         // 
         Back.BackColor = Color.White;
         Back.BackgroundImage = Properties.Resources.Back;
         Back.BackgroundImageLayout = ImageLayout.Stretch;
         Back.Image = Properties.Resources.Back;
         Back.Location = new Point(1, 1);
         Back.Name = "Back";
         Back.Size = new Size(39, 29);
         Back.TabIndex = 23;
         Back.TabStop = false;
         Back.Click += Back_Click;
         // 
         // pictureBox2
         // 
         pictureBox2.BackColor = Color.Transparent;
         pictureBox2.Image = Properties.Resources.pngegg__1_;
         pictureBox2.Location = new Point(729, 1);
         pictureBox2.Name = "pictureBox2";
         pictureBox2.Size = new Size(48, 37);
         pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox2.TabIndex = 26;
         pictureBox2.TabStop = false;
         pictureBox2.Click += pictureBox2_Click;
         // 
         // pictureBox1
         // 
         pictureBox1.BackColor = Color.Transparent;
         pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
         pictureBox1.Image = Properties.Resources.DefaultPP;
         pictureBox1.Location = new Point(4, 132);
         pictureBox1.Name = "pictureBox1";
         pictureBox1.Size = new Size(286, 228);
         pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox1.TabIndex = 28;
         pictureBox1.TabStop = false;
         // 
         // EditProfile
         // 
         EditProfile.AutoSize = true;
         EditProfile.BackColor = Color.Transparent;
         EditProfile.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold | FontStyle.Underline);
         EditProfile.ForeColor = Color.Cyan;
         EditProfile.Location = new Point(12, 372);
         EditProfile.Name = "EditProfile";
         EditProfile.Size = new Size(176, 32);
         EditProfile.TabIndex = 29;
         EditProfile.Text = "Change Picture";
         EditProfile.Click += EditProfile_Click;
         // 
         // Finish
         // 
         Finish.BackColor = Color.Cyan;
         Finish.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Finish.ForeColor = Color.Black;
         Finish.Location = new Point(321, 395);
         Finish.Name = "Finish";
         Finish.Size = new Size(217, 53);
         Finish.TabIndex = 19;
         Finish.Text = "Finish";
         Finish.UseVisualStyleBackColor = false;
         Finish.Click += FinishClick;
         // 
         // FullName
         // 
         FullName.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         FullName.ForeColor = Color.Black;
         FullName.Location = new Point(315, 158);
         FullName.Name = "FullName";
         FullName.PlaceholderText = "Full Name";
         FullName.Size = new Size(266, 46);
         FullName.TabIndex = 34;
         // 
         // Username
         // 
         Username.Enabled = false;
         Username.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Username.ForeColor = Color.Black;
         Username.Location = new Point(315, 262);
         Username.Name = "Username";
         Username.PlaceholderText = "Username";
         Username.ReadOnly = true;
         Username.Size = new Size(266, 46);
         Username.TabIndex = 33;
         // 
         // ShowPass
         // 
         ShowPass.AutoSize = true;
         ShowPass.BackColor = Color.Transparent;
         ShowPass.Font = new Font("Cooper Black", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
         ShowPass.ForeColor = Color.Gold;
         ShowPass.Location = new Point(544, 359);
         ShowPass.Name = "ShowPass";
         ShowPass.Size = new Size(223, 30);
         ShowPass.TabIndex = 32;
         ShowPass.Text = "Show Password";
         ShowPass.UseVisualStyleBackColor = false;
         ShowPass.CheckedChanged += ShowPass_CheckedChanged;
         // 
         // Pass
         // 
         Pass.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Pass.ForeColor = Color.Black;
         Pass.Location = new Point(315, 314);
         Pass.Name = "Pass";
         Pass.PlaceholderText = "Password";
         Pass.Size = new Size(266, 46);
         Pass.TabIndex = 31;
         Pass.UseSystemPasswordChar = true;
         // 
         // Email
         // 
         Email.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Email.ForeColor = Color.Black;
         Email.Location = new Point(315, 210);
         Email.Name = "Email";
         Email.PlaceholderText = "Email";
         Email.Size = new Size(266, 46);
         Email.TabIndex = 30;
         // 
         // RemovePic
         // 
         RemovePic.AutoSize = true;
         RemovePic.BackColor = Color.Transparent;
         RemovePic.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold | FontStyle.Underline);
         RemovePic.ForeColor = Color.FromArgb(255, 128, 128);
         RemovePic.Location = new Point(12, 411);
         RemovePic.Name = "RemovePic";
         RemovePic.Size = new Size(174, 32);
         RemovePic.TabIndex = 35;
         RemovePic.Text = "Remove Picture";
         RemovePic.Click += RemovePic_Click;
         // 
         // StudentEditProfile
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Indigo;
         BackgroundImage = Properties.Resources.Walpaper;
         ClientSize = new Size(779, 460);
         Controls.Add(RemovePic);
         Controls.Add(FullName);
         Controls.Add(Username);
         Controls.Add(ShowPass);
         Controls.Add(Pass);
         Controls.Add(Email);
         Controls.Add(EditProfile);
         Controls.Add(pictureBox1);
         Controls.Add(pictureBox2);
         Controls.Add(Back);
         Controls.Add(Finish);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.Blue;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "StudentEditProfile";
         Text = "MathMind";
         Load += StudentEditProfile_Load;
         ((System.ComponentModel.ISupportInitialize)Back).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private PictureBox Back;
      private PictureBox pictureBox2;
      private PictureBox pictureBox1;
      private Label EditProfile;
      private Button Finish;
      public TextBox FullName;
      public TextBox Username;
      private CheckBox ShowPass;
      private TextBox Pass;
      public TextBox Email;
      private Label RemovePic;
   }
}
