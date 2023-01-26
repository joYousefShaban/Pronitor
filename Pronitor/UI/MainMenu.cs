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
    public partial class UIMainMenu : Form
    {
        static private Timer refreshTimer;
        public UIMainMenu()
        {
            InitializeComponent();
        }

        // Form close event listener
        private void UIMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshTimer.Dispose();
        }

        // Form load event listener
        private void UIMainMenu_Load(object sender, EventArgs e)
        {
            //DEFAULT VALUES IF NEEDED
            /*
            AddToDataGridView("Discord", 1, 1, 'S');
            AddToDataGridView("chrome", 10, 15);
            AddToDataGridView("OUTLOOK", 6, 2, 'C');
            AddToDataGridView("Messenger", 1, 2);
            AddToDataGridView("Taskmgr", 5, 2, 'A');
            */
            InitRefreshTimer();
        }

        // Initialize timer upon refresh seconds
        private void InitRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            refreshTimer.Interval = 500;  //Refresh each half a Second
            refreshTimer.Enabled = true;
        }

        // Timer event listener
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            RefreshDataGridView();
        }

        // Periodically refreshes the gridview based on the updated model
        private void RefreshDataGridView()
        {
            // Used try catch block to handle possible thread exeptions
            try
            {
                // Executes the specified delegate on the main thread
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

                            // Checks whether the monitor contians any active tasks or not
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

                            dataGridView.Rows.Add(row);
                        }

                        // Preserve gridview cell focus after refresh
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
            catch (Exception)
            {
            }
        }

        // Append a new monitor to the datagridview
        public void AddToDataGridView(string name, int lifeTime, int frequency, char key = 'Q')
        {
            Manager.AddMonitor(name, lifeTime, frequency, key);
            RefreshDataGridView();
        }

        // Datagridview button click listner
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Checks if the button corresponds to the last column (delete monitor)
            if (e.ColumnIndex == 6 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                Manager.DeleteMonitor(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            // Checks if the button corresponds to the first column (delete task)
            else if (e.ColumnIndex == 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                Manager.KillTask(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        // Listen for keyboard entries and kill the corresponding monitors based on a predefined hotkey (killKey)
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

        // Add task button click listner
        private void AddMonitorButton_Click(object sender, EventArgs e)
        {
            AddMonitorButton.Enabled = false;
            if (Application.OpenForms.OfType<AddMonitorForm>().Count() == 1)
                Application.OpenForms.OfType<AddMonitorForm>().First().Focus();
            else
            {
                AddMonitorForm addProcessForm = new AddMonitorForm(this);
                addProcessForm.Show();
            }
            AddMonitorButton.Enabled = true;
        }

        // Open log button click listner
        private void OpenLogButton_Click(object sender, EventArgs e)
        {
            Process.Start(Logger.exePath);
        }

        // Kill all tasks button click listner
        private void KillAllTasksButton_Click(object sender, EventArgs e)
        {
            Manager.KillTask();
        }

        // Delete all monitors button click listner
        private void DeleteAllMonitorsButton_Click(object sender, EventArgs e)
        {
            Manager.DeleteMonitor();
        }
    }
}