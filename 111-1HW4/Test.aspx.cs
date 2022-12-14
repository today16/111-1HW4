using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;

namespace _111_1HW4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString
                );
            o_conn.Open();
            SqlDataAdapter o_a = new SqlDataAdapter("select * from Users", o_conn);
            DataSet o_d = new DataSet();
            o_a.Fill(o_d, "ds_Res");
            gd_View.DataSource = o_d;
            gd_View.DataBind();
            o_conn.Close();


        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString
                );
            o_conn.Open();

            SqlCommand o_cmd = new SqlCommand("Insert into Users (Name, Birthday) " +
                "values(N'阿貓阿狗','2000/10/10')", o_conn);
            o_cmd.ExecuteNonQuery();

            o_conn.Close();
               


        }
    }
}