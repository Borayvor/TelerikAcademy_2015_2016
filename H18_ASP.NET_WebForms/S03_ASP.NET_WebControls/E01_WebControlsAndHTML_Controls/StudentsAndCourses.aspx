<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" Inherits="E01_WebControlsAndHTML_Controls.StudentsAndCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>StudentsAndCourses</title>
</head>
<body>
    <form id="formStudentsAndCourses" runat="server">
        <h1>Students And Courses</h1>

        First name:<br />
        <asp:TextBox ID="TextBoxFirstName" runat="server" ></asp:TextBox>

        <br />
        Last name:<br />
        <asp:TextBox ID="TextBoxLastName" runat="server" ></asp:TextBox>

        <br />

        <br />
        Faculty number:<br />
        <asp:TextBox ID="TextBoxFacultyNumber" TextMode="Number" runat="server" ></asp:TextBox>

        <br />
        Choose a university:<br />
        <asp:DropDownList ID="DropDownListUniversity" runat="server" >
            <asp:ListItem Value="SofiaUniversity">SofiaUniversity</asp:ListItem>
            <asp:ListItem Value="PlovdivUniversity">PlovdivUniversity</asp:ListItem>
            <asp:ListItem Value="VarnaUniversity">VarnaUniversity</asp:ListItem>
        </asp:DropDownList>

        <br />
        Choose a specialty:<br />
        <asp:DropDownList ID="DropDownListSpecialty" runat="server" >
            <asp:ListItem Value="Footballer">Footballer</asp:ListItem>
            <asp:ListItem Value="Box">Box</asp:ListItem>
            <asp:ListItem Value="Athletics">Athletics</asp:ListItem>
        </asp:DropDownList>

        <br />
        List of courses:<br />
        <asp:ListBox ID="ListBoxListOfCourses" runat="server" AutoPostBack="True" Height="56px">
            <asp:ListItem Value="Football">Football</asp:ListItem>
            <asp:ListItem Value="Box">Box</asp:ListItem>
            <asp:ListItem Value="Athletics">Athletics</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"/>

        <br />
        <br />
        <h2>Result</h2>
        <asp:Literal ID="LiteralResult" runat="server" />
    </form>
</body>
</html>
