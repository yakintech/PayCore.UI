using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    public class WriterController : BaseController
    {

        public IActionResult Index()
        {
            List<ListWriterDto> model = db.Writers.Where(q => !q.IsDeleted).Select(q => new ListWriterDto()
            {
                Id= q.Id,
                Name = q.Name,
                Surname = q.Surname,
                BirthDate = q.BirthDate,
                ProfileImagePath = q.ProfileImagePath
                
            }).ToList();

            return View(model);
        }

      
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddWriterDto model, IFormFile profilePicture)
        {

            if(profilePicture != null && profilePicture.Length > 0)
            {

                var guid = Guid.NewGuid().ToString();
                var ext = Path.GetExtension(profilePicture.FileName);
                var fileName = guid + ext;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await profilePicture.CopyToAsync(fileSrteam);
                }

                if(ext == ".jpeg" || ext == ".png" || ext == ".jpg")
                {
                    if (ModelState.IsValid)
                    {
                        Writer writer = new Writer();
                        writer.Name = model.Name;
                        writer.Surname = model.Surname;
                        writer.BirthDate = model.BirthDate;
                        writer.AddDate = DateTime.Now;
                        writer.UpdateDate = DateTime.Now;
                        writer.IsDeleted = false;
                        writer.ProfileImagePath = fileName;

                        db.Writers.Add(writer);
                        db.SaveChanges();

                        return Redirect("Index");

                    }
                }
            }


            return View();
        }

        public IActionResult Detail(int id)
        {
            // oncelikle writer db den buluyorum.

            Writer writer = db.Writers.FirstOrDefault(db=> db.Id == id && !db.IsDeleted);

            if (writer != null)
            {
                var model = new GetWriterByIdDto();
                model.Id = id;
                model.Name = writer.Name;
                model.Surname = writer.Surname;
                model.BirthDate = writer.BirthDate;
                model.AddDate = writer.AddDate;
                writer.UpdateDate = writer.UpdateDate;

                return View(model);
            }

            return RedirectToAction("Index");  
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var writer = db.Writers.Find(id);

            if(writer == null)
            {
                return Json("islem sirasinda bir hata meydana geldi");
            }
            else
            {
                writer.IsDeleted = true;
                db.SaveChanges();
                //delete file 

                System.IO.File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/images/" + writer.ProfileImagePath);
                return Json("ok");
            }

        }
    }
}
