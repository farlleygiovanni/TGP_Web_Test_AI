﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGP_AI_ALG.objetos
{
    public class individuo_comparado
    {
        [Required(ErrorMessage = "O estado da informação e necessario")]
        [Display(Name = "Alfa")]
        public int ALFA { get; set; }
        [Required(ErrorMessage = "A disponibilidade da informação e necessaria")]
        [Display(Name = "Beta")]
        public double BETA { get; set; }
        [Required(ErrorMessage = "A relevancia da informação e necessaria")]
        [Display(Name = "Gama")]
        public double GAMA { get; set; }
        [Required(ErrorMessage = "A informação propriamente dita e necessaria")]
        [Display(Name = "Teta")]
        public teta TETA { get; set; }
        [Required(ErrorMessage = "Parametro de controle de beta")]
        [Display(Name = "Beta_Min")]
        public double BETA_MIN { get; set; }
        [Required(ErrorMessage = "Parametro de controle de beta")]
        [Display(Name = "Beta_max")]
        public double BETA_MAX { get; set; }
        [Required(ErrorMessage = "Parametro de controle da evolução da população resposta")]
        [Display(Name = "FiltroEvolutivo")]
        public double Filtro_Evol { get; set; }
    }
}
