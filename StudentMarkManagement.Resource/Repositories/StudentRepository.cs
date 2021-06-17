using StudentMarkManagement.Core.IRepositories;
using StudentMarkManagement.Core.Models;
using StudentMarkManagement.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Resources.Repositories
{
   public class StudentRepository:IStudentRepositories
    {
        #region GetStudent Details from Db to Model
       public IEnumerable<StudentDetails> GetStudentDetails()
        {

                IList<StudentDetails> studentList = new List<StudentDetails>();

                var StudentDB = new StudentMarkManagementDBEntities();
                var query = from student in StudentDB.student_Details
                            where student.Is_Deleted == false
                            select student;
                var studentRecords = query.ToList();

              
                var students = studentRecords.ToList();

                foreach (var studentData in students)
                {
                    studentList.Add(new StudentDetails()
                    {
                        StudentId = studentData.Student_Id,
                        Name = studentData.Name,
                        Email = studentData.Email,
                        Department = studentData.Department,
                        Gender = studentData.Gender

                    });
                }
            return studentList;


        }
        #endregion

        #region GetStudent Marks from Db to Model
        public IEnumerable<StudentMarks> GetStudentMarks()
        {

            IList<StudentMarks> studentList = new List<StudentMarks>();

            var StudentDB = new StudentMarkManagementDBEntities();


            var query = from student in StudentDB.student_Details
                        join
                        mark in StudentDB.student_Marks
                        on
                        student.Student_Id
                        equals mark.Student_Id where mark.Is_Deleted==false && student.Is_Deleted==false
                        select new
                        {
                            markId = mark.Student_Marks_Id,
                            studentName = student.Name,
                            StudentMark1 = mark.Mark_1,
                            StudentMark2 = mark.Mark_2,
                            markTotal = mark.Total
                        };

            var students = query.ToList();
            foreach (var studentData in students)
            {
                studentList.Add(new StudentMarks()
                {
                    StudentId = studentData.markId,
                    StudentName = studentData.studentName,
                    Mark1 = studentData.StudentMark1,
                    Mark2 = studentData.StudentMark2,
                    Total = studentData.markTotal
                });
            }
            
            //var query = from student in StudentDB.student_Marks
            //            where student.Is_Deleted == false
            //            select student;
            //var studentRecords = query.ToList();


            //var students = studentRecords.ToList();

            //foreach (var studentData in students)
            //{
            //    studentList.Add(new StudentMarks()
            //    {
            //        StudentId = studentData.Student_Id,
            //        Name = studentData.Name,
            //        Mark1 = studentData.Mark_1,
            //        Mark2 = studentData.Mark_2,
            //        Total=studentData.Total

            //    });
            //}
            return studentList;


        }
        #endregion

        #region GetStudent Details By ID

      public  StudentDetails GetStudentById(int StudentId)
        {

            var StudentDB = new StudentMarkManagementDBEntities();
            var query = from student in StudentDB.student_Details
                        where student.Student_Id == StudentId
                        select student;
            var studentData = query.FirstOrDefault();
            var model = new StudentDetails()
            {
                StudentId = studentData.Student_Id,
                Name = studentData.Name,
                Email=studentData.Email,
                Department=studentData.Department,
                Gender=studentData.Gender
            };

            return model;
        }
        #endregion

        #region Get Student Mark BY ID

        //public StudentMarks GetStudentMarkById(int StudentId)
        //{

        //    var StudentDB = new StudentMarkManagementDBEntities();
        //    var query = from student in StudentDB.student_Marks
        //                where student.Student_Id == StudentId
        //                select student;
        //    //var query = from student in StudentDB.student_Details
        //    //            join
        //    //            mark in StudentDB.student_Marks
        //    //            on
        //    //            student.Student_Id
        //    //            equals mark.Student_Id
        //    //            select new
        //    //            {
        //    //                markId=mark.Student_Marks_Id,
        //    //                studentName = student.Name,
        //    //                StudentMark1=mark.Mark_1,
        //    //                StudentMark2=mark.Mark_2,
        //    //                markTotal=mark.Total
        //    //            };


        //    var studentData = query.FirstOrDefault();
        //    var model = new StudentMarks()
        //    {
        //        StudentId = studentData.Student_Marks_Id, 
        //        Name=studentData.Name,
        //        Mark1 = studentData.Mark_1,
        //        Mark2 = studentData.Mark_2,
        //        Total = studentData.Total
        //    };

        //    return model;
        //}
        //public list<studentmarks> viewstudentmarkdetails()
        //{
        //    list<studentmarks> studentmark = new list<studentmarks>();
        //    using (var studentmarksdb = new studentmarkmanagementdbentities())
        //    {
        //        var stdmarksdb = studentmarksdb.student_marks.where(model => model.is_deleted == false).tolist();
        //        if (stdmarksdb != null)
        //        {
        //            foreach (var stdmarks in stdmarksdb)
        //            {
        //                studentmarks studentmarks = new studentmarks();
        //                studentmarks.name = stdmarks.name;
        //                studentmarks.mark1 = stdmarks.mark_1;
        //                studentmarks.mark2 = stdmarks.mark_2;
        //                //studentmarks.total = stdmarks.total;
        //                studentmark.add(studentmarks);
        //            }
        //        }
        //    }
        //    return studentmark;
        //}
        #endregion

        #region InsertStudentDetails
        public void InsertStudentDetails(StudentDetails student)
        {
            student_Details dbstudent = new student_Details();

            using (var entity = new StudentMarkManagementDBEntities())
            {
               
                dbstudent.Name = student.Name;
                dbstudent.Email = student.Email;
                if (student.Department == "1")
                {
                    student.Department = "ECE";
                }
                else if (student.Department == "2")
                {
                    student.Department = "EEE";
                }
                else if (student.Department == "3")
                {
                    student.Department = "CSE";
                }
                else if (student.Department == "4")
                {
                    student.Department = "IT";
                }
                dbstudent.Department = student.Department;
                dbstudent.Gender = student.Gender;
                entity.student_Details.Add(dbstudent);
                entity.SaveChanges();
            }

            //if (student != null)
            //{
            //    var StudentDB = new StudentMarkManagementDBEntities();
            //    var studentData = new student_Details()
            //    {
            //        Student_Id = student.StudentId,
            //        Name = student.Name,
            //        Email = student.Email,
            //        Department = student.Department,
            //        Gender = student.Gender
            //    };
            //    StudentDB.student_Details.Add(studentData);

            //    StudentDB.SaveChanges();
            //}
        }
        #endregion

        #region InsertStudentMark

        public void InsertStudentMark(StudentMarks studentMark)
        {
            if (studentMark != null)
            {
                var StudentDB = new StudentMarkManagementDBEntities();
                var studentData = new student_Marks()
                {
                    Student_Id = studentMark.Name,
                    Name = studentMark.Name,
                    Mark_1 = studentMark.Mark1,
                    Mark_2 = studentMark.Mark2,
                    Total = studentMark.Mark1 + studentMark.Mark1
                };
                StudentDB.student_Marks.Add(studentData);

                StudentDB.SaveChanges();
            }

        }
        #endregion


        #region Delete student Details
        public void DeleteStudentDetails(int StudentId)
        {
            var StudentDB = new StudentMarkManagementDBEntities();
            var student = StudentDB.student_Details.Where(x => x.Student_Id == StudentId && x.Is_Deleted == false).SingleOrDefault();
            if (student != null)
            {
                student.Is_Deleted = true;
                student.Updated_Time_Stamp = DateTime.Now;
                StudentDB.SaveChanges();
            }


        }
        #endregion
        #region Delete student Marks
        public void DeleteStudentMarks(int StudentId)
        {
            var StudentDB = new StudentMarkManagementDBEntities();
            var student = StudentDB.student_Marks.Where(x => x.Student_Marks_Id == StudentId && x.Is_Deleted == false).SingleOrDefault();
            if (student != null)
            {
                student.Is_Deleted = true;
                student.Updated_Time_Stamp = DateTime.Now;
                StudentDB.SaveChanges();
            }


        }
        #endregion

        #region Department
        public IList<Department> GetAllDepartment()
        {
            #region Detartment commented
            //IList<Department> departmentList = new List<Department>();
            //var studentDB = new StudentMarkManagementDBEntities();

            //var query = from student in studentDB.Departments                       
            //            select student;
            //var dbDepartment = query.ToList();

            //foreach (var department in dbDepartment)
            //{
            //    Department departmentDetails = new()
            //    {
            //        DepartmentId = department.Department_Id,
            //        DepartmentName = department.Department_name
            //    };
            //    departmentList.Add(departmentDetails);
            //}
            //return departmentList;

            #endregion


            List<Department> departmentList = new List<Department>();
            using (var entites = new StudentMarkManagementDBEntities())
            {
                var dbDepartment = entites.Departments.ToList();
                if (dbDepartment != null)
                {
                    foreach (var departmntData in dbDepartment)
                    {
                        Department departmentDetails = new Department();
                        departmentDetails.DepartmentId = departmntData.Department_Id;
                        departmentDetails.DepartmentName = departmntData.Department_name;
                        departmentList.Add(departmentDetails);
                    }
                }

            }
            return departmentList;
        }
        #endregion

        #region NameList
        public IList<StudentDetails> GetStudentName()
        {
            List<StudentDetails> NameList = new List<StudentDetails>();
            using (var entites = new StudentMarkManagementDBEntities())
            {
                var dbStudentName = entites.student_Details.Where(x => x.Is_Deleted == false).ToList();
                if (dbStudentName != null)
                {
                    foreach(var dbname in dbStudentName)
                    {
                        StudentDetails studentname = new StudentDetails();
                        studentname.StudentId = dbname.Student_Id;
                        studentname.Name = dbname.Name;
                        NameList.Add(studentname);
                    }
                }
            }
            return NameList;
        }
        #endregion
    }

}
