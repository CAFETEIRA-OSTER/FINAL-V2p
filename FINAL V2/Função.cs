using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2
{
    class Função
    {
        protected SqlConnection Conexão()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";
            return cn;
        }
        public DataSet GetData(String consulta)
        {
            SqlConnection cn = Conexão();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = consulta;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void SetData(String consulta, String sms)
        {
            SqlConnection cn = Conexão();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(sms, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
