using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Client_WEB.Gestor
{
    public partial class GereMusicas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TM_TDG.WithDataSets.BLL.Musica musicabll = new TM_TDG.WithDataSets.BLL.Musica();
            gvMusicas.DataSource = musicabll.GetAll();
            gvMusicas.DataBind();
        }

        protected void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int val = Convert.ToInt32(gvMusicas.DataKeys[index].Value.ToString());
            TM_TDG.WithDataSets.BLL.Musica musicabll = new TM_TDG.WithDataSets.BLL.Musica();

            if (e.CommandName == "Select")
            {
                ID.Text = val.ToString();
                DataTable dt = musicabll.GetId(val);
                EditNome.Text = (string)dt.Rows[0]["Nome"];
                EditArtista.Text = (string)dt.Rows[0]["Artista"];
                EditTema.Text = (string)dt.Rows[0]["Tema"].ToString();
                EditDuracao.Text = (string)dt.Rows[0]["Duracao"].ToString();
            }

            if (e.CommandName == "Apagar")
            {
                musicabll.ApagarId(val);
                gvMusicas.DataSource = musicabll.GetAll();
                gvMusicas.DataBind();
            }

            if (e.CommandName == "Disp")
            {
                musicabll.MudarDisponibilidade(val);
                gvMusicas.DataSource = musicabll.GetAll();
                gvMusicas.DataBind();
            }
        }

        protected void Inserir_Click(object sender, EventArgs e)
        {
            TM_TDG.WithDataSets.BLL.Musica musicabll = new TM_TDG.WithDataSets.BLL.Musica();

            musicabll.InserirMusica(INome.Text, IArtista.Text, ITema.Text, IDuracao.Text);

            gvMusicas.DataSource = musicabll.GetAll();
            gvMusicas.DataBind();
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            TM_TDG.WithDataSets.BLL.Musica musicabll = new TM_TDG.WithDataSets.BLL.Musica();
            musicabll.EditarMusica(ID.Text, EditNome.Text, EditArtista.Text, EditTema.Text, EditDuracao.Text);

            gvMusicas.DataSource = musicabll.GetAll();
            gvMusicas.DataBind();
        }

    }
}