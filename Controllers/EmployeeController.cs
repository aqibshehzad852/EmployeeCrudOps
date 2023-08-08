using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NewCrudApp.Controllers.Data;
using NewCrudApp.Models;
using NewCrudApp.Models.Domain;

namespace NewCrudApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NewDbContext newDb;

        public EmployeeController(NewDbContext newDb)
        {
            this.newDb = newDb;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var employees = await newDb.Employee_Tab.ToListAsync();
           return View(employees);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeModel addEmployee)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployee.Name,
                Email = addEmployee.Email,
                Salary = addEmployee.Salary,
                DateOfJoining = addEmployee.DateOfJoining,
                City = addEmployee.City,
            };
            await newDb.Employee_Tab.AddAsync(employee);
            await newDb.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task <IActionResult> View(Guid id) 
        {
            var employee= await newDb.Employee_Tab.FirstOrDefaultAsync(x=>x.Id==id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfJoining = employee.DateOfJoining,
                    City = employee.City,
                };
                return await Task.Run(()=>  View("view",viewModel));
            }
           
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel viewModel)
        {
            var employee = await newDb.Employee_Tab.FindAsync(viewModel.Id);
            if (employee != null)
            {
                employee.Name = viewModel.Name;
                employee.Email = viewModel.Email;
                employee.Salary = viewModel.Salary;
                employee.DateOfJoining= viewModel.DateOfJoining;
                employee.City= viewModel.City;

                await newDb.SaveChangesAsync();
                return RedirectToAction("index");

            }
            return RedirectToAction("index");

        }
     
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await newDb.Employee_Tab.FindAsync(model.Id);
            if (employee != null)
            {
                newDb.Employee_Tab.Remove(employee);
                await newDb.SaveChangesAsync();
                return RedirectToAction("index");

            }
     
            return RedirectToAction("index");
        }


    }
}
