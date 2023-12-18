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
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);

            if (book != null)
            {
                book.IsDeleted = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = db.Books.FirstOrDefault(q => q.Id == id && !q.IsDeleted);
            if (book != null)
                return View(book);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            db.Books.Update(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Book book = db.Books.FirstOrDefault(q => !q.IsDeleted && q.Id == id);
            if (book != null)
                return View(book);
            return RedirectToAction("Index");
        }
    }
}
