using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _3tir_architecture
{
    public partial class COUNT : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["count"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setcount();
            }
        }
        public void setcount()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select countfield from Table_2;", con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                int c = Convert.ToInt32(dr["countfield"].ToString());
               // TextBox3.Text = "";
               c= c+1;
               TextBox3.Text = c.ToString(); ;
            }

        }
        protected void Save_Click(object sender, EventArgs e)
        {int a = Convert.ToInt32(TextBox3.Text);
        if (a == 2) { Response.Write("<Script> alert ('not save')</script>"); } 
  
        }
    }
}