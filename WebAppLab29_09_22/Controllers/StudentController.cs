using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppLab29_09_22.Models;

namespace WebAppLab29_09_22.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentService obj = new StudentService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(obj.GetAllStudent());
        }
        public ActionResult Create()
        {
            StudentModel studentobj = new StudentModel();
            return View(studentobj);
        }
        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            obj.SetDataInDBINsert(student);
           
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
          obj.DeletDataFromDb(id);
            return RedirectToAction("List");
        }
        public ActionResult DetialBYID(int Id)
        {
            return View(obj.GetIDStudent(Id));
        }
        public ActionResult Update(int id)
        {
            
            return View(obj.GetIDStudent(id));
        }
        [HttpPost]
        public ActionResult Update(int id, StudentModel StuModel)
        {
            obj.EditDataInDbt(id, StuModel);
            return RedirectToAction("List");
        }


    }
}