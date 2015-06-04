<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarContratosporCliente.aspx.cs" Inherits="ListarContratosporCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #993300;
            font-weight: bold;
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <span class="style1">Listar Contratos de um Cliente<br />
    </span>
    <br />
    <span class="style1">
    ID Cliente: <asp:TextBox ID="txtID" 
        runat="server"></asp:TextBox>
    <asp:Button ID="btListar" runat="server" onclick="btListar_Click" 
        Text="Listar" />
    </span>
    <asp:GridView ID="gvContratos" runat="server">
    </asp:GridView>
    <div>
    
    </div>
    </form>
</body>
</html>
