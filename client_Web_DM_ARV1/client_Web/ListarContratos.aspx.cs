using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ListarContratos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        IList listcontracts = DM_AR.Model.Contract.LoadAll();
        gvContratos.DataSource = listcontracts;
        gvContratos.DataBind();
    }
}