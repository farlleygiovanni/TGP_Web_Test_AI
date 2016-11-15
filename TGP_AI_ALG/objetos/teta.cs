using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGP_AI_ALG.objetos
{
    public class teta
    {
        [Required(ErrorMessage = "A informação e necessaria")]
        [Display(Name = "teta")]
        public object v_teta { get; set; }
        [Required(ErrorMessage = "A posicao da informação e necessaria")]
        [Display(Name = "r")]
        public object v_r_vetor_posicao { get; set; }
    }
}
