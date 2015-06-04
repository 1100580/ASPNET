<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarContratos.aspx.cs" Inherits="ListarContratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #990000;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="style1">
        <br />
        <br />
        Listagem dos Contratos a partir de uma view da BD</span><br />
        <br />
    <asp:GridView ID="gvContratos" runat="server">
    </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
