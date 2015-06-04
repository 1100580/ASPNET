using System;
using System.Data;
using System.Data.OleDb;

namespace DM_AR.Model
{
	/// <summary>
	/// Summary description for BaseGateway.
	/// </summary>
	public abstract class ActiveRecord
	{
		public ActiveRecord()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public abstract void Save();

		protected int myID;

		public int ID
		{
			get
			{
				return myID;
			}
		}

		
        private const string _CONNSTR = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|revenuerecognitions.mdb;";

        private static string CONNSTR
		{
			get 
			{
				//return System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
                return _CONNSTR;
            }
		}

		private static OleDbTransaction myTx;
		private static OleDbConnection myCnx;

		protected static OleDbTransaction CurrentTransaction
		{
			get { return myTx; }
		}

		protected static OleDbConnection GetConnection(bool open)
		{
			OleDbConnection cnx = new OleDbConnection(CONNSTR);
			if (open)
				cnx.Open();
			return cnx;
		}

		protected static DataSet ExecuteQuery(OleDbConnection cnx, string sql)
		{
			try
			{
				OleDbDataAdapter da = new OleDbDataAdapter(sql, cnx);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (OleDbException ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		protected static int ExecuteNonQuery(OleDbConnection cnx, string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql, cnx);
			return cmd.ExecuteNonQuery();
		}

		protected static int ExecuteNonQuery(OleDbTransaction tx, string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql, tx.Connection, tx);
			return cmd.ExecuteNonQuery();
		}

		protected static int ExecuteNonQuery(OleDbTransaction tx, OleDbCommand cmd)
		{
			cmd.Transaction = tx;
			return cmd.ExecuteNonQuery();
		}

		protected static DataSet ExecuteQuery(string sql)
		{
			try
			{
				if (myCnx == null)
					myCnx = GetConnection(false);

				OleDbDataAdapter da = new OleDbDataAdapter(sql, myCnx);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (OleDbException ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		protected static DataSet ExecuteTransactedQuery(string sql)
		{
			try
			{
				OleDbDataAdapter da = new OleDbDataAdapter(sql, myCnx);
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds;
			}
			catch (OleDbException ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		protected static int ExecuteNonQuery(string sql)
		{
			OleDbConnection cnx = GetConnection(true);
			int r = ExecuteNonQuery(cnx, sql);
			cnx.Close();
			return r;
		}

		protected static int ExecuteTransactedNonQuery(string sql)
		{
			OleDbCommand cmd = new OleDbCommand(sql);
			return ExecuteTransactedNonQuery(cmd);
		}

		protected static int ExecuteTransactedNonQuery(OleDbCommand cmd)
		{
			try
			{
				cmd.Transaction = CurrentTransaction;
				cmd.Connection = CurrentTransaction.Connection;
				return cmd.ExecuteNonQuery();
			}
			catch (OleDbException ex)
			{
				// debug purposes only!!!
				throw ex;	
			}
		}

		protected static void BeginTransaction()
		{
			try
			{
				if (myTx == null)
					myTx = GetConnection(true).BeginTransaction();
			}
			catch (OleDbException ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

		protected static void CommitTransaction()
		{
			if (myTx != null)
			{
				OleDbConnection cnx = myTx.Connection;
				myTx.Commit();
				cnx.Close();
			}
		}

		protected static void RoolbackTransaction()
		{
			if (myTx != null)
			{
				OleDbConnection cnx = myTx.Connection;
				myTx.Rollback();
				cnx.Close();
			}
		}
	}
}

namespace DM_AR_Model_alt
{
	///// <summary>
	///// Summary description for BaseGateway.
	///// </summary>
	//abstract public class ActiveRecord
	//{
	//	public ActiveRecord()
	//	{
	//	}
	//	public int ID
	//	{
	//		get
	//		{
	//			return 0;
	//		}
	//	}
	//	public abstract void Save();
	//	protected int myID;
	//	private System.Data.OleDb.OleDbConnection myCnx;
	//	private System.Data.OleDb.OleDbTransaction myTx;
	//}


}
