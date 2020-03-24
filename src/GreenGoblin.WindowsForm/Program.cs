using System;
using System.Configuration;
using System.IO;
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
            var mutex = new System.Threading.Mutex(true, "GreenGoblin", out bool alreadyRunning);

            if (!alreadyRunning)
            {
                MessageBox.Show("Green Goblin is already running", "Green Goblin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var directory = ConfigurationManager.AppSettings["TimeFileLocation"];
            if (!Directory.Exists(directory))
            {
                MessageBox.Show("Invalid Directory. Please verify directory in configuration exists", "Green Goblin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IGreenGoblinRepository repository = new TestingRepository();
            IGreenGoblinRepository fileRepository = new GreenGoblinFileRepository(directory);
            var viewModel = new GreenGoblinViewModel(fileRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(viewModel));

            GC.KeepAlive(mutex);
        }
    }
}
