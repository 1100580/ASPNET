using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calculos;

public partial class MaqCalc : System.Web.UI.Page
{
    private int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Object obj = Session["count"];
            if (obj != null)
                counter = Int32.Parse(obj.ToString());
        }
        catch
        {
            Session["count"] = 0;
        }
        if (!Page.IsPostBack)
        {
            Label1.Text = "Bemvindo à nossa calculadora!";
        }
        else
        {
            Label1.Text = "Continue a usar a nossa Calculadora";
        }
    
    }

    public void Calcula(Object s, EventArgs e)
    {
        double r = 0;
        double f1,f2;

        f1 = double.Parse(TextBox1.Text);
        f2 = double.Parse(TextBox2.Text);

        Calculos.ICalculos comp;
        comp = new Calculos.CalculosImpl();

        if (DropDownList1.SelectedValue == "1")
        {
            r = comp.Adicao(f1,f2);
        }else if (DropDownList1.SelectedValue == "2")
        {
            r = comp.Subtracao(f1,f2);
        }
        else if (DropDownList1.SelectedValue == "3")
        {
            r = comp.Multiplicacao(f1,f2);
        }
        else if (DropDownList1.SelectedValue == "4")
        {
            r = comp.Divisao(f1, f2);
        }
        counter++;
        Session["count"] = counter;
        LabelCounter.Text = "Já efectuou " + counter.ToString() + " calculos com sucesso!";
        TextBox3.Text = r.ToString();
    }
}