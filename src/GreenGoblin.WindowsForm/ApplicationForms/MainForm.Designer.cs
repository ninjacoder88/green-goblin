namespace GreenGoblin.WindowsForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgvTimeEntries = new System.Windows.Forms.DataGridView();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationTimeSpanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeEntryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiTaskStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskBreak = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskLunch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTaskEndDay = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageReconcile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataSave = new System.Windows.Forms.ToolStripMenuItem();
            this.lbxCategories = new System.Windows.Forms.ListBox();
            this.categoryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTaskTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTaskStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEntryModelBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryModelBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(627, 23);
            this.txtDescription.TabIndex = 0;
            // 
            // dgvTimeEntries
            // 
            this.dgvTimeEntries.AllowUserToAddRows = false;
            this.dgvTimeEntries.AllowUserToDeleteRows = false;
            this.dgvTimeEntries.AllowUserToResizeRows = false;
            this.dgvTimeEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimeEntries.AutoGenerateColumns = false;
            this.dgvTimeEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimeEntries.BackgroundColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimeEntries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimeEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.durationTimeSpanDataGridViewTextBoxColumn,
            this.endDateTimeDataGridViewTextBoxColumn,
            this.startDateTimeDataGridViewTextBoxColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvTimeEntries, 2);
            this.dgvTimeEntries.DataSource = this.timeEntryModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimeEntries.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimeEntries.GridColor = System.Drawing.Color.Black;
            this.dgvTimeEntries.Location = new System.Drawing.Point(3, 28);
            this.dgvTimeEntries.Name = "dgvTimeEntries";
            this.dgvTimeEntries.ReadOnly = true;
            this.dgvTimeEntries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTimeEntries.RowHeadersVisible = false;
            this.dgvTimeEntries.RowHeadersWidth = 10;
            this.tableLayoutPanel1.SetRowSpan(this.dgvTimeEntries, 2);
            this.dgvTimeEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeEntries.Size = new System.Drawing.Size(1260, 596);
            this.dgvTimeEntries.TabIndex = 1;
            this.dgvTimeEntries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeEntries_CellDoubleClick);
            this.dgvTimeEntries.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTimeEntries_CellFormatting);
            this.dgvTimeEntries.SelectionChanged += new System.EventHandler(this.dgvTimeEntries_SelectionChanged);
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.FillWeight = 200F;
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "Start Time";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.FillWeight = 200F;
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "End Time";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.FillWeight = 300F;
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.FillWeight = 200F;
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationTimeSpanDataGridViewTextBoxColumn
            // 
            this.durationTimeSpanDataGridViewTextBoxColumn.DataPropertyName = "DurationTimeSpan";
            this.durationTimeSpanDataGridViewTextBoxColumn.HeaderText = "DurationTimeSpan";
            this.durationTimeSpanDataGridViewTextBoxColumn.Name = "durationTimeSpanDataGridViewTextBoxColumn";
            this.durationTimeSpanDataGridViewTextBoxColumn.ReadOnly = true;
            this.durationTimeSpanDataGridViewTextBoxColumn.Visible = false;
            // 
            // endDateTimeDataGridViewTextBoxColumn
            // 
            this.endDateTimeDataGridViewTextBoxColumn.DataPropertyName = "EndDateTime";
            this.endDateTimeDataGridViewTextBoxColumn.HeaderText = "EndDateTime";
            this.endDateTimeDataGridViewTextBoxColumn.Name = "endDateTimeDataGridViewTextBoxColumn";
            this.endDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // startDateTimeDataGridViewTextBoxColumn
            // 
            this.startDateTimeDataGridViewTextBoxColumn.DataPropertyName = "StartDateTime";
            this.startDateTimeDataGridViewTextBoxColumn.HeaderText = "StartDateTime";
            this.startDateTimeDataGridViewTextBoxColumn.Name = "startDateTimeDataGridViewTextBoxColumn";
            this.startDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.startDateTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // timeEntryModelBindingSource
            // 
            this.timeEntryModelBindingSource.DataSource = typeof(GreenGoblin.WindowsForm.TimeEntryModel);
            // 
            // txtCategory
            // 
            this.txtCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCategory.Location = new System.Drawing.Point(636, 3);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(627, 23);
            this.txtCategory.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Location = new System.Drawing.Point(3, 630);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1260, 19);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1393, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiTaskStart,
            this.tsmiTaskBreak,
            this.tsmiTaskLunch,
            this.tsmiTaskEndDay});
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.taskToolStripMenuItem.Text = "&Task";
            // 
            // tmsiTaskStart
            // 
            this.tmsiTaskStart.Name = "tmsiTaskStart";
            this.tmsiTaskStart.Size = new System.Drawing.Size(131, 22);
            this.tmsiTaskStart.Text = "&Start";
            // 
            // tsmiTaskBreak
            // 
            this.tsmiTaskBreak.Name = "tsmiTaskBreak";
            this.tsmiTaskBreak.Size = new System.Drawing.Size(131, 22);
            this.tsmiTaskBreak.Text = "&Break";
            // 
            // tsmiTaskLunch
            // 
            this.tsmiTaskLunch.Name = "tsmiTaskLunch";
            this.tsmiTaskLunch.Size = new System.Drawing.Size(131, 22);
            this.tsmiTaskLunch.Text = "&Lunch";
            // 
            // tsmiTaskEndDay
            // 
            this.tsmiTaskEndDay.Name = "tsmiTaskEndDay";
            this.tsmiTaskEndDay.Size = new System.Drawing.Size(131, 22);
            this.tsmiTaskEndDay.Text = "&End of Day";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageReconcile,
            this.tsmiManageArchive,
            this.tsmiManageDelete});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "&Manage";
            // 
            // tsmiManageReconcile
            // 
            this.tsmiManageReconcile.Name = "tsmiManageReconcile";
            this.tsmiManageReconcile.Size = new System.Drawing.Size(125, 22);
            this.tsmiManageReconcile.Text = "&Reconcile";
            // 
            // tsmiManageArchive
            // 
            this.tsmiManageArchive.Name = "tsmiManageArchive";
            this.tsmiManageArchive.Size = new System.Drawing.Size(125, 22);
            this.tsmiManageArchive.Text = "&Archive";
            // 
            // tsmiManageDelete
            // 
            this.tsmiManageDelete.Name = "tsmiManageDelete";
            this.tsmiManageDelete.Size = new System.Drawing.Size(125, 22);
            this.tsmiManageDelete.Text = "&Delete";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDataRefresh,
            this.tsmiDataSave});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // tsmiDataRefresh
            // 
            this.tsmiDataRefresh.Name = "tsmiDataRefresh";
            this.tsmiDataRefresh.Size = new System.Drawing.Size(138, 22);
            this.tsmiDataRefresh.Text = "&Refresh";
            // 
            // tsmiDataSave
            // 
            this.tsmiDataSave.Name = "tsmiDataSave";
            this.tsmiDataSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiDataSave.Size = new System.Drawing.Size(138, 22);
            this.tsmiDataSave.Text = "&Save";
            // 
            // lbxCategories
            // 
            this.lbxCategories.BackColor = System.Drawing.Color.DarkGreen;
            this.lbxCategories.DataSource = this.categoryModelBindingSource;
            this.lbxCategories.DisplayMember = "CategoryName";
            this.lbxCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxCategories.ForeColor = System.Drawing.Color.White;
            this.lbxCategories.FormattingEnabled = true;
            this.lbxCategories.ItemHeight = 15;
            this.lbxCategories.Location = new System.Drawing.Point(1269, 3);
            this.lbxCategories.Name = "lbxCategories";
            this.tableLayoutPanel1.SetRowSpan(this.lbxCategories, 2);
            this.lbxCategories.Size = new System.Drawing.Size(121, 219);
            this.lbxCategories.TabIndex = 15;
            this.lbxCategories.ValueMember = "CategoryId";
            // 
            // categoryModelBindingSource
            // 
            this.categoryModelBindingSource.DataSource = typeof(GreenGoblin.Repository.Models.CategoryModel);
            // 
            // lblTaskTime
            // 
            this.lblTaskTime.AutoSize = true;
            this.lblTaskTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskTime.ForeColor = System.Drawing.Color.White;
            this.lblTaskTime.Location = new System.Drawing.Point(35, 10);
            this.lblTaskTime.Name = "lblTaskTime";
            this.lblTaskTime.Size = new System.Drawing.Size(45, 19);
            this.lblTaskTime.TabIndex = 17;
            this.lblTaskTime.Text = "00:00";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCategory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvTimeEntries, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbxCategories, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTaskStart, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1393, 652);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTaskTime);
            this.panel1.Location = new System.Drawing.Point(1269, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 36);
            this.panel1.TabIndex = 18;
            // 
            // btnTaskStart
            // 
            this.btnTaskStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaskStart.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskStart.Location = new System.Drawing.Point(1269, 630);
            this.btnTaskStart.Name = "btnTaskStart";
            this.btnTaskStart.Size = new System.Drawing.Size(121, 19);
            this.btnTaskStart.TabIndex = 19;
            this.btnTaskStart.Text = "Start Task";
            this.btnTaskStart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnTaskStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1393, 676);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Green Goblin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEntryModelBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryModelBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView dgvTimeEntries;
        private System.Windows.Forms.BindingSource timeEntryModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationTimeSpanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmsiTaskStart;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskBreak;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskLunch;
        private System.Windows.Forms.ToolStripMenuItem tsmiTaskEndDay;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageReconcile;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageArchive;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageDelete;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataSave;
        private System.Windows.Forms.ListBox lbxCategories;
        private System.Windows.Forms.Label lblTaskTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource categoryModelBindingSource;
        private System.Windows.Forms.Button btnTaskStart;
    }
}

