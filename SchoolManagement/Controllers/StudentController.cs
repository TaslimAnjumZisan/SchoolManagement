using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SchoolManagement.Manager.ManagerInterface;
using SchoolManagement.ViewModel.Student;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentsManager _studentManager;
        public StudentController(IStudentsManager studentsManager)
        {
            _studentManager = studentsManager;
        }
        public async Task<IActionResult> Index()
        {
            var studentList = await _studentManager.GetAllTeacherStudentsAsync();
            return View(studentList);
        }

        public IActionResult Create()
        {
            var model = new StudentCreateModel();
            model.GenderList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Gender", Value=""},
                new SelectListItem(){Text="Male", Value="Male"},
                new SelectListItem(){Text="Female", Value="Female"},
                new SelectListItem(){Text="Other", Value="Other"},
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateModel obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Boolean result = await _studentManager.CreateStudentAsync(obj);
                    if (result)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                        return RedirectToAction("Create");
                }
                obj.GenderList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Gender", Value=""},
                new SelectListItem(){Text="Male", Value="Male"},
                new SelectListItem(){Text="Female", Value="Female"},
                new SelectListItem(){Text="Other", Value="Other"},
            };
                return View(obj);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _studentManager.GetStudentBy(id);
                model.GenderList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Gender", Value=""},
                new SelectListItem(){Text="Male", Value="Male"},
                new SelectListItem(){Text="Female", Value="Female"},
                new SelectListItem(){Text="Other", Value="Other"},
            };
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(StudentEditModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Boolean result = await _studentManager.UpdateStudent(model);
                    if (result)
                    {
                        
                    }
                    else
                        return RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var model = await _studentManager.GetStudentById(id);
            //    model.GenderList = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Select Gender", Value=""},
            //    new SelectListItem(){Text="Male", Value="Male"},
            //    new SelectListItem(){Text="Female", Value="Female"},
            //    new SelectListItem(){Text="Other", Value="Other"},
            //};
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult>Delete( StudentDeleteModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Boolean result = await _studentManager.DeleteStudent(model);
                    if (result)
                    {
                       
                    }
                    
                }
                return RedirectToAction("Delete");

                //return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
