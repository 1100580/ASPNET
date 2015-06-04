using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ListarProdutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IList produtos =  DM_AR.Model.Product.LoadAll();
        gvProdutos.DataSource = produtos;
        gvProdutos.DataBind();
    }
}