<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlcoRaportChart.aspx.cs" Inherits="AspAlcoTestver._1._0.AlcoRaportChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 444px;
        }
        .auto-style2 {
            width: 444px;
            height: 1436px;
        }
        .auto-style3 {
            height: 1436px;
        }
        .auto-style4 {
            height: 1436px;
            width: 533px;
        }
        .auto-style5 {
            width: 533px;
        }
        .auto-style6 {
            width: 143px;
        }
        .auto-style7 {
            width: 143px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            width: 63px;
        }
        .auto-style10 {
            width: 63px;
            height: 23px;
        }
        .auto-style11 {
            width: 76px;
        }
        .auto-style12 {
            height: 23px;
            width: 76px;
        }
        .auto-style13 {
            width: 143px;
            height: 51px;
        }
        .auto-style14 {
            width: 76px;
            height: 51px;
        }
        .auto-style15 {
            width: 63px;
            height: 51px;
        }
        .auto-style16 {
            height: 51px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
        <asp:Chart ID="PromilesInBloodCrt" runat="server" Width="540px" Height="1440px">
            <Series>
                <asp:Series Name="Promiles" ChartType="Bar" XValueType="String" YValueType="Double" IsValueShownAsLabel="True" YValuesPerPoint="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="White" BorderColor="DarkRed">
                    <AxisY Interval="1" LineWidth="0" Title=" Stężenie alkoholu we krwi (‰)">
                        <MajorGrid Enabled="False" />
                        <MajorTickMark Enabled="False" />
                        <LabelStyle Angle="-90" Enabled="False" />
                    </AxisY>
                    <AxisX Interval="1" Title="Godziny występowania alkoholu we krwi (cyfra przed godziną oznacza kolejny dzien)">
                        <MajorGrid Enabled="False" />
                        <LabelStyle Angle="-90" Font="Microsoft Sans Serif, 10pt, style=Underline" ForeColor="Red" />
                        <ScaleBreakStyle LineColor="Maroon" />
                    </AxisX>
                    <AxisX2>
                        <MajorGrid Enabled="False" />
                    </AxisX2>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
                </td>
                <td class="auto-style4">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style13">Twoj Nick:</td>
                            <td class="auto-style14">
                                <asp:Label ID="rprtNameLbl" runat="server" ForeColor="Red" Text="Anonim"></asp:Label>
                            </td>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">
                                &nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">Twoj raport w dniu </td>
                            <td class="auto-style14">dzisiejszym:</td>
                            <td class="auto-style15">Data:</td>
                            <td class="auto-style16">
                                <asp:Label ID="rprtDataLbl" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="auto-style16"></td>
                        </tr>
                        <tr>
                            <td class="auto-style6">płeć</td>
                            <td class="auto-style11">
                                <asp:Label ID="rprtGenderLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">waga</td>
                            <td class="auto-style11">
                                <asp:Label ID="rprtWeightLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7">wypiłeś</td>
                            <td class="auto-style12">
                                <asp:Label ID="rprtAmountLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style10">ml,&nbsp; vol:</td>
                            <td class="auto-style8">
                                <asp:Label ID="rprtVoltageLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">nietrzeźwośćć przez</td>
                            <td class="auto-style12">
                                <asp:Label ID="rprtDrunkTimeLbl" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style10">godzin</td>
                            <td class="auto-style8">od rozpoczęcia picia alk.</td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_history" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="date" HeaderText="Data" SortExpression="Date" />
                            <asp:BoundField DataField="weight_hist" HeaderText="Waga (kg)" SortExpression="weight_hist" />
                            <asp:BoundField DataField="drink_time_hist" HeaderText="Liczba nietrzeźwych godzin" SortExpression="drink_time_hist" />
                            <asp:BoundField DataField="ml_drunked_hist" HeaderText="Wypity alk. (ml)" SortExpression="ml_drunked_hist" />
                            <asp:BoundField DataField="max_promiles_hist" HeaderText="Max promil we krwii" SortExpression="max_promiles_hist" />
                            <asp:BoundField DataField="user_id" HeaderText="Nr uzytkownika" SortExpression="user_id" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style5" colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style5" colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
        <asp:Label ID="dataTodayLbl" runat="server"></asp:Label>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AlcoPersonalDataSqlConnectionString2 %>" SelectCommand="SELECT id_history, weight_hist, drink_time_hist, ml_drunked_hist, max_promiles_hist, date, user_id FROM userHistory WHERE (user_id = @user_id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="uzytkownikLbl" Name="user_id" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>      
       <asp:Label ID="uzytkownikLbl" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
