﻿using AutoMapper;
using DesafioFortes.Application.Interface;
using DesafioFortes.Domain.Entities;
using DesafioFortes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;
        private readonly IPedidoAppService _pedidoAPP;
        private readonly IFornecedorAppService _fornecedorAPP;        

        public PedidoController(IProdutoAppService produtoApp, IClienteAppService clienteApp, IPedidoAppService pedidoApp, IFornecedorAppService fornecedorApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
            _pedidoAPP = pedidoApp;
            _fornecedorAPP = fornecedorApp;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var pedidoViewModel = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoAPP.GetAll());           

            return View(pedidoViewModel);
        }
       
        public ActionResult ListarPorFornecedor(int id)
        {
            var pedidoViewModel = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoAPP.ObterPedidosPorFornecedor(id));

            ViewBag.FornecedorID = new SelectList(_fornecedorAPP.GetAll(), "FornecedorID", "RazaoSocial");
            return View(pedidoViewModel);

        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {            
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(_pedidoAPP.GetById(id));

            return View(pedidoViewModel);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {            
            ViewBag.FornecedorID = new SelectList(_fornecedorAPP.GetAll(), "FornecedorID", "RazaoSocial");
            ViewBag.ProdutoID = new SelectList(_produtoApp.GetAll(), "ProdutoID", "Nome");
             
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(PedidoViewModel pedido)
        {
            
            DateTime localDate = DateTime.Now;
            pedido.DataPedido = localDate;
            foreach (var item in pedido.Produtos)
            {
                item.Fornecedor = _fornecedorAPP.GetAll().First();
            }
                          
                var pedidoDomain = Mapper.Map<PedidoViewModel, Pedido>(pedido);
                                            
                _pedidoAPP.Add(pedidoDomain);
               
          
            ViewBag.FornecedorID = new SelectList(_fornecedorAPP.GetAll(), "FornecedorID", "RazaoSocial", pedido.FornecedorID);
            ViewBag.ProdutoID = new SelectList(_produtoApp.GetAll(), "ProdutoID", "Nome");
            return View();
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            var pedido = _pedidoAPP.GetById(id);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);

            ViewBag.FornecedorID = new SelectList(_fornecedorAPP.GetAll(), "FornecedorID", "RazaoSocial", pedido.FornecedorID);
            return View(pedidoViewModel);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedido)
        {
            if (ModelState.IsValid)
            {
                var pedidoDomain = Mapper.Map<PedidoViewModel, Pedido>(pedido);
                _pedidoAPP.Update(pedidoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.FornecedorID = new SelectList(_fornecedorAPP.GetAll(), "FornecedorID", "RazaoSocial", pedido.FornecedorID);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            var pedido = _pedidoAPP.GetById(id);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);

            return View(pedidoViewModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pedido = _pedidoAPP.GetById(id);
            _pedidoAPP.Remove(pedido);

            return RedirectToAction("Index");
        }
               

        [HttpPost]
        public ActionResult ListaProdutos(List<string> items)
        {
            List<Produto> produtosAdicionados = new List<Produto>();

            foreach (var item in items)
            {
                produtosAdicionados.Add(_produtoApp.GetById(int.Parse(item)));
            }
            var produtosViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtosAdicionados);
            
            return PartialView("_ListaProdutos", produtosViewModel);
        }
        
    }
}
