using System;
using System.Windows.Forms;

namespace MathMind
{
   public partial class HomePage : Form
   {

      public HomePage()
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
      private void Examiner_Click(object sender, EventArgs e)
      {
         var x = new ExaminerLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }
      private void examinerpic_Click(object sender, EventArgs e)
      {
         var x = new ExaminerLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;

      }

      private void Student_Click(object sender, EventArgs e)
      {
         var x = new StudentLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }

      private void studentpic_Click(object sender, EventArgs e)
      {
         var x = new StudentLogin();
         x.StartPosition = FormStartPosition.Manual;
         x.Location = this.Location;
         x.Show();
         Visible = false;
      }
     
      private void Close_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

   }
}
