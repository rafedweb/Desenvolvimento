using DesafioFortes.Application.Interface;
using DesafioFortes.Domain.Entities;
using DesafioFortes.Domain.Interfaces.Services;
using DesafioFortes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFortes.Application
{
    public class FornecedorAppService : AppServiceBase<Fornecedor>, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorAppService(IFornecedorService fornecedorService)
            :base(fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public IEnumerable<Fornecedor> ObterFornecedoresEspeciais()
        {
            return _fornecedorService.ObterFornecedoresEspeciais(_fornecedorService.GetAll());
        }
    }
}
