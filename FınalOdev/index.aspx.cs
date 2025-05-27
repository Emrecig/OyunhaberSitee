using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FınalOdev
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadImages();
            }
        }

        private void LoadImages()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Id FROM Images";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    List<string> descriptions = new List<string>
            {
                "Gearbox Software, Gamescom açılış gecesinde Borderlands 4'ü duyurdu. İşte  sevilen shooter serisinden resmi fragman ve beklenen çıkış tarihi...",
                "Death Stranding 2: On the Beach için meraklı bekleyiş devam ederken Hideo Kojima oyunun çıkış tarihine ilişkin yeni açıklamalarda bulundu.",
                "Doom: The Dark Ages ne zaman çıkacak? Xbox Games Showcase kapsamında tanıtılan yeni oyun, hikayeyi Orta Çağ'a götürecek.",
                "SNK'nın açıklamasına göre Fatal Fury: City of the Wolves isimli bu yeni oyun 2025 yılının başlarında çıkacak.",
                "Dün gece gerçekleşen State of Play sunumunun en sonunda sürpriz bir şekilde ortaya çıkan Ghost of Yotei, bizleri Japonya semalarına geri götürüyor.",
                "Warhorse Studios’un sevilen aksiyon RPG oyunu Kingdom Come Deliverance 2’nin çıkış tarihi, geliştirici ekip tarafından 11 Şubat 2025 tarihine ertelendi.",
                "Mafia: The Old Country'nin fragmanının internete sızmasının ardından, oyunun tam fragmanı The Game Awards 2024'te ilk kez yayınlandı. Ayrıca oyunun çıkış dönemi de açıklandı.",
                "Little Nightmares oyununun ertelendiğini duyurdu. Bu sene içerisinde çıkması planlanan oyunun 2025 yılına sarkıtıldığı açıklandı.",
                "Ubisoft, Assassin's Creed Shadows'un çıkış tarihini 14 Şubat 2025 tarihine erteledi. Bu ertelemenin nedeni ise geçtiğimiz saatlerde belli oldu. İşte detaylar...",
                "Sid Meier’s Civilization VII veya kısaca Civilization 7 için beklenen çıkış tarihi açıklandı. Firaxis Games, Gamescom kapsamında aynı zamanda bir de oynanış fragmanı yayınladı.",
                "CD Projekt, The Witcher 4'ün yakında üretime gireceğini açıkladı. Polonyalı geliştirici aynı zamanda The Witcher 4 çıkış tarihi hakkında bazı tüyolar ve Cyberpunk 2 hakkında bilgiler verdi.",
                "Rockstar, Grand Theft Auto VI fragmanını yayınlayalı çok uzun süre geçti \"GTA 6 çıkış tarihi ertelendi\" dedikoduları ortaya çıktı."
            };

      
                    dt.Columns.Add("Description", typeof(string));

              
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i < descriptions.Count)
                            dt.Rows[i]["Description"] = descriptions[i];
                        else
                            dt.Rows[i]["Description"] = "Varsayılan açıklama."; 
                    }

                    rptImages.DataSource = dt;
                    rptImages.DataBind();
                }
            }
        }
    }
}