<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="client_WEB_MEU_TM_TDG.WithDataSets.Login" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h3>Login</h3> <br />
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate><asp:Login ID="Login2" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="1em" BorderPadding="4" ForeColor="#333333">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="1em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="1em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFFFF" 
                Font-Size="1em" />
        </asp:Login></AnonymousTemplate>

             <LoggedInTemplate><a href="/Membros/membro.aspx" class="navbar">Página de Membros</a>
             <a href="/gestor/gestor.aspx" class="navbar">Página de gestores</a></LoggedInTemplate>
        </asp:LoginView>
        
    </div>
</asp:Content>