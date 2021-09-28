<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIngresoDatos.aspx.cs" Inherits="proyecto02_EduardoR_BryanS.frmIngresoDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style4 {
            width: 100%;
            height: 151px;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
        .auto-style5 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            color: #0066FF;
            width: 317px;
        }
        .auto-style8 {
            text-align: center;
            width: 899px;
            height: 23px;
        }
        .auto-style10 {
            width: 948px;
        }
        .auto-style11 {
            width: 336px;
        }
        .auto-style14 {
            width: 318px;
            height: 23px;
        }
        .auto-style15 {
            height: 23px;
        }
        .auto-style16 {
            width: 318px;
        }
        .auto-style18 {
            width: 899px;
        }
        .auto-style19 {
            width: 317px;
        }
        .auto-style20 {
            width: 900px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style14"></td>
                    <td class="auto-style8">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Ingrese los datos para generar el pago"></asp:Label>
                    </td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Número de cedula:"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtNumeroCedula" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="Label3" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Nombre:"></asp:Label>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="txtNombre" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5">Fepon:</td>
                    <td class="auto-style20">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                            <asp:ListItem>Si</asp:ListItem>
                            <asp:ListItem Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="Label4" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Horas/Creditos: "></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True">
                            <asp:ListItem>Creditos</asp:ListItem>
                            <asp:ListItem Value="Horas">Horas</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="Label5" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Primera: "></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtPrimera" runat="server" OnTextChanged="txtPrimera_TextChanged"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Segunda: "></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtSegunda" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label7" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Tercera: "></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtTercera" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSiguiente" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Dotted" ForeColor="#0099FF" OnClick="Button1_Click" Text="Siguiente" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
