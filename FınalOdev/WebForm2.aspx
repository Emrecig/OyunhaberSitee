<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FınalOdev.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Abdullah Emre Çığ</h1>

    <div class="tanıtım-kutu">
          
         
        <div class="iletisim-bilgi">
            <h2>İletişim Bilgilerimiz</h2>
            <p><strong>Adres:</strong> OyunHaber Merkezi, Seyran, Ermenek, Türkiye</p>
            <p><strong>Telefon:</strong> +90 555 555 5555</p>
            <p><strong>E-posta:</strong> <a href="mailto:info@oyunhaber.com">info@oyunhaber.com</a></p>
            <p><strong>Çalışma Saatleri:</strong> Hafta içi 09:00 - 18:00</p>
        </div>


  
        <div class="map">
            <iframe 
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6403.978482452137!2d32.917279911667066!3d36.626645605906226!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14dbe77e604e1083%3A0xc0cfb3d5b76d4eee!2zR1NCIEVybWVuZWsgWXVydCBNw7xkw7xybMO8xJ_DvA!5e0!3m2!1sen!2str!4v1735125430100!5m2!1sen!2str" 
                allowfullscreen="" 
                loading="lazy" 
                referrerpolicy="no-referrer-when-downgrade">
            </iframe>
        </div>
       </div>

            <div class="form-container">
    <h2>İletişim Formu</h2>
    <asp:TextBox ID="txtAd" runat="server" CssClass="form-control" required="true" placeholder="Adınız" OnTextChanged="txtAd_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="true" placeholder="E-Posta"></asp:TextBox>
    <asp:TextBox ID="txtMesaj" runat="server" CssClass="form-control" TextMode="MultiLine" required="true" placeholder="Mesajınız"></asp:TextBox>

    <asp:FileUpload ID="fuDosya" runat="server" CssClass="form-control" />

    <asp:Button ID="btnGonder" runat="server" CssClass="btn btn-primary" Text="Gönder" OnClick="btnGonder_Click" />
    <asp:Label ID="lblSonuc" runat="server" CssClass="text-success"></asp:Label>

                     <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
</div>




</asp:Content>
