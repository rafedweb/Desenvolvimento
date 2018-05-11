using System.Data.Entity.ModelConfiguration;
using DesafioFortes.Domain.Entities;

namespace DesafioFortes.Infra.Data.EntityConfig
{
   public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Valor)
                .IsRequired();

            HasRequired(p => p.Fornecedor)
                .WithMany()
                .HasForeignKey(p => p.FornecedorID);
   
        }
    }
}
