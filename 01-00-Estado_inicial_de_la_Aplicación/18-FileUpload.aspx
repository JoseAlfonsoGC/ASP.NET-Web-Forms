<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="18-FileUpload.aspx.cs" Inherits="_01_00_Estado_inicial_de_la_Aplicación._18_FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnSubir" runat="server" OnClick="btnSubir_Click" Text="Subir" />
        </div>
    </form>
</body>
</html>
