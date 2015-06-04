<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SubmeterPlaylist.aspx.cs" CodeFile="SubmeterPlaylist.aspx.cs" Inherits="Client_WEB.Membros.SubmeterPlaylist" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:GridView ID="gvSubmeterPlaylist" runat="server" 
            onselectedindexchanged="gvSubmeterPlaylist_SelectedIndexChanged"
            datakeynames="ID">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Submeter" 
                    ShowHeader="True" Text="Submeter" />
            </Columns>
        </asp:GridView>
        Semana do ano para submissão:<asp:TextBox ID="Semana" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Sub" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>