<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AspAlcoTestver._1._0.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
        <asp:Label ID="nameLbl" runat="server" Text="Imię"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTxb" runat="server" MaxLength="20"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="emailTxb" runat="server" MaxLength="20"></asp:TextBox>
            <asp:Label ID="wrongInfoEmailLbl" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="passLbl" runat="server" Text="Hasło"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passTxb" TextMode="Password" runat="server" MaxLength="20"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="confirmPassLbl" runat="server" Text="Potwierdź hasło"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="confirmPassTxb" TextMode="Password" runat="server" MaxLength="20"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="wrongInfoLbl" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AlcoPersonalDataSqlConnectionString %>" SelectCommand="SELECT * FROM [AlcoPrsnTable]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rejestruj się" />
        </p>
        <p>
            <asp:HyperLink ID="toLogSIteHpLink" runat="server" NavigateUrl="LoggIn.aspx">Zaloguj się</asp:HyperLink>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    <div>
    
    </div>
    </form>
</body>
</html>
