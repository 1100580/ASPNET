<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaqCalc.aspx.cs" Inherits="MaqCalc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
        <p><asp:Label ID="LabelCounter" runat="server" Text=""></asp:Label></p>
        <p>1º Operando:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server" 
                ControlToValidate="TextBox1" 
                ErrorMessage="Campo de preenchimento obrigatorio."
                Display="dynamic" 
                Text=" * " >
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidator2"
                runat="server" 
                ControlToValidate="TextBox1"
                ValidationExpression="[0-9]+(\,[0-9])?" 
                ErrorMessage="Introduza um numero inteiro ou neste formato X,X" 
                Display="dynamic" 
                Text=" * " >
            </asp:RegularExpressionValidator>
        </p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="+" Value="1"/>
            <asp:ListItem Text="-" Value="2"/>
            <asp:ListItem Text="*" Value="3"/>
            <asp:ListItem Text="/" Value="4"/>
        </asp:DropDownList>
        <p>2º Operando:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" 
                runat="server" 
                ControlToValidate="TextBox2" 
                ErrorMessage="Campo de preenchimento obrigatorio." 
                Display="dynamic" 
                Text=" * " >
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator
                ID="RegularExpressionValidator1"
                runat="server" 
                ControlToValidate="TextBox2"
                ValidationExpression="[0-9]+(\,[0-9])?" 
                ErrorMessage="Introduza um numero inteiro ou neste formato X,X" 
                Display="dynamic" 
                Text=" * " >
            </asp:RegularExpressionValidator>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Calcular" OnClick="Calcula"/>
        <p>Resposta:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></p>
        <p></p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    </form>
</body>
</html>
