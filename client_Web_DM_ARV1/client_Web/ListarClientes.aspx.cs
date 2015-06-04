using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ListarClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IList clientes = DM_AR.Model.Customer.LoadAll();
        gvClientes.DataSource = clientes;
        gvClientes.DataBind();
    }
    protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
    {

        int customerID = (int)gvClientes.SelectedDataKey.Value;
        IList contratos = DM_AR.Model.Contract.LoadByCustomer(customerID);
        gvContratosCliente.DataSource = contratos;
        gvContratosCliente.DataBind();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        String name = NomeCliente.Text;
        DM_AR.Model.Customer c = new DM_AR.Model.Customer(name);
        c.Save();
    }
}