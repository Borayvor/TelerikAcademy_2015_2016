<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random_WebServerControls.aspx.cs" Inherits="E01_WebControlsAndHTML_Controls.WebServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebServerControls</title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:Label ID="LabelResult" runat="server" Text="" Visible="false" />
        <asp:TextBox ID="TextBoxInputFirst" TextMode="Number" Text="10" runat="server" />
        <asp:RangeValidator id="RangeValidatorFirst"
           ControlToValidate="TextBoxInputFirst"
           MinimumValue="10"
           MaximumValue="20"
           Type="Integer"
           EnableClientScript="false"
           Text="The value must be from 10 to 20!"
           runat="server"/>
        <asp:TextBox ID="TextBoxInputSecond" TextMode="Number" Text="20" runat="server" />
        <asp:RangeValidator id="RangeValidatorSecond"
           ControlToValidate="TextBoxInputSecond"
           MinimumValue="20"
           MaximumValue="30"
           Type="Integer"
           EnableClientScript="false"
           Text="The value must be from 20 to 30!"
           runat="server"/>
        <asp:Button ID="ButtonSubmit" runat="server" 
            Text="Submit" OnClick="ButtonSubmit_Click" />
    </form>
</body>
</html>
