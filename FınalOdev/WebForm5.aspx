<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="FınalOdev.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:Panel ID="pnlLogin" runat="server" CssClass="login-panel">
    <h2 class="login-title">Giriş Yap</h2>

    <asp:Label ID="lblLoginMessage" runat="server" ForeColor="Red" CssClass="login-message"></asp:Label><br />

    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Kullanıcı Adı" CssClass="login-input"></asp:TextBox><br />

    <asp:TextBox ID="txtPassword" runat="server" Placeholder="Şifre" TextMode="Password" CssClass="login-input"></asp:TextBox><br />

    <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" CssClass="login-button" />
</asp:Panel>






    <asp:Panel ID="pnlContent" runat="server" Visible="false">
    <div class="popup" id="popup">
        <div class="popup-content">
            <span class="popup-close" onclick="closePopup()">×</span>
            <h3>Duyuru</h3>
            <p id="deneme1" runat="server"></p>
            <p id="deneme2" runat="server"></p>
            <p id="deneme3" runat="server"></p>
        </div>
    </div>


    <asp:Panel ID="pnlDuyuruGuncelle" runat="server" CssClass="panel">
        <h4>Duyuru Güncelle</h4>
        <asp:TextBox ID="txtDuyuruMetin" runat="server" CssClass="form-control" placeholder="Yeni Duyuru Metni"></asp:TextBox>
        <br />
        <asp:DropDownList ID="ddlDuyuruSec" runat="server" CssClass="form-control">
            <asp:ListItem Value="1">Duyuru 1</asp:ListItem>
            <asp:ListItem Value="2">Duyuru 2</asp:ListItem>
            <asp:ListItem Value="3">Duyuru 3</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnDuyuruGuncelle" runat="server" Text="Duyuruyu Güncelle" OnClick="btnDuyuruGuncelle_Click" CssClass="btn btn-primary" />
    </asp:Panel>















<div class="panel-container">
    <h2 class="panel-title">Fotoğraf Yönetim Paneli</h2>

    <div class="panel-content">
        <label for="ddlImages">Mevcut Fotoğraflar:</label>
        <asp:DropDownList ID="ddlImages" runat="server" CssClass="dropdown-list"></asp:DropDownList>

        <label for="fileUpload">Yeni Fotoğraf Seç:</label>
        <asp:FileUpload ID="fileUpload" runat="server" CssClass="file-upload" />

        <asp:Button ID="btnUpdateImage" runat="server" Text="Güncelle" OnClick="btnUpdateImage_Click" CssClass="update-button" />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="message-label"></asp:Label>
    </div>
</div>


                </asp:Panel>

            <script type="text/javascript">
                window.onload = function () {

                    document.getElementById("popup").style.display = "block";
                };

                function closePopup() {

                    document.getElementById("popup").style.display = "none";
                }
            </script>


    <style>
        .popup {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            z-index: 1000;
        }
    .popup-content {
        background-color: #fff;
        padding: 20px;
        border-radius: 8px;
        width: 50%;
        margin: 10% auto;
        text-align: center;
        color: black; 
    }


    .popup-close {
        position: absolute;
        top: 10px;
        right: 10px;
        font-size: 25px;
        cursor: pointer;
    }

            .popup-message {
            margin: 10px 0; 
        }
</style>

</asp:Content>
