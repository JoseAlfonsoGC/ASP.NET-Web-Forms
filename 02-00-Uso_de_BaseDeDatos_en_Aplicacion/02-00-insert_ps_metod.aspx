<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02-00-insert_ps_metod.aspx.cs" Inherits="_02_00_Uso_de_BaseDeDatos_en_Aplicacion._02_00_insert_ps_metod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlDatoAlumno" runat="server">
            <asp:GridView ID="gvdAlumnos" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo Alumno" />
        </asp:Panel>
        <asp:Panel ID="pnlAltaAlumno" runat="server" Visible="false">
            <div>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblAp_Paterno" runat="server" Text="Ap paterno"></asp:Label>
                <asp:TextBox ID="txtAp_Paterno" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblAp_materno" runat="server" Text="Ap_materno"></asp:Label>
                <asp:TextBox ID="txtAp_materno" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar alumno" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
