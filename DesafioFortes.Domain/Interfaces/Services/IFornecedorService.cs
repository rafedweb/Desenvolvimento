using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Domain.Interfaces.Services
{
    public interface IFornecedorService : IServiceBase<Fornecedor>
    {
        IEnumerable<Fornecedor> ObterFornecedoresEspeciais(IEnumerable<Fornecedor> fornecedores);
    }
}
