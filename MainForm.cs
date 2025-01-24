using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClientDatabase
{
    public partial class MainForm : Form
    {

        List<Client> clientList = new List<Client>();
        private string loggedInUserEmail;
        private string loggedInUserPassword;
        private string defaultEmail;
        public string currentRecipient;
        private Timer renewalCheckTimer;

        public MainForm()
        {
            InitializeComponent();
            FillGridView();
            AdjustGridView();
            UpdateLoggedInUserLabel();
            LoadDefaultEmail();
            currentRecipient = defaultEmail; // Set current recipient to default email
            lblCurrentReceiverEmail.Text = currentRecipient; // Change to currentRecipient
            checkToAskLogin();

            // Initial check
            CheckRenewalDates();
            InitializeRenewalCheckTimer();
        }
        // Check auto-send email setting on startup
        private void InitializeRenewalCheckTimer()
        {
            // Set up the timer to check every 12 hours
            renewalCheckTimer = new Timer();
            renewalCheckTimer.Interval = 12 * 60 * 60 * 1000; // 12 hours in milliseconds
            renewalCheckTimer.Tick += new EventHandler(OnRenewalCheckTimerTick);
            renewalCheckTimer.Start();

            // Call the method initially
            OnRenewalCheckTimerTick(null, EventArgs.Empty);
        }

        private void checkToAskLogin()
        {
            if (LoadAutoSendEmailSetting())
            {
                while (string.IsNullOrEmpty(loggedInUserEmail))
                {
                    DialogResult result = MessageBox.Show("Auto-send email is enabled. Please log in to your " +
                                                          "email account to send emails automatically.", "Login Required", 
                                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        btnLogin_Click(null, null); // Call login button click event
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        DialogResult skipLoginResult = MessageBox.Show("Are you sure that you want to skip this step? " +
                                                                       "The system won't be able to automatically send emails " +
                                                                       "if you don't log in.", "Skip Login?", MessageBoxButtons.YesNo, 
                                                                        MessageBoxIcon.Warning);
                        if (skipLoginResult == DialogResult.Yes)
                        {
                            // User decided to skip login, break the loop
                            break;
                        }
                        else
                        {
                            // User decided not to skip, continue prompting for login
                            continue;
                        }
                    }
                }
            }
        }

        // setting up data grid view, pulling data from SQL. CRUD funtions.
        void FillGridView()
        {
            Client client = new Client();
            clientList = client.GetClients();
            dataGridViewClients.DataSource = clientList;
            CheckRenewalDates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClient formAddClient = new AddClient();
            formAddClient.ShowDialog();
            CheckRenewalDates();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClient();
            CheckRenewalDates();
        }

        void EditClient()
        {
            int clientId;
            if (dataGridViewClients.CurrentRow != null)
            {
                clientId = (int)dataGridViewClients.CurrentRow.Cells[0].Value;
                EditClient formEditClient = new EditClient(clientId);
                formEditClient.ShowDialog();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClient();
            CheckRenewalDates();
        }

        void DeleteClient()
        {
            int clientId;

            clientId = (int)dataGridViewClients.CurrentRow.Cells[0].Value;
            string companyRecord = dataGridViewClients.CurrentRow.Cells[1].Value.ToString();

            string message = "Do you want to delete '" + companyRecord + "' record?";
            DialogResult dr = MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Client client = new Client();
                client.DeleteClient(clientId);
                FillGridView();
            }
        }

        void AdjustGridView()
        {
            dataGridViewClients.Columns[0].HeaderText = "Member ID";
            dataGridViewClients.Columns[1].HeaderText = "Company Name";
            dataGridViewClients.Columns[3].HeaderText = "Contact Name";
            dataGridViewClients.Columns[8].HeaderText = "Renewal Date";

            dataGridViewClients.Columns[0].Width = 50;
            dataGridViewClients.Columns[1].Width = 130;
            dataGridViewClients.Columns[2].Width = 200;
            dataGridViewClients.Columns[3].Width = 130;
            dataGridViewClients.Columns[4].Width = 90;
            dataGridViewClients.Columns[5].Width = 40;
            dataGridViewClients.Columns[6].Width = 100;
            dataGridViewClients.Columns[7].Width = 90;
            dataGridViewClients.Columns[8].Width = 90;
            dataGridViewClients.Columns[9].Width = 80;
        }
        // ============ end of setting up functions =====================================

        // export to word function methods
        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
        void exportToWord()
        {
            int clientId;
            clientId = (int)dataGridViewClients.CurrentRow.Cells[0].Value;
            Client client = new Client();
            client = client.GetClientData(clientId);

            // ask user where to save the file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word Document|*.docx";
            saveFileDialog1.Title = "Save Reminder Letter";
            saveFileDialog1.FileName = client.CompanyName + "_Reminder Letter"; // default file name

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                GenerateDocument(client, saveFileDialog1.FileName);
                MessageBox.Show("Document generated successfully.");
            }

        }
        void GenerateDocument(Client client, string filePath, bool includePdf = false)
        {
            // connect and create word file
            Microsoft.Office.Interop.Word._Application word = new Microsoft.Office.Interop.Word.Application(); //create word object
            Document doc = word.Documents.Add();

            DateTime dt = DateTime.Now;
            // get sender and receiver info
            string senderInfo = "\n\nScott Ransom, PHD\n" +
                                "3800 E. Stevens Way NE\n" +
                                "Seattle, WA 98105\n" +
                                dt.ToString("MMMM dd, yyyy") + ".\n";

            string receiverInfo = " " +
                                  client.ClientName + "\n" +
                                  client.Title + ", " + "\n" +
                                  client.CompanyName + "\n" +
                                  client.Address + "\n";

            // Add a table with 1 row and 2 columns
            Table table = doc.Tables.Add(doc.Range(0, 0), 1, 2);
            table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);

            // Add picture to the first cell (left)
            string picturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CMaT_Logo_w_byline.jpg");
            InlineShape picture = table.Cell(1, 1).Range.InlineShapes.AddPicture(picturePath);
            picture.Width = 230; // Adjust picture width as needed
            picture.Height = 85;

            // Add sender information to the second cell (right)
            table.Cell(1, 2).Range.Text = senderInfo;
            table.Cell(1, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

            // Add receiver information justified to the left
            Paragraph receiverPara = doc.Content.Paragraphs.Add();
            receiverPara.Range.Text = receiverInfo;

            // Letter body text
            Paragraph bodyPara = doc.Content.Paragraphs.Add();
            bodyPara.Range.Text = "\nDear " + client.ClientName + ",\n" +
                                  "We at CNT hope you have enjoyed this past year of membership in the CNT Industry Member program" +
                                  " and are looking forward to your dues renewal for this next year." +
                                  " Attached please find the invoice for these dues.\n" +
                                  "Your membership dues of " + client.Cost.ToString($"C") + " annually allow CNT to send students " +
                                  "to conferences, provide supplies and resources for student hackathons, host Industry " +
                                  "/ Student Seminars, and support other operations that benefit our students and industry program." +
                                  " These help us achieve our mission of developing neurotechnology solutions to help stroke " +
                                  "and spinal cord injury patients around the world." +
                                  " On behalf of CNT, our students and faculty, thank you for your Industry Affiliate " +
                                  "program membership renewal and your continued support for our research efforts!" +
                                  " We really appreciate our partnership with you and " + client.CompanyName +
                                  " and are excited about our collaborations going forward.\n" +
                                  "Best regards,\n";
            string signPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Picture1.png");
            InlineShape signPic = bodyPara.Range.InlineShapes.AddPicture(signPath);
            bodyPara.Range.InsertParagraphAfter();
            bodyPara.Range.Text = "Scott Ransom\n" + "University of Washington\n" + "Tacoma";

            // Save the document
            object fileName = filePath;
            object fileFormat = WdSaveFormat.wdFormatDocumentDefault;
            doc.SaveAs2(ref fileName, ref fileFormat);
            doc.Close();
            word.Quit();

            if (includePdf)
            {
                // Create PDF from the generated Word document
                var pdfFileName = Path.ChangeExtension(filePath, ".pdf");
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document wordDoc = wordApp.Documents.Open(filePath);
                wordDoc.ExportAsFixedFormat(pdfFileName, WdExportFormat.wdExportFormatPDF);
                wordDoc.Close();
                wordApp.Quit();
            }
        }
        // ============= end of export to word function =================================


        // search and sort function methods
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower();
            List<Client> filteredList = new List<Client>();

            foreach (Client client in clientList)
            {
                if (client.CompanyName.ToLower().Contains(searchTerm) ||
                    client.ClientName.ToLower().Contains(searchTerm) ||
                    client.Address.ToLower().Contains(searchTerm) ||
                    client.Title.ToLower().Contains(searchTerm) ||
                    client.Tier.ToString().Contains(searchTerm) ||
                    client.Email.ToLower().Contains(searchTerm) ||
                    client.Phone.ToLower().Contains(searchTerm) ||
                    client.DateRenewal.ToString().Contains(searchTerm) ||
                    client.Cost.ToString().Contains(searchTerm))
                {
                    filteredList.Add(client);
                }
            }
            dataGridViewClients.DataSource = null;
            dataGridViewClients.DataSource = filteredList;
            AdjustGridView();
            CheckRenewalDates();
        }


        private void filterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string columnName = filterBox.SelectedItem.ToString();

            // Sort the client list by the selected column
            switch (columnName)
            {
                case "Company Name":
                    clientList = clientList.OrderBy(c => c.CompanyName).ToList();
                    break;
                case "Address":
                    clientList = clientList.OrderBy(c => c.Address).ToList();
                    break;
                case "Client Name":
                    clientList = clientList.OrderBy(c => c.ClientName).ToList();
                    break;
                case "Title":
                    clientList = clientList.OrderBy(c => c.Title).ToList();
                    break;
                case "Tier":
                    clientList = clientList.OrderBy(c => c.Tier).ToList();
                    break;
                case "Email":
                    clientList = clientList.OrderBy(c => c.Email).ToList();
                    break;
                case "Phone":
                    clientList = clientList.OrderBy(c => c.Phone).ToList();
                    break;
                case "Renewal Date":
                    clientList = clientList.OrderBy(c => c.DateRenewal).ToList();
                    break;
                case "Cost":
                    clientList = clientList.OrderBy(c => c.Cost).ToList();
                    break;
                case "Default":
                    clientList = clientList.OrderBy(c => c.ClientId).ToList();
                    break;
                default:
                    break;
            }
            dataGridViewClients.DataSource = null;
            dataGridViewClients.DataSource = clientList;
            AdjustGridView();
            CheckRenewalDates();
        }
        // ============== end of search and sort function ================================


        // Email function methods
        private void UpdateLoggedInUserLabel()
        {
            lblLoggedInUser.Text = loggedInUserEmail ?? "Email not logged in";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Logout")
            {
                loggedInUserEmail = null;
                loggedInUserPassword = null;
                btnLogin.Text = "Login";
                UpdateLoggedInUserLabel();
            }
            else
            {
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        loggedInUserEmail = loginForm.LoggedInUserEmail;
                        loggedInUserPassword = loginForm.LoggedInUserPassword;
                        btnLogin.Text = "Logout";
                        UpdateLoggedInUserLabel();
                    }
                }
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            int clientId = (int)dataGridViewClients.CurrentRow.Cells[0].Value;
            SendEmail(clientId);
        }

        public void SendEmail(int clientId)
        {
            if (!string.IsNullOrEmpty(loggedInUserEmail))
            {
                try
                {

                    Client client = new Client();
                    client = client.GetClientData(clientId);

                    string wordFilePath = Path.ChangeExtension(Path.GetTempFileName(), ".docx");
                    string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");
                    GenerateDocument(client, wordFilePath, true); // Generate both Word and PDF files

                    // Send email
                    string host;
                    int port;
                    if (loggedInUserEmail.EndsWith("@gmail.com"))
                    {
                        host = "smtp.gmail.com";
                        port = 587;
                    }
                    else if (loggedInUserEmail.EndsWith("@outlook.com"))
                    {
                        host = "smtp-mail.outlook.com";
                        port = 587;
                    }
                    else
                    {
                        MessageBox.Show("Unsupported email provider.");
                        return;
                    }

                    EmailHelper.SendEmail(loggedInUserEmail, currentRecipient, "Reminder", "Please find the attached reminder letter.", wordFilePath, pdfFilePath, host, port, loggedInUserPassword);

                    // Clean up
                    File.Delete(wordFilePath);
                    File.Delete(pdfFilePath);

                    // Update email log after sent email
                    string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
                    string logEntry = $"{DateTime.Now}: Email of Client ID {clientId} was sent to {currentRecipient}{Environment.NewLine}";
                    File.AppendAllText(logFilePath, logEntry);

                    MessageBox.Show("Email sent successfully.");
                    CheckRenewalDates();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select recipient and login to send an email.");
            }
        }
        private void LoadDefaultEmail()
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string defaultEmailFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "default_email.txt");
                if (File.Exists(defaultEmailFilePath))
                {
                    defaultEmail = File.ReadAllText(defaultEmailFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading default email: " + ex.Message);
            }
        }
        private void btnEmailSettings_Click(object sender, EventArgs e)
        {
            using (var emailManagementForm = new EmailManagementForm(currentRecipient))
            {
                if (emailManagementForm.ShowDialog() == DialogResult.OK)
                {
                    currentRecipient = emailManagementForm.CurrentRecipient;
                    lblCurrentReceiverEmail.Text = currentRecipient;
                }
            }
        }
        // ============ end of email function ==============================================

        // Check for renewal date function
        private void OnRenewalCheckTimerTick(object sender, EventArgs e)
        {
            CheckRenewalDates();
            if (LoadAutoSendEmailSetting())
            {
                List<Client> clientsToRenew = GetClientsToRenew();

                // Check if there are clients to renew before sending emails
                if (clientsToRenew.Count > 0)
                {
                    foreach (Client client in clientsToRenew)
                    {
                        SendEmail(client.ClientId); // Add a parameter to SendEmail to specify the client ID
                    }
                }
                else
                {
                    // Log or handle the case where no emails need to be sent
                    Console.WriteLine("No clients need renewal reminders at this time.");
                }
            }
        }
        public void CheckRenewalDates()
        {
            DateTime today = DateTime.Now;
            foreach (DataGridViewRow row in dataGridViewClients.Rows)
            {
                if (row.Cells["DateRenewal"].Value != null)
                {
                    DateTime renewalDate = Convert.ToDateTime(row.Cells["DateRenewal"].Value);
                    string clientId = row.Cells["ClientId"].Value.ToString();
                    if ((renewalDate - today).TotalDays <= 5 && (renewalDate - today).TotalDays >= 0)
                    {
                        if (HasSentEmailRecently(clientId, currentRecipient, 5))
                        {
                            row.DefaultCellStyle.BackColor = Color.Green;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    else if (renewalDate < today)
                    {
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        private bool HasSentEmailRecently(string clientId, string recipient, int days)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
            if (File.Exists(logFilePath))
            {
                var logEntries = File.ReadAllLines(logFilePath);
                DateTime today = DateTime.Now;
                foreach (var logEntry in logEntries)
                {
                    if (logEntry.Contains($"Client ID {clientId}") && logEntry.Contains($"at {recipient}"))
                    {
                        string[] parts = logEntry.Split(':');
                        DateTime logDate = DateTime.Parse(parts[0]);
                        if ((today - logDate).TotalDays <= days)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btnCheckRenewals_Click(object sender, EventArgs e)
        {
            List<Client> clientsToRenew = GetClientsToRenew();
            RenewalNotificationsForm renewalCheckForm = new RenewalNotificationsForm(clientsToRenew, this);
            renewalCheckForm.ShowDialog();
        }
        private List<Client> GetClientsToRenew()
        {
            DateTime today = DateTime.Now;
            List<Client> clientsToRenew = new List<Client>();
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_log.txt");
            HashSet<int> sentClientIds = new HashSet<int>();

            // Read client IDs from the email log file
            string pattern = @"Client\s+ID\s+(\d+)";

            // Read client IDs from the email log file
            if (File.Exists(logFilePath))
            {
                string[] logEntries = File.ReadAllLines(logFilePath);
                foreach (string logEntry in logEntries)
                {
                    // Match the pattern using Regex
                    Match match = Regex.Match(logEntry, pattern);
                    if (match.Success)
                    {
                        // Extract the client ID from the matched group
                        if (int.TryParse(match.Groups[1].Value, out int clientId))
                        {
                            sentClientIds.Add(clientId);
                        }
                    }
                }
            }

            // Add clients to renew if they are not in the email log file
            foreach (Client client in clientList)
            {
                if (!sentClientIds.Contains(client.ClientId) && (client.DateRenewal - today).TotalDays <= 5)
                {
                    clientsToRenew.Add(client);
                }
            }

            return clientsToRenew;
        }
        private bool LoadAutoSendEmailSetting()
        {
            string autoSendEmailFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "auto_send_email.txt");
            if (File.Exists(autoSendEmailFilePath))
            {
                string autoSendEmailSetting = File.ReadAllText(autoSendEmailFilePath);
                return bool.Parse(autoSendEmailSetting);
            }
            return false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Extract the PDF file from the resources
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Cell Manufacturing Technologies_UserManual.pdf");
            if (File.Exists(pdfPath))
            {
                // Open the PDF file using the default PDF viewer
                Process.Start(pdfPath);
            }
            else
            {
                MessageBox.Show("User manual not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

