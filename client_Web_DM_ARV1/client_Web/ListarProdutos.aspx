﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarProdutos.aspx.cs" Inherits="ListarProdutos" %>

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
    <div>
    
        <span class="style1">Listagem dos Produtos</span><br />
        <br />
        <asp:GridView ID="gvProdutos" runat="server">
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
