using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ClientDatabase
{
    public partial class RenewalNotificationsForm : Form
    {
        private List<Client> clientsToRenew;
        private MainForm mainForm;

        public RenewalNotificationsForm(List<Client> clients, MainForm form)
        {
            InitializeComponent();
            clientsToRenew = clients;
            mainForm = form;
            FillTables();
            LoadEmailLogs();
        }
        public void FillTables()
        {
            // Fill the table with clients whose renewal date is within 5 days
            DateTime today = DateTime.Now;
            ConfigureClientGridView();

            // Load the email log entries
            List<string> emailLogEntries = LoadEmailLogEntries();

            foreach (Client client in clientsToRenew)
            {
                if ((client.DateRenewal - today).TotalDays <= 5)
                {
                    // Check if an email entry for this client exists in the log file
                    bool emailSent = EmailSentToClient(client.ClientId, emailLogEntries);

                    // If an email has not been sent to this client, add them to the renewal table
                    if (!emailSent)
                    {
                        dataGridViewClientsToRenew.Rows.Add(client.ClientId, client.CompanyName, client.DateRenewal);
                    }
                }
            }

        }

        private void ConfigureRenewalLogsGridView()
        {
            dataGridViewRenewalLogs.AutoGenerateColumns = false;
            dataGridViewRenewalLogs.Columns.Clear();

            dataGridViewRenewalLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LogEntry",
                HeaderText = "Log Entry",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Adjust column width
            });
        }
        private void ConfigureClientGridView()
        {
            dataGridViewClientsToRenew.AutoGenerateColumns = false;
            dataGridViewClientsToRenew.Columns.Clear();

            dataGridViewClientsToRenew.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientId",
                HeaderText = "Client ID",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridViewClientsToRenew.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Client Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridViewClientsToRenew.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateRenewal",
                HeaderText = "Renewal Date",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
        }
        private List<string> LoadEmailLogEntries()
        {
            List<string> emailLogEntries = new List<string>();
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");

            if (File.Exists(logFilePath))
            {
                emailLogEntries = File.ReadAllLines(logFilePath).ToList();
            }

            return emailLogEntries;
        }
        private bool EmailSentToClient(int clientId, List<string> emailLogEntries)
        {
            string clientIdentifier = $"Client ID {clientId}";

            foreach (string entry in emailLogEntries)
            {
                if (entry.Contains(clientIdentifier))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewClientsToRenew.SelectedRows)
            {
                int clientId = (int)dataGridViewClientsToRenew.CurrentRow.Cells[0].Value;
                mainForm.SendEmail(clientId);
                MoveRowToLogs(row);
            }
        }
        private void MoveRowToLogs(DataGridViewRow row)
        {
            string logEntry = $"{DateTime.Now}: Email of Client ID {row.Cells[0].Value} was sent to {mainForm.currentRecipient}";
            dataGridViewRenewalLogs.Rows.Add(logEntry);
            dataGridViewClientsToRenew.Rows.Remove(row);
        }
        public void LoadEmailLogs()
        {
            dataGridViewRenewalLogs.Rows.Clear(); // Clear existing rows
            ConfigureRenewalLogsGridView();
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
            if (File.Exists(logFilePath))
            {
                var logEntries = File.ReadAllLines(logFilePath);
                foreach (var logEntry in logEntries)
                {
                    dataGridViewRenewalLogs.Rows.Add(logEntry);
                }
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            // Remove selected log entries from the email log .txt file
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
            if (File.Exists(logFilePath))
            {
                var logEntries = File.ReadAllLines(logFilePath).ToList();
                var entriesToRemove = new List<string>();

                foreach (DataGridViewRow row in dataGridViewRenewalLogs.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string selectedLogEntry = row.Cells[0].Value.ToString();
                        entriesToRemove.Add(selectedLogEntry);
                    }
                }

                // Remove the collected entries from the logEntries list
                foreach (var entry in entriesToRemove)
                {
                    logEntries.Remove(entry);
                }

                File.WriteAllLines(logFilePath, logEntries);

                // Clear selected rows from the dataGridViewRenewalLogs after updating the .txt file
                foreach (DataGridViewRow row in dataGridViewRenewalLogs.SelectedRows)
                {
                    dataGridViewRenewalLogs.Rows.Remove(row);
                }
            }
        }

        private void btnClearOldLogs_Click(object sender, EventArgs e)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
            if (File.Exists(logFilePath))
            {
                var logEntries = File.ReadAllLines(logFilePath);
                List<string> updatedLogs = new List<string>();
                foreach (var logEntry in logEntries)
                {
                    string[] parts = logEntry.Split(' ');
                    DateTime logDate = DateTime.Parse(parts[0]);
                    if ((DateTime.Now - logDate).TotalDays <= 60) // Only keep logs within 2 months
                    {
                        updatedLogs.Add(logEntry);
                    }
                }
                File.WriteAllLines(logFilePath, updatedLogs);
                LoadEmailLogs(); // Reload email logs
            }
        }

        private void btnCheckRenewalDate_Click(object sender, EventArgs e)
        {
            mainForm.CheckRenewalDates();
            FillTables();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
