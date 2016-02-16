<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="E01_CacheInWebForms.About" %>

<%@ Import Namespace="Caching" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %>.</h1>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <br />
    <div class="hero-unit">        
        <h2>Time: <%= DateTime.Now %></h2>
        <h3>Value of the "id" parameter: <%= Request.QueryString["id"] %></h3>
        <h3>Page number: <%= GlobalCounter.Next() %></h3>        
    </div>
    <br />
</asp:Content>
