<%@ Page Title="PersonalInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="E01_UsingMasterPages.PersonalInfo" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <h2><%: Title %></h2>

    <table class="table table-striped table-bordered">
        <tr>
            <th class="text-center">First name</th>
            <th class="text-center">Last Name</th>
            <th class="text-center">Age(yars)</th>
        </tr>
        <tr>
            <td>Pesho</td>
            <td>Peshev</td>
            <td>801</td>
        </tr>        
    </table>

</asp:Content>
