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
    class TemasGateway: BaseGateway
    {
        public TemasGateway()
		{
		}
 
		public DataTable GetAll()
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Tema", ds, "tema");
            return ds.Tables[0];
        }
    }
}
