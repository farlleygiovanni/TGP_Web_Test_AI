using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGP_AI_ALG.modelo
{
    class objAITGP
    {
        /// <summary>
        /// seta a variavel alfa
        /// onde alfa é o fator que determina se a informação é recebida ou passada
        /// <param name="v_estado"></param>
        /// <returns>value of alfa</returns>
        public int Alfa(string v_estado)
        {
            try
            {
                int vle_alfa = 0;
                if (v_estado == "P")
                {
                    vle_alfa = 1;
                }
                else
                {
                    vle_alfa = 1;
                }
                return vle_alfa;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// a função calcula e retorna o valor de beta
        /// sendo gama a disponibilidade de uma determinada informação.
        /// </summary>
        /// <param name="v_gama"></param>
        /// <param name="v_mi_media"></param>
        /// <param name="v_sigma_desvio"></param>
        /// <param name="v_gama_max"></param>
        /// <param name="v_gama_min"></param>
        /// <returns>value of gama</returns>
        public double Beta(double v_gama, double v_mi_media, double v_sigma_desvio, double v_gama_max, double v_gama_min)
        {
            try
            {
                if (v_gama >= v_gama_min && v_gama <= v_gama_max)
                {
                    double vle_beta;
                    vle_beta = (1 / (2 * Math.PI * Math.Pow(v_sigma_desvio, 2))) * (Math.Exp(((-1) * ((v_gama - v_mi_media) / (2 * Math.Pow(v_sigma_desvio, 2))))));
                    return vle_beta;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// a função calcula e retorna o valor de gama
        /// sendo gama a relevancia de uma determinada informação.
        /// </summary>
        /// <param name="v_lambda"></param>
        /// <param name="v_k_iterations"></param>
        /// <param name="v_t_time"></param>
        /// <returns>value of gama</returns>
        public double Gama(double v_lambda, int v_k_iterations, int v_t_tempo)
        {
            try
            {
                double vle_gama;
                vle_gama = Math.Exp(v_lambda - Convert.ToDouble(v_k_iterations * v_t_tempo));
                return vle_gama;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// a função calcula e retorna o valor de lambda
        /// sendo lambda o fator de crescimento/decaimento da relevancia de uma informação.
        /// </summary>
        /// <param name="v_num_alfa_pos"></param>
        /// <param name="v_num_alfa_neg"></param>
        /// <param name="v_anls_alfa_time"></param>
        /// <returns>value of lambda</returns>
        public double Lambda(double v_num_alfa_pos, double v_num_alfa_neg, double v_anls_alfa_time)
        {
            try
            {
                double vle_lambda;
                vle_lambda = (v_num_alfa_neg / v_anls_alfa_time) * v_anls_alfa_time;
                return vle_lambda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// a função calcula e retorna o valor de lambda
        /// sendo lambda o fator de crescimento/decaimento da relevancia de uma informação.
        /// </summary>
        /// <param name="v_gama"></param>
        /// <param name="v_media"></param>
        /// <returns>value of lambda sigma</returns>
        public double Variancia(List<double> v_gama, double v_media)
        {
            try
            {
                double vle_variancia = 0;
                for (int i = 0; i < v_gama.Count; i++)
                {
                    vle_variancia += Math.Pow((v_gama[i] - v_media), 2);
                }
                vle_variancia = Math.Sqrt((1 / (v_gama.Count - 1)) * vle_variancia);
                return vle_variancia;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// a função calcula e retorna o valor de mi
        /// sendo mi a media dos valores da relevancia de uma informação em um grupo amostral omega.
        /// </summary>
        /// <param name="v_gama"></param>
        /// <returns></returns>
        public double Media(List<double> v_gama)
        {
            try
            {
                double vle_media = 0;
                for (int i = 0; i < v_gama.Count; i++)
                {
                    vle_media += v_gama[0];
                }
                vle_media = (1 / (v_gama.Count) * vle_media);
                return vle_media;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
