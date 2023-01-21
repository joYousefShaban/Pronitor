using Pronitor.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Pronitor
{
    public partial class MainMenu : Form
    {
        Timer refreshTimer;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            InitRefreshTimer();
        }

        private void InitRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            refreshTimer.Interval = 10000; //scan each ten secounds
            refreshTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dataGridView.Invoke((MethodInvoker)delegate
            {
                List<Monitor> monitoringList = Manager.MonitoringList;
                dataGridView.Rows.Clear();
                for (int i = 0; monitoringList.Count > i; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                    if (monitoringList[i].Tasks.Count > 0)
                    {
                        row.Cells[0].Style.BackColor = Color.Green;
                        row.Cells[0].Value = "Active (" + monitoringList[i].Tasks.Count + ")";
                        row.Cells[2].Value = monitoringList[i].Tasks[0].StartTime;
                    }
                    else
                    {
                        row.Cells[0].Style.BackColor = Color.Red;
                        row.Cells[0].Value = "InActive";
                        row.Cells[2].Value = "-";
                    }
                    row.Cells[1].Value = monitoringList[i].Name;
                    row.Cells[3].Value = monitoringList[i].LifeTime + " minutes";
                    row.Cells[4].Value = monitoringList[i].Frequency + " minutes";
                    row.Cells[5].Value = monitoringList[i].KillKey;
                    // Running on the UI thread
                    dataGridView.Rows.Add(row);
                }
            });
        }

        public void AddToDataGridView(string name, int lifeTime, int frequency, char key)
        {
            Manager.AddMonitor(name, lifeTime, frequency, key);
            RefreshDataGridView();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AddTaskForm>().Count() == 1)
                Application.OpenForms.OfType<AddTaskForm>().First().Focus();
            else
            {
                AddTaskForm addProcessForm = new AddTaskForm(this);
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
                var cell = ((DataGridViewButtonCell)dataGridView.Rows[i - 1].Cells[0]);
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