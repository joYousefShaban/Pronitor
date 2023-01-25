using System;
using Pronitor.Logic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Pronitor
{
    public partial class AddTaskForm : Form
    {
        private readonly MainMenu MainMenuCopy;
        public AddTaskForm(MainMenu MainMenuCopy)
        {
            //Make dependency enjection
            InitializeComponent();
            this.MainMenuCopy = MainMenuCopy;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            numericUpDown2.Focus();
        }

        private bool Validations()
        {
            if (textBox1.Enabled == true)
            {
                Console.WriteLine("I'm here-");
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Name can't be null");
                    return false;
                }
                else if (!Manager.IsNameUnique(textBox1.Text))
                {
                    MessageBox.Show("Name is already registered");
                    return false;
                }
            }
            else if (comboBox1.Enabled == true)
            {
                Console.WriteLine("I'm here-");
                if (comboBox1.Text.Length == 0)
                {
                    MessageBox.Show("Process Name can't be null");
                    return false;
                }
                else if (!Manager.IsNameUnique(comboBox1.Text))
                {
                    MessageBox.Show("Name is already registered");
                    return false;
                }
            }
            if (textBox2.TextLength == 0)
            {
                MessageBox.Show("killKey can't be null");
                return false;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Liftime can't be less or equal zero");
                return false;
            }
            if (!(numericUpDown1.Value == (int)numericUpDown1.Value))
            {
                MessageBox.Show("Liftime has to be a decimal number");
                return false;
            }
            if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show("Frequency can't be less or equal zero");
                return false;
            }
            if (!(numericUpDown2.Value == (int)numericUpDown2.Value))
            {
                MessageBox.Show("Frequency has to be a decimal number");
                return false;
            }
            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                string name;
                if (textBox1.Enabled)
                    name = textBox1.Text;
                else
                    name = comboBox1.Text;
                MainMenuCopy.AddToDataGridView(name, (int)numericUpDown1.Value, (int)numericUpDown2.Value, char.Parse(textBox2.Text));
                Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            comboBox1.Focus();
        }

        private void AddTaskForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
            else if (textBox1.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = false;
                comboBox1.AllowDrop = false;
            }
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.Bounds);
            Console.WriteLine(textBox1.Bounds);
            Console.WriteLine(comboBox1.ClientRectangle);
            Console.WriteLine(textBox1.ClientRectangle);
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Process[] processList = Process.GetProcesses();
            var distinctProcessList = processList.Select(x => x.ProcessName).Distinct().ToArray();
            foreach (string theprocess in distinctProcessList)
            {
                comboBox1.Items.Add(theprocess);
            }
        }
    }
}