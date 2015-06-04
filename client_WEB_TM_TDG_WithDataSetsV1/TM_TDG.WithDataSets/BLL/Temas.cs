using System;
using System.Data;
using Common;

namespace TM_TDG.WithDataSets.BLL
{
    public class Temas
    {
        public Temas()
		{
		}

        public DataTable GetAll()
        {
            DAL.TemasGateway dal = new DAL.TemasGateway();
            return dal.GetAll();
        }
	}
}

