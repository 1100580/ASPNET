using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;

namespace TM_TDG.WithDataSets.DAL
{
	/// <summary>
	/// Summary description for ContractGateway.
	/// </summary>
	public class VotacaoGateway : BaseGateway
	{
		public VotacaoGateway()
		{
		}


        public DataTable GetAllEdicao(int edicao)
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Votacao where Edicao =" + edicao, ds, "playlist");

            return ds.Tables[0];
        }


        public void Votar(int index)
        {
            ExecuteNonQuery("UPDATE dbo.Votacao SET Votos = Votos+1 where ID=" + index);
        }
    }
}
