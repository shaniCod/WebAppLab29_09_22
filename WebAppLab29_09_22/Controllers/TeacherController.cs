using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppLab29_09_22.Models;

namespace WebAppLab29_09_22.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        TeacherService obj = new TeacherService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(obj.GetAllTeacher());
        }
        public ActionResult Create()
        {
            TeacherModel teacherobj = new TeacherModel();
            return View(teacherobj);
        }
        [HttpPost]
        public ActionResult Create(TeacherModel teacher)
        {
            obj.SetDataInDBINsert(teacher);

            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            obj.DeletDataFromDb(id);
            return RedirectToAction("List");
        }
        public ActionResult DetialBYID(int Id)
        {
            return View(obj.GetIDTeacher(Id));
        }
        public ActionResult Update(int id)
        {

            return View(obj.GetIDTeacher(id));
        }
        [HttpPost]
        public ActionResult Update(int id, TeacherModel teacModel)
        {
            obj.EditDataInDbt(id, teacModel);
            return RedirectToAction("List");
        }
    }
}