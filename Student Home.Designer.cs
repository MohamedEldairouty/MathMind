namespace MathMind
{
   partial class StudentHome
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentHome));
         Title = new Label();
         Slogan = new Label();
         TakeQuiz = new Button();
         Back = new PictureBox();
         ViewGrades = new Button();
         pictureBox2 = new PictureBox();
         Welcome = new Label();
         PFP = new PictureBox();
         EditProfile = new Label();
         ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
         ((System.ComponentModel.ISupportInitialize)PFP).BeginInit();
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
         // TakeQuiz
         // 
         TakeQuiz.BackColor = Color.Cyan;
         TakeQuiz.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         TakeQuiz.ForeColor = Color.Black;
         TakeQuiz.Location = new Point(389, 228);
         TakeQuiz.Name = "TakeQuiz";
         TakeQuiz.Size = new Size(311, 54);
         TakeQuiz.TabIndex = 19;
         TakeQuiz.Text = "Take a New Quiz";
         TakeQuiz.UseVisualStyleBackColor = false;
         TakeQuiz.Click += TakeQuizClick;
         // 
         // Back
         // 
         Back.BackColor = Color.Transparent;
         Back.BackgroundImage = Properties.Resources.f;
         Back.BackgroundImageLayout = ImageLayout.Stretch;
         Back.Image = Properties.Resources.f;
         Back.Location = new Point(1, 1);
         Back.Name = "Back";
         Back.Size = new Size(39, 29);
         Back.TabIndex = 23;
         Back.TabStop = false;
         Back.Click += Back_Click;
         // 
         // ViewGrades
         // 
         ViewGrades.BackColor = Color.Cyan;
         ViewGrades.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         ViewGrades.ForeColor = Color.Black;
         ViewGrades.Location = new Point(389, 288);
         ViewGrades.Name = "ViewGrades";
         ViewGrades.Size = new Size(311, 54);
         ViewGrades.TabIndex = 24;
         ViewGrades.Text = "View Grades";
         ViewGrades.UseVisualStyleBackColor = false;
         ViewGrades.Click += ViewGradesClick;
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
         // Welcome
         // 
         Welcome.AutoSize = true;
         Welcome.BackColor = Color.Transparent;
         Welcome.Font = new Font("Script MT Bold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Welcome.ForeColor = Color.Gold;
         Welcome.Location = new Point(12, 131);
         Welcome.Name = "Welcome";
         Welcome.Size = new Size(273, 48);
         Welcome.TabIndex = 27;
         Welcome.Text = "Welcome,Name";
         // 
         // PFP
         // 
         PFP.BackColor = Color.Transparent;
         PFP.BackgroundImageLayout = ImageLayout.Stretch;
         PFP.Image = Properties.Resources.DefaultPP;
         PFP.Location = new Point(12, 182);
         PFP.Name = "PFP";
         PFP.Size = new Size(286, 228);
         PFP.SizeMode = PictureBoxSizeMode.Zoom;
         PFP.TabIndex = 28;
         PFP.TabStop = false;
         // 
         // EditProfile
         // 
         EditProfile.AutoSize = true;
         EditProfile.BackColor = Color.Transparent;
         EditProfile.Font = new Font("Viner Hand ITC", 12F, FontStyle.Bold | FontStyle.Underline);
         EditProfile.ForeColor = Color.Cyan;
         EditProfile.Location = new Point(12, 426);
         EditProfile.Name = "EditProfile";
         EditProfile.Size = new Size(134, 32);
         EditProfile.TabIndex = 29;
         EditProfile.Text = "Edit Profile";
         EditProfile.Click += EditProfile_Click;
         // 
         // StudentHome
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Indigo;
         BackgroundImage = Properties.Resources.Walpaper;
         ClientSize = new Size(779, 460);
         Controls.Add(EditProfile);
         Controls.Add(PFP);
         Controls.Add(Welcome);
         Controls.Add(pictureBox2);
         Controls.Add(ViewGrades);
         Controls.Add(Back);
         Controls.Add(TakeQuiz);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.Blue;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "StudentHome";
         Text = "MathMind";
         Load += StudentHome_Load;
         ((System.ComponentModel.ISupportInitialize)Back).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
         ((System.ComponentModel.ISupportInitialize)PFP).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private Button TakeQuiz;
      private PictureBox Back;
      private Button ViewGrades;
      private PictureBox pictureBox2;
      private Label Welcome;
      private PictureBox PFP;
      private Label EditProfile;
   }
}
