using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class Exam
    {

        #region Attributes
        private int time;
        private int numOfQuestion;
        #endregion

        #region Properties
        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public int NumOfQuestion
        {
            get { return numOfQuestion; }
            set { numOfQuestion = value; }
        } 
        #endregion
    }
}
