using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public class categoriasGateway
{
    OleDbConnection conn;
    OleDbCommand sqlCommand;

	public categoriasGateway(String connStr)
	{
        conn = new OleDbConnection(connStr);
        sqlCommand = new OleDbCommand();
	}

    public OleDbConnection getConnection()
    {
        conn.Open();
        return conn;
    }

    public OleDbDataReader findAllCategorias()
    {
        OleDbDataReader reader;
        String sqlQuery = "select * from categorias;";
        sqlCommand.Connection = conn;
        sqlCommand.CommandText = sqlQuery;
        reader = sqlCommand.ExecuteReader();

        return reader;
    }

    public DataRow findCategoriasById(int idCategoria)
    {
        DataSet ds = new DataSet();
        String sqlQuery = "select * from categorias where IdCat = " + idCategoria + ";";
        OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery,conn);
        adapter.Fill(ds);
        DataTable dt = ds.Tables["Categorias"];
        
        return dt.Rows[0];
    }

    public void update(String id, String cat)
    {

    }

    public void insert(String cat)
    {
        String sqlQuery = "insert into categorias values(?);";
        //sqlQuery.Parameters.AddWithValue("nomeCat", cat);
    }
}