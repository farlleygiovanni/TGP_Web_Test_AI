using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGP_AI_ALG.objetos
{
    class individuo_comparado
    {
        [Required(ErrorMessage = "O estado da informação e necessario")]
        [Display(Name = "Alfa")]
        public int ALFA { get; set; }
        [Required(ErrorMessage = "A disponibilidade da informação e necessaria")]
        [Display(Name = "Alfa")]
        public double BETA { get; set; }
        [Required(ErrorMessage = "A relevancia da informação e necessaria")]
        [Display(Name = "Alfa")]
        public double GAMA { get; set; }
        [Required(ErrorMessage = "A informação propriamente dita e necessaria")]
        [Display(Name = "Alfa")]
        public teta TETA { get; set; }
    }
}
