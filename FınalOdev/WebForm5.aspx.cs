using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;

namespace FınalOdev
{
    public partial class WebForm5 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["isLoggedIn"] != null && (bool)Session["isLoggedIn"])
                {
                    pnlLogin.Visible = false;
                    pnlContent.Visible = true;
                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlContent.Visible = false;
                }
            }
            if (!IsPostBack)
            {
                LoadDuyurular();
                LoadImages(); 
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string hardcodedUsername = "Emre";
            string hardcodedPassword = "1234";

            if (txtUsername.Text == hardcodedUsername && txtPassword.Text == hardcodedPassword)
            {
                Session["isLoggedIn"] = true;
                pnlLogin.Visible = false;
                pnlContent.Visible = true;
            }
            else
            {
                lblLoginMessage.Text = "Hatalı kullanıcı adı veya şifre!";
            }
        }
        private void LoadDuyurular()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;


            string query = "SELECT Metin FROM Duyurular";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int index = 1; 
                while (reader.Read())
                {
                    string metin = reader["Metin"].ToString();

                    if (index == 1)
                    {
                        deneme1.InnerText = metin;
                    }
                    else if (index == 2)
                    {
                        deneme2.InnerText = metin;
                    }
                    else if (index == 3)
                    {
                        deneme3.InnerText = metin;
                    }
                    index++;
                }
            }
        }

        protected void btnDuyuruGuncelle_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            string query = "UPDATE Duyurular SET Metin = @Metin WHERE ID = @ID"; 

            int duyuruID = int.Parse(ddlDuyuruSec.SelectedValue); 
            string yeniMetin = txtDuyuruMetin.Text; 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Metin", yeniMetin);
                cmd.Parameters.AddWithValue("@ID", duyuruID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

           
            LoadDuyurular();
        }

        private void LoadImages()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Id, ImageName FROM Images"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlImages.DataSource = reader;
                    ddlImages.DataValueField = "Id";
                    ddlImages.DataTextField = "ImageName"; 
                    ddlImages.DataBind();

                    conn.Close();
                }
            }
            ddlImages.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seçiniz...", "0")); 
        }

        protected void btnUpdateImage_Click(object sender, EventArgs e)
        {
            if (ddlImages.SelectedValue == "0")
            {
                lblMessage.Text = "Lütfen güncellenecek bir fotoğraf seçin!";
                return;
            }

            if (fileUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string query = "UPDATE Images SET ImageData = @ImageData, ImageName = @ImageName WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(ddlImages.SelectedValue);
                            cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = fileUpload.FileBytes;
                            cmd.Parameters.Add("@ImageName", SqlDbType.NVarChar).Value = fileUpload.FileName; 

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            lblMessage.Text = "Fotoğraf başarıyla güncellendi!";
                            LoadImages(); 
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Sadece .jpg, .jpeg, .png veya .gif dosyaları yükleyebilirsiniz!";
                }
            }
            else
            {
                lblMessage.Text = "Lütfen bir fotoğraf seçin!";
            }
        }
    }
}