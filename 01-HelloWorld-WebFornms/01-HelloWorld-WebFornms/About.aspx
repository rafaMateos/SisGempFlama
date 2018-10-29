<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_01_HelloWorld_WebFornms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p><asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label></p>
    <p><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
    <p> <asp:Button ID="btnSaludar" runat="server" Text="Saludo" OnClick="btnSaludar_Click" /></p>
    <p><asp:Label ID="lblResultado" runat="server" Text=""></asp:Label></p>
</asp:Content>
