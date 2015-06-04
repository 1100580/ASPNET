<%@ Page Language="C#" CodeFile="Form_Code.aspx.cs" Inherits="_Default"%>

<html>
<head>
    <title></title>
</head>
<body>
    <form runat="server">
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:Button id="Button1" Text="click me!" runat="server" OnClick="Button1_Click"/>
      <p><asp:Label ID="Label1" runat="server"></asp:Label></p>
      <p><asp:Label ID="Label2" runat="server"></asp:Label></p>
    </form>
</body>
</html>
