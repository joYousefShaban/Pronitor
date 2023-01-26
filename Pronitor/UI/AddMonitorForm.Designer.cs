
namespace Pronitor
{
    partial class AddMonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMonitorForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FrequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LifeTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.MonitorNameTextBox = new System.Windows.Forms.TextBox();
            this.MonitoringFrequencyLabel = new System.Windows.Forms.Label();
            this.MaximumLifetimeLabel = new System.Windows.Forms.Label();
            this.TypeMonitorLabel = new System.Windows.Forms.Label();
            this.KillKeyTextBox = new System.Windows.Forms.TextBox();
            this.MonitorKillKeyLabel = new System.Windows.Forms.Label();
            this.ChooseFromAnActiveProcessesLabel = new System.Windows.Forms.Label();
            this.MonitorNameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Footlight MT Light", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(305, 265);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(52, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Footlight MT Light", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 265);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "Minutes";
            // 
            // FrequencyNumericUpDown
            // 
            this.FrequencyNumericUpDown.Location = new System.Drawing.Point(252, 262);
            this.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown";
            this.FrequencyNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FrequencyNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.FrequencyNumericUpDown.TabIndex = 20;
            // 
            // LifeTimeNumericUpDown
            // 
            this.LifeTimeNumericUpDown.Location = new System.Drawing.Point(52, 262);
            this.LifeTimeNumericUpDown.Name = "LifeTimeNumericUpDown";
            this.LifeTimeNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LifeTimeNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.LifeTimeNumericUpDown.TabIndex = 19;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ConfirmButton.Location = new System.Drawing.Point(133, 343);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(137, 45);
            this.ConfirmButton.TabIndex = 18;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // MonitorNameTextBox
            // 
            this.MonitorNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorNameTextBox.Location = new System.Drawing.Point(13, 163);
            this.MonitorNameTextBox.Name = "MonitorNameTextBox";
            this.MonitorNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MonitorNameTextBox.Size = new System.Drawing.Size(170, 22);
            this.MonitorNameTextBox.TabIndex = 17;
            // 
            // MonitoringFrequencyLabel
            // 
            this.MonitoringFrequencyLabel.AutoSize = true;
            this.MonitoringFrequencyLabel.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitoringFrequencyLabel.Location = new System.Drawing.Point(225, 231);
            this.MonitoringFrequencyLabel.Name = "MonitoringFrequencyLabel";
            this.MonitoringFrequencyLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MonitoringFrequencyLabel.Size = new System.Drawing.Size(155, 18);
            this.MonitoringFrequencyLabel.TabIndex = 16;
            this.MonitoringFrequencyLabel.Text = "Monitoring Frequency";
            this.MonitoringFrequencyLabel.Click += new System.EventHandler(this.MonitoringFrequencyLabel_Click);
            // 
            // MaximumLifetimeLabel
            // 
            this.MaximumLifetimeLabel.AutoSize = true;
            this.MaximumLifetimeLabel.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumLifetimeLabel.Location = new System.Drawing.Point(23, 231);
            this.MaximumLifetimeLabel.Name = "MaximumLifetimeLabel";
            this.MaximumLifetimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MaximumLifetimeLabel.Size = new System.Drawing.Size(134, 18);
            this.MaximumLifetimeLabel.TabIndex = 15;
            this.MaximumLifetimeLabel.Text = "Maximum Lifetime";
            this.MaximumLifetimeLabel.Click += new System.EventHandler(this.MaximumLifetimeLabel_Click);
            // 
            // TypeMonitorLabel
            // 
            this.TypeMonitorLabel.AutoSize = true;
            this.TypeMonitorLabel.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeMonitorLabel.Location = new System.Drawing.Point(49, 108);
            this.TypeMonitorLabel.Name = "TypeMonitorLabel";
            this.TypeMonitorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TypeMonitorLabel.Size = new System.Drawing.Size(102, 36);
            this.TypeMonitorLabel.TabIndex = 14;
            this.TypeMonitorLabel.Text = "Type Monitor \r\nName";
            this.TypeMonitorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TypeMonitorLabel.Click += new System.EventHandler(this.TypeMonitorLabel_Click);
            // 
            // KillKeyTextBox
            // 
            this.KillKeyTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KillKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KillKeyTextBox.Location = new System.Drawing.Point(181, 55);
            this.KillKeyTextBox.MaxLength = 1;
            this.KillKeyTextBox.Name = "KillKeyTextBox";
            this.KillKeyTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KillKeyTextBox.Size = new System.Drawing.Size(31, 22);
            this.KillKeyTextBox.TabIndex = 24;
            // 
            // MonitorKillKeyLabel
            // 
            this.MonitorKillKeyLabel.AutoSize = true;
            this.MonitorKillKeyLabel.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitorKillKeyLabel.Location = new System.Drawing.Point(141, 25);
            this.MonitorKillKeyLabel.Name = "MonitorKillKeyLabel";
            this.MonitorKillKeyLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MonitorKillKeyLabel.Size = new System.Drawing.Size(115, 18);
            this.MonitorKillKeyLabel.TabIndex = 23;
            this.MonitorKillKeyLabel.Text = "Monitor Kill Key";
            this.MonitorKillKeyLabel.Click += new System.EventHandler(this.MonitorKillKeyLabel_Click);
            // 
            // ChooseFromAnActiveProcessesLabel
            // 
            this.ChooseFromAnActiveProcessesLabel.AutoSize = true;
            this.ChooseFromAnActiveProcessesLabel.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseFromAnActiveProcessesLabel.Location = new System.Drawing.Point(236, 108);
            this.ChooseFromAnActiveProcessesLabel.Name = "ChooseFromAnActiveProcessesLabel";
            this.ChooseFromAnActiveProcessesLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChooseFromAnActiveProcessesLabel.Size = new System.Drawing.Size(117, 36);
            this.ChooseFromAnActiveProcessesLabel.TabIndex = 26;
            this.ChooseFromAnActiveProcessesLabel.Text = "Choose From An\r\nActive Processes";
            this.ChooseFromAnActiveProcessesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChooseFromAnActiveProcessesLabel.Click += new System.EventHandler(this.ChooseFromAnActiveProcessesLabel_Click);
            // 
            // MonitorNameComboBox
            // 
            this.MonitorNameComboBox.Enabled = false;
            this.MonitorNameComboBox.FormattingEnabled = true;
            this.MonitorNameComboBox.Location = new System.Drawing.Point(210, 163);
            this.MonitorNameComboBox.Name = "MonitorNameComboBox";
            this.MonitorNameComboBox.Size = new System.Drawing.Size(170, 21);
            this.MonitorNameComboBox.Sorted = true;
            this.MonitorNameComboBox.TabIndex = 27;
            this.MonitorNameComboBox.DropDown += new System.EventHandler(this.MonitorNameComboBox_DropDown);
            // 
            // AddMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 411);
            this.Controls.Add(this.MonitorNameComboBox);
            this.Controls.Add(this.ChooseFromAnActiveProcessesLabel);
            this.Controls.Add(this.KillKeyTextBox);
            this.Controls.Add(this.MonitorKillKeyLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FrequencyNumericUpDown);
            this.Controls.Add(this.LifeTimeNumericUpDown);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.MonitorNameTextBox);
            this.Controls.Add(this.MonitoringFrequencyLabel);
            this.Controls.Add(this.MaximumLifetimeLabel);
            this.Controls.Add(this.TypeMonitorLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMonitorForm";
            this.Text = "Add Monitor";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddMonitorForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown FrequencyNumericUpDown;
        private System.Windows.Forms.NumericUpDown LifeTimeNumericUpDown;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox MonitorNameTextBox;
        private System.Windows.Forms.Label MonitoringFrequencyLabel;
        private System.Windows.Forms.Label MaximumLifetimeLabel;
        private System.Windows.Forms.Label TypeMonitorLabel;
        private System.Windows.Forms.TextBox KillKeyTextBox;
        private System.Windows.Forms.Label MonitorKillKeyLabel;
        private System.Windows.Forms.Label ChooseFromAnActiveProcessesLabel;
        private System.Windows.Forms.ComboBox MonitorNameComboBox;
    }
}