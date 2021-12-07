using PosGe.Context;
using PosGe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PosGe.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(context.produtos.OrderBy(D => D.nome));
        }

        // GET: /Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produtos)
            {
            context.produtos.Add(produtos);
            context.SaveChanges();
            return RedirectToAction("Index");
            }

        public ActionResult Edit(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
            Fornecedor forenecedor = context.forenecedor.Find(id);
            if (forenecedor == null)
                {
                return HttpNotFound();
                }
            return View(forenecedor);
            }

        // POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produtos)
            {
            if (ModelState.IsValid)
                {
                context.Entry(produtos).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(produtos);
            }

        // GET: /Delete/5
        public ActionResult Delete(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
            Produto produtos = context.produtos.Find(id);
            if (produtos == null)
                {
                return HttpNotFound();
                }
            return View(produtos);
            }
        }
}