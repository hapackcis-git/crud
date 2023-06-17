using crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace crud.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentContext _Db;
        public StudentController(StudentContext Db)
        {
            _Db = Db;   
        }
        public IActionResult StudentList()
        {
            try
            {
                var stdList = from a in _Db.student
                              join b in _Db.Departments
                              on a.DepID equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()
                              select new student
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  Fname = a.Fname,
                                  Mobile = a.Mobile,
                                  Email = a.Email,
                                  Description = a.Description,
                                  DepID = a.DepID,
                                  Department=b==null?"":b.Department
                              };
                return View();
            }
            catch ( Exception ex)
            {
                return View();

            }
           
        }
    }
}
