using System;
using System.Windows.Forms;
using GreenGoblin.Repository;

namespace GreenGoblin.WindowsForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //const string PrimaryTimeFilePath = @"C:\computer\development\time\time.txt";
            //const string BackupTimeFilePath = @"C:\computer\development\time\time.backup.txt";
            const string TimeFilesDirectory = @"C:\computer\development\time";

            IGreenGoblinRepository repository = new TestingRepository();
            IGreenGoblinRepository fileRepository = new GreenGoblinFileRepository(TimeFilesDirectory);
            var viewModel = new GreenGoblinViewModel(fileRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(viewModel));
        }
    }
}
