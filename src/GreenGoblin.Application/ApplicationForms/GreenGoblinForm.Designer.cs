namespace GreenGoblin.WindowsFormApplication.ApplicationForms
{
    partial class GreenGoblinForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.startDateTimeStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateTimeStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvWorkDays = new System.Windows.Forms.DataGridView();
            this.dayTimeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workDayModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboCategories = new System.Windows.Forms.ComboBox();
            this.textTaskName = new System.Windows.Forms.TextBox();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.btnEndTask = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.btnReconcile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workDayModelBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvTasks);
            this.panel1.Controls.Add(this.dgvWorkDays);
            this.panel1.Controls.Add(this.comboCategories);
            this.panel1.Controls.Add(this.textTaskName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 577);
            this.panel1.TabIndex = 0;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToResizeColumns = false;
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.AutoGenerateColumns = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startDateTimeStringDataGridViewTextBoxColumn,
            this.endDateTimeStringDataGridViewTextBoxColumn,
            this.startDateTimeDataGridViewTextBoxColumn,
            this.endDateTimeDataGridViewTextBoxColumn,
            this.taskNameDataGridViewTextBoxColumn,
            this.categoryNameDataGridViewTextBoxColumn});
            this.dgvTasks.DataSource = this.taskModelBindingSource;
            this.dgvTasks.Location = new System.Drawing.Point(185, 30);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(660, 544);
            this.dgvTasks.TabIndex = 3;
            // 
            // startDateTimeStringDataGridViewTextBoxColumn
            // 
            this.startDateTimeStringDataGridViewTextBoxColumn.DataPropertyName = "StartDateTimeString";
            this.startDateTimeStringDataGridViewTextBoxColumn.HeaderText = "Start";
            this.startDateTimeStringDataGridViewTextBoxColumn.Name = "startDateTimeStringDataGridViewTextBoxColumn";
            // 
            // endDateTimeStringDataGridViewTextBoxColumn
            // 
            this.endDateTimeStringDataGridViewTextBoxColumn.DataPropertyName = "EndDateTimeString";
            this.endDateTimeStringDataGridViewTextBoxColumn.HeaderText = "End";
            this.endDateTimeStringDataGridViewTextBoxColumn.Name = "endDateTimeStringDataGridViewTextBoxColumn";
            // 
            // startDateTimeDataGridViewTextBoxColumn
            // 
            this.startDateTimeDataGridViewTextBoxColumn.DataPropertyName = "StartDateTime";
            this.startDateTimeDataGridViewTextBoxColumn.HeaderText = "StartDateTime";
            this.startDateTimeDataGridViewTextBoxColumn.Name = "startDateTimeDataGridViewTextBoxColumn";
            this.startDateTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // endDateTimeDataGridViewTextBoxColumn
            // 
            this.endDateTimeDataGridViewTextBoxColumn.DataPropertyName = "EndDateTime";
            this.endDateTimeDataGridViewTextBoxColumn.HeaderText = "EndDateTime";
            this.endDateTimeDataGridViewTextBoxColumn.Name = "endDateTimeDataGridViewTextBoxColumn";
            this.endDateTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // taskNameDataGridViewTextBoxColumn
            // 
            this.taskNameDataGridViewTextBoxColumn.DataPropertyName = "TaskName";
            this.taskNameDataGridViewTextBoxColumn.HeaderText = "Task";
            this.taskNameDataGridViewTextBoxColumn.Name = "taskNameDataGridViewTextBoxColumn";
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            // 
            // taskModelBindingSource
            // 
            this.taskModelBindingSource.DataSource = typeof(GreenGoblin.WindowsFormApplication.Models.TaskModel);
            // 
            // dgvWorkDays
            // 
            this.dgvWorkDays.AllowUserToAddRows = false;
            this.dgvWorkDays.AllowUserToDeleteRows = false;
            this.dgvWorkDays.AllowUserToResizeRows = false;
            this.dgvWorkDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvWorkDays.AutoGenerateColumns = false;
            this.dgvWorkDays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayTimeStampDataGridViewTextBoxColumn,
            this.timeStampDataGridViewTextBoxColumn});
            this.dgvWorkDays.DataSource = this.workDayModelBindingSource;
            this.dgvWorkDays.Location = new System.Drawing.Point(3, 29);
            this.dgvWorkDays.Name = "dgvWorkDays";
            this.dgvWorkDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkDays.Size = new System.Drawing.Size(176, 545);
            this.dgvWorkDays.TabIndex = 2;
            // 
            // dayTimeStampDataGridViewTextBoxColumn
            // 
            this.dayTimeStampDataGridViewTextBoxColumn.DataPropertyName = "DayTimeStamp";
            this.dayTimeStampDataGridViewTextBoxColumn.HeaderText = "Day";
            this.dayTimeStampDataGridViewTextBoxColumn.Name = "dayTimeStampDataGridViewTextBoxColumn";
            this.dayTimeStampDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeStampDataGridViewTextBoxColumn
            // 
            this.timeStampDataGridViewTextBoxColumn.DataPropertyName = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.HeaderText = "TimeStamp";
            this.timeStampDataGridViewTextBoxColumn.Name = "timeStampDataGridViewTextBoxColumn";
            this.timeStampDataGridViewTextBoxColumn.Visible = false;
            // 
            // workDayModelBindingSource
            // 
            this.workDayModelBindingSource.DataSource = typeof(GreenGoblin.WindowsFormApplication.Models.WorkDayModel);
            // 
            // comboCategories
            // 
            this.comboCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCategories.FormattingEnabled = true;
            this.comboCategories.Location = new System.Drawing.Point(561, 3);
            this.comboCategories.Name = "comboCategories";
            this.comboCategories.Size = new System.Drawing.Size(284, 21);
            this.comboCategories.TabIndex = 1;
            // 
            // textTaskName
            // 
            this.textTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTaskName.Location = new System.Drawing.Point(3, 3);
            this.textTaskName.Name = "textTaskName";
            this.textTaskName.Size = new System.Drawing.Size(552, 20);
            this.textTaskName.TabIndex = 0;
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageCategories.Location = new System.Drawing.Point(3, 3);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(172, 23);
            this.btnManageCategories.TabIndex = 1;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartTask.Location = new System.Drawing.Point(3, 32);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(172, 23);
            this.btnStartTask.TabIndex = 2;
            this.btnStartTask.Text = "Start Task";
            this.btnStartTask.UseVisualStyleBackColor = true;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // btnEndTask
            // 
            this.btnEndTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndTask.Location = new System.Drawing.Point(3, 61);
            this.btnEndTask.Name = "btnEndTask";
            this.btnEndTask.Size = new System.Drawing.Size(172, 23);
            this.btnEndTask.TabIndex = 3;
            this.btnEndTask.Text = "End Task";
            this.btnEndTask.UseVisualStyleBackColor = true;
            this.btnEndTask.Click += new System.EventHandler(this.btnEndTask_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnRemoveTask);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCreateReport);
            this.panel2.Controls.Add(this.btnReconcile);
            this.panel2.Controls.Add(this.btnManageCategories);
            this.panel2.Controls.Add(this.btnEndTask);
            this.panel2.Controls.Add(this.btnStartTask);
            this.panel2.Location = new System.Drawing.Point(866, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 548);
            this.panel2.TabIndex = 4;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(3, 149);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(172, 23);
            this.btnRemoveTask.TabIndex = 8;
            this.btnRemoveTask.Text = "Remove Task";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(3, 493);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(172, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(3, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(3, 120);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(172, 23);
            this.btnCreateReport.TabIndex = 5;
            this.btnCreateReport.Text = "Create Report";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            // 
            // btnReconcile
            // 
            this.btnReconcile.Location = new System.Drawing.Point(3, 178);
            this.btnReconcile.Name = "btnReconcile";
            this.btnReconcile.Size = new System.Drawing.Size(172, 23);
            this.btnReconcile.TabIndex = 4;
            this.btnReconcile.Text = "Reconcile";
            this.btnReconcile.UseVisualStyleBackColor = true;
            // 
            // GreenGoblinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 601);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GreenGoblinForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Green Goblin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GreenGoblinForm_FormClosing);
            this.Load += new System.EventHandler(this.GreenGoblinForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workDayModelBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboCategories;
        private System.Windows.Forms.TextBox textTaskName;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridView dgvWorkDays;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.BindingSource taskModelBindingSource;
        private System.Windows.Forms.BindingSource workDayModelBindingSource;
        private System.Windows.Forms.Button btnEndTask;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateTimeStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateTimeStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayTimeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.Button btnReconcile;
    }
}

