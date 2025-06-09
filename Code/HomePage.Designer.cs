namespace MathMind
{
   partial class HomePage
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
         Title = new Label();
         Slogan = new Label();
         Contin = new Label();
         examinerpic = new PictureBox();
         studentpic = new PictureBox();
         Examiner = new Button();
         Student = new Button();
         pictureBox1 = new PictureBox();
         ((System.ComponentModel.ISupportInitialize)examinerpic).BeginInit();
         ((System.ComponentModel.ISupportInitialize)studentpic).BeginInit();
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
         // Contin
         // 
         Contin.AutoSize = true;
         Contin.BackColor = Color.Transparent;
         Contin.Font = new Font("Segoe Script", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
         Contin.ForeColor = Color.Gold;
         Contin.Location = new Point(12, 153);
         Contin.Name = "Contin";
         Contin.Size = new Size(237, 50);
         Contin.TabIndex = 14;
         Contin.Text = "Continue as :";
         // 
         // examinerpic
         // 
         examinerpic.BackColor = Color.WhiteSmoke;
         examinerpic.BackgroundImageLayout = ImageLayout.None;
         examinerpic.Image = Properties.Resources.examiner;
         examinerpic.Location = new Point(198, 206);
         examinerpic.Name = "examinerpic";
         examinerpic.Size = new Size(129, 105);
         examinerpic.SizeMode = PictureBoxSizeMode.Zoom;
         examinerpic.TabIndex = 15;
         examinerpic.TabStop = false;
         examinerpic.Click += examinerpic_Click;
         // 
         // studentpic
         // 
         studentpic.BackColor = Color.WhiteSmoke;
         studentpic.BackgroundImageLayout = ImageLayout.None;
         studentpic.Image = Properties.Resources.student;
         studentpic.Location = new Point(383, 206);
         studentpic.Name = "studentpic";
         studentpic.Size = new Size(129, 105);
         studentpic.SizeMode = PictureBoxSizeMode.Zoom;
         studentpic.TabIndex = 16;
         studentpic.TabStop = false;
         studentpic.Click += studentpic_Click;
         // 
         // Examiner
         // 
         Examiner.BackColor = Color.SaddleBrown;
         Examiner.BackgroundImageLayout = ImageLayout.Center;
         Examiner.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Examiner.ForeColor = Color.Transparent;
         Examiner.Location = new Point(175, 319);
         Examiner.Name = "Examiner";
         Examiner.Size = new Size(177, 53);
         Examiner.TabIndex = 17;
         Examiner.Text = "Examiner";
         Examiner.UseVisualStyleBackColor = false;
         Examiner.Click += Examiner_Click;
         // 
         // Student
         // 
         Student.BackColor = Color.SaddleBrown;
         Student.BackgroundImageLayout = ImageLayout.Center;
         Student.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Student.ForeColor = Color.Transparent;
         Student.Location = new Point(368, 319);
         Student.Name = "Student";
         Student.Size = new Size(177, 53);
         Student.TabIndex = 18;
         Student.Text = "Student";
         Student.UseVisualStyleBackColor = false;
         Student.Click += Student_Click;
         // 
         // pictureBox1
         // 
         pictureBox1.BackColor = Color.Transparent;
         pictureBox1.Image = Properties.Resources.pngegg__1_;
         pictureBox1.Location = new Point(658, 12);
         pictureBox1.Name = "pictureBox1";
         pictureBox1.Size = new Size(48, 37);
         pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox1.TabIndex = 19;
         pictureBox1.TabStop = false;
         pictureBox1.Click += Close_Click;
         // 
         // HomePage
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Black;
         BackgroundImage = Properties.Resources.Walp;
         ClientSize = new Size(727, 413);
         Controls.Add(pictureBox1);
         Controls.Add(Student);
         Controls.Add(Examiner);
         Controls.Add(studentpic);
         Controls.Add(examinerpic);
         Controls.Add(Contin);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.Blue;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "HomePage";
         Text = "MathMind";
         ((System.ComponentModel.ISupportInitialize)examinerpic).EndInit();
         ((System.ComponentModel.ISupportInitialize)studentpic).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private Label Contin;
      private PictureBox examinerpic;
      private PictureBox studentpic;
      private Button Examiner;
      private Button Student;
      private PictureBox pictureBox1;
   }
}
