using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.Contexto;

namespace Web.Controllers
{
    public class TipoItensController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: TipoItens
        public ActionResult Index()
        {
            return View(db.TipoItems.ToList());
        }

        // GET: TipoItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItem tipoItem = db.TipoItems.Find(id);
            if (tipoItem == null)
            {
                return HttpNotFound();
            }
            return View(tipoItem);
        }

        // GET: TipoItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoItens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoItemID,Nome")] TipoItem tipoItem)
        {
            if (ModelState.IsValid)
            {
                db.TipoItems.Add(tipoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoItem);
        }

        // GET: TipoItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItem tipoItem = db.TipoItems.Find(id);
            if (tipoItem == null)
            {
                return HttpNotFound();
            }
            return View(tipoItem);
        }

        // POST: TipoItens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoItemID,Nome")] TipoItem tipoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoItem);
        }

        // GET: TipoItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoItem tipoItem = db.TipoItems.Find(id);
            if (tipoItem == null)
            {
                return HttpNotFound();
            }
            return View(tipoItem);
        }

        // POST: TipoItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoItem tipoItem = db.TipoItems.Find(id);
            db.TipoItems.Remove(tipoItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
