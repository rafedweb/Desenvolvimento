using AutoMapper;
using DesafioFortes.Domain.Entities;
using DesafioFortes.MVC.ViewModels;

namespace DesafioFortes.MVC.AutoMapper 
{
    public class DomainToViewModelMappingProfile : Profile
    {
        //public override string ProfileName
        //{
        //    get { return "ViewModelToDomainMappins"; }
        //}

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<FornecedorViewModel, Fornecedor>();
            Mapper.CreateMap<PedidoViewModel, Pedido>();
        }
    }
}