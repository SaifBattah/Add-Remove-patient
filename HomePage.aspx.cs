using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalCenter
{
    public partial class HomePage : System.Web.UI.Page
    {
        /*satart of public variables*/
        public string connectionString = "Data Source=SAIFBATTAH;Initial Catalog=MedicalCenter;Integrated Security=True";
        /*end of public variables*/
        protected void Page_Load(object sender, EventArgs e)
        {
            lblwelcome.Text = "Welcome Dr."+ Session["username"];
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query1 = "SELECT * FROM PatientTable Where Patient_Doctor = '"+ Session["username"] + "'";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable dt1 = new DataTable();
                    adapter1.Fill(dt1);
                    tblyourpat.DataSource = dt1;
                    tblyourpat.DataBind();
                    connection.Close();

                    if (tblyourpat.Rows.Count == 0)
                    {
                        empty.Text = "No patients found for this doctor";
                        empty.Visible = true;
                    }
                    else
                    {
                        empty.Visible = false;
                    }

                    //---------------------------------------------------------//


                    connection.Open();
                    string query2 = "SELECT * FROM PatientTable ";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    tblallpat.DataSource = dt2;
                    tblallpat.DataBind();
                    connection.Close();

                }
            }
        }

        protected void btnlgout_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx");
        }

        protected void tblallpat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = tblallpat.SelectedRow;
            string patientId = row.Cells[1].Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE PatientTable SET Patient_Doctor = @Doctor WHERE Patient_ID = @PatientId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Doctor", Session["username"]);
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.ExecuteNonQuery();
                connection.Close();

                // Refresh the tblyourpat gridview
                tblyourpat.DataBind();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}