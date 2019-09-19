using System.Windows.Forms;

namespace GreenGoblin.WindowsForm
{
    public partial class PromptForm : Form
    {
        public PromptForm()
        {
            InitializeComponent();
        }

        public string UserInput => txtUserInput.Text;
    }
}
