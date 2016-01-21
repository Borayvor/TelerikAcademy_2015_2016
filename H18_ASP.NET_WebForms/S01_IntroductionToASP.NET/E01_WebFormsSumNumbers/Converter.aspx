<%@ Page Title="Converter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Converter.aspx.cs" Inherits="E01_WebFormsSumNumbers.Converter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2><%: this.Title %></h2>
        <div class="row">
            <div class="col-xs-12 col-sm-6">
                <h3>Enter text in the box and convert to image.</h3>
                <br />
                <asp:TextBox class="form-control" runat="server" ID="TextBoxInput"></asp:TextBox>
                <asp:Button class="btn btn-primary" runat="server" ID="ButtonRenderImage" OnClick="ButtonRenderImage_Click" Text="Change text/image" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-6">
                <asp:Image class="img-thumbnail center-block" runat="server" ID="ImageOutput" />
            </div>
        </div>
    </div>
</asp:Content>
