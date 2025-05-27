using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FınalOdev
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSliderImages();
            }
        }
        private void LoadSliderImages()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            string query = "SELECT ImageUrl FROM SliderImages WHERE IsActive = 1";

            var imageList = new List<dynamic>();  // Anonymous type listesi

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    imageList.Add(new { ImageUrl = reader["ImageUrl"].ToString() });
                }
            }

            rptSlider.DataSource = imageList;
            rptSlider.DataBind();
        }
    }
}