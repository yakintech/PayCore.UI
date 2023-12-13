using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    public class BookController : BaseController
    {
        //book
        public IActionResult Index()
        {
            List<Book> books = db.Books.Where(q => !q.IsDeleted).ToList();
            return View(books);
        }

        //book/add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.IsDeleted = false;
            model.AddDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;

            db.Books.Add(model);
            db.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
