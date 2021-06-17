using Microsoft.AspNetCore.Mvc;
using StudentMarkManagement.Core.IServices;
using StudentMarkManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMarkManagement.Web.Controllers
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

        public ActionResult AddStudent()
        {
            return View();
        }
    }
}
