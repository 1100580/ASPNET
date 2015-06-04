<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categorias.aspx.cs" Inherits="categorias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="AccessDataSource1" 
            AutoGenerateColumns="False" DataKeyNames="IdCat">
            <Columns>
                <asp:BoundField DataField="IdCat" HeaderText="IdCat" InsertVisible="False" 
                    ReadOnly="True" SortExpression="IdCat" Visible="False" />
                <asp:BoundField DataField="NomeCat" HeaderText="Categorias" 
                    SortExpression="NomeCat" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" 
                    ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/loja.mdb" SelectCommand="SELECT * FROM [Categorias]">
        </asp:AccessDataSource>
    
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="AccessDataSource1" DataTextField="NomeCat" 
            DataValueField="NomeCat">
            <asp:ListItem Value="Carrinho">Carrinho</asp:ListItem>
            <asp:ListItem Selected="True" Value="Categorias">Categorias</asp:ListItem>
            <asp:ListItem Value="Clientes">Clientes</asp:ListItem>
            <asp:ListItem Value="Produtos">Produtos</asp:ListItem>
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
