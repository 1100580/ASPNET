using System;
using System.Data;
using Common;



namespace TM_TDG.WithDataSets.BLL
{
	public class Votacao
	{
		public Votacao()
		{
		}

        public DataTable GetAllEdicao(int edicao)
        {
            DAL.VotacaoGateway dal = new DAL.VotacaoGateway();
            return dal.GetAllEdicao(edicao);
        }

        public void Votar(int index)
        {
            DAL.VotacaoGateway dal = new DAL.VotacaoGateway();
            dal.Votar(index);
        }
	}
}
