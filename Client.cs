using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ClientDatabase
{
    public class Client
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public int Tier { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateRenewal { get; set; }
        public decimal Cost { get; set; }


        // change the source to user SQL server name
        public string connectionString = ConfigurationManager.ConnectionStrings["ClientDatabaseConnectionString"].ConnectionString;

        // get client method
        public List<Client> GetClients() // required to install microsoft.data.sqlclient in nuget packages
        {
            List<Client> clientList = new List<Client>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectSQL = "SELECT ClientID, CompanyName, Address, ClientName, Title, Tier, Email, Phone, Cost, DateRenewal FROM GetClientData";

                SqlCommand cmd = new SqlCommand(selectSQL, con);

                try
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Client client = new Client();

                            client.ClientId = Convert.ToInt32(dr["ClientId"]);
                            client.CompanyName = dr["CompanyName"].ToString();
                            client.Address = dr["Address"].ToString();
                            client.ClientName = dr["ClientName"].ToString();
                            client.Title = dr["Title"].ToString();
                            client.Tier = Convert.ToInt32(dr["Tier"]);
                            client.Email = dr["Email"].ToString();
                            client.Phone = dr["Phone"].ToString();
                            client.DateRenewal = Convert.ToDateTime(dr["DateRenewal"]);
                            client.Cost = Convert.ToDecimal(dr["Cost"]);

                            clientList.Add(client);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return clientList;
        }

        // create client method
        public void CreateClient(Client client)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateClient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", client.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@Address", client.Address));
                cmd.Parameters.Add(new SqlParameter("@ClientName", client.ClientName));
                cmd.Parameters.Add(new SqlParameter("@Title", client.Title));
                cmd.Parameters.Add(new SqlParameter("Tier", client.Tier));
                cmd.Parameters.Add(new SqlParameter("Email", client.Email));
                cmd.Parameters.Add(new SqlParameter("Phone", client.Phone));
                cmd.Parameters.Add(new SqlParameter("@DateRenewal", client.DateRenewal));
                cmd.Parameters.Add(new SqlParameter("@Cost", client.Cost));

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Get the client id method
        public Client GetClientData(int clientId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            String selectSQL = "select ClientID, CompanyName, Address, ClientName, Title, Tier, Email, Phone, Cost, DateRenewal from GetClientData where ClientID = " + clientId;
            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Client client = new Client();

            if (dr != null)
            {
                while (dr.Read())
                {
                    client.ClientId = Convert.ToInt32(dr["ClientId"]);
                    client.CompanyName = dr["CompanyName"].ToString();
                    client.Address = dr["Address"].ToString();
                    client.ClientName = dr["ClientName"].ToString();
                    client.Title = dr["Title"].ToString();
                    client.Tier = Convert.ToInt32(dr["Tier"]);
                    client.Email = dr["Email"].ToString();
                    client.Phone = dr["Phone"].ToString();
                    client.DateRenewal = Convert.ToDateTime(dr["DateRenewal"]);
                    client.Cost = Convert.ToDecimal(dr["Cost"]);

                }
            }
            return client;
        }

        // edit client method
        public void EditClient(Client client)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ClientId", client.ClientId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", client.CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@Address", client.Address));
                    cmd.Parameters.Add(new SqlParameter("@ClientName", client.ClientName));
                    cmd.Parameters.Add(new SqlParameter("@Title", client.Title));
                    cmd.Parameters.Add(new SqlParameter("Tier", client.Tier));
                    cmd.Parameters.Add(new SqlParameter("Email", client.Email));
                    cmd.Parameters.Add(new SqlParameter("Phone", client.Phone));
                    cmd.Parameters.Add(new SqlParameter("@DateRenewal", client.DateRenewal));
                    cmd.Parameters.Add(new SqlParameter("@Cost", client.Cost));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Delete client method
        public void DeleteClient(int clientId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("DeleteClient", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ClientId", clientId));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
