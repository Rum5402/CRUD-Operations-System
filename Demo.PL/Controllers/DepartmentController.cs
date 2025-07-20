using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository) // Ask CLR for creating object from class implement interface IDepartmentRepository 
        {
            _departmentRepository = departmentRepository;
            //_departmentRepository = new IDepartmentRepository();
        }
        //BaseURL/Department/index
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server side validation
            { 
               var Result = _departmentRepository.Add(department);
                if (Result > 0)
                {
                    TempData["Message"] = "Department is created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        //BaseURL/Department/Details
        public IActionResult Details(int? id , string ViewName = "Details")
        {
            if (id is null)
                return BadRequest(); // status code 400
            var department = _departmentRepository.GetById(id.Value);
            if (id is null)
                return NotFound();
            return View(ViewName,department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if(id is null)
            //    return BadRequest();
            //var department = _departmentRepository.GetById(id.Value);
            //if (id is null)
            //    return NotFound();
            //return View(department);
            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department, [FromRoute] int id)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid) // Server side validation
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1.Log excepption
                    //2.Form
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department department , [FromRoute] int id)
        {
            if (id != department.Id)
                return BadRequest();
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(department);
            }

        }
    
        
    }
}
