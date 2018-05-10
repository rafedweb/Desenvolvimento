using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Domain.Entities
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public int QuantidadeProdutos { get; set; }
        public List<int> ProdutoID { get; set; }
        public int FornecedorID { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
