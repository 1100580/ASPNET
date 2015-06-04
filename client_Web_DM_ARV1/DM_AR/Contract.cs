using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Common;

namespace DM_AR.Model
{
	public class Contract : ActiveRecord
	{
		private int _CustomerID;
		private DateTime _DateSigned;
		private int _ProductID;
		private decimal _Revenue;
		private IList _RevenueRecognitions = new ArrayList();
		private Customer _Customer;
		private Product _Product;

		public IList RevenueRecognitions
		{
			get 
			{
				// não deveria retornar directamente a lista mas sim um Enumerator ou um clone da lista ou uma copia readonly
				//return _RevenueRecognitions; 
				return System.Collections.ArrayList.ReadOnly(_RevenueRecognitions); 
			}
		}

		public DateTime DateSigned
		{
			get { return _DateSigned; }
		}
		public int ProductID
		{
			get { return _ProductID; }
		}

		public int customerID
		{
			get { return _CustomerID; }
		}
		public decimal Revenue
		{
			get { return _Revenue; }
		}

		private class RevenueRecognition
		{
			private decimal _Amount;
			//private int ContractID;
			private DateTime _DateRecognition;
			private int _ID;

			public decimal Amount
			{
				get { return _Amount; }
			}
			public DateTime DateRecognition
			{
				get { return _DateRecognition; }
			}
			public int ID
			{
				get { return _ID; }
			}

			public RevenueRecognition(int id, DateTime dt, decimal amt)
			{
				_Amount = amt;
				_DateRecognition = dt;
				_ID = id;
			}

			public RevenueRecognition(DateTime dt, decimal amt)
			{
				_Amount = amt;
				_DateRecognition = dt;
			}
		}

		public Customer Customer
		{
			get { return _Customer; }
		}

		public Product Product 
		{
			get 
			{  
				//Lazy Load
                //if (this._Product == null)
				//	this._Product = Product.LoadById(this.ProductID);
				return this._Product;
			} 
		}

		protected void AddRecognition(DateTime recognitionDate, decimal amount)
		{
			_RevenueRecognitions.Add(new RevenueRecognition(recognitionDate, amount)); 
		}

		protected void AddRecognition(int id, DateTime recognitionDate, decimal amount)
		{
			_RevenueRecognitions.Add(new RevenueRecognition(id, recognitionDate, amount)); 
		}

		public Contract()
		{
		}

		protected Contract(DataRow row)
		{
			this.myID = (int)row["ID"];
			this._ProductID = (int)row["productid"];
      //    this._Product = new Product((int)row["productid"], (String)row["Type"], (String)row["Name"]);
			this._CustomerID = (int)row["customerid"];
			this._DateSigned = (DateTime)row["datesigned"];
			this._Revenue = (decimal)row["revenue"];
		}

		protected Contract(DataSet dsContractAndRecognitions)
		{
			this.myID = (int)dsContractAndRecognitions.Tables[0].Rows[0]["TContracts.id"];
			this._ProductID = (int)dsContractAndRecognitions.Tables[0].Rows[0]["productid"];
			this._CustomerID = (int)dsContractAndRecognitions.Tables[0].Rows[0]["customerid"];
			this._DateSigned = (DateTime)dsContractAndRecognitions.Tables[0].Rows[0]["datesigned"];
			this._Revenue = (decimal)dsContractAndRecognitions.Tables[0].Rows[0]["revenue"];

			foreach (DataRow r in dsContractAndRecognitions.Tables[0].Rows)
			{
				// tratamento de campos nulos
				if (!r.IsNull("daterecognition"))
					this.AddRecognition((DateTime)r["daterecognition"], (decimal)r["amount"]);
			}
		}

		public Money RecognizedRevenue(DateTime asOf)
		{
			//TODO implementar este método
			throw new NotImplementedException(this.GetType().FullName + ".RecognizedRevenue");
		}

		public void CalculateRevenueRecognitions()
		{
			
			//limpar calculos anteriores
			_RevenueRecognitions.Clear();

			switch (this.Product.Type)
			{
				case Product.WordProcessor:
				{
					AddRecognition(DateSigned, Revenue);
				}
					break;
				case Product.SpreadSheet:
				{
					decimal[] allocs = Money.Allocate(Revenue, 3);
					AddRecognition(DateSigned, allocs[0]);
					AddRecognition(DateSigned.AddDays(60), allocs[1]);
					AddRecognition(DateSigned.AddDays(90), allocs[2]);
				}
					break;
				case Product.DataBase:
                {
                    decimal[] allocs = Money.Allocate(Revenue, 3);
					AddRecognition(DateSigned, allocs[0]);
					AddRecognition(DateSigned.AddDays(30), allocs[1]);
					AddRecognition(DateSigned.AddDays(60), allocs[2]);
                }
                    break;
			}
		}

