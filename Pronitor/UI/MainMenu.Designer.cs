namespace Pronitor
{
    partial class UIMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIMainMenu));
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.KillAllTasksButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteAllMonitorsButton = new System.Windows.Forms.Button();
            this.OpenLogButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(26, 42);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(104, 45);
            this.AddTaskButton.TabIndex = 8;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column3,
            this.Column6});
            this.dataGridView.Location = new System.Drawing.Point(241, 56);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(649, 393);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Status";
            this.Column1.MinimumWidth = 65;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Task Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 105;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Time Started";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 105;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Maximum Lifetime";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 105;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Refresh Rate";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 105;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Kill Key";
            this.Column3.MinimumWidth = 60;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Action";
            this.Column6.MinimumWidth = 60;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Delete";
            this.Column6.UseColumnTextForButtonValue = true;
            this.Column6.Width = 60;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(902, 461);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pronitor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KillAllTasksButton
            // 
            this.KillAllTasksButton.Location = new System.Drawing.Point(26, 198);
            this.KillAllTasksButton.Name = "KillAllTasksButton";
            this.KillAllTasksButton.Size = new System.Drawing.Size(104, 45);
            this.KillAllTasksButton.TabIndex = 10;
            this.KillAllTasksButton.Text = "Inactive / Kill\r\nAll Tasks";
            this.KillAllTasksButton.UseVisualStyleBackColor = true;
            this.KillAllTasksButton.Click += new System.EventHandler(this.KillAllTasksButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.DeleteAllMonitorsButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.KillAllTasksButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AddTaskButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OpenLogButton, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(43, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0018F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.9996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.9998F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(158, 393);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // DeleteAllMonitorsButton
            // 
            this.DeleteAllMonitorsButton.Location = new System.Drawing.Point(26, 276);
            this.DeleteAllMonitorsButton.Name = "DeleteAllMonitorsButton";
            this.DeleteAllMonitorsButton.Size = new System.Drawing.Size(104, 45);
            this.DeleteAllMonitorsButton.TabIndex = 11;
            this.DeleteAllMonitorsButton.Text = "Delete All Monitors";
            this.DeleteAllMonitorsButton.UseVisualStyleBackColor = true;
            this.DeleteAllMonitorsButton.Click += new System.EventHandler(this.DeleteAllMonitorsButton_Click);
            // 
            // OpenLogButton
            // 
            this.OpenLogButton.Location = new System.Drawing.Point(26, 120);
            this.OpenLogButton.Name = "OpenLogButton";
            this.OpenLogButton.Size = new System.Drawing.Size(104, 45);
            this.OpenLogButton.TabIndex = 12;
            this.OpenLogButton.Text = "Open Log";
            this.OpenLogButton.UseVisualStyleBackColor = true;
            this.OpenLogButton.Click += new System.EventHandler(this.OpenLogButton_Click);
            // 
            // UIMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIMainMenu";
            this.Text = "Pronitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.UIMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button KillAllTasksButton;
        private System.Windows.Forms.Button DeleteAllMonitorsButton;
        private System.Windows.Forms.Button OpenLogButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
    }
}