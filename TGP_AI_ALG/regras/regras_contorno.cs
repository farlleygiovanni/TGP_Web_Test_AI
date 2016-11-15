using System;
using TGP_AI_ALG.objetos;

namespace TGP_AI_ALG.regras
{
    public class regras_contorno
    {
        string erro = "";
        public string valida_teta(teta v_teta)
        {
            try
            {
                if (valida_vetor_posicao(v_teta.v_r_vetor_posicao))
                {
                    if (valida_informacao(v_teta.v_teta))
                    {
                        return "OK";
                    }
                    else
                    {
                        throw new Exception("Erro ao validar a informação" + erro);
                    }
                }
                else
                {
                    throw new Exception("Erro ao validar o vetor posicao" + erro);
                }
            }
            catch (Exception ex)
            {
                return "Erro ao validar a informação: " + ex.Message;
            }
        }

        public bool valida_informacao(object v_teta)
        {
            try
            {
                switch (identifica_objeto(v_teta))
                {
                    case TypeCode.Boolean:
                        {
                            Boolean vle_teste = Convert.ToBoolean(v_teta);
                            return true;
                        }
                    case TypeCode.Byte:
                        {
                            Byte vle_teste = Convert.ToByte(v_teta);
                            return true;
                        }
                    case TypeCode.Char:
                        {
                            Char vle_teste = Convert.ToChar(v_teta);
                            return true;
                        }
                    case TypeCode.DateTime:
                        {
                            DateTime vle_teste = Convert.ToDateTime(v_teta);
                            return true;
                        }
                    case TypeCode.DBNull:
                        {
                            return false;
                        }
                    case TypeCode.Decimal:
                        {
                            Decimal vle_teste = Convert.ToDecimal(v_teta);
                            return true;
                        }
                    case TypeCode.Double:
                        {
                            Double vle_teste = Convert.ToDouble(v_teta);
                            return true;
                        }
                    case TypeCode.Empty:
                        {
                            return false;
                        }
                    case TypeCode.Int16:
                        {
                            Int16 vle_teste = Convert.ToInt16(v_teta);
                            return true;
                        }
                    case TypeCode.Int32:
                        {
                            Int32 vle_teste = Convert.ToInt32(v_teta);
                            return true;
                        }
                    case TypeCode.Int64:
                        {
                            Int64 vle_teste = Convert.ToInt64(v_teta);
                            return true;
                        }
                    case TypeCode.Object:
                        {
                            return false;
                        }
                    case TypeCode.SByte:
                        {
                            SByte vle_teste = Convert.ToSByte(v_teta);
                            return true;
                        }
                    case TypeCode.Single:
                        {
                            Single vle_teste = Convert.ToSingle(v_teta);
                            return true;
                        }
                    case TypeCode.String:
                        {
                            string vle_teste = Convert.ToString(v_teta);
                            return true;
                        }
                    case TypeCode.UInt16:
                        {
                            UInt16 vle_teste = Convert.ToUInt16(v_teta);
                            return true;
                        }
                    case TypeCode.UInt32:
                        {
                            UInt32 vle_teste = Convert.ToUInt32(v_teta);
                            return true;
                        }
                    default:
                        {
                            UInt64 vle_teste = Convert.ToUInt64(v_teta);
                            return true;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool valida_vetor_posicao(object v_r_vetor_posicao)
        {
            object[] vle_r_posicao;
            if (v_r_vetor_posicao.ToString().Contains("|"))
            {
                vle_r_posicao = v_r_vetor_posicao.ToString().Split('|');
                return true;
            }
            else if (v_r_vetor_posicao.ToString().Contains(";"))
            {
                vle_r_posicao = v_r_vetor_posicao.ToString().Split(';');
                return true;
            }
            else if (v_r_vetor_posicao.ToString().Contains("|"))
            {
                vle_r_posicao = v_r_vetor_posicao.ToString().Split(',');
                return true;
            }
            else
                return true;
        }

        public TypeCode identifica_objeto(object var)
        {
            try
            {
                TypeCode vle_type = Type.GetTypeCode(var.GetType());
                return vle_type;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double FiltroEvolucao(individuo_comparado v_individuo, individuo_comparado_output v_out_individuo)
        {
            try
            {
                double vle_FiltroEvolucao = 0;
                vle_FiltroEvolucao = v_individuo.GAMA * (v_out_individuo.GAMA / v_individuo.GAMA);
                return vle_FiltroEvolucao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
