using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioFortes.MVC.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public int PedidoID { get; set; }

        public DateTime DataPedido { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "99999999999999")]
        [Required(ErrorMessage = "Preencha o valor")]
        public decimal ValorTotal { get; set; }

        public int QuantidadeProdutos { get; set; }
        public List<Produto> podutos { get; set; }


        public int ProdutoID { get; set; }
        public int FornecedorID { get; set; }

        public virtual List<Produto> Produtos { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}