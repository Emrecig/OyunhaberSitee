using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace FınalOdev
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
    
                string kullaniciAd = txtAd.Text.Trim();
                string kullaniciEmail = txtEmail.Text.Trim();
                string kullaniciMesaj = txtMesaj.Text.Trim();

            
                if (string.IsNullOrEmpty(kullaniciAd) || string.IsNullOrEmpty(kullaniciEmail) || string.IsNullOrEmpty(kullaniciMesaj))
                {
                    lblSonuc.Text = "Lütfen tüm alanları doldurun.";
                    return;
                }

     
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("emrecig4@gmail.com"); 
                mail.To.Add("emrecig4@gmail.com"); 
                mail.Subject = "Yeni İletişim Formu Mesajı";

          
                mail.Body = $"<b>Ad Soyad:</b> {kullaniciAd}<br>" +
                            $"<b>E-posta:</b> {kullaniciEmail}<br><br>" +
                            $"<b>Mesaj:</b><br>{kullaniciMesaj}<br><br>";

                mail.IsBodyHtml = true; 

               
                if (fuDosya.HasFile)
                {
                    string dosyaAdi = Path.GetFileName(fuDosya.FileName);
                    Attachment attachment = new Attachment(fuDosya.FileContent, dosyaAdi);
                    mail.Attachments.Add(attachment);
                    mail.Body += $"<b>Eklenen Dosya:</b> {dosyaAdi}<br>";
                }
                else
                {
                    mail.Body += "<b>Eklenen Dosya:</b> Yok<br>";
                }

              
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("emrecig4@gmail.com", "boda uygg wprb qkwh");
                smtp.EnableSsl = true;

             
                smtp.Send(mail);


                lblSonuc.Text = "Mesaj başarıyla gönderildi!";
            }
            catch (Exception ex)
            {
                lblSonuc.Text = "Hata oluştu: " + ex.Message;
            }

        }

        protected void txtAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}