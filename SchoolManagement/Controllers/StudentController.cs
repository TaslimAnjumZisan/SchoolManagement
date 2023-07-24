using Microsoft.AspNetCore.Mvc;
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
            var studentList = await _studentManager.GetAllStudentsAsync();
            return View(studentList);
        }

        public IActionResult Create()
        {
            var model = new StudentCreateModel();
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
                        return RedirectToAction("Index");
                    }
                    else
                        return RedirectToAction("Update");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<IActionResult>Delete(int id)
        //{
        //    try
        //    {
        //        var model = await _studentManager.GetStudentById(id);
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<IActionResult>Delete( StudentDeleteModel model)
        //{
        //    try
        //    {
        //        if(ModelState.IsValid)
        //        {
        //            Boolean result = await _studentManager.DeleteStudent(model);
        //            if (result)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //                return RedirectToAction("Delete");
        //        }
        //        return View(model);

        //    }catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
