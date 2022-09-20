<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="06-Variables_se_sesion_pasar_Info.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._06_Variables_se_sesion_pasar_Info" %>

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
            <asp:Button ID="btnIncrementa" runat="server" Text="Incrementa" OnClick="btnIncrementa_Click" />
        </div>
            <asp:Label ID="Label1" runat="server" Text="Variables de sesion WebForm2"></asp:Label>
    </form>
</body>
</html>
