using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class categorias : System.Web.UI.Page
{
    categoriasGateway cG;
    protected void Page_Load(object sender, EventArgs e)
    {
        String connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;User ID=;Data Source=|DataDirectory|/loja.mdb";
        cG = new categoriasGateway(connStr);

        OleDbConnection conn = cG.getConnection();
            OleDbDataReader dr = cG.findAllCategorias();
            gdvCategorias.DataSource = dr;
            gdvCategorias.DataBind();
            dr.Close();
        //conn.Close();
    }

    public void SelectedIndexChanged(Object sender, EventArgs e)
    {
        int selValue = (int)gdvCategorias.SelectedDataKey.Value;
        DataRow dr = cG.findCategoriasById(selValue);
        idBox.Text = dr[0].ToString();
        catBox.Text = dr[1].ToString();
        
    }

    public void update(Object sender, EventArgs e)
    {
        cG.update(idBox.Text,catBox.Text);
    }

    public void insert(Object sender, EventArgs e) 
    {
        cG.insert(catBox.Text);
    }
}