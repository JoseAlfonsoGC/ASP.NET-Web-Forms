<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="20-AdRotator.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._20_AdRotator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/anuncios.xml" />
        </div>
    </form>
</body>
</html>
