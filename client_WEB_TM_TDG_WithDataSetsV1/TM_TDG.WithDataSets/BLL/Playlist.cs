using System;
using System.Data;
using Common;
using System.Collections;



namespace TM_TDG.WithDataSets.BLL
{
	public class Playlist
	{
		public Playlist()
		{
		}

        public DataTable GetAll()
        {
            DAL.PlaylistGateway dal = new DAL.PlaylistGateway();
            return dal.GetAll();
        }

        public DataTable GetFromUser(string nome)
        {
            DAL.PlaylistGateway dal = new DAL.PlaylistGateway();
            return dal.GetFromUser(nome);
        }

        public void SubmeterPlaylist(int id, int semana)
        {
            DAL.PlaylistGateway dal = new DAL.PlaylistGateway();
            dal.SubmeterPlaylist(id, semana);
        }

        public int CreatePlaylist(int m1, int m2, int m3, int m4, int m5, string user)
        {
            DAL.PlaylistGateway dal = new DAL.PlaylistGateway();
            return dal.CreatePlaylist(m1,m2,m3,m4,m5,user);
        }
	}
}
