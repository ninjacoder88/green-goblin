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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.dgvWorkDays = new System.Windows.Forms.DataGridView();
            this.comboCategories = new System.Windows.Forms.ComboBox();
            this.textTaskName = new System.Windows.Forms.TextBox();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDays)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTasks);
            this.panel1.Controls.Add(this.dgvWorkDays);
            this.panel1.Controls.Add(this.comboCategories);
            this.panel1.Controls.Add(this.textTaskName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 426);
            this.panel1.TabIndex = 0;
            // 
            // dgvTasks
            // 
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(185, 30);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.Size = new System.Drawing.Size(418, 393);
            this.dgvTasks.TabIndex = 3;
            // 
            // dgvWorkDays
            // 
            this.dgvWorkDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkDays.Location = new System.Drawing.Point(3, 29);
            this.dgvWorkDays.Name = "dgvWorkDays";
            this.dgvWorkDays.Size = new System.Drawing.Size(176, 394);
            this.dgvWorkDays.TabIndex = 2;
            // 
            // comboCategories
            // 
            this.comboCategories.FormattingEnabled = true;
            this.comboCategories.Location = new System.Drawing.Point(369, 3);
            this.comboCategories.Name = "comboCategories";
            this.comboCategories.Size = new System.Drawing.Size(234, 21);
            this.comboCategories.TabIndex = 1;
            // 
            // textTaskName
            // 
            this.textTaskName.Location = new System.Drawing.Point(3, 3);
            this.textTaskName.Name = "textTaskName";
            this.textTaskName.Size = new System.Drawing.Size(360, 20);
            this.textTaskName.TabIndex = 0;
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.Location = new System.Drawing.Point(624, 41);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(164, 23);
            this.btnManageCategories.TabIndex = 1;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.Location = new System.Drawing.Point(624, 70);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(164, 23);
            this.btnStartTask.TabIndex = 2;
            this.btnStartTask.Text = "Start Task";
            this.btnStartTask.UseVisualStyleBackColor = true;
            // 
            // GreenGoblinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartTask);
            this.Controls.Add(this.btnManageCategories);
            this.Controls.Add(this.panel1);
            this.Name = "GreenGoblinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Green Goblin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDays)).EndInit();
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
    }
}

