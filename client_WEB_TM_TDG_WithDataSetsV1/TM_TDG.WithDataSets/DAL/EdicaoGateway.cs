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
	public class EdicaoGateway : BaseGateway
	{
		public EdicaoGateway()
		{
		}


        public DataTable GetAll()
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Edicao", ds, "playlist");

            return ds.Tables[0];
        }

        public DataTable GetAberta()
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Edicao where Aberta = 1", ds, "playlist");

            return ds.Tables[0];
        }

        public void Abrir(int index)
        {
            ExecuteNonQuery("UPDATE dbo.Edicao SET Aberta = 0");
            ExecuteNonQuery("UPDATE dbo.Edicao SET Aberta = 1 where ID =" + index);
        }

        public void Fechar(int index)
        {
            ExecuteNonQuery("UPDATE dbo.Edicao SET Aberta = 0 where ID =" + index);
        }

    }
}
