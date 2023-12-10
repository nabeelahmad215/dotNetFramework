using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotNetFramework
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con != null) {
                
                //lblMsg.Text = "connection established";
            }
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            try 
            {
                string user = username.Text;
                string pass = password.Text;
                

                con.Open();
                //string queryUser = "SELECT full_name FROM tblLoginData WHERE username='" + user + "'";
                //SqlCommand cmdUser = new SqlCommand(queryUser, con);
                //string strUsrNm = Convert.ToString(cmdUser.ExecuteScalar());
                
                string qry = "SELECT * FROM tblLoginData WHERE username='"+user+"' AND password='"+pass+"'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //lblMsg.Text = "Your Username is: " + strUsrNm;
                    Response.Redirect("Dashboard.aspx");

                }
                else
                {
                    //lblMsg.Text = "Check Username & Password";
                }
                con.Close();

            }
            catch (Exception ex) 
            {
                Response.Write(ex.Message);
            }
        }
    }
}