using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TM_TDG.WithDataSets.DAL
{
	/// <summary>
	/// Summary description for BaseGateway.
	/// </summary>
	public abstract class BaseGateway
	{
		public BaseGateway()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        //alteradas as connectionStrings
        private const string _CONNSTR = @"Data Source=gandalf;Initial Catalog=ARQSI75;User ID=ARQSI75;Password=qwerty";
		private string CONNSTR
		{
			get 
			{
				//return System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
                return _CONNSTR;
            }
		}

		private SqlTransaction myTx;

		protected SqlTransaction CurrentTransaction
		{
			get { return myTx; }
		}

		protected SqlConnection GetConnection(bool open)
		{
			SqlConnection cnx = new SqlConnection(CONNSTR);
			if (open)
				cnx.Open();
			return cnx;
		}

		protected DataSet ExecuteQuery(SqlConnection cnx, string sql)
		{
			try
			{
				SqlDataAdapter da = new SqlDataAdapter(sql, cnx);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		protected void FillDataSet(SqlConnection cnx, string sql, DataSet ds, string tableName)
		{
			try
			{
				SqlDataAdapter da = new SqlDataAdapter(sql, cnx);
				da.Fill(ds, tableName);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

        protected int ExecuteNonQuery(string sql)
        {
            SqlConnection cnx = GetConnection(true);
            int r = ExecuteNonQuery(cnx, sql);
            cnx.Close();
            return r;
        }

		protected int ExecuteNonQuery(SqlConnection cnx, string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, cnx);
			return cmd.ExecuteNonQuery();
		}

		protected int ExecuteNonQuery(SqlTransaction tx, string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, tx.Connection, tx);
			return cmd.ExecuteNonQuery();
		}

		protected int ExecuteNonQuery(SqlTransaction tx, SqlCommand cmd)
		{
			cmd.Transaction = tx;
			return cmd.ExecuteNonQuery();
		}

		public void BeginTransaction()
		{
			try
			{
				if (myTx == null)
					myTx = GetConnection(true).BeginTransaction();
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		public void CommitTransaction()
		{
			if (myTx != null)
			{
				SqlConnection cnx = myTx.Connection;
				myTx.Commit();
				cnx.Close();
			}
		}

		public void RoolbackTransaction()
		{
			if (myTx != null)
			{
				SqlConnection cnx = myTx.Connection;
				myTx.Rollback();
				cnx.Close();
			}
		}
	}
}
