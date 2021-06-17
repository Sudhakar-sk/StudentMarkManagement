using StudentMarkManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Core.IServices
{
    public interface IStudentServices
    {
        IEnumerable<StudentDetails> GetStudentDetails();
        IEnumerable<StudentMarks> GetStudentMarks();

        IList<Department> GetAllDepartment();
        IList<StudentDetails> GetStudentName();

        StudentDetails GetStudentById(int StudentId);
        //StudentMarks GetStudentMarkById(int StudentId);

        void InsertStudentDetails(StudentDetails student);
        void InsertStudentMark(StudentMarks studentMarks);



        void DeleteStudentDetails(int StudentId);
        void DeleteStudentMarks(int StudentId);

    }
}