		public static Contract LoadById(int contractID)
		{
			DataSet ds = ExecuteQuery("SELECT * FROM vwContractsAndRecognitionsAndProduct WHERE TContracts.id=" + contractID);
			if (ds.Tables[0].Rows.Count < 1)
				return null;

			return new Contract(ds);
		}

		public static IList LoadByProduct(int productID)
		{
			//TODO implementar este método
			throw new NotImplementedException(typeof(Contract).FullName + ".LoadByProduct");
		}

        //IMPLEMENTAR O CÓDIGO  
		public static IList LoadByCustomer(int customerID)
		{
            DataSet ds = ExecuteQuery("SELECT * FROM TContracts where CustomerID=" + customerID);

            IList ret = new ArrayList();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Contract c = new Contract(r);
                ret.Add(c);
            }

            return ret;
		}

		public static IList LoadAll()
		{
			DataSet ds = ExecuteQuery("SELECT * FROM vwContractsAndRecognitionsAndProduct");

			IList ret = new ArrayList();

			Contract current = null;
			int currentID = -1;
			foreach (DataRow r in ds.Tables[0].Rows)
			{
				if ( (int)r["TContracts.id"] != currentID)
				{
					current = new Contract(r);
					ret.Add(current);

					currentID = (int)r["TContracts.id"];
				}
			//	 tratamento de campos nulos
				if (!r.IsNull("daterecognition"))
					current.AddRecognition( (int)r["TRevenueRecognitions.ID"], (DateTime)r["daterecognition"], (decimal)r["amount"]);
			}

			return ret;
		}

       

        public Contract LoadByCustomerDate(string nome, DateTime date)
        {
            //TODO implementar este método
            throw new NotImplementedException(typeof(Contract).FullName + ".LoadByCustomerDate");

        }

        public override void Save()
		{
			BeginTransaction();

			System.Data.OleDb.OleDbCommand sqlContract = new System.Data.OleDb.OleDbCommand();
			if (this.ID != 0)
				sqlContract.CommandText = "UPDATE TContracts SET productId=?, customerID=?, dateSigned=?, revenue=? WHERE ID=?";
			else
				sqlContract.CommandText = "INSERT INTO TContracts(productId, customerId, dateSigned, revenue) VALUES(?, ?, ?, ?)";
			sqlContract.Transaction = CurrentTransaction;
			System.Data.IDataParameter p = sqlContract.Parameters.Add("@pid", System.Data.OleDb.OleDbType.Integer);
			p.Value = _ProductID;
			//p = sqlContract.Parameters.Add("@cid", System.Data.OleDb.OleDbType.Integer);
			//p.Value = _CustomerID;
            //ou usando AddWithValue;
			sqlContract.Parameters.AddWithValue("@cid", _CustomerID);
			p = sqlContract.Parameters.Add("@dt", System.Data.OleDb.OleDbType.Date);
			p.Value = DateSigned;
			p = sqlContract.Parameters.Add("@rev", System.Data.OleDb.OleDbType.Currency);
			p.Value = _Revenue;
			if (this.ID != 0)
			{
				p = sqlContract.Parameters.Add("@id", System.Data.OleDb.OleDbType.Integer);
				p.Value = this.ID;
			}
			int id = ExecuteTransactedNonQuery(sqlContract);

			if (this.ID != 0)
				ExecuteTransactedNonQuery("DELETE FROM TRevenueRecognitions WHERE contractID=" + this.ID);
			else
				this.myID = id;

			foreach (RevenueRecognition r in _RevenueRecognitions)
			{
				System.Data.OleDb.OleDbCommand sqlRecognition = new System.Data.OleDb.OleDbCommand();
				sqlRecognition.CommandText = "INSERT INTO TRevenueRecognitions(contractID, dateRecognition, amount) VALUES(?, ?, ?)";
				sqlRecognition.Transaction = CurrentTransaction;
				sqlRecognition.Parameters.AddWithValue("@cid", this.ID);
				p = sqlRecognition.Parameters.Add("@dt", System.Data.OleDb.OleDbType.Date);
				p.Value = r.DateRecognition;
				p = sqlRecognition.Parameters.Add("@amt", System.Data.OleDb.OleDbType.Currency);
				p.Value =  r.Amount;
			
				ExecuteTransactedNonQuery(sqlRecognition);
			}

			CommitTransaction();
		}
	}
}

