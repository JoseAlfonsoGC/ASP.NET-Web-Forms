<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="21-HiddenField.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._21_HiddenField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfValor" runat="server" />
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Dato"></asp:Label>
                    <asp:TextBox ID="txtDato" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMostrar" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLeer" runat="server" OnClick="btnLeer_Click" Text="Leer" />
                    <asp:Button ID="btnMostrar" runat="server" OnClick="btnMostrar_Click" Text="Mostrar" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
