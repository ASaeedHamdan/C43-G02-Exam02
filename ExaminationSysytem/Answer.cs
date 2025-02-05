using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSysytem
{
    internal class Answer
    {
        #region Attributes
        private int id;
        private string? text;
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        } 
        #endregion
    }
}
