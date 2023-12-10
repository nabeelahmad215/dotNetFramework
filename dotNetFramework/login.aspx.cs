using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotNetFramework
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con != null)
            {

                lblMsg.Text = "connection failed";
            }
            else if(con == null)
            {
                lblMsg.Text = "Passed";
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



                //string queryUser = "SELECT full_name FROM tblLoginData WHERE username='" + user + "'";
                //SqlCommand cmdUser = new SqlCommand(queryUser, con);
                //string strUsrNm = Convert.ToString(cmdUser.ExecuteScalar());
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM tblLoginData WHERE username='" + user + "' AND password='" + pass + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //string qry = "SELECT * FROM tblLoginData WHERE username='"+user+"' AND password='"+pass+"'";
                //SqlCommand cmd = new SqlCommand(qry, con);
                //SqlDataReader reader = cmd.ExecuteReader();
                //if (reader.Read())

                foreach (DataRow dr in dt.Rows)
                {
                    //DataTable dt = new DataTable();
                    //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    //adp.Fill(dt);

                    //lblMsg.Text = "Your Username is: " + strUsrNm; 
                    Session["username"] = dr["username"].ToString();
                    Response.Redirect("Dashboard.aspx");

                }
                //else
                //{
                //    //lblMsg.Text = "Check Username & Password";
                //}
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message); 
            }
        }
    }
}
//if (imetxt.text == "")
//{
//    messagebox.show("please enter a valid user name!");
//    imetxt.focus();
//    return;
//}
//else if (passtxt.text == "")
//{
//    messagebox.show("please enter a valid password!");
//    passtxt.focus();
//    return;
//}