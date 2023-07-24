using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Manager.ManagerInterface;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeachersManager _teachersManager;
        public TeacherController(ITeachersManager teachersManager)
        {
            _teachersManager = teachersManager;
        }
        public async Task< IActionResult> Index()
        {
            var teacherList= await _teachersManager.GetAllTeacherAsync();
            return View(teacherList);
        }
        
    }
}
