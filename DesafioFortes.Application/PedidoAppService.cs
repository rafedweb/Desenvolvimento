using DesafioFortes.Application.Interface;
using DesafioFortes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioFortes.Domain.Interfaces.Services;

namespace DesafioFortes.Application
{
   public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;

        public PedidoAppService(IPedidoService pedidoService)
            : base(pedidoService)
        {
            _pedidoService = pedidoService;
        }

       
        public IEnumerable<Pedido> ObterPedidosPorFornecedor(int fornecedorID)
        {
            return _pedidoService.ObterPedidosPorFornecedor(fornecedorID);
        }
    }
}
