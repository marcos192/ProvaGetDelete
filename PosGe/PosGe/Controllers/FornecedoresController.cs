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
    public class FornecedoresController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fornecedores
        public ActionResult Index()
        {
            return View(context.forenecedor.OrderBy(c => c.nome));
        }

        // GET: /Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor forenecedor)
            {
            context.forenecedor.Add(forenecedor);
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
        public ActionResult Edit(Fornecedor forenecedor)
            {
            if (ModelState.IsValid)
                {
                context.Entry(forenecedor).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(forenecedor);
            }

        // GET: /Delete/5
        public ActionResult Delete(long? id)
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
        }
}