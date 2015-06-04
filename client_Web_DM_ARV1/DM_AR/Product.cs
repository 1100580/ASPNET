using System;
using System.Collections;
using System.Data;

namespace DM_AR.Model
{
	public class Product : ActiveRecord
	{
		//public enum Type { SpreadSheet, WordProcessor, DataBase }
		public const string SpreadSheet = "FC";
		public const string WordProcessor = "PT";
		public const string DataBase = "BD";

		private string _name;
		private string _type;

		public Product()
		{
		}

        public Product(int productid, String type, String name)
        {
            this.myID = productid;
            this._name = name;
            this._type = type;
        }

		protected Product(DataRow row)
		{
			this.myID = (int)row["id"];
			this._name = (string)row["name"];
			this._type = (string)row["type"];
		}

		public string Type { get { return _type; } }
		public string Name { get { return _name; } }

		public override string ToString()
		{
			return Name;
		}

        
 
		public static Product LoadById(int productID)
		{
           
			DataSet ds = ExecuteQuery("SELECT * FROM TProducts WHERE ID=" + productID);
			Product p = new Product(ds.Tables[0].Rows[0]);

           	return p;
		}

		public static IList LoadAll()
		{
			try
			{
				DataSet ds = ExecuteQuery(GetConnection(false), "SELECT * FROM TProducts");

				IList ret = new ArrayList();

				foreach (DataRow r in ds.Tables[0].Rows)
				{
					Product p = new Product(r);
					ret.Add(p);

                    //apagar
					// save in registry
					//loaded[p.ID] = p;
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
			//TODO implementar este método
			throw new NotImplementedException(this.GetType().FullName + ".Save");
		}	
	}
}

