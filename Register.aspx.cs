using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace onlineStore
{
    public partial class Register : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=teejaySQL;database=legendsstore");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO customer(Customer_ID,FirstName,LastName,EmailAddress,Contact_No) VALUES (@id,@name,@surname,@email,@tel,@password)", con);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@tel", txtTel.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.ExecuteNonQuery();

                Label1.Text = "Sucessfully Registered. Click ";

                con.Close();
            }
            catch (MySqlException error)
            {
                lblError.Text = error.Message;
            }
        }
    }
}