using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace TM_TDG.WithDataSets.DAL
{
	/// <summary>
	/// Summary description for ContractGateway.
	/// </summary>
	public class MusicaGateway : BaseGateway
	{
		public MusicaGateway()
		{
		}


        public DataTable GetAll()
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Musica where Disponivel = 1", ds, "musica");

            return ds.Tables[0];
        }

        public DataTable GetbyTema(string tema)
        {
            if (tema.Equals("Rock"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 1", ds, "musica");
                return ds.Tables[0];
            }
            else if (tema.Equals("Pop"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 2", ds, "musica");
                return ds.Tables[0];
            }
            else if (tema.Equals("Classical"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 3", ds, "musica");
                return ds.Tables[0];
            }
            else if (tema.Equals("Opera"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 3", ds, "musica");
                return ds.Tables[0];
            }
            else if (tema.Equals("Opera"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 4", ds, "musica");
                return ds.Tables[0];
            }
            else if (tema.Equals("Other"))
            {
                SqlConnection cnx = GetConnection(true);
                DataSet ds = new DataSet();
                FillDataSet(cnx, "SELECT * FROM dbo.Musica where Tema = 5", ds, "musica");
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetId(int index)
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Musica where ID = "+index, ds, "musica");

            return ds.Tables[0];
        }

        public void ApagarId(int index)
        {
            ExecuteNonQuery("DELETE FROM dbo.Musica where ID=" + index);
        }

        public void MudarDisponibilidade(int index)
        {
            int disp;
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Musica where ID ="+index, ds, "musica");
            disp = Convert.ToInt32(ds.Tables[0].Rows[0]["Disponivel"]);
            if (disp == 0)
                disp = 1;
            else
                disp = 0;

            ExecuteNonQuery("UPDATE dbo.Musica set Disponivel = "+disp+" where ID=" + index);
        }

        public void InserirMusica(string n, string a, string t, string d)
        {
            ExecuteNonQuery("INSERT INTO dbo.Musica (nome,artista,tema,duracao,disponivel) VALUES ('" + n + "','" + a + "'," + t + "," + d + "," + 1 + ")");
        }

        public void EditarMusica(string index, string n, string a, string t, string d)
        {
            ExecuteNonQuery("UPDATE dbo.Musica set Nome = " + n + ", Artista = " + a + ", Tema = " + t + ", Duracao = " + d + " where ID=" + index);
        }
    }
}
