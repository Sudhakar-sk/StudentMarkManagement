using StudentMarkManagement.Core.IRepositories;
using StudentMarkManagement.Core.IServices;
using StudentMarkManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Services.Services
{
    public class StudentService:IStudentServices
    {
        #region Declaration
        readonly IStudentRepositories _IStudentRepositories;
        #endregion

        public StudentService(IStudentRepositories studentRepositories)
        {
            _IStudentRepositories = studentRepositories;
        }
        #region Insert Student Details
        public void InsertStudentDetails(StudentDetails student)
        {
            _IStudentRepositories.InsertStudentDetails(student);

        }
        #endregion

        #region Insert Student Mark
        public void InsertStudentMark(StudentMarks studentMark)
        {
            _IStudentRepositories.InsertStudentMark(studentMark);
        }

        #endregion

        #region GetStudent Details
        public IEnumerable<StudentDetails> GetStudentDetails()
        {
            return _IStudentRepositories.GetStudentDetails();
        }
        #endregion

        #region GetStudent Marks
        public IEnumerable<StudentMarks> GetStudentMarks()
        {
            return _IStudentRepositories.GetStudentMarks();
        }
        #endregion

        #region Get Department
        public IList<Department> GetAllDepartment()
        
        {
           var value= _IStudentRepositories.GetAllDepartment();
            return value;
        }
        #endregion

        #region Get Name List
        public IList<StudentDetails> GetStudentName()
        {
            var value = _IStudentRepositories.GetStudentName();
            return value;
        }
        #endregion

        #region Delete Student Details
        public void DeleteStudentDetails(int StudentId)
        {
            _IStudentRepositories.DeleteStudentDetails( StudentId);
        }
        #endregion
        #region Delete Mark Details
        public void DeleteStudentMarks(int StudentId)
        {
            _IStudentRepositories.DeleteStudentMarks(StudentId);
        }
        #endregion

        #region GetStudent BY Id
        public StudentDetails GetStudentById(int studentId)
        {
           return _IStudentRepositories.GetStudentById(studentId);
        }
        #endregion

        #region GetStudent Mark By Id
        //public  StudentMarks GetStudentMarkById(int studentId)
        //{
        //    return _IStudentRepositories.GetStudentMarkById(studentId);
        //}
        #endregion
    }
}
