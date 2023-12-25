using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        IMapper mapper;

        public EmployeeController(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            List<EmployeeListDto> list = new List<EmployeeListDto>();

            list = db.Employees.Where(q => !q.IsDeleted).Select(q => new EmployeeListDto()
            {
                Id = q.Id,
                Name = q.Name,
                Surname = q.Surname,
                Address = q.Address,
                City = q.City,
                AddDate = q.AddDate
            }).ToList();

            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeDto model)
        {
            Employee employee = new Employee();

            employee = mapper.Map<Employee>(model);

            db.Employees.Add(employee);
            db.SaveChanges();

            return View(model);
        }

        //delete
        public IActionResult Delete(int id)
        {
           
            var employee = db.Employees.FirstOrDefault(q => q.Id == id);

            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            employee.IsDeleted = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
