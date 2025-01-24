using System;
using System.Windows.Forms;

namespace ClientDatabase
{
    public partial class LoginForm : Form
    {
        public string LoggedInUserEmail { get; private set; }
        public string LoggedInUserPassword { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            textPassBox.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = textEmailBox.Text.Trim();
            string password = textPassBox.Text.Trim();
            if (EmailHelper.ValidateCredentials(email, password, "smtp.gmail.com", 587) || EmailHelper.ValidateCredentials(email, password, "smtp-mail.outlook.com", 587))
            {
                LoggedInUserEmail = email;
                LoggedInUserPassword = password;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }
    }
}
