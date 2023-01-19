using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pronitor
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void AddToDataGridView(string name, string key, decimal lifeTime, decimal frequency)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
            row.Cells[0].Style.BackColor = Color.Green;
            row.Cells[0].Value = "Active";
            row.Cells[1].Value = name;
            row.Cells[2].Value = "---";
            row.Cells[3].Value = lifeTime + " minutes";
            row.Cells[4].Value = frequency + " minutes";
            row.Cells[5].Value = key;
            dataGridView.Rows.Add(row);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AddProcess>().Count() == 1)
                Application.OpenForms.OfType<AddProcess>().First().Focus();
            else
            {
                AddProcess addProcessForm = new AddProcess(this);
                addProcessForm.Show();
            }
        }

        private void DataGridView_VisibleChanged(object sender, EventArgs e) => dataGridView.ClearSelection();

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 6 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex == 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                var cell = ((DataGridViewButtonCell)dataGridView.Rows[e.RowIndex].Cells[0]);
                if (cell.Value.Equals("Active"))
                {
                    cell.Value = "Inactive";
                    cell.Style.BackColor = Color.Red;
                    cell.Style.ForeColor = Color.White;
                }
                else
                {
                    cell.Value = "Active";
                    cell.Style.BackColor = Color.Green;
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView.Rows.Count; i++)
            {
                var cell = ((DataGridViewButtonCell)dataGridView.Rows[i-1].Cells[0]);
                if (cell.Value.Equals("Active"))
                {
                    cell.Value = "Inactive";
                    cell.Style.BackColor = Color.Red;
                    cell.Style.ForeColor = Color.White;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }
    }
}