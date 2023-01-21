using System;
using Pronitor.Logic;
using System.Windows.Forms;

namespace Pronitor
{
    public partial class AddTaskForm : Form
    {
        private MainMenu MainMenuCopy;
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
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("killKey can't be null");
                return false;
            }
            else if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Liftime can't be less or equal zero");
                return false;
            }
            else if (!(numericUpDown1.Value == (int)numericUpDown1.Value))
            {
                MessageBox.Show("Liftime has to be a decimal number");
                return false;
            }
            else if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show("Frequency can't be less or equal zero");
                return false;
            }
            else if (!(numericUpDown2.Value == (int)numericUpDown2.Value))
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
                MainMenuCopy.AddToDataGridView(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value, char.Parse(textBox2.Text));
                Close();
            }
        }
    }
}