<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categorias.aspx.cs" Inherits="categorias" MasterPageFile="~/Site.master"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gdvCategorias" runat="server" DataKeyNames = "IdCat" onselectedindexchanged="SelectedIndexChanged">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" ShowHeader="True" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="panelControl" runat="server">
        ID:<asp:TextBox ID="idBox" runat="server"></asp:TextBox>
        Cat:<asp:TextBox ID="catBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="gravar" runat="server" Text="Gravar" />
        <asp:Button ID="novo" runat="server" Text="Novo" />
        <asp:Button ID="apagar" runat="server" Text="Apagar" />
    </asp:Panel>
</asp:Content>