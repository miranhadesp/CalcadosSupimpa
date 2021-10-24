using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int Id_Modelo { get; set; }

        public int Id_Cliente { get; set; }

        public int Quantidade { get; set; }

        public DateTime DtVenda { get; set; }
    }
}
