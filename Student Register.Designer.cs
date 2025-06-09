namespace MathMind
{
   partial class StudentRegister
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentRegister));
         Title = new Label();
         Slogan = new Label();
         ShowPass = new CheckBox();
         Pass = new TextBox();
         Email = new TextBox();
         Create = new Button();
         Back = new PictureBox();
         Username = new TextBox();
         FullName = new TextBox();
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
         Title.Location = new Point(164, 9);
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
         Slogan.Location = new Point(126, 82);
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
         ShowPass.Location = new Point(478, 305);
         ShowPass.Name = "ShowPass";
         ShowPass.Size = new Size(223, 30);
         ShowPass.TabIndex = 22;
         ShowPass.Text = "Show Password";
         ShowPass.UseVisualStyleBackColor = true;
         ShowPass.CheckedChanged += ShowPass_CheckedChanged;
         // 
         // Pass
         // 
         Pass.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Pass.ForeColor = Color.Black;
         Pass.Location = new Point(206, 280);
         Pass.Name = "Pass";
         Pass.PlaceholderText = "Password";
         Pass.Size = new Size(266, 46);
         Pass.TabIndex = 21;
         Pass.UseSystemPasswordChar = true;
         // 
         // Email
         // 
         Email.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Email.ForeColor = Color.Black;
         Email.Location = new Point(206, 176);
         Email.Name = "Email";
         Email.PlaceholderText = "Email";
         Email.Size = new Size(266, 46);
         Email.TabIndex = 20;
         // 
         // Create
         // 
         Create.BackColor = Color.Green;
         Create.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Create.ForeColor = Color.AliceBlue;
         Create.Location = new Point(246, 336);
         Create.Name = "Create";
         Create.Size = new Size(197, 54);
         Create.TabIndex = 19;
         Create.Text = "Create";
         Create.UseVisualStyleBackColor = false;
         Create.Click += Create_Click;
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
         // Username
         // 
         Username.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Username.ForeColor = Color.Black;
         Username.Location = new Point(206, 228);
         Username.Name = "Username";
         Username.PlaceholderText = "Username";
         Username.Size = new Size(266, 46);
         Username.TabIndex = 24;
         // 
         // FullName
         // 
         FullName.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         FullName.ForeColor = Color.Black;
         FullName.Location = new Point(206, 124);
         FullName.Name = "FullName";
         FullName.PlaceholderText = "Full Name";
         FullName.Size = new Size(266, 46);
         FullName.TabIndex = 25;
         // 
         // pictureBox1
         // 
         pictureBox1.BackColor = Color.Transparent;
         pictureBox1.Image = Properties.Resources.pngegg__1_;
         pictureBox1.Location = new Point(657, 9);
         pictureBox1.Name = "pictureBox1";
         pictureBox1.Size = new Size(48, 37);
         pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox1.TabIndex = 26;
         pictureBox1.TabStop = false;
         pictureBox1.Click += pictureBox1_Click;
         // 
         // StudentRegister
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Black;
         BackgroundImage = Properties.Resources.Walp;
         ClientSize = new Size(726, 412);
         Controls.Add(pictureBox1);
         Controls.Add(FullName);
         Controls.Add(Username);
         Controls.Add(Back);
         Controls.Add(ShowPass);
         Controls.Add(Pass);
         Controls.Add(Email);
         Controls.Add(Create);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.Blue;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "StudentRegister";
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
      private TextBox Pass;
      public TextBox Email;
      private Button Create;
      private PictureBox Back;
      public TextBox Username;
      public TextBox FullName;
      private PictureBox pictureBox1;
   }
}
