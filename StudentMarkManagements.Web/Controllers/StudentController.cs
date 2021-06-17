using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMarkManagement.Core.IServices;
using StudentMarkManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMarkManagements.Web.Controllers
{
    public class StudentController : Controller
    {
        #region Declaration
        private readonly IStudentServices _IStudentServices;
        #endregion

        #region Constructor
        public StudentController(IStudentServices StudentServices)
        {
            _IStudentServices = StudentServices;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        #region Department
        public IActionResult Department()
        {
 
            return View();
        }
        #endregion

        #region AddStudent Details
        public ActionResult AddStudents()
        {
            StudentDetails student = new StudentDetails();
            student.Departments = _IStudentServices.GetAllDepartment();
            return View(student);
        }
        [HttpPost]
        public ActionResult AddStudents(StudentDetails student)
        {
            _IStudentServices.InsertStudentDetails(student);
            return RedirectToAction("StudentList");
           
        }
        #endregion

        #region Add Student Marks

        public ActionResult AddStudentMark()
        {
            ViewBag.Name = new SelectList(_IStudentServices.GetStudentName(), "StudentId","Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentMark(StudentMarks student)
        {
            _IStudentServices.InsertStudentMark(student);
            return RedirectToAction("StudentMarkList");
        }
        #endregion

        #region Show Student List
        public ActionResult StudentList()
        {
           var StudentList = _IStudentServices.GetStudentDetails();
            return View(StudentList);
        }
        #endregion

        #region Show Student Mark List
        public IActionResult StudentMarkList()
        {
            var stdMarks = _IStudentServices.GetStudentMarks();
            return View(stdMarks);
        }
        #endregion

        #region delete Student Detail
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                StudentDetails student = new StudentDetails();
                student = _IStudentServices.GetStudentById(id);
                _IStudentServices.DeleteStudentDetails(id);
            }
            return RedirectToAction("StudentList");
        }

        #endregion

        #region delete mark
        public ActionResult DeleteMark(int id)
        {
            if (id != 0)
            {
                
                _IStudentServices.DeleteStudentMarks(id);
            }
            return RedirectToAction("StudentMarkList");
        }
        #endregion
    }
}
