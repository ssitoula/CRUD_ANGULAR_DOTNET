using CRUD_Angular_Asp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Angular_Asp.Services
{
    public interface IStudentServices
    {

        List<StudentViewModel> ListStudent();
        bool AddStudent(StudentViewModel model);
       bool EditStudent(StudentViewModel model);
        bool DeleteStudent(int id);
        StudentViewModel GetStudentById(int id);
    }
}