using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ClientDatabase
{
    public partial class EmailManagementForm : Form
    {
        private List<string> emailList;
        public string defaultEmail;
        private string currentRecipient; // Add a new variable to store the current recipient
        public string CurrentRecipient { get { return currentRecipient; } } // Modify the constructor to accept currentRecipient only


        public EmailManagementForm(string currentRecipient)
        {
            InitializeComponent();
            this.currentRecipient = currentRecipient; // Set the currentRecipient variable
            LoadEmailList();
            LoadDefaultEmail();
            LoadEmails();
            LoadAutoSendEmailSetting();
        }
        private void LoadEmails()
        {
            listBoxEmails.Items.Clear();
            foreach (string email in emailList)
            {
                string item = email;
                if (email == defaultEmail)
                    item += " (Default)";
                listBoxEmails.Items.Add(item);
            }
            lblCurrentReceiverEmail.Text = currentRecipient;
        }
        private void LoadEmailList()
        {
            try
            {

                string emailListFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_list.txt");
                if (File.Exists(emailListFilePath))
                {
                    emailList = new List<string>(File.ReadAllLines(emailListFilePath));
                }
                else
                {
                    emailList = new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading email list: " + ex.Message);
            }
        }
        private void LoadDefaultEmail()
        {
            try
            {
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
        private void SaveDefaultEmail()
        {
            try
            {
                string defaultEmailFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "default_email.txt");
                File.WriteAllText(defaultEmailFilePath, defaultEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving default email: " + ex.Message);
            }
        }
        private void SaveEmailList()
        {
            try
            {
                string emailListFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email_list.txt");
                File.WriteAllLines(emailListFilePath, emailList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving email list: " + ex.Message);
            }
        }
        private void LoadAutoSendEmailSetting()
        {
            string autoSendEmailFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "auto_send_email.txt");
            if (File.Exists(autoSendEmailFilePath))
                if (File.Exists(autoSendEmailFilePath))
                {
                    string autoSendEmailSetting = File.ReadAllText(autoSendEmailFilePath);
                    chkAutoSendEmail.Checked = bool.Parse(autoSendEmailSetting);
                }
        }
        private void SaveAutoSendEmailSetting()
        {
            string autoSendEmailFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "auto_send_email.txt");
            if (File.Exists(autoSendEmailFilePath))
                File.WriteAllText(autoSendEmailFilePath, chkAutoSendEmail.Checked.ToString());
        }

        // button functions
        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            if (listBoxEmails.SelectedItem != null)
            {
                defaultEmail = listBoxEmails.SelectedItem.ToString();
                for (int i = 0; i < listBoxEmails.Items.Count; i++)
                {
                    if (listBoxEmails.Items[i].ToString().Contains("(Default)"))
                        listBoxEmails.Items[i] = listBoxEmails.Items[i].ToString().Replace("(Default)", "").Trim();
                }
                listBoxEmails.Items[listBoxEmails.SelectedIndex] = defaultEmail + " (Default)";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDefaultEmail();
            SaveEmailList();
            SaveAutoSendEmailSetting();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newEmail = txtNewEmail.Text.Trim();
            if (!string.IsNullOrEmpty(newEmail) && !emailList.Contains(newEmail))
            {
                emailList.Add(newEmail);
                listBoxEmails.Items.Add(newEmail);
                txtNewEmail.Clear();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listBoxEmails.SelectedItem != null)
            {
                currentRecipient = listBoxEmails.SelectedItem.ToString();
                lblCurrentReceiverEmail.Text = currentRecipient;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxEmails.SelectedItem != null)
            {
                string selectedEmail = listBoxEmails.SelectedItem.ToString();
                emailList.Remove(selectedEmail);
                listBoxEmails.Items.Remove(selectedEmail);

                // If the removed email is the current recipient, update the current recipient label
                if (selectedEmail == currentRecipient)
                {
                    currentRecipient = "";
                    lblCurrentReceiverEmail.Text = "";
                }
            }
        }
    }
}
