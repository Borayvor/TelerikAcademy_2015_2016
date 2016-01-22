<%@ Page Title="Hello" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="E01_Hello.Hello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />
    <div class="container">
        <asp:Label class="label label-info" Font-Size="14px" ID="LabelLocation" runat="server"></asp:Label>
    </div>
    <br />
    <div class="form-group">
        <asp:Label ID="LabelName" AssociatedControlID="TextBoxName" runat="server">Name: </asp:Label>
        <asp:TextBox class="form-control" ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <asp:Button class="btn btn-primary" ID="ButtonHelloName" runat="server" OnClick="ButtonHelloName_Click" Text="Print" />
    </div>
    <br />
    <asp:Label class="label label-success" Font-Size="48px" ID="LabelResult" runat="server"></asp:Label>
</asp:Content>
