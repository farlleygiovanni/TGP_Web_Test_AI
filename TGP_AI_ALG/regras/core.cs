using System;
using System.Collections.Generic;
using TGP_AI_ALG.objetos;
using TGP_AI_ALG.regras;

namespace TGP_AI_ALG.regras
{
    class core
    {
        public List<individuo_comparado_output> brain_function(individuo_comparado Ind_Comparado, universo_individuos_comparaveis Uni_Comparavel)
        {
            try
            {
                List<individuo_comparado_output> List_Ind_Output = new List<individuo_comparado_output>();
                individuo_comparado_output Ind_Output = new individuo_comparado_output();
                regras_contorno contorno = new regras_contorno();
                if (contorno.valida_teta(Ind_Comparado.TETA) == "OK")
                {
                    for (int i = 0; i < Uni_Comparavel.TETA.Count; i++)
                    {
                        if (contorno.valida_teta(Uni_Comparavel.TETA[i]) == "OK")
                        {
                            if (Ind_Comparado.ALFA != Uni_Comparavel.ALFA[i])
                            {
                                if (Ind_Comparado.TETA.v_teta == Uni_Comparavel.TETA[i].v_teta)
                                {
                                    if ((Uni_Comparavel.BETA[i] >= (Ind_Comparado.BETA - Ind_Comparado.BETA_MIN)) && (Uni_Comparavel.BETA[i] >= (Ind_Comparado.BETA - Ind_Comparado.BETA_MAX)))
                                    {
                                        if ((Uni_Comparavel.GAMA[i] >= (Ind_Comparado.GAMA - Ind_Comparado.Filtro_Evol)) && (Uni_Comparavel.GAMA[i] <= (Ind_Comparado.GAMA + Ind_Comparado.Filtro_Evol)))
                                        {
                                            Ind_Output.ALFA = Uni_Comparavel.ALFA[i];
                                            Ind_Output.BETA = Uni_Comparavel.BETA[i];
                                            Ind_Output.GAMA = Uni_Comparavel.GAMA[i];
                                            Ind_Output.TETA.v_r_vetor_posicao = Uni_Comparavel.TETA[i].v_r_vetor_posicao;
                                            Ind_Output.TETA.v_teta = Uni_Comparavel.TETA[i].v_teta;
                                            List_Ind_Output.Add(Ind_Output);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return List_Ind_Output;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
