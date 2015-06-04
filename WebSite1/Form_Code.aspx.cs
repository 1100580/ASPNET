using System;
public partial class _Default : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Label1.Text = "PostBack";
        }
        else
        {
            Label1.Text = "Load";
        }
    }

    public void Button1_Click(Object s, EventArgs e)
    {
        Label2.Text = TextBox1.Text;
    }
}