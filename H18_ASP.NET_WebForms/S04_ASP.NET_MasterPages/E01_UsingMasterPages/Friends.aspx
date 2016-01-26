<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="E01_UsingMasterPages.Friends" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <h2><%: Title %></h2>

    <table class="table table-striped table-bordered">
        <tr>
            <th class="text-center">First name</th>
            <th class="text-center">Last Name</th>
            <th class="text-center">Age(yars)</th>
        </tr>
        <tr>
            <td>Ivan</td>
            <td>Ivanov</td>
            <td>81</td>
        </tr>        
    </table>

</asp:Content>


