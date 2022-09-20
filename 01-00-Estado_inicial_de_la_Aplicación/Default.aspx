<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        
    </p>
    <p>
        <asp:TextBox ID="txtConteo" runat="server"></asp:TextBox>
        <asp:Button ID="btnIncrementa" runat="server" OnClick="btnIncrementa_Click" Text="Incrementa" />
    </p>

</asp:Content>
