﻿
namespace DesafioFortes.Domain.Entities
{
   public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteID { get; set; }
        public int FornecedorID { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
