using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    
    internal abstract class Question
    {
        #region Attributes
        private string? head;
        private string? body;
        private int mark;
        private Answer[] answerList;
        private int correctAnswerId;
        #endregion
        #region PropertiesProperties
        public string Head
        {
            get { return head; }
            set { head = value; }
        }
        public Answer[] AnswerList
        {
            get { return answerList; }
            set { answerList = value; }
        }


        public string Body
        {
            get { return body; }
            set { body = value; }
        }


        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public int CorrectAnswerId
        {
            get { return correctAnswerId; }
            set { correctAnswerId = value; }
        } 
        #endregion

        public abstract void ShowQuestion();

    }
}
