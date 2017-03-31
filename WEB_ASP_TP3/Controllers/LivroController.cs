using WEB_ASP_TP3.Models;
using WEB_ASP_TP3.Repository;
using System.Linq;
using System.Web.Mvc;
using WEB_ASP_TP3.Domain;

namespace WEB_ASP_TP3.Controllers
{
    public class LivroController : Controller
    {

        private readonly ILivroRepository repository;
        public LivroController(ILivroRepository repository) {

            this.repository = repository;
        }



        // GET: Livro Lista
        public ActionResult index()
        {
            //var repository = new LivroRepository();

            var Livros = repository.GetAllLivros();

            return View(
                Livros.Select(a => new LivroViewModel()
                {
                    Id = a.Id,
                    Titulo = a.Titulo,
                    Autor = a.Autor,
                    Editora = a.Editora,
                    Ano = a.Ano,
                    Anotacao = a.Anotacao
                }));

        }


        public ActionResult Create()
        {
            return View();
        }


        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                //var repository = new LivroRepository();

                repository.CreateLivro(new Livro()
                {
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    Editora = livro.Editora,
                    Ano = livro.Ano,
                    Anotacao = livro.Anotacao
                });

                return RedirectToAction("index");
            }
                return View();
        }

        // GET: Livro/Detalhe/5
        public ActionResult Detalhe(int Id)
        {
            //var repository = new LivroRepository();
            var Livro = repository.GetOneLivro(Id);
            if (Livro == null)
            {
                return HttpNotFound();
            }

            return View(Livro);
        }

        public ActionResult Edit(int Id)
        {
            //var repository = new LivroRepository();
            var Livro = repository.GetOneLivro(Id);
            if (Livro == null)
            {
                return HttpNotFound();
            }

            return View(Livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            
                if (ModelState.IsValid)
                {
                    //var repository = new LivroRepository();
                    repository.EditLivro(livro);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(livro);
                }
                         
        }

        public ActionResult PreviewDelete(int Id)
        {
            //var repository = new LivroRepository();
            var Livro = repository.GetOneLivro(Id);
            if (Livro == null)
            {
                return HttpNotFound();
            }

            return View(Livro);
        }


        public ActionResult Delete(int Id)
        {
        try
            {
               //var repository = new LivroRepository();


        repository.DeleteLivro(Id);
                    // TODO: Add delete logic here
                
                return RedirectToAction("index");
    }
            catch
            {
                return View();
}
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {

                return View();
        }
    }
}