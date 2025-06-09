namespace MathMind
{
   partial class ManageGrades
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
         DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageGrades));
         Title = new Label();
         Slogan = new Label();
         Results = new Button();
         Back = new PictureBox();
         pictureBox2 = new PictureBox();
         dataGridView1 = new DataGridView();
         NameLabel = new Label();
         export = new Button();
         Remove = new Button();
         Grade = new Button();
         ((System.ComponentModel.ISupportInitialize)Back).BeginInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
         ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
         SuspendLayout();
         // 
         // Title
         // 
         Title.AutoSize = true;
         Title.BackColor = Color.Transparent;
         Title.Font = new Font("Jokerman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Title.ForeColor = Color.LightBlue;
         Title.Location = new Point(248, 2);
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
         Slogan.Location = new Point(208, 72);
         Slogan.Name = "Slogan";
         Slogan.Size = new Size(444, 40);
         Slogan.TabIndex = 13;
         Slogan.Text = "Where Math Meets Mastery";
         // 
         // Results
         // 
         Results.BackColor = Color.Cyan;
         Results.Enabled = false;
         Results.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Results.ForeColor = Color.Black;
         Results.Location = new Point(248, 591);
         Results.Name = "Results";
         Results.Size = new Size(177, 49);
         Results.TabIndex = 19;
         Results.Text = "Review";
         Results.UseVisualStyleBackColor = false;
         Results.Click += ResultsView;
         // 
         // Back
         // 
         Back.BackColor = Color.White;
         Back.BackgroundImage = Properties.Resources.Back;
         Back.BackgroundImageLayout = ImageLayout.Stretch;
         Back.Image = Properties.Resources.Back;
         Back.Location = new Point(2, 2);
         Back.Name = "Back";
         Back.Size = new Size(38, 29);
         Back.TabIndex = 23;
         Back.TabStop = false;
         Back.Click += Back_Click;
         // 
         // pictureBox2
         // 
         pictureBox2.BackColor = Color.Transparent;
         pictureBox2.Image = Properties.Resources.pngegg__1_;
         pictureBox2.Location = new Point(845, 2);
         pictureBox2.Name = "pictureBox2";
         pictureBox2.Size = new Size(48, 37);
         pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
         pictureBox2.TabIndex = 26;
         pictureBox2.TabStop = false;
         pictureBox2.Click += pictureBox2_Click;
         // 
         // dataGridView1
         // 
         dataGridView1.AllowUserToDeleteRows = false;
         dataGridView1.AllowUserToResizeColumns = false;
         dataGridView1.AllowUserToResizeRows = false;
         dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
         dataGridView1.BackgroundColor = Color.White;
         dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
         dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dataGridView1.Location = new Point(2, 150);
         dataGridView1.MultiSelect = false;
         dataGridView1.Name = "dataGridView1";
         dataGridView1.ReadOnly = true;
         dataGridView1.RowHeadersWidth = 51;
         dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         dataGridView1.Size = new Size(892, 435);
         dataGridView1.TabIndex = 27;
         dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
         // 
         // NameLabel
         // 
         NameLabel.AutoSize = true;
         NameLabel.BackColor = Color.Transparent;
         NameLabel.Font = new Font("Script MT Bold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
         NameLabel.ForeColor = Color.Gold;
         NameLabel.Location = new Point(2, 110);
         NameLabel.Name = "NameLabel";
         NameLabel.Size = new Size(355, 41);
         NameLabel.TabIndex = 0;
         NameLabel.Text = "Students Quizzes Record";
         // 
         // export
         // 
         export.BackColor = Color.DarkGray;
         export.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         export.ForeColor = Color.Black;
         export.Location = new Point(688, 591);
         export.Name = "export";
         export.Size = new Size(177, 49);
         export.TabIndex = 28;
         export.Text = "Export";
         export.UseVisualStyleBackColor = false;
         export.Click += Export_Click;
         // 
         // Remove
         // 
         Remove.BackColor = Color.Red;
         Remove.Enabled = false;
         Remove.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Remove.ForeColor = Color.Black;
         Remove.Location = new Point(475, 591);
         Remove.Name = "Remove";
         Remove.Size = new Size(177, 49);
         Remove.TabIndex = 29;
         Remove.Text = "Remove";
         Remove.UseVisualStyleBackColor = false;
         Remove.Click += Remove_Click;
         // 
         // Grade
         // 
         Grade.BackColor = Color.SpringGreen;
         Grade.Enabled = false;
         Grade.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Grade.ForeColor = Color.Black;
         Grade.Location = new Point(21, 591);
         Grade.Name = "Grade";
         Grade.Size = new Size(177, 49);
         Grade.TabIndex = 30;
         Grade.Text = "Grade";
         Grade.UseVisualStyleBackColor = false;
         Grade.Click += Grade_Click;
         // 
         // ManageGrades
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Indigo;
         BackgroundImage = Properties.Resources.Walpaper;
         ClientSize = new Size(893, 647);
         Controls.Add(Grade);
         Controls.Add(Remove);
         Controls.Add(export);
         Controls.Add(NameLabel);
         Controls.Add(dataGridView1);
         Controls.Add(pictureBox2);
         Controls.Add(Back);
         Controls.Add(Results);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.White;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "ManageGrades";
         Text = "MathMind";
         ((System.ComponentModel.ISupportInitialize)Back).EndInit();
         ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
         ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private Label Title;
      private Label Slogan;
      private Button Results;
      private PictureBox Back;
      private PictureBox pictureBox2;
      private DataGridView dataGridView1;
      private Label NameLabel;
      private Button export;
      private Button Remove;
      private Button Grade;
   }
}
