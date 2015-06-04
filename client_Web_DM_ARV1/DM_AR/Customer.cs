using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace DM_AR.Model
{
	public class Customer : ActiveRecord
	{
		//private int ID;
		private string _Name;
		
		public Customer()
		{
		}
		
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

        public Customer(String name)
        {
            this._Name = name;
        }

		protected Customer(DataRow row)
		{
            this.myID = (int)row["ID"];
            this._Name = (string)row["Name"];
		}
	
		public override string ToString()
		{
			return Name;
		}

		public static Customer LoadById(int customerID)
		{
			DataSet ds = ExecuteQuery(GetConnection(false), "SELECT * FROM TCustomers WHERE id=" + customerID);
			if (ds.Tables[0].Rows.Count != 1)
				return null;
			else
				return new Customer(ds.Tables[0].Rows[0]);
		}

		public static IList LoadAll()
		{
            try{
                DataSet ds = ExecuteQuery(GetConnection(false), "SELECT * FROM TCustomers");
                IList ret = new ArrayList();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Customer c = new Customer(r);
                    ret.Add(c);
                }

                return ret;
            }
			catch (Exception ex)
			{
				throw new ApplicationException("Erro BD", ex);
			}
		}

       
		public override void Save()
		{
			BeginTransaction();

			System.Data.OleDb.OleDbCommand sqlContract = new System.Data.OleDb.OleDbCommand();
			sqlContract.CommandText = "INSERT INTO TCustomers(Name) VALUES(?)";
			sqlContract.Transaction = CurrentTransaction;
			System.Data.IDataParameter p = sqlContract.Parameters.Add("@Name", System.Data.OleDb.OleDbType.WChar);
			p.Value = _Name;
			//sqlContract.Parameters.AddWithValue("@Name", _Name);

			int id = ExecuteTransactedNonQuery(sqlContract);

			this.myID = id;

			CommitTransaction();
		
		}
	}
}
