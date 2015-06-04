<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="GereEdicoes.aspx.cs" CodeFile="GereEdicoes.aspx.cs" Inherits="Client_WEB.Gestor.GereEdicoes" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:GridView ID="gvEdicoes" runat="server" datakeynames="ID" 
            onselectedindexchanged="gvEdicoes_SelectedIndexChanged" >
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Abrir" 
                    ShowHeader="True" Text="Abrir" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>