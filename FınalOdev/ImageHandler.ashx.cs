using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FınalOdev
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int imageId;
            if (!int.TryParse(context.Request.QueryString["id"], out imageId))
            {
                context.Response.StatusCode = 400;
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ImageData, ContentType FROM Images WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", imageId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["ImageData"];
                        string contentType = reader["ContentType"].ToString();

                        context.Response.ContentType = contentType;
                        context.Response.BinaryWrite(imageData);
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}