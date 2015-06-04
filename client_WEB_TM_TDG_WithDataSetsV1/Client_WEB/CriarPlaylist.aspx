<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="CriarPlaylist.aspx.cs" CodeFile="CriarPlaylist.aspx.cs" Inherits="client_WEB_MEU_TM_TDG.WithDataSets.ListarContratoPorID" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Musicas disponíveis para escolha:"></asp:Label>
        <asp:GridView ID="gvMusica" runat="server" 
            onselectedindexchanged="gvMusica_SelectedIndexChanged"
            datakeynames="ID">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" 
                    ShowHeader="True" Text="Select" />
            </Columns>
        </asp:GridView>
        Musicas Selecionadas - <asp:Label ID="Count" runat="server" Text="0 "></asp:Label> de 5.<br />
        <br />

        <asp:Button ID="Criar" runat="server" Text="Criar" onclick="Criar_Click" />
        <br />
        <asp:Button ID="Apagar" runat="server" Text="Apagar" onclick="Apagar_Click" />
        <br />
        <br />
        Se não for utilizador registado preencha o seguinte campo:<br />
        Semana do ano para votação:
        <asp:TextBox ID="Semana" runat="server"></asp:TextBox>

        <br />
        <br />
        <br />

        Temas:<br />
        <asp:DropDownList ID="ddTemas" runat="server">
        </asp:DropDownList>
        <br />
        Algumas sugestões:<asp:GridView ID="gvSugestoes" runat="server">
        </asp:GridView>
        <asp:Button ID="btSugestoes" runat="server" Text="Escolher das Sugestões" />
    </div>
</asp:Content>