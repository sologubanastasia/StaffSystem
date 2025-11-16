using Microsoft.AspNetCore.Mvc;

namespace StaffSystem.Web.Controllers
{
    // ТИМЧАСОВА ДІАГНОСТИКА: Це обходить всі сервіси, щоб перевірити, чи падає контролер.
    public class EmployeeController : Controller
    {
        // ❗ ВИДАЛЕНО ВСІ ЗАЛЕЖНОСТІ З КОНСТРУКТОРА
        // public EmployeeController(IEmployeeService service) { ... }

        public EmployeeController()
        {
            // Порожній конструктор
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Повертаємо простий View, щоб протестувати завантаження View Engine
            return View(); 
        }

        [HttpGet]
        public IActionResult Test()
        {
            // Чистий текст, без View
            return Content("Employee Controller Test OK!");
        }
    }
}