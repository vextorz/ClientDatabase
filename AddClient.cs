using System;
using System.Windows.Forms;

namespace ClientDatabase
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            SaveClientData();
            BacktoMainForm();
        }

        void SaveClientData()
        {
            Client client = new Client();

            client.CompanyName = addCompanyNameBox.Text;
            client.Address = addAddressBox.Text;
            client.ClientName = addNameBox.Text;
            client.Title = addTitleBox.Text;
            client.Tier = Convert.ToInt32(addTierBox.Text);
            client.Email = addEmailBox.Text;
            client.Phone = addPhoneBox.Text;
            client.DateRenewal = dateRenewal.Value;
            client.Cost = Convert.ToDecimal(addCostBox.Text);


            client.CreateClient(client);
        }

        // make sure the cost only in numberic
        private void addCostBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numbers, decimal point, and minus sign
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Allow minus sign only at the beginning
            if ((e.KeyChar == '-') && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        void BacktoMainForm()
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BacktoMainForm();
        }


    }
}
