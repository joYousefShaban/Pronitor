using Pronitor.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Pronitor
{
    public partial class MainMenu : Form
    {
        static private Timer refreshTimer;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshTimer.Dispose();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //DEFAULT VALUES 
            /*AddToDataGridView("Discord", 1, 1, 'S');
            AddToDataGridView("chrome", 10, 15);
            AddToDataGridView("OUTLOOK", 6, 2, 'C');
            AddToDataGridView("Messenger", 1, 2);
            AddToDataGridView("Taskmgr", 5, 2, 'A');*/
            InitRefreshTimer();
        }

        private void InitRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            refreshTimer.Interval = 500;  //Refresh each half a Second
            refreshTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                dataGridView.Invoke(new Action(() =>
                {
                    {
                        List<Monitor> monitoringList = Manager.MonitoringList;
                        int selectedRowIndex = 0;
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
                        if (selectedRowIndex < dataGridView.Rows.Count)
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[selectedRowIndex].Cells[selectedColumnIndex];
                        }
                        else
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[0].Cells[0];
                        }
                    }
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }

        public void AddToDataGridView(string name, int lifeTime, int frequency, char key = 'Q')
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

        private void Button3_Click(object sender, EventArgs e)
        {
            Manager.KillTask();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Manager.DeleteMonitor();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start(Logger.exePath);
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            List<Monitor> monotoringList = Manager.MonitoringList;
            for (int i = 0; i < monotoringList.Count; i++)
            {
                if (monotoringList[i].KillKey == e.KeyValue)
                {
                    Manager.DeleteMonitor(monotoringList[i].Name);
                    i--;
                }
            }
        }
    }
}