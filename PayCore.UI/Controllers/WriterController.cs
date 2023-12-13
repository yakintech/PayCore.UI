using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    public class WriterController : BaseController
    {

        public IActionResult Index()
        {
            List<ListWriterDto> model = db.Writers.Select(q => new ListWriterDto()
            {
                Id= q.Id,
                Name = q.Name,
                Surname = q.Surname,
                BirthDate = q.BirthDate,
            }).ToList();

            return View(model);
        }

      
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddWriterDto model)
        {
            if(ModelState.IsValid)
            {
                Writer writer = new Writer();
                writer.Name = model.Name;
                writer.Surname = model.Surname;
                writer.BirthDate= model.BirthDate;
                writer.AddDate = DateTime.Now;
                writer.UpdateDate = DateTime.Now;
                writer.IsDeleted = false;

                db.Writers.Add(writer);
                db.SaveChanges();

            }

            return View();
        }
    }
}
