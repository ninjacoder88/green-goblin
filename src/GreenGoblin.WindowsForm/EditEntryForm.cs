using System.Windows.Forms;

namespace GreenGoblin.WindowsForm
{
    public partial class EditEntryForm : Form
    {
        public EditEntryForm(TimeEntryModel model)
        {
            InitializeComponent();
            dtpStart.DataBindings.Add(nameof(dtpStart.Value), model, nameof(model.StartDateTime));
            dtpEnd.DataBindings.Add(nameof(dtpEnd.Value), model, nameof(model.EndDateTime));
            txtDescription.DataBindings.Add(nameof(txtDescription.Text), model, nameof(model.Description));
            txtCategory.DataBindings.Add(nameof(txtCategory.Text), model, nameof(model.Category));
        }
    }
}