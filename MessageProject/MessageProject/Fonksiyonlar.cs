using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MessageProject
{
    class Fonksiyonlar
    {

        public SqlConnection Baglan()
        {
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-6UK4290\\SQLEXPRESS;Database=MessageProject;Integrated Security=true;");
            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                }
                catch (SqlException)
                {
                }
            }
            return baglanti;
        }


        public int cmd(string sqlcumle)
        {
            SqlConnection baglan = this.Baglan();

            SqlCommand cmd = new SqlCommand(sqlcumle, baglan);

            int sonuc = 0;
            try
            {
                sonuc = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            cmd.Dispose();
            baglan.Close();
            baglan.Dispose();

            return (sonuc);
        }

        //data table için

        public DataTable GetDataTable(string sql)
        {
            SqlConnection baglan = this.Baglan();
            SqlDataAdapter adap = new SqlDataAdapter(sql, baglan);
            DataTable dt = new DataTable();
            try
            {
                adap.Fill(dt);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            adap.Dispose();
            baglan.Close();

            return dt;

        }

        // tek satır kayıt çekmek için kullanabiliriz...
        public DataRow GetDataRow(string sql)
        {

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }








    }
}
