using System;
using System.Data;
using Common;



namespace TM_TDG.WithDataSets.BLL
{
	public class Musica
	{
		public Musica()
		{
		}

        public DataTable GetAll()
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            return dal.GetAll();
        }

        public DataTable GetbyTema(string tema)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            return dal.GetbyTema(tema);
        }


        public DataTable GetId(int index)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            return dal.GetId(index);
        }

        public void ApagarId(int index)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            dal.ApagarId(index);
        }

        public void MudarDisponibilidade(int index)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            dal.MudarDisponibilidade(index);
        }

        public void InserirMusica(string n, string a, string t, string d)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            dal.InserirMusica(n, a, t, d);
        }

        public void EditarMusica(string index, string n, string a, string t, string d)
        {
            DAL.MusicaGateway dal = new DAL.MusicaGateway();
            dal.EditarMusica(index, n, a, t, d);
        }

	}
}
