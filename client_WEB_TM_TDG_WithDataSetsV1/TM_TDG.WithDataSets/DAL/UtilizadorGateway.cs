using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TM_TDG.WithDataSets.DAL
{
    public class UtilizadorGateway : BaseGateway
    {
        public UtilizadorGateway()
		{
		}
 
		public DataTable GetUserbyRegiao(string str_regiao)
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Utilizador WHERE Regiao=' " + str_regiao + " ' ", ds, "utilizador");
            return ds.Tables[0];
        }
        public DataTable GetRegiao(string str_user)
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT Regiao FROM dbo.Utilizador WHERE Username=' " + str_user + " ' ", ds, "utilizador");
            return ds.Tables[0];
        }
    }
}
