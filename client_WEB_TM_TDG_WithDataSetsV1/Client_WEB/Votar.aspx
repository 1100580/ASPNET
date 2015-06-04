<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Votar.aspx.cs" CodeFile="Votar.aspx.cs" Inherits="Client_WEB.Votar" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
    <h3>Votação de Playlists</h3> <br />
        <asp:GridView ID="gvVotacao" runat="server" datakeynames="ID" 
            onselectedindexchanged="gvVotacao_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Votar" 
                    ShowHeader="True" Text="Votar" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Msg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>