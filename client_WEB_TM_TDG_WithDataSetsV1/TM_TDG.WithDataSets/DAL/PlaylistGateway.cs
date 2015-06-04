using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;

namespace TM_TDG.WithDataSets.DAL
{
	/// <summary>
	/// Summary description for ContractGateway.
	/// </summary>
	public class PlaylistGateway : BaseGateway
	{
		public PlaylistGateway()
		{
		}


        public DataTable GetAll()
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Playlist", ds, "playlist");

            return ds.Tables[0];
        }

        public DataTable GetFromUser(string nome)
        {
            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT * FROM dbo.Playlist where IDUSER ='" + nome+"'", ds, "playlistUser");

            return ds.Tables[0];
        }

        public void SubmeterPlaylist(int id, int semana)
        {
            ExecuteNonQuery("INSERT INTO dbo.Votacao VALUES (0,"+id+","+semana+")");
        }

        public int CreatePlaylist(int m1, int m2, int m3, int m4, int m5, string user)
        {
            ExecuteNonQuery("INSERT INTO dbo.Playlist VALUES (" + m1 + "," + m2 + "," + m3 + "," + m4 + "," + m5 + ",'" + user + "')");

            SqlConnection cnx = GetConnection(true);
            DataSet ds = new DataSet();
            FillDataSet(cnx, "SELECT @@IDENTITY as Identity", ds, "playlistUser");

            return Convert.ToInt32(ds.Tables[0].Rows[0]["Identity"].ToString());
        }
    }
}
