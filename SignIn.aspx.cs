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
    public partial class SignIn : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd=teejaySQL;database=legendsstore");
        MySqlDataAdapter ad;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM customer WHERE FirstName = '"+txtName.Text+"'", conn);
                ad = new MySqlDataAdapter(command);

                //ad.SelectCommand = command;
                //ad.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();

                ad.Fill(dt);

                /*if (dt.Rows.Count == 1)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Close();
                }
                */

                HttpCookie _customer = new HttpCookie("Information");
                _customer["name"] = txtName.Text; 
                Response.Cookies.Add( _customer );
                _customer.Expires = DateTime.Now.AddMonths(1);
                
                Response.Redirect("Home.aspx");

                conn.Close();
            }
            catch (MySqlException error)
            {
                Error.Text = error.Message;
            }
        }
    }
}