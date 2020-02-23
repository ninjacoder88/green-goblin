using System;

namespace GreenGoblin.WindowsForm
{
    public class QuestionEventArgs : EventArgs
    {
        public bool Answer { get; set; }

        public string Question { get; set; }

        public string Caption { get; set; }
    }
}