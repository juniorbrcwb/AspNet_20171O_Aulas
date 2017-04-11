using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WingtipToysMVC.Models;

namespace WingtipToysMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private WingtipToysMVCContext banco = new WingtipToysMVCContext();

        // GET: Categorias  (www.meusistema.com/Categorias)
        public ActionResult Index()
        {
            return View(banco.Categorias.ToList());
        }

        //GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                banco.Categorias.Add(categoria);
                banco.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }


        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = banco.Categorias.Find(id);

            if(categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                banco.Entry(categoria).State = EntityState.Modified;
                banco.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }
    }
}