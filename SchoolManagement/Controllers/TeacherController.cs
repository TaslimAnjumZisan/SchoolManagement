using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Manager.ManagerInterface;
using SchoolManagement.Models;
using SchoolManagement.ViewModel.Teacher;

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
        public async Task<IActionResult> Create()
        {
            var model= new TeacherCreateModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(TeacherCreateModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result= await _teachersManager.CreateTeacherAsync(model);
                    if(result)
                     {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var teacher = await _teachersManager.GetTeacherBy(id);
                return View(teacher);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boolean teacher = await _teachersManager.UpdateTeacher(model);
                    if (teacher)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Update");
                    }

                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var teacher= await _teachersManager.GetTeacherById(id);
                return View(teacher);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(TeacherDeleteModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    Boolean result= await _teachersManager.DeleteTeacherAsync(model);
                    if(result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Delete");
                    }
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
