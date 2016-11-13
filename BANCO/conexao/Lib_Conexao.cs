using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCO.Conexao
{
    public class Lib_Conexao
    {


        #region "Prop"

        private SqlConnection f_Conexao;

        public SqlConnection Conexao
        {
            get { return f_Conexao; }
            private set { f_Conexao = value; }
        }

        #endregion

        #region "Var"

        private static string SourceDatabase = string.Empty;

        #endregion


        public void CriarConexao(SqlConnection Conexao)
        {

            try
            {
                if (this.Conexao == null)
                {
                    if (Conexao == null)
                    {
                        Conexao = new SqlConnection();
                    }
                    else
                    {
                        this.Conexao = Conexao;
                    }
                }
                else
                {
                    Conexao = this.Conexao;
                }

                if (Conexao.State != ConnectionState.Open)
                {
                    if (Conexao.ConnectionString == null || Conexao.ConnectionString == "")
                    {
                        string con = "";
                        con = "Data Source=DESKTOP-P8D2H66;Initial Catalog=TGPAIALG;User ID=idTECMaster2;Password=idtec0608";
                        //con = "data source=DESKTOP-P8D2H66; initial catalog =idTECGeradorProvas; integrated security = SSPI; persist security info = False; Trusted_Connection = Yes; ";
                        Conexao.ConnectionString = con;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível estabelecer conexão com o servidor. Motivo: " + ex.Message.ToString() + "");
            }

        }

        public void AbrirConexao(SqlConnection Conexao)
        {
            if (Conexao.State == System.Data.ConnectionState.Open)
            {
                Conexao.Close();
            }

            if (Conexao.State != System.Data.ConnectionState.Open)
            {
                Conexao.Open();
            }
        }

        public void FecharConexao(SqlConnection Conexao)
        {
            if (Conexao.State == System.Data.ConnectionState.Open)
            {
                Conexao.Close();
                Conexao.Dispose();
            }
        }

        public void DefinirBaseDados(string ID)
        {
            SourceDatabase = ID;
        }

        internal void CriarConexao()
        {
            throw new NotImplementedException();
        }
    }
}
