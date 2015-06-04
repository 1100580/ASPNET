using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client_WEB.Membros
{
    public partial class SubmeterPlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nome = (string)User.Identity.Name.ToString();
            TM_TDG.WithDataSets.BLL.Playlist playlistbll = new TM_TDG.WithDataSets.BLL.Playlist();
            gvSubmeterPlaylist.DataSource = playlistbll.GetFromUser(nome);
            gvSubmeterPlaylist.DataBind();
        }

        protected void gvSubmeterPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int semana = Convert.ToInt32(Semana.Text);
                if (semana > 0 && semana < 53)
                {
                    int index = gvSubmeterPlaylist.SelectedIndex;
                    TM_TDG.WithDataSets.BLL.Playlist playlistbll = new TM_TDG.WithDataSets.BLL.Playlist();
                    playlistbll.SubmeterPlaylist(Convert.ToInt32(gvSubmeterPlaylist.DataKeys[index].Value.ToString()), semana);
                    Sub.Text = "Playlist submetida a votação com sucesso!";
                }
                else
                {
                    Semana.Text = "Tem de inserir um numero entre 0 e 52";
                }
            }
            catch (Exception ex)
            {
                Semana.Text = "Tem de inserir um numero entre 0 e 52";
            }
        }
    }
}