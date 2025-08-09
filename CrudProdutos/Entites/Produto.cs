using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProdutos.Entites
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; } = 0d;
        public int Quantidade { get; set; } = 0;
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
        public DateTime DataHoraUltimaAlteracao { get; set; } = DateTime.Now;
    }
}
