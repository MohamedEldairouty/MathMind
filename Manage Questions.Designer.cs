namespace MathMind
{
   partial class Managequestions
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Managequestions));
         Title = new Label();
         Slogan = new Label();
         Add = new Button();
         Back = new PictureBox();
         pictureBox2 = new PictureBox();
         dataGridView1 = new DataGridView();
         NameLabel = new Label();
         Refresh = new Button();
         Remove = new Button();
         Edit = new Button();
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
         // Add
         // 
         Add.BackColor = Color.SpringGreen;
         Add.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Add.ForeColor = Color.Black;
         Add.Location = new Point(37, 678);
         Add.Name = "Add";
         Add.Size = new Size(164, 44);
         Add.TabIndex = 19;
         Add.Text = "Add";
         Add.UseVisualStyleBackColor = false;
         Add.Click += Add_Click;
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
         pictureBox2.Location = new Point(862, 2);
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
         dataGridView1.Size = new Size(908, 522);
         dataGridView1.TabIndex = 27;
         dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
         // 
         // NameLabel
         // 
         NameLabel.AutoSize = true;
         NameLabel.BackColor = Color.Transparent;
         NameLabel.Font = new Font("Script MT Bold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
         NameLabel.ForeColor = Color.Gold;
         NameLabel.Location = new Point(2, 110);
         NameLabel.Name = "NameLabel";
         NameLabel.Size = new Size(232, 41);
         NameLabel.TabIndex = 0;
         NameLabel.Text = "Questions Bank";
         // 
         // Refresh
         // 
         Refresh.BackColor = Color.Cyan;
         Refresh.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Refresh.ForeColor = Color.Black;
         Refresh.Location = new Point(704, 678);
         Refresh.Name = "Refresh";
         Refresh.Size = new Size(164, 44);
         Refresh.TabIndex = 29;
         Refresh.Text = "Refresh";
         Refresh.UseVisualStyleBackColor = false;
         Refresh.Click += Refresh_Click;
         // 
         // Remove
         // 
         Remove.BackColor = Color.Red;
         Remove.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Remove.ForeColor = Color.Black;
         Remove.Location = new Point(481, 678);
         Remove.Name = "Remove";
         Remove.Size = new Size(164, 44);
         Remove.TabIndex = 30;
         Remove.Text = "Remove";
         Remove.UseVisualStyleBackColor = false;
         Remove.Click += Remove_Click;
         // 
         // Edit
         // 
         Edit.BackColor = Color.Fuchsia;
         Edit.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Edit.ForeColor = Color.Black;
         Edit.Location = new Point(263, 678);
         Edit.Name = "Edit";
         Edit.Size = new Size(164, 44);
         Edit.TabIndex = 31;
         Edit.Text = "Edit";
         Edit.UseVisualStyleBackColor = false;
         Edit.Click += Edit_Click;
         // 
         // Managequestions
         // 
         AutoScaleDimensions = new SizeF(20F, 43F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.Indigo;
         BackgroundImage = Properties.Resources.Walpaper;
         ClientSize = new Size(911, 725);
         Controls.Add(Edit);
         Controls.Add(Remove);
         Controls.Add(Refresh);
         Controls.Add(NameLabel);
         Controls.Add(dataGridView1);
         Controls.Add(pictureBox2);
         Controls.Add(Back);
         Controls.Add(Add);
         Controls.Add(Slogan);
         Controls.Add(Title);
         Font = new Font("Jokerman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
         ForeColor = Color.White;
         Icon = (Icon)resources.GetObject("$this.Icon");
         Margin = new Padding(8, 6, 8, 6);
         MaximizeBox = false;
         MinimizeBox = false;
         Name = "Managequestions";
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
      private Button Add;
      private PictureBox Back;
      private PictureBox pictureBox2;
      private DataGridView dataGridView1;
      private Label NameLabel;
      private Button Refresh;
      private Button Remove;
      private Button Edit;
   }
}
