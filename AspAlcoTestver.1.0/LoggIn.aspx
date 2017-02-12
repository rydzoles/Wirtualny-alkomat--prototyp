<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggIn.aspx.cs" Inherits="AspAlcoTestver._1._0.LoggIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="nameLbl" runat="server" Text="imie"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameUserTxb" runat="server" MaxLength="14" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="passUserLbl" runat="server" Text="Hasło"></asp:Label>
&nbsp;
        <asp:TextBox ID="passUserTxb" TextMode="Password" runat="server" MaxLength="14"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="wrongNameEmailLogLbl" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="InvalidDataInfoLbl" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="enterUserBtn" runat="server" OnClick="enterUserBtn_Click" Text="Wejście" style="height: 26px" />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="PassNotRememberlbl" runat="server" Text="Nie znasz Hasła (podaj email)"></asp:Label>
&nbsp;
        <asp:TextBox ID="emailUserTxb" runat="server"></asp:TextBox>
    
        <asp:Button ID="sendNewPassBtn" runat="server" OnClick="sendNewPassBtn_Click" Text="wyślij do naszej bazy danych" />
    
    </div>
    </form>
</body>
</html>
