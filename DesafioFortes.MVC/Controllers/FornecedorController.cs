using AutoMapper;
using DesafioFortes.Application.Interface;
using DesafioFortes.Domain.Entities;
using DesafioFortes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioFortes.MVC.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorAppService _fornecedorApp;

        public FornecedorController(IFornecedorAppService fornecedorApp)
        {
            _fornecedorApp = fornecedorApp;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            var fornecedorViewModel = Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(_fornecedorApp.GetAll());
            return View(fornecedorViewModel);
        }

        public ActionResult Especiais()
        {
            var fornecedorViewModel = Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(_fornecedorApp.ObterFornecedoresEspeciais());

            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {            
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(id));
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorViewModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                _fornecedorApp.Add(fornecedorDomain);

                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {           
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(id));
            return View(fornecedorViewModel);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(FornecedorViewModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                _fornecedorApp.Update(fornecedorDomain);

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {         
            var forncedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(id));

            return View(forncedorViewModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            _fornecedorApp.Remove(_fornecedorApp.GetById(id));

            return RedirectToAction("Index");
        }
    }
}
