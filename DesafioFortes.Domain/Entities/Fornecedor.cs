using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorID { get; set; }      
        public int CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string UF { get; set; }
        public string EmailContato { get; set; }
        public string NomeContato { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool ClienteEspecial(Fornecedor fornecedor)
        {
            return fornecedor.Ativo && DateTime.Now.Year - fornecedor.DataCadastro.Year >= 5;
        }
    }
}
