using System;
using Pronitor.Logic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Pronitor
{
    public partial class AddMonitorForm : Form
    {
        private readonly UIMainMenu UIMainMenu;
        public AddMonitorForm(UIMainMenu UIMainMenu)
        {
            InitializeComponent();

            // Inject mainMenu object
            this.UIMainMenu = UIMainMenu;
        }

        // Validate form information
        private bool Validations()
        {
            if (MonitorNameTextBox.Enabled)
            {
                if (MonitorNameTextBox.TextLength == 0)
                {
                    MessageBox.Show("Name can't be null");
                    return false;
                }
                else if (!Manager.IsNameUnique(MonitorNameTextBox.Text))
                {
                    MessageBox.Show("Name is already registered");
                    return false;
                }
            }
            else if (MonitorNameComboBox.Enabled)
            {
                if (MonitorNameComboBox.Text.Length == 0)
                {
                    MessageBox.Show("Process Name can't be null");
                    return false;
                }
                else if (!Manager.IsNameUnique(MonitorNameComboBox.Text))
                {
                    MessageBox.Show("Name is already registered");
                    return false;
                }
            }
            if (KillKeyTextBox.TextLength == 0)
            {
                MessageBox.Show("KillKey can't be null");
                return false;
            }
            if (LifeTimeNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Liftime can't be less or equal zero");
                return false;
            }
            if (!(LifeTimeNumericUpDown.Value == (int)LifeTimeNumericUpDown.Value))
            {
                MessageBox.Show("Liftime has to be a decimal number");
                return false;
            }
            if (FrequencyNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Frequency can't be less or equal zero");
                return false;
            }
            if (!(FrequencyNumericUpDown.Value == (int)FrequencyNumericUpDown.Value))
            {
                MessageBox.Show("Frequency has to be a decimal number");
                return false;
            }
            return true;
        }

        // Confirm button click listner
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                string name;
                if (MonitorNameTextBox.Enabled)
                    name = MonitorNameTextBox.Text;
                else
                    name = MonitorNameComboBox.Text;
                UIMainMenu.AddToDataGridView(name, (int)LifeTimeNumericUpDown.Value, (int)FrequencyNumericUpDown.Value, char.Parse(KillKeyTextBox.Text));
                Close();
            }
        }

        // Populate MonitorNameComboBox on dropDown
        private void MonitorNameComboBox_DropDown(object sender, EventArgs e)
        {
            MonitorNameComboBox.Items.Clear();
            Process[] processList = Process.GetProcesses();
            var distinctProcessList = processList.Select(x => x.ProcessName).Distinct().ToArray();
            foreach (string theprocess in distinctProcessList)
            {
                MonitorNameComboBox.Items.Add(theprocess);
            }
        }

        // Switches between comboBox or textBox whenether is clicked
        private void AddMonitorForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (MonitorNameComboBox.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                MonitorNameTextBox.Enabled = false;
                MonitorNameTextBox.Text = "";
                MonitorNameComboBox.Enabled = true;
                MonitorNameComboBox.Focus();
            }
            else if (MonitorNameTextBox.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                MonitorNameComboBox.Enabled = false;
                MonitorNameComboBox.Text = "";
                MonitorNameTextBox.Enabled = true;
                MonitorNameTextBox.Focus();
            }
        }

        // Pressing on a label Focuses on its associated element
        private void TypeMonitorLabel_Click(object sender, EventArgs e)
        {
            MonitorNameTextBox.Focus();
        }
        private void MonitorKillKeyLabel_Click(object sender, EventArgs e)
        {
            KillKeyTextBox.Focus();
        }
        private void MaximumLifetimeLabel_Click(object sender, EventArgs e)
        {
            LifeTimeNumericUpDown.Focus();
        }
        private void MonitoringFrequencyLabel_Click(object sender, EventArgs e)
        {
            FrequencyNumericUpDown.Focus();
        }
        private void ChooseFromAnActiveProcessesLabel_Click(object sender, EventArgs e)
        {
            MonitorNameComboBox.Focus();
        }
    }
}