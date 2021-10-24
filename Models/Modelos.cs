using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class Modelos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Id_fornecedor { get; set; }

        public string Nome { get; set; }

        public string CodigoRef { get; set; }

        public string Cor { get; set; }

        public int Tamanho { get; set; }
    }
}
