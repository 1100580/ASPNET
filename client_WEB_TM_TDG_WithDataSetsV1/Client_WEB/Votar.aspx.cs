using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Client_WEB
{
    public partial class Votar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                TM_TDG.WithDataSets.BLL.Edicao edicaobll = new TM_TDG.WithDataSets.BLL.Edicao();
                DataTable dt = edicaobll.GetAberta();
                int edicao = Convert.ToInt32(dt.Rows[0]["ID"]);

                TM_TDG.WithDataSets.BLL.Votacao votacaobll = new TM_TDG.WithDataSets.BLL.Votacao();
                gvVotacao.DataSource = votacaobll.GetAllEdicao(edicao);
                gvVotacao.DataBind();
            }
            catch (Exception ex){
                Msg.Text = "Não existem musicas para votação.";
            }
        }

        protected void gvVotacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvVotacao.SelectedIndex;
            int val = Convert.ToInt32(gvVotacao.DataKeys[index].Value);
            
            TM_TDG.WithDataSets.BLL.Votacao votacaobll = new TM_TDG.WithDataSets.BLL.Votacao();
            votacaobll.Votar(val);

            TM_TDG.WithDataSets.BLL.Edicao edicaobll = new TM_TDG.WithDataSets.BLL.Edicao();
            DataTable dt = edicaobll.GetAberta();
            int edicao = Convert.ToInt32(dt.Rows[0]["ID"]);
            gvVotacao.DataSource = votacaobll.GetAllEdicao(edicao);
            gvVotacao.DataBind();
        }
    }
}