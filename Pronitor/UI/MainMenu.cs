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
            AddToDataGridView("Discord", 1, 1, 'Q');
            AddToDataGridView("chrome", 1, 1, 'Q');
            InitRefreshTimer();
        }

        private void InitRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            refreshTimer.Interval = 1000; //scan each ten secounds
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
                int selectedRowIndex=0;
                int selectedColumnIndex = 0;
                if (dataGridView.CurrentCell != null)
                {
                    selectedRowIndex = dataGridView.CurrentCell.RowIndex;
                    selectedColumnIndex = dataGridView.CurrentCell.ColumnIndex;
                }
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
                dataGridView.Focus();
                dataGridView.CurrentCell = dataGridView.Rows[selectedRowIndex].Cells[selectedColumnIndex];
            });
        }

        public void AddToDataGridView(string name, int lifeTime, int frequency, char key)
        {
            Manager.AddMonitor(name, lifeTime, frequency, key);
            RefreshDataGridView();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (Application.OpenForms.OfType<AddTaskForm>().Count() == 1)
                Application.OpenForms.OfType<AddTaskForm>().First().Focus();
            else
            {
                AddTaskForm addProcessForm = new AddTaskForm(this);
                addProcessForm.Show();
            }
            button1.Enabled = true;
        }

        /*private void DataGridView_VisibleChanged(object sender, EventArgs e) => dataGridView.ClearSelection();*/

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 6 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                Manager.DeleteMonitor(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            else if (e.ColumnIndex == 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                Manager.KillTask(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Manager.KillTask();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Manager.DeleteMonitor();
        }
    }
}