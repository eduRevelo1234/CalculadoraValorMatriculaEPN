<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPago.aspx.cs" Inherits="proyecto02_EduardoR_BryanS.frmPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 19px;
        }
        .auto-style3 {
            height: 23px;
            width: 157px;
        }
        .auto-style4 {
            height: 19px;
            width: 157px;
        }
        .auto-style5 {
            width: 157px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            height: 23px;
            width: 192px;
        }
        .auto-style8 {
            height: 19px;
            width: 192px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            width: 193px;
        }
        .auto-style12 {
            width: 156px;
        }
        .auto-style14 {
            width: 155px;
        }
        .auto-style15 {
            width: 194px;
        }
        .auto-style16 {
            width: 192px;
        }
        .auto-style17 {
            height: 26px;
            width: 194px;
        }
        .auto-style19 {
            width: 194px;
            height: 23px;
            color: #0066FF;
        }
        .auto-style20 {
            height: 26px;
            width: 156px;
        }
        .auto-style21 {
            height: 23px;
            width: 156px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label14" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Resultados:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Gratuidad"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label15" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Real"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label16" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Factor"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFactorG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFactorR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label17" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Valor matrícula"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="txtValorMatriculaG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtValorMatriculaR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label18" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Valor arancel"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtValorArancelG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtValorArancelR" runat="server" CssClass="auto-style10" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label19" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Recargo repetición 2da"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtRecargo2daG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecargo2daR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">
                        <asp:Label ID="Label20" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Recargo repetición 3ra"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtRecargo3raG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecargo3raR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label21" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Fepon"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtFeponG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFeponR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label22" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Adicionales"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtAdicionalesG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdicionalesR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label23" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Bancario"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtBancarioG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBancarioR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Label24" runat="server" CssClass="auto-style4" ForeColor="#0066FF" Text="Total Matricula"></asp:Label>
                    </td>
                    <td aria-sort="none" class="auto-style17">
                        <asp:TextBox ID="txtTotalG" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtTotalR" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style21"></td>
                    <td class="auto-style19">Valor a pagar</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtValorApagar" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
