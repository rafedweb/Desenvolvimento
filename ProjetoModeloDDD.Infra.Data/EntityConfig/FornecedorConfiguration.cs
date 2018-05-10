using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Infra.Data.EntityConfig
{
    class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            HasKey(c => c.FornecedorID);

            Property(c => c.RazaoSocial)
                .IsRequired()
                .HasMaxLength(150);            

            Property(c => c.EmailContato)
                .IsRequired();
        }
    }
}
