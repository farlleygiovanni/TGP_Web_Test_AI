using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCO.Conexao
{
    public class Lib_Dao
    {
        public static Hashtable OutputParameters = new Hashtable();

        #region "Propriedades"

        private static string f_StringSql;

        public static string StringSql
        {
            get { return f_StringSql; }
            set { f_StringSql = value; }
        }

        #endregion

        #region "Variaveis"

        static DataTable workTable = null;

        static object NovoValor = null;
        static SqlDbType NovoValorTipo = default(SqlDbType);
        static string NovoParametro = null;
        static string Output = null;
        static object OutputValue = null;

        #endregion

        #region "Objetos"

        private static Lib_Conexao objFabricaConexao = new Lib_Conexao();
        private static SqlConnection conexao = new SqlConnection();

        #endregion

        #region "Metodos"

        public object GetParameters(int index)
        {
            return OutputParameters[index].ToString();
        }

        public static Boolean ExecultarNaoConsulta(int CmdType = 1)
        {
            SqlCommand cmd = new SqlCommand();
            objFabricaConexao.FecharConexao(conexao);
            objFabricaConexao.CriarConexao(conexao);

            cmd.Connection = conexao;
            cmd.CommandTimeout = 100;

            switch (CmdType)
            {
                case 1:
                    cmd.CommandType = CommandType.Text;
                    break;
                case 2:
                    cmd.CommandType = CommandType.StoredProcedure;
                    break;
            }

            cmd.CommandText = StringSql;
            //cmd.Parameters.Clear();

            objFabricaConexao.AbrirConexao(conexao);
            CriarParametros();

            try
            {
                //  cmd.Parameters.Clear();

                if (workTable.Rows.Count > 0)
                {
                    for (int i = 0; i <= workTable.Rows.Count - 1; i++)
                    {
                        NovoParametro = workTable.Rows[i][0].ToString();
                        NovoValor = workTable.Rows[i][1];
                        NovoValorTipo = (SqlDbType)workTable.Rows[i][2];
                        Output = workTable.Rows[i][3].ToString();
                        OutputValue = workTable.Rows[i][4];
                        if (Output == "Input")
                        {
                            cmd.Parameters.Add(new SqlParameter(NovoParametro, NovoValorTipo)).Value = NovoValor;
                        }
                        else if (Output == "Output")
                        {
                            cmd.Parameters.Add(new SqlParameter(NovoParametro, NovoValorTipo)).Direction = ParameterDirection.Output;
                        }
                    }
                }
                cmd.ExecuteNonQuery();

                for (int j = 0; j < cmd.Parameters.Count - 1; j++)
                {
                    if (cmd.Parameters[j].Direction == ParameterDirection.Output)
                    {
                        OutputParameters.Add(j, cmd.Parameters[j].Value);
                    }
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception("Erro ao Executar." + Ex.Message);
            }
            finally
            {
                LimparParametros();
            }
        }

        public static SqlDataReader ExecultarConsulta(int CmdType = 1)
        {


            SqlCommand cmd = new SqlCommand();

            try
            {

                objFabricaConexao.CriarConexao(conexao);
                CriarParametros();

                cmd.Connection = conexao;
                cmd.CommandTimeout = 100;

                switch (CmdType)
                {
                    case 1:
                        //DEFAULT - Text
                        cmd.CommandType = CommandType.Text;
                        break;
                    case 2:
                        //Stored Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                }
                cmd.CommandText = StringSql;
                cmd.Parameters.Clear();

                if (workTable.Rows.Count > 0)
                {
                    for (int i = 0; i <= workTable.Rows.Count - 1; i++)
                    {
                        NovoParametro = workTable.Rows[i][0].ToString();
                        NovoValor = workTable.Rows[i][1];
                        NovoValorTipo = (SqlDbType)workTable.Rows[i][2];
                        Output = workTable.Rows[i][3].ToString();
                        OutputValue = workTable.Rows[i][4];
                        if (Output == "Input")
                        {
                            cmd.Parameters.Add(new SqlParameter(NovoParametro, NovoValorTipo)).Value = NovoValor;
                        }
                        else if (Output == "Output")
                        {
                            cmd.Parameters.Add(new SqlParameter(NovoParametro, NovoValorTipo)).Direction = ParameterDirection.Output;
                        }
                    }
                }
                objFabricaConexao.AbrirConexao(conexao);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                LimparParametros();

            }
        }

        private static void LimparParametros()
        {
            workTable.Clear();
            workTable = null;

        }

        private static void CriarParametros()
        {
            if (workTable == null)
            {
                workTable = new DataTable();

                workTable.Columns.Add(new DataColumn("Parameter", typeof(string)));
                workTable.Columns.Add(new DataColumn("Value", typeof(object)));
                workTable.Columns.Add(new DataColumn("ValueType", typeof(SqlDbType)));
                workTable.Columns.Add(new DataColumn("Output", typeof(string)));
                workTable.Columns.Add(new DataColumn("OutputValue", typeof(object)));

            }
        }

        internal static void AdicionarParametro(object Parametro, object Valor, SqlDbType TipoValor)
        {
            CriarParametros();

            DataRow row;
            row = workTable.NewRow();
            row[0] = Parametro;
            row[1] = Valor;
            row[2] = TipoValor;
            row[3] = "Input";
            row[4] = "";

            workTable.Rows.Add(row);
            Debug.Print("Declare @" + Parametro + " " + TipoValor + " = " + Valor);
        }
        public DataTable RetornarProcedure(string _procedure, List<SqlParameter> ls)
        {

            SqlDataReader rd;

            objFabricaConexao.FecharConexao(conexao);
            objFabricaConexao.CriarConexao(conexao);

            SqlConnection conn = new SqlConnection(conexao.ConnectionString);
            SqlCommand cmd = new SqlCommand(_procedure, conn);
            DataTable dt = new DataTable();
            cmd.Parameters.Clear();
            foreach (SqlParameter i in ls)
            {
                cmd.Parameters.Add(i);
            }

            cmd.CommandTimeout = 10000;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(("Erro de acesso aos dados </br></br> " + (_procedure + ("</br></br> " + ex.Message))));
            }
            finally
            {
                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }

            return dt;
        }
        #endregion

    }
}
