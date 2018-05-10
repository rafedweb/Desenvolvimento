using DesafioFortes.Domain.Entities;
using DesafioFortes.Domain.Interfaces.Repositories;
using DesafioFortes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository forncedorRepository)
            :base(forncedorRepository)
        {
            _fornecedorRepository = forncedorRepository;
        }

        public IEnumerable<Fornecedor> ObterFornecedoresEspeciais(IEnumerable<Fornecedor> fornecedores)
        {
            return fornecedores.Where(c => c.ClienteEspecial(c));
        }
    }
}
