using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ListarContratosporCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btListar_Click(object sender, EventArgs e)
    {
        int customerID = Convert.ToInt32(txtID.Text);
        IList listaContratos=DM_AR.Model.Contract.LoadByCustomer(customerID);
        gvContratos.DataSource = listaContratos;
        gvContratos.DataBind();
    }
}