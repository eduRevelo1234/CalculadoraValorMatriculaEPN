<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="proyecto02_EduardoR_BryanS.frmInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 151px;
        }
        .auto-style2 {
            text-align: center;
            width: 696px;
        }
        .auto-style3 {
            width: 696px;
        }
        .auto-style4 {
            width: 100%;
            height: 151px;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
        .auto-style5 {
            width: 334px;
        }
        .auto-style6 {
            text-align: left;
            width: 696px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Calculo de valor a pagar de matricula"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Ingrese su numero de cedula:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtNumeroDeCedula" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" ForeColor="#0099FF" OnClick="Button1_Click" Text="Iniciar Sesión" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
