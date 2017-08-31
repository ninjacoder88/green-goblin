using System;

namespace GreenGoblin.WindowsForm
{
    public class BackupFileExistsEventArgs : EventArgs
    {
        public bool Load { get; set; }
    }
}