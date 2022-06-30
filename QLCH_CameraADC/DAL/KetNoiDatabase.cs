using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KetNoiDatabase
    {
        public static SqlConnection ConnectDB;

        // MỞ KẾT NỐI TỚI SQL SERVER
        public void OpenConnect()
        {
            if (KetNoiDatabase.ConnectDB == null)
                // KetNoiDatabase.ConnectDB = new SqlConnection(@"Data Source=DESKTOP-L3VUEAK;Initial Catalog=PM_BanLinhKienPC;Integrated Security=True");
                KetNoiDatabase.ConnectDB = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog =QLCH_CameraADC;Integrated Security = True");

            if (KetNoiDatabase.ConnectDB.State != ConnectionState.Open)
                KetNoiDatabase.ConnectDB.Open();
        }
        // ĐÓNG KẾT NỐI TỚI SQL SERVER
        public void CloseConnect()
        {
            if (KetNoiDatabase.ConnectDB != null)
                KetNoiDatabase.ConnectDB.Close();

        }
        // LẤY BẢNG DỮ LIỆU
        public DataTable GetDataTable(string strSQL)
        {
            try
            {
                OpenConnect();
                DataTable dt = new DataTable();
                SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, ConnectDB);
                sqlda.Fill(dt);
                CloseConnect();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        // TRUY VẤN DỮ LIỆU
        public void ExecuteReader(string strSQL)
        {
            try
            {
                OpenConnect();
                SqlCommand sqlcmd = new SqlCommand(strSQL, ConnectDB);
                sqlcmd.ExecuteNonQuery();
                CloseConnect();
            }
            catch
            {

            }
        }
    }
}
