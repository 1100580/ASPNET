<%@ Page Title="Gestor Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Gestor.aspx.cs" CodeFile="Gestor.aspx.cs" Inherits="Client_WEB.Gestor.Gestor" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="/Gestor/GereEdicoes.aspx" class="navbar">Gerir Edicoes</a>
        <br />
        <a href="/Gestor/GereMusicas.aspx" class="navbar">Gerir Musicas</a>
    </div>
</asp:Content>