using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotNetFramework
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                string queryUser = "SELECT full_name FROM tblLoginData";
                SqlCommand cmdUser = new SqlCommand(queryUser, con);
                string strUsrNm = Convert.ToString(cmdUser.ExecuteScalar());

                    lblMsg.Text = "Your Username is: " + strUsrNm;
                    
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        
    }
}