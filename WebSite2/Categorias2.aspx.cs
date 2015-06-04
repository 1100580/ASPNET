using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Categorias2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strconn = @"Provider=Microsoft.Jet.OLEDB.4.0;User ID=i100580;Data Source=loja.mdb";
        String sqlSelect = "Select * from Produtos where IdCat=" + id;
        
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = strconn;
        OleDbDataAdapter da;
        da = new OleDbDataAdapter(sqlSelect, conn);
        DataSet dsProdutos = new DataSet();
        da.Fill(dsProdutos, "Produtos"); //Populating DataSet
        gvProdutos.DataSource = dsProdutos; //GridView
        gvProdutos.DataBind();
    }
}