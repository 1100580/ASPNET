<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="GereMusicas.aspx.cs" CodeFile="GereMusicas.aspx.cs" Inherits="Client_WEB.Gestor.GereMusicas" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:GridView ID="gvMusicas" runat="server"
        datakeynames="ID" onrowcommand="CustomersGridView_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Apagar" HeaderText="Apagar" 
                    ShowHeader="True" Text="Apagar" />
                <asp:ButtonField ButtonType="Button" CommandName="Disp" 
                    HeaderText="Mudar Disponibilidade" ShowHeader="True" 
                    Text="Mudar Disponibilidade" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" 
                    HeaderText="Seleccionar" ShowHeader="True" Text="Seleccionar" />
            </Columns>
        </asp:GridView>

        <asp:Panel ID="Panel1" runat="server">
            Inserir Musica:<br /> Nome
            <asp:TextBox ID="INome" runat="server"></asp:TextBox>
            <br />
            Artista
            <asp:TextBox ID="IArtista" runat="server"></asp:TextBox>
            <br />
            Tema
            <asp:TextBox ID="ITema" runat="server"></asp:TextBox>
            <br />
            Duracao
            <asp:TextBox ID="IDuracao" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Inserir" runat="server" Text="Inserir" 
                onclick="Inserir_Click" />
            <br />
            <br />
            Editar Musica:<br /> ID
            <asp:TextBox ID="ID" runat="server" Enabled="False"></asp:TextBox>
            <br />
            Nome
            <asp:TextBox ID="EditNome" runat="server"></asp:TextBox>
            <br />
            Artista
            <asp:TextBox ID="EditArtista" runat="server"></asp:TextBox>
            <br />
            Tema
            <asp:TextBox ID="EditTema" runat="server"></asp:TextBox>
            <br />
            Duracao
            <asp:TextBox ID="EditDuracao" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Editar" runat="server" Text="Editar" onclick="Editar_Click" />
        </asp:Panel>
    </div>
</asp:Content>