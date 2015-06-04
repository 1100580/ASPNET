<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarClientes.aspx.cs" Inherits="ListarClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #993300;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        Listagem de Clientes<br />
        <br />
        <asp:GridView ID="gvClientes" runat="server" 
            DataKeyNames="ID"
            onselectedindexchanged="gvClientes_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvContratosCliente" runat="server">
        </asp:GridView>
        <asp:Panel ID="NovoCliente" runat="server">
            <p>Inserir novo Cliente</p>
            Nome:<asp:TextBox ID="NomeCliente" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
