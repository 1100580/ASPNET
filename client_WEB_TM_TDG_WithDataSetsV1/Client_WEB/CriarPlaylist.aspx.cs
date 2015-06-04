using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TM_TDG.WithDataSets.BLL;
using System.Data;
using System.Collections;


namespace client_WEB_MEU_TM_TDG.WithDataSets
{
    public partial class ListarContratoPorID : System.Web.UI.Page
    {
        ArrayList ids = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["list"] == null)
            {
                Session["list"] = ids;
            }
            TM_TDG.WithDataSets.BLL.Musica musicabll = new TM_TDG.WithDataSets.BLL.Musica();
            gvMusica.DataSource = musicabll.GetAll();
            gvMusica.DataBind();


            //-------Vilaça
            if (!IsPostBack)
            {
                TM_TDG.WithDataSets.BLL.Temas temasbll = new TM_TDG.WithDataSets.BLL.Temas();
                ddTemas.DataSource = temasbll.GetAll();
                ddTemas.DataBind();
            }
            String tema = ddTemas.SelectedValue.ToString();
            gvSugestoes.DataSource = musicabll.GetbyTema(tema);
            gvSugestoes.DataBind();
            //string user = User.Identity.Name;
            //TM_TDG.WithDataSets.BLL.Utilizador userbll = new TM_TDG.WithDataSets.BLL.Utilizador();
            //DataTable dtregiao = userbll.GetRegiao(user);
            //string regiao = dtregiao.ToString();
            //DataTable tbl=userbll.GetUserbyRegiao(regiao);
        }

        protected void gvMusica_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvMusica.SelectedIndex;
            ids = (ArrayList)Session["list"];
            if (ids.Count < 5)
            {
                ids.Add( Convert.ToInt32(gvMusica.DataKeys[index].Value.ToString()));
                Count.Text = (string)ids.Count.ToString();
            }
            else
            {
                Count.Text = "Todas as 5 musicas foram selecionadas, clique criar ou apagar para começar de novo.";
            }
        }

        protected void Criar_Click(object sender, EventArgs e)
        {
            ids = (ArrayList)Session["list"];
            if (ids.Count == 5)
            {
                try
                {
                    string nome = (string)User.Identity.Name;
                
                    TM_TDG.WithDataSets.BLL.Playlist playlistbll = new TM_TDG.WithDataSets.BLL.Playlist();
                    int pl = playlistbll.CreatePlaylist((int)ids[0], (int)ids[1], (int)ids[2], (int)ids[3], (int)ids[4], nome);
                
                    if (nome.Equals(""))
                    {
                        int s = Convert.ToInt32(Semana.Text);
                        if (s > 0 && s < 53)
                            playlistbll.SubmeterPlaylist(pl, s);
                        else
                            Semana.Text = "Insira Um Numero Entre 0 e 52";
                    }
                }catch(Exception ex){}

                Count.Text = User.Identity.Name.ToString() + "A sua playlist foi criada com sucesso!";
            }
            else
            {
                Count.Text = "Tem de ter 5 musicas selecionadas.";
            }
        }

        protected void Apagar_Click(object sender, EventArgs e)
        {
            Session["list"] = null;
            Count.Text = "Lista apagada, pode começar de novo.";
        }

    }
}