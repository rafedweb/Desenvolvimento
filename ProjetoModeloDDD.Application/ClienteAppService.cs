using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
   public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService )
            :base(clienteService)
        {
            _clienteService = clienteService;
        } 

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
