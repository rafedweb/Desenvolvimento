using DesafioFortes.Domain.Entities;
using System.Collections.Generic;


namespace DesafioFortes.Domain.Interfaces.Repositories
{
   public  interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
