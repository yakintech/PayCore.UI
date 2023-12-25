using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    public class SupplierController : BaseController
    {

        IMapper mapper;

        public SupplierController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var suppliers = db.Suppliers.Where(q => !q.IsDeleted).ToList();
            return View(suppliers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddSupplierDto model)
        {
            Supplier supplier = new Supplier();

            supplier = mapper.Map<Supplier>(model);
            db.Suppliers.Add(supplier);
            db.SaveChanges();

            return View(model);
        }   

        //delete supplier with id. isdeleted true
        public IActionResult Delete(int id)
        {
            var supplier = db.Suppliers.FirstOrDefault(q => q.Id == id);
                
            if (supplier == null)
            {
                return NotFound();
            }

            supplier.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
