<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Random_HtmlServerControls.aspx.cs" Inherits="E01_WebControlsAndHTML_Controls.HtmlServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML Server Controls</title>
</head>
<body>
    <form id="formMain" runat="server">
        <div runat="server" id="divContainer">
            <input id="TextFieldFirst" type="number" min="10" max="20" value="10" runat="server" />
            <input id="TextFieldSecond" type="number" min="20" max="30" value="20" runat="server" />
            <input id="ButtonSubmit" type="button" runat="server" value="Submit"                
                onserverclick="ButtonSubmit_ServerClick" />
        </div>       
    </form>    
</body>
</html>
