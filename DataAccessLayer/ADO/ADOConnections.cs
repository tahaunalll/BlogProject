using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.ADO
{
    public class ADOConnections
    {
        #region bağlantı fonksiyonu
        //bağlantı fonksiyoonu
        /// <summary>
        /// Bu proje için bağlantı SqlConnection nesnesi döndüren fonksiyon
        /// </summary>
        /// <returns></returns>
        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=.; database=BlogDB; integrated security =true;";
            return conn;
        }
        #endregion
        #region storedProc fonksiyonu
        /// <summary>
        /// Stored Procedure parametresi ile DataTable nesnesi döndüren fonksiyon
        /// </summary>
        /// <param name="spName"></param>
        /// <returns>DataTable nesnesi</returns>
        public DataTable stroredProcCommands(string spName)
        {
            //System.InvalidOperationException: 'ADP_ConnectionRequired_Fill' Hatası
            //sqlCommand cmd = new SqlCommand() olarak initialize edilirse verilen hata
            //connection nesnesi.CreateCommand(); 
            SqlCommand cmd = this.connection().CreateCommand();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection().Open();
            sda.Fill(dt);
            connection().Close();
            return dt;
        }
        #endregion
    }
}
