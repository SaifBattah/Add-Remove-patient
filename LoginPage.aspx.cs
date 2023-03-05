using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalCenter
{
    public partial class LoginPage : System.Web.UI.Page
    {
        /*satart of public variables*/
        public string conString = "Data Source=SAIFBATTAH;Initial Catalog=MedicalCenter;Integrated Security=True";
        /*end of public variables*/
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DoctorsTable where Doctor_Name = @uname and Doctor_Pw = @password", con);
            cmd.Parameters.AddWithValue("@uname", UserName.Text);
            cmd.Parameters.AddWithValue("@password", PassWord.Text);

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                Session["username"] = UserName.Text.ToString();
                Server.Transfer("HomePage.aspx");
            }
            else
            {
                message.Text = "Invalid UserName or Password !!!";
            }

            sdr.Close();
            con.Close();
        }
    }
}