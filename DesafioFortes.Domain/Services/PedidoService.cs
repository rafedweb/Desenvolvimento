using DesafioFortes.Domain.Entities;
using DesafioFortes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioFortes.Domain.Interfaces.Repositories;

namespace DesafioFortes.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
            : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        IEnumerable<Pedido> IPedidoService.ObterPedidosPorFornecedor(int fornecedorID)
        {
            return _pedidoRepository.GetAll().Where(p => p.FornecedorID == fornecedorID);
        }
            
        
    }
}
