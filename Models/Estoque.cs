using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class Estoque
    {
        public virtual Modelo ModeloNavigation { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int Id_Modelo { get; set; }

        public int Qtd { get; set; }
    }
}
