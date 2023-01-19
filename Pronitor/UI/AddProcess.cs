using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pronitor
{
    public partial class AddProcess : Form
    {
        private MainMenu MainMenuCopy;
        public AddProcess(MainMenu MainMenuCopy)
        {
            //Make dependency enjection
            InitializeComponent();
            this.MainMenuCopy = MainMenuCopy;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainMenuCopy.AddToDataGridView(textBox1.Text, textBox2.Text, numericUpDown1.Value, numericUpDown2.Value);
            Close();
        }
    }
}