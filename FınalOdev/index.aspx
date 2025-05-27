<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FınalOdev.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <h1> Abdullah Emre Çığ </h1>

                <div class="foto-oyun">


<asp:Repeater ID="rptImages" runat="server">
    <ItemTemplate>
        <div class="oyun-item animate-on-scroll">
            <img src="ImageHandler.ashx?id=<%# Eval("Id") %>" alt="Fotoğraf">
            <p><%# Eval("Description") %></p>
        </div>
    </ItemTemplate>
</asp:Repeater>

                    </div>


</asp:Content>