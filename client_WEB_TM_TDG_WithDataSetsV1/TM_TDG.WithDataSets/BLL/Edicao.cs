using System;
using System.Data;
using Common;



namespace TM_TDG.WithDataSets.BLL
{
	public class Edicao
	{
		public Edicao()
		{
		}

        public DataTable GetAll()
        {
            DAL.EdicaoGateway dal = new DAL.EdicaoGateway();
            return dal.GetAll();
        }

        public DataTable GetAberta()
        {
            DAL.EdicaoGateway dal = new DAL.EdicaoGateway();
            return dal.GetAberta();
        }

        public void Abrir(int index)
        {
            DAL.EdicaoGateway dal = new DAL.EdicaoGateway();
            dal.Abrir(index);
        }

	}
}
