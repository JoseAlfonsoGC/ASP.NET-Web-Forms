﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="05-Variables_de_sesión.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._05_Variables_de_sesión" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtConteo" runat="server"></asp:TextBox>
            <asp:Button ID="btnIncrementa" runat="server" OnClick="btnIncrementa_Click" Text="Incrementa" />
        </div>
            <asp:Label ID="Label1" runat="server" Text="Variables de sesion webForm1"></asp:Label>

    </form>
</body>
</html>
