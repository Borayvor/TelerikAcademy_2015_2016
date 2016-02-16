<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CacheFiles.aspx.cs" Inherits="E01_CacheInWebForms.CacheFiles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1><%= Page.Title %></h1>
        <h2>Time: <%= DateTime.Now %></h2>
        <h2>Value taken from cache: <span id="currentTimeSpan" runat="server"></span></h2>
        <% foreach (var filePath in allFilesPaths) { %>
        <h2>File path: <%= filePath %></h2>
        <% } %>
    </div>
</asp:Content>
