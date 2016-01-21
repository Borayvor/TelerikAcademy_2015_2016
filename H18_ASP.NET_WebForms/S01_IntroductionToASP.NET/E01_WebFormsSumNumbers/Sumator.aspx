<%@ Page Title="Sumator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="E01_WebFormsSumNumbers.Sumator" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">   
        <h2><%: this.Title %></h2> 
        <br></br>    
        <div class="form-group">
            <asp:Label ID="LabelFirstNumberLabel" AssociatedControlId="TextBoxFirstNumber"  runat="server">First number: </asp:Label>
            <asp:TextBox class="form-control" ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
            <br></br>
            <asp:Label ID="LabelSecondNumber" AssociatedControlId="TextBoxSecondNumber"  runat="server">First number: </asp:Label>
            <asp:TextBox class="form-control" ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
            <br></br>
            <asp:Button class="btn btn-primary" ID="ButtonCalculateSum" runat="server" OnClick="ButtonCalculateSum_Click" Text="Calculate Sum"/>            
        </div>
        <br></br>
        <asp:TextBox class="form-control" ID="TextBoxResult" runat="server"></asp:TextBox>
    </div>
</asp:Content>