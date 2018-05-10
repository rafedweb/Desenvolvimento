using AutoMapper;
using DesafioFortes.Domain.Entities;
using DesafioFortes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioFortes.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        //public override string ProfileName
        //{
        //    get { return "DomainToViewModelMappins"; }
        //}

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Pedido, PedidoViewModel>();
            Mapper.CreateMap<Fornecedor, FornecedorViewModel>();
        }
    }
}