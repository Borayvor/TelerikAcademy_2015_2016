<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Searching.aspx.cs" Inherits="E01_Cars.Searching" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cars</title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:DropDownList runat="server" ID="DropDownListProducer" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>all</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList runat="server" ID="DropDownListModel" OnSelectedIndexChanged="DropDownListModel_SelectedIndexChanged">
            <asp:ListItem>all</asp:ListItem>
        </asp:DropDownList>

        <asp:CheckBoxList runat="server" ID="CheckBoxListExtra"            
            CellPadding="5"
            CellSpacing="5"
            RepeatColumns="2"
            RepeatDirection="Vertical"
            RepeatLayout="Flow"
            TextAlign="Right"
            OnSelectedIndexChanged="CheckBoxListExtra_SelectedIndexChanged">
        </asp:CheckBoxList>

        <asp:RadioButtonList ID="RadioButtonListEngines" runat="server"            
            CellPadding="5"
            CellSpacing="5"
            RepeatColumns="2"
            RepeatDirection="Horizontal"
            RepeatLayout="Flow"
            TextAlign="Right"
            OnSelectedIndexChanged="RadioButtonListEngines_SelectedIndexChanged">
            <asp:ListItem Selected="True">1.6</asp:ListItem>
            <asp:ListItem>1.8</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:RadioButtonList>

        <asp:Button runat="server" ID="SearchButton" Text="Search" OnCommand="SearchButton_Command" />

        <asp:Literal runat="server" ID="LiteralResult">

        </asp:Literal>        
    </form>
</body>
</html>
