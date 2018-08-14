using CRUD_Angular_Asp.Table;
using CRUD_Angular_Asp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Angular_Asp.Services
{
    public class StudentServices :IStudentServices
    {



        protected DataContext db;
        public StudentServices()
        {
            db = new DataContext();
        }


        public List<StudentViewModel> ListStudent()
        {

            //todo:add server side pagination
            var query = db.Students.Select(x => new StudentViewModel()
            {
                id = x.id,
                Name = x.Name,
                address = x.address

            }).ToList();
            return query;
            //return queryable.ToDataSourceResult<Notice, NoticeViewModel>(request.Model, new Sort() { Field = "Name", Dir = "asc" })
        }



        public bool AddStudent(StudentViewModel model)
        {
            var data = new Student()
            {
                Name = model.Name,
                address = model.address


            };
            db.Students.Add(data);
            db.SaveChanges();
            return true;

        }



        public StudentViewModel GetStudentById(int id)
        {
            var query = db.Students.Where(x => x.id == id).Select(x => new StudentViewModel
            {
                id = x.id,
                Name = x.Name,
                address = x.address

            }).FirstOrDefault();


            return query;
        }

        public bool EditStudent(StudentViewModel model)
        {
            var data = new StudentViewModel();

            if (data != null)
            {
                var isExist = db.Students.Where(x => x.id == model.id).FirstOrDefault();
                if (isExist != null)
                {
                    isExist.Name = model.Name;
                    isExist.address = model.address;

                }
                db.SaveChanges();
            }
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var IsExistData = db.Students.Where(x => x.id == id).FirstOrDefault();
            db.Students.Remove(IsExistData);
            db.SaveChanges();
            return true;


        }
    }


}
