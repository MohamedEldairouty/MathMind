namespace MathMind
{
   partial class TakeQuiz
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeQuiz));
         Title = new Label();
         Slogan = new Label();
         Request = new Button();
         Back = new PictureBox();
         pictureBox2 = new PictureBox();
         flowLayoutPanel1 = new FlowLayoutPanel();
         pictureBox1 = new PictureBox();
         timerpic = new PictureBox();
         timer = new Label();
         ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
         ((System.ComponentModel.ISupportInitialize)timerpic).BeginInit();
         SuspendLayout();
         // 
         // Title
         // 
         Title.AutoSize = true;
         Title.BackColor = Color.Transparent;
         Title.Font = new Font("Jokerman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Title.ForeColor = Color.LightBlue;
         Title.Location = new Point(217, 1);
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
         Slogan.Location = new Point(183, 73);
         Slogan.Name = "Slogan";
         Slogan.Size = new Size(444, 40);
         Slogan.TabIndex = 13;
         Slogan.Text = "Where Math Meets Mastery";
         // 
         // Request
         // 
         Request.BackColor = Color.Cyan;
         Request.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Request.ForeColor = Color.Black;
         Request.Location = new Point(289, 590);
         Request.Name = "Request";
         Request.Size = new Size(311, 54);
         Request.TabIndex = 19;
         Request.Text = "Request Quiz";
         Request.UseVisualStyleBackColor = false;
         Request.Click += TakeQuizClick;
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
         pictureBox2.Location = new Point(845, 1);
         pictureBox2.Name = "pictureBox2";
         pictureBox2.Size = new Size(48, 37);
         pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox2.TabIndex = 26;
         pictureBox2.TabStop = false;
         pictureBox2.Click += pictureBox2_Click;
         // 
         // flowLayoutPanel1
         // 
         flowLayoutPanel1.BackColor = Color.Transparent;
         flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
         flowLayoutPanel1.Location = new Point(1, 119);
         flowLayoutPanel1.Name = "flowLayoutPanel1";
         flowLayoutPanel1.Padding = new Padding(10);
         flowLayoutPanel1.Size = new Size(892, 465);
         flowLayoutPanel1.TabIndex = 27;
         flowLayoutPanel1.Visible = false;
         flowLayoutPanel1.WrapContents = false;
         // 
         // pictureBox1
         // 
         pictureBox1.BackColor = Color.Transparent;
         pictureBox1.Image = Properties.Resources.Quiz;
         pictureBox1.Location = new Point(1, 119);
         pictureBox1.Name = "pictureBox1";
         pictureBox1.Size = new Size(379, 363);
         pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox1.TabIndex = 29;
         pictureBox1.TabStop = false;
         // 
         // timerpic
         // 
         timerpic.BackColor = Color.Transparent;
         timerpic.Image = Properties.Resources.clock;
         timerpic.Location = new Point(633, 20);
         timerpic.Name = "timerpic";
         timerpic.Size = new Size(83, 93);
         timerpic.SizeMode = PictureBoxSizeMode.Zoom;
         timerpic.TabIndex = 28;
         timerpic.TabStop = false;
         timerpic.Visible = false;
         // 
         // timer
         // 
         timer.AutoSize = true;
         timer.BackColor = Color.Transparent;
         timer.Font = new Font("Wide Latin", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         timer.ForeColor = Color.FromArgb(255, 128, 128);
         timer.Location = new Point(720, 52);
         timer.Name = "timer";
         timer.Size = new Size(143, 37);
         timer.TabIndex = 0;
         timer.Text = "2:00";
         timer.Visible = false;
         // 
         // TakeQuiz
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Indigo;
         BackgroundImage = Properties.Resources.Walpaper;
         ClientSize = new Size(893, 646);
         Controls.Add(timer);
         Controls.Add(timerpic);
         Controls.Add(flowLayoutPanel1);
         Controls.Add(pictureBox2);
         Controls.Add(pictureBox1);
         Controls.Add(Back);
         Controls.Add(Request);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.White;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "TakeQuiz";
         Text = "MathMind";
         Load += TakeQuiz_Load;
         ((System.ComponentModel.ISupportInitialize)Back).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
         ((System.ComponentModel.ISupportInitialize)timerpic).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private Button Request;
      private PictureBox Back;
      private PictureBox pictureBox2;
      private FlowLayoutPanel flowLayoutPanel1;
      private PictureBox timerpic;
      private Label timer;
      private PictureBox pictureBox1;
   }
}
