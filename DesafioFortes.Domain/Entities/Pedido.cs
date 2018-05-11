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
        public int ProdutoID { get; set; }
        public int FornecedorID { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public int TotalProdutos(List<int> Produtos)
        {
            return Produtos.Count();
        }

        public decimal ObterValorTotal(List<Produto> Produtos)
        {
            return Produtos.Select(p => p.Valor).Sum();
        }
    }
}
