using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Infra.Data.EntityConfig
{
    class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(c => c.PedidoID);

            HasRequired(p => p.Fornecedor)
               .WithMany()
               .HasForeignKey(p => p.FornecedorID);

            HasRequired(p => p.Produtos)
               .WithMany()
               .HasForeignKey(p => p.ProdutoID);
        }
    }
}
