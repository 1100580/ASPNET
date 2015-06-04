using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Client_WEB.Gestor
{
    public partial class GereEdicoes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TM_TDG.WithDataSets.BLL.Edicao edicaobll = new TM_TDG.WithDataSets.BLL.Edicao();
            gvEdicoes.DataSource = edicaobll.GetAll();
            gvEdicoes.DataBind();
        }

        protected void gvEdicoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvEdicoes.SelectedIndex;
            int val = Convert.ToInt32(gvEdicoes.DataKeys[index].Value.ToString());

            TM_TDG.WithDataSets.BLL.Edicao edicaobll = new TM_TDG.WithDataSets.BLL.Edicao();
            edicaobll.Abrir(val);

            gvEdicoes.DataSource = edicaobll.GetAll();
            gvEdicoes.DataBind();
        }

    }
}