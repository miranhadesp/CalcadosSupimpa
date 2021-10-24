using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Loja_Sapatos.Models
{
    public class VendaViewModel
    {

        public List<string> CodigoRef { get; set;}

        public List<int> Id_Modelo { get; set; }

        public List<string> Nome_Modelo { get; set; }

        public List<string> Nome_Fornecedor { get; set; }

        public List<int> Tamanho_Modelo { get; set; }

        public List<string> Cor_Modelo { get; set; }

        public List<float> Valor_Item { get; set; }

        public List<int> Quantidade { get; set; }

        public int Id_Cliente { get; set; }

        public string Nome_Cliente { get; set; }

        public DateTime DtVenda { get; set; }

        public float Total { get; set; }
    }
}
