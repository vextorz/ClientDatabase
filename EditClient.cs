using System;
using System.Windows.Forms;

namespace ClientDatabase
{
    public partial class EditClient : Form
    {

        int selectClientId;
        public EditClient(int clientId)
        {
            InitializeComponent();
            selectClientId = clientId;
            GetClientData();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            EditClientData();
            BacktoMainForm();
        }

        void GetClientData()
        {
            Client client = new Client();
            client = client.GetClientData(selectClientId);

            addCompanyNameBox.Text = client.CompanyName;
            addAddressBox.Text = client.Address;
            addNameBox.Text = client.ClientName;
            addTitleBox.Text = client.Title;
            addTierBox.Text = client.Tier.ToString();
            addEmailBox.Text = client.Email;
            addPhoneBox.Text = client.Phone;
            dateRenewal.Value = client.DateRenewal;
            addCostBox.Text = client.Cost.ToString();

        }

        void EditClientData()
        {
            Client client = new Client();

            client.ClientId = selectClientId;
            client.CompanyName = addCompanyNameBox.Text;
            client.Address = addAddressBox.Text;
            client.ClientName = addNameBox.Text;
            client.Title = addTitleBox.Text;
            client.Tier = Convert.ToInt32(addTierBox.Text);
            client.Email = addEmailBox.Text;
            client.Phone = addPhoneBox.Text;
            client.DateRenewal = dateRenewal.Value;
            client.Cost = Convert.ToDecimal(addCostBox.Text);


            client.EditClient(client);
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
