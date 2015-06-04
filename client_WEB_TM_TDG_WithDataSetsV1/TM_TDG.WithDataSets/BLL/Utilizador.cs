using System;
using System.Data;
using Common;

namespace TM_TDG.WithDataSets.BLL
{
    public class Utilizador
    {
        public Utilizador()
        {
        }
        public DataTable GetUserbyRegiao(string str_regiao)
        {
            DAL.UtilizadorGateway dal = new DAL.UtilizadorGateway();
            return dal.GetUserbyRegiao(str_regiao);
        }
        public DataTable GetRegiao(string str_user)
        {
            DAL.UtilizadorGateway dal = new DAL.UtilizadorGateway();
            return dal.GetRegiao(str_user);
        }
    }
}
