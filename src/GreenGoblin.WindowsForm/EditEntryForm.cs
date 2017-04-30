using System;
using System.Windows.Forms;

namespace GreenGoblin.WindowsForm
{
    public partial class EditEntryForm : Form
    {
        public EditEntryForm(TimeEntryModel model)
        {
            InitializeComponent();

            FormModel = new TimeEntryModel(model.Id, model.StartDateTime, model.EndDateTime, model.Description, model.Category);
            EditModel = model;

            if (FormModel.EndDateTime == DateTime.MaxValue)
            {
                FormModel.EndDateTime = dtpEnd.MaxDate;
            }

            dtpStart.DataBindings.Add(nameof(dtpStart.Value), FormModel, nameof(FormModel.StartDateTime));
            dtpEnd.DataBindings.Add(nameof(dtpEnd.Value), FormModel, nameof(FormModel.EndDateTime));
            txtDescription.DataBindings.Add(nameof(txtDescription.Text), FormModel, nameof(FormModel.Description));
            txtCategory.DataBindings.Add(nameof(txtCategory.Text), FormModel, nameof(FormModel.Category));
        }

        private TimeEntryModel EditModel { get; }

        private TimeEntryModel FormModel { get; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: if end time was null, but is no longer, need to terminate active model
            //TODO: if start or end time change, need to update/warn other models

            EditModel.Category = FormModel.Category;
            EditModel.Description = FormModel.Description;
            EditModel.StartDateTime = FormModel.StartDateTime;

            if (dtpEnd.Value == dtpEnd.MaxDate)
            {
                EditModel.EndDateTime = DateTime.MaxValue;
            }
            else
            {
                EditModel.EndDateTime = FormModel.EndDateTime;
            }
        }
    }
}