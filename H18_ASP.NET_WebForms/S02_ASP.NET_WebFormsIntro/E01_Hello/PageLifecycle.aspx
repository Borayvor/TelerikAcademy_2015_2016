<%@ Page Title="PageLifecycle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageLifecycle.aspx.cs" Inherits="E01_Hello.PageLifecycle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button ID="ButtonOK" Text="OK" runat="server"
        OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
        OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
</asp:Content>
