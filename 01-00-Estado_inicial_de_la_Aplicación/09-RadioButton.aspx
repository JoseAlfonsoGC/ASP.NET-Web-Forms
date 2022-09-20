<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="09-RadioButton.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._09_RadioButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButton ID="rbPizza" runat="server" GroupName="alimentos" Text="Pizza" AutoPostBack="True" OnCheckedChanged="rbPizza_CheckedChanged" />
            <asp:RadioButton ID="rbFruta" runat="server" GroupName="alimentos" Text="Fruta" />
            <asp:RadioButton ID="rbVerduras" runat="server" GroupName="alimentos" Text="Verduras" />
        </div>
        <div>
            <asp:Button ID="btnProcesa" runat="server" Text="Procesa" OnClick="btnProcesa_Click" />
        </div>
    </form>
</body>
</html>
