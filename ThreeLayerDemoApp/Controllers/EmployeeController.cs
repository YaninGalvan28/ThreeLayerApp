using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;

namespace ThreeLayerDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployeesAsync(); //this makes sure the business logic gets processed before returning the view
            return View(employees);
        }
        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            await employeeService.GetDetailsAsync(employee);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)//
            {
                await employeeService.AddEmployeeAsync(employee);

                return RedirectToAction(nameof(Index));

            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) //works with database so its async
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employeeEdited)
        {
            if (ModelState.IsValid)
            {
                await employeeService.EditEmployeeAsync(employeeEdited);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeEdited);

        }
    }
}



