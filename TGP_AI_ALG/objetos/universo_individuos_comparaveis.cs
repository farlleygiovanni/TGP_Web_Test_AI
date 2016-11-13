using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGP_AI_ALG.objetos;

namespace TGP_AI_ALG.objetos
{
    class universo_individuos_comparaveis
    {
        [Required(ErrorMessage = "O estado da informação e necessario")]
        [Display(Name = "Alfa")]
        public List<int> ALFA { get; set; }
        [Required(ErrorMessage = "A disponibilidade da informação e necessaria")]
        [Display(Name = "Alfa")]
        public List<double> BETA { get; set; }
        [Required(ErrorMessage = "A relevancia da informação e necessaria")]
        [Display(Name = "Alfa")]
        public List<double> GAMA { get; set; }
        [Required(ErrorMessage = "A informação propriamente dita e necessaria")]
        [Display(Name = "Alfa")]
        public List<teta> TETA { get; set; }
    }
}
