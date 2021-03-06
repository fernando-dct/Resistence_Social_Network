using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resistence_Entity
{
    [Serializable]
    public class Rebelde
    {
        public Rebelde()
        {
            QtdeReportadaTraidor = 0;
        }
        public int IdRebelde { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A idade é obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "O genero é obrigatório")]
        public int QtdeReportadaTraidor { get; set; }
        public string Genero { get; set; }
        public Local Local { get; set; }
        public IList<Inventario> Inventario { get; set; }

    }
}
