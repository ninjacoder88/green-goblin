using System;
using System.Configuration;
using System.Drawing;
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
            bool result;
            var mutex = new System.Threading.Mutex(true, "GreenGoblin", out result);

            if (!result)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }

            var directory = ConfigurationManager.AppSettings["TimeFileLocation"];
            if (!Directory.Exists(directory))
            {
                throw new Exception("Invalid Directory. Please verify directory in configuration exists");
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
