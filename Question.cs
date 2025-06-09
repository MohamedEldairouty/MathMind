using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMind
{
   internal class Question
   {
      public int ID { get; set; }
      public string Text { get; set; }
      public string[] Options { get; set; }
      public int CorrectAnswerIndex { get; set; }
      public int? StudentAnswerIndex { get; set; }
      public bool? IsCorrect { get; set; }
   }
}
