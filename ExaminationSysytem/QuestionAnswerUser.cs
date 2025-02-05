using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class QuestionAnswerUser
    {
        #region Properties
        public string Question { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public string CorrectAnswer { get; set; } 
        #endregion
    }
}
