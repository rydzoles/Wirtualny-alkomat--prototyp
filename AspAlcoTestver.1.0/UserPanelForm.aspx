
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanelForm.aspx.cs" Inherits="AspAlcoTestver._1._0.UserPanelForm" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
        .auto-style2 {
            width: 145px;
        }
        .auto-style3 {
            width: 146px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    
        <br />
        <asp:Label ID="logInInfoLbl" runat="server" Text="Jeśli chcesz monitorować swoje promile alkoholowe "></asp:Label>
        &nbsp;<asp:HyperLink ID="setUserHpLink" runat="server" NavigateUrl="~/LOggIn.aspx">Zaloguj</asp:HyperLink>
    &nbsp;/&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registration.aspx">Zarejestruj się</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="invalidDataLbl" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="TitleLbl" runat="server" Font-Bold="True" Font-Names="Corbel" Font-Size="Large" Text="Wirtualny Alkomat" ForeColor="#003300"></asp:Label>
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">

        <asp:Label ID="genderLbl" runat="server" Text="Płeć:"></asp:Label>

        <asp:RadioButtonList ID="genderRBtn" runat="server">
            <asp:ListItem Value="0">kobieta</asp:ListItem>
            <asp:ListItem Value="1">mężczyzna</asp:ListItem>
        </asp:RadioButtonList>
                    <br />
                </td>
                <td class="auto-style2">
        <asp:Label ID="drinkStartLbl" runat="server" Text="Godzina rozpoczęcia:"></asp:Label>
                    <br />
        <asp:DropDownList ID="drinkStartDdl" runat="server">
            <asp:ListItem Value="1">01:00</asp:ListItem>
            <asp:ListItem Value="2">02:00</asp:ListItem>
            <asp:ListItem Value="3">03:00</asp:ListItem>
            <asp:ListItem Value="4">04:00</asp:ListItem>
            <asp:ListItem Value="5">05:00</asp:ListItem>
            <asp:ListItem Value="6">06:00</asp:ListItem>
            <asp:ListItem Value="7">07:00</asp:ListItem>
            <asp:ListItem Value="8">08:00</asp:ListItem>
            <asp:ListItem Value="9">09:00</asp:ListItem>
            <asp:ListItem Value="10">10:00</asp:ListItem>
            <asp:ListItem Value="11">11:00</asp:ListItem>
            <asp:ListItem Value="12">12:00</asp:ListItem>
            <asp:ListItem Value="13">13:00</asp:ListItem>
            <asp:ListItem Value="14">14:00</asp:ListItem>
            <asp:ListItem Value="15">15:00</asp:ListItem>
            <asp:ListItem Value="16">16:00</asp:ListItem>
            <asp:ListItem Value="17">17:00</asp:ListItem>
            <asp:ListItem Value="18">18:00</asp:ListItem>
            <asp:ListItem Value="19">19:00</asp:ListItem>
            <asp:ListItem Value="20">20:00</asp:ListItem>
            <asp:ListItem Value="21">21:00</asp:ListItem>
            <asp:ListItem Value="22">22:00</asp:ListItem>
            <asp:ListItem Value="23">23:00</asp:ListItem>
            <asp:ListItem Value="24">00:00</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td class="auto-style3">
        <asp:Label ID="drinkEndLbl" runat="server" Text="Ilość godzin picia alk"></asp:Label>
                    <br />
                    <asp:TextBox ID="drinkTimeTxb" runat="server" Width="63px" MaxLength="2"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="infoIdeaLbl" runat="server" Font-Bold="True" ForeColor="#66FF33" Text="Uwaga! Kalkulator ma charakter rozrywkowy. Nie bierz pod uwagę wyników badań jeśli chcesz  motywować swoje zachowanie wynikami kalkulatora."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Label ID="weightLbl" runat="server" Text="Ważę [kg]"></asp:Label>
                    <br />
        <asp:TextBox ID="weightPersonTbx" runat="server" Width="54px" Height="22px" MaxLength="3"></asp:TextBox>
                </td>
                <td class="auto-style2">
        <asp:Label ID="concentrationLbl" runat="server" Text="Stężenie alk. [%]"></asp:Label>
                    <br />
        <asp:TextBox ID="alcoholVoltageTxb" runat="server" Width="49px" MaxLength="5"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Label ID="Label1" runat="server" Text="Wypiłem [ml.]"></asp:Label>
                    <br />
        <asp:TextBox ID="alcoholAmountsTbx" runat="server" Width="44px"></asp:TextBox>
                    <br />
                    <br />
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Button ID="countPromiles" runat="server" OnClick="countPromiles_Click" Text="Oblicz " />
                </td>
                <td class="auto-style2">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AlcoPersonalDataSqlConnectionString %>" SelectCommand="SELECT * FROM [AlcoPrsnTable]"></asp:SqlDataSource>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>      
        <br />     
        <br />
    </form>
</body>
</html>
