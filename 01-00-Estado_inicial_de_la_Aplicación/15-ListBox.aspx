<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="15-ListBox.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._15_ListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lbFrutas" runat="server" SelectionMode="Multiple">
                <asp:ListItem Text="Banana" Value="1"></asp:ListItem>
                <asp:ListItem Text="Cerveza" Value="2"></asp:ListItem>
                <asp:ListItem Text="Kiwi" Value="3"></asp:ListItem>
            </asp:ListBox>

            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click" />
        </div>
    </form>
</body>
</html>
